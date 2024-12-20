﻿using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using GraduationProject.ModelObjects.Objects;
using GraduationProject.SolidWorks_Algorithms;

namespace GraduationProject.Controllers;

public static class FileController
{
    private const string ModelTextProperties = @"\Свойства модели.txt";
    private const string ModelObjectsProperties = @"\Свойства модели.bin";
    private const string StandardDirectoryPath = @"..\..\Files\Models\Модель № ";

    /// <summary>
    /// </summary>
    /// <param name="modelVariant"></param>
    /// <returns></returns>
    private static bool DirectoryExists(string modelVariant)
    {
        return Directory.Exists(StandardDirectoryPath + modelVariant);
    }

    /// <summary>
    /// </summary>
    /// <param name="modelVariant"></param>
    /// <returns></returns>
    private static (bool textModel, bool objectsModel) StandardFilesExists(string modelVariant)
    {
        return (File.Exists(StandardDirectoryPath + modelVariant + ModelObjectsProperties),
            File.Exists(StandardDirectoryPath + modelVariant + ModelTextProperties));
    }

    /// <summary>
    /// </summary>
    /// <param name="modelVariant"></param>
    /// <returns></returns>
    private static bool DataExists(string modelVariant)
    {
        var fileExists = StandardFilesExists(modelVariant);
        return DirectoryExists(modelVariant) && fileExists.textModel && fileExists.objectsModel;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private static string DataDoesNotExist()
    {
        Message.ErrorMessage(@"Данные для модели не найдены!");
        return null;
    }

    /// <summary>
    /// </summary>
    /// <param name="modelVariant"></param>
    /// <returns></returns>
    private static string GetPathOfCreatedFile(string modelVariant)
    {
        var directoryPath = StandardDirectoryPath + modelVariant;
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        if (!File.Exists(directoryPath + $@"{ModelObjectsProperties}"))
            File.Create(directoryPath + $@"{ModelObjectsProperties}").Close();

        if (!File.Exists(directoryPath + $@"{ModelTextProperties}"))
            File.Create(directoryPath + $@"{ModelTextProperties}").Close();

        return directoryPath;
    }

    /// <summary>
    ///     Ассинхронная процедура сохранения текста и объектов в файлы
    /// </summary>
    /// <param name="variant">Вариант модели</param>
    public static async void SavingModelPropertiesToAFile(string variant)
    {
        var path = GetPathOfCreatedFile(variant);
        var template = CreateTemplateModelProperties();
        using var writer = new StreamWriter(path + ModelTextProperties, false);
        await writer.WriteLineAsync(template);
        writer.Close();

        Stream saveFileStream = File.OpenWrite(path + ModelObjectsProperties);
        var serializer = new BinaryFormatter();
        var model = ReadingModel.GetModel();
        serializer.Serialize(saveFileStream, model);
        saveFileStream.Close();
    }


    /// <summary>
    ///     Функция чтения объектов примитивов из бинарного файла
    /// </summary>
    /// <param name="modelVariant">Вариант модели</param>
    /// <returns>Возвращает объекты из бинарного файла</returns>
    public static Model GetModelObjectFromFile(string modelVariant)
    {
        if (!DataExists(modelVariant)) return null;
        Stream openFileStream = File.OpenRead(StandardDirectoryPath + modelVariant + ModelObjectsProperties);
        var deserializer = new BinaryFormatter();
        var correctModel = (Model)deserializer.Deserialize(openFileStream);
        openFileStream.Close();
        return correctModel;
    }

    /// <summary>
    ///     Функция чтения текста из файла
    /// </summary>
    /// <param name="modelVariant">Вариант модели</param>
    /// <returns>Возвращает текст из файла</returns>
    public static string GetModelTextSketchesFromFile(string modelVariant)
    {
        return DataExists(modelVariant)
            ? File.ReadAllText(StandardDirectoryPath + modelVariant + ModelTextProperties)
                .Replace("\n", Environment.NewLine)
            : DataDoesNotExist();
    }

    /// <summary>
    ///     Функция по созданию текстового типа информации о модели
    /// </summary>
    /// <returns>Возвращает информацию о модели в тексте</returns>
    public static string CreateTemplateModelProperties()
    {
        var template = new StringBuilder();

        foreach (var sketch in ReadingModel.Sketches)
        {
            template.Append("Имя эскиза: " + sketch.SketchName + "\n");
            template.Append("Количество точек: " + sketch.UserPoints.Count + "\n");
            template.Append("Количество отрезков: " + sketch.Lines.Count + "\n");
            template.Append("Количество горизонтальных отрезков: " +
                            sketch.Lines.Count(l => l.Arrangement.Equals("Горизонтальный")) + "\n");
            template.Append("Количество вертикальных отрезков: " +
                            sketch.Lines.Count(l => l.Arrangement.Equals("Вертикальный")) + "\n");
            template.Append("Количество наклонных отрезков: " +
                            sketch.Lines.Count(l => l.Arrangement.Equals("Наклонный")) + "\n");
            template.Append("Количество вспомогательных линий: " +
                            sketch.Lines.Select(l => l.Type).Count(type => type == 4) +
                            "\n");
            template.Append("Количество дуг: " + sketch.Arcs.Count + "\n");
            template.Append("Количество эллипсов: " + sketch.Ellipses.Count + "\n");
            template.Append("Количество парабол: " + sketch.Parabolas.Count + "\n");
            if (sketch.Lines.Count != 0)
                foreach (var line in sketch.Lines)
                {
                    template.Append("Отрезок: \n\t" + "Расположение отрезка: " + line.Arrangement +
                                    "\n\t" + line.Coordinate.Replace("\n", "\n\t") + "\n\t");
                    template.Append("Длина: " + line.Length + " м\n");
                }
            if (sketch.Arcs.Count != 0)
                foreach (var arc in sketch.Arcs)
                {
                    template.Append("Дуга: \n\t" + arc.Coordinate.Replace("\n", "\n\t") + "\n\t");
                    template.Append("Радиус: " + arc.ArcRadius + " м\n");
                }
            if (sketch.Ellipses.Count != 0)
                foreach (var ellipse in sketch.Ellipses)
                    template.Append("Эллипс: \n\t" + ellipse.Coordinate.Replace("\n", "\n\t") + "\n\t");
            if (sketch.Parabolas.Count != 0)
                foreach (var parabola in sketch.Parabolas)
                    template.Append("Парабола: \n\t" + parabola.Coordinate.Replace("\n", "\n\t") + "\n\t");
        }

        return template.Replace("\n", Environment.NewLine).ToString();
    }
}