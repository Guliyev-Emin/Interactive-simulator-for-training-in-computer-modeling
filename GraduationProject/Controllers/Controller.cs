using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using GraduationProject.Construction;
using GraduationProject.Model.IModels;
using GraduationProject.Model.Models;
using JetBrains.Annotations;

namespace GraduationProject.Controllers;

[UsedImplicitly]
public class Controller : Connection
{
    public static List<List<(string name, List<(List<string> correct, List<string> error)>)>> GetLines()
    {
        var userSketches = Reader.SketchInfos;
        var correctSketches = GetModelSketchesFromFile();
        var comparerResults = new List<List<(string name, List<(List<string> correct, List<string> error)>)>>();
        var index = 0;
        foreach (var userSketch in userSketches)
        {
            comparerResults.Add(new Comparer().SketchComparer(correctSketches[index++], userSketch));
        }

        return comparerResults;
    }

    public static string GetLineArrangement(ILine userLine)
    {
        if (userLine.XStart.Equals(userLine.XEnd) && !userLine.YStart.Equals(userLine.YEnd))
            return "Вертикальный";
        if (!userLine.XStart.Equals(userLine.XEnd) && userLine.YStart.Equals(userLine.YEnd))
            return "Горизонтальный";

        return "Наклонный";
    }

    /// <summary>
    ///     Процедура по записи свойств модели в файл.
    /// </summary>
    public static string CreateTemplateModelProperties()
    {
        var template = new StringBuilder();
        if (Reader.SketchInfos is null) return null;
        foreach (var sketch in Reader.SketchInfos)
        {
            template.Append("Имя эскиза: " + sketch.SketchName + "\n");
            template.Append("Количество точек: " + sketch.UserPoints.Count + "\n");
            template.Append("Количество отрезков: " + sketch.Lines.Count + "\n");
            template.Append("Количество горизонтальных отрезков: " +
                            sketch.Lines.Count(l => l.LineArrangement.Equals("Горизонтальный")) + "\n");
            template.Append("Количество вертикальных отрезков: " +
                            sketch.Lines.Count(l => l.LineArrangement.Equals("Вертикальный")) + "\n");
            template.Append("Количество наклонных отрезков: " +
                            sketch.Lines.Count(l => l.LineArrangement.Equals("Наклонный")) + "\n");
            template.Append("Количество вспомогательных линий: " +
                            sketch.Lines.Select(l => l.LineType).Count(type => type == 4) +
                            "\n");
            template.Append("Количество дуг: " + sketch.Arcs.Count + "\n");
            template.Append("Количество эллипсов: " + sketch.Ellipses.Count + "\n");
            template.Append("Количество парабол: " + sketch.Parabolas.Count + "\n");

            if (sketch.Lines.Count != 0)
                foreach (var line in sketch.Lines.Where(line => line.LineType != 4))
                {
                    template.Append("Отрезок: \n\t" + "Расположение отрезка: " + line.LineArrangement +
                                    "\n\t" + line.Coordinate.Replace("\n", "\n\t") + "\n\t");
                    template.Append("Длина: " + line.LineLength + " мм\n");
                }

            if (sketch.Arcs.Count != 0)
                foreach (var arc in sketch.Arcs)
                {
                    template.Append("Дуга: \n\t" + arc.Coordinate.Replace("\n", "\n\t") + "\n\t");
                    template.Append("Радиус: " + arc.ArcRadius + " мм\n");
                }

            if (sketch.Ellipses.Count != 0)
                foreach (var ellipse in sketch.Ellipses)
                    template.Append("Эллипс: \n\t" + ellipse.Coordinate.Replace("\n", "\n\t") + "\n\t");

            if (sketch.Parabolas.Count != 0)
                foreach (var parabola in sketch.Parabolas)
                    template.Append("Парабола: \n\t" + parabola.Coordinate.Replace("\n", "\n\t") + "\n\t");

            template.Append("Выдавливание: " + sketch.Deepth + " мм\n\n");
        }

        return template.ToString();
    }

    public static async void SavingModelPropertiesToAFile(string template)
    {
        const string pathTxt = @"..\..\Files/Свойства модели.txt";
        using var writer = new StreamWriter(pathTxt, false);
        await writer.WriteLineAsync(template);

        const string pathBin = @"..\..\Files/Свойства модели.bin";
        Stream saveFileStream = File.OpenWrite(pathBin);


        var serializer = new BinaryFormatter();
        serializer.Serialize(saveFileStream, Reader.SketchInfos);
        saveFileStream.Close();
    }

    private static List<SketchInfo> GetModelSketchesFromFile()
    {
        const string pathBin = @"..\..\Files/Свойства модели.bin";
        Stream openFileStream = File.OpenRead(pathBin);
        var deserializer = new BinaryFormatter();
        var sketchInfosFromFile = (List<SketchInfo>)deserializer.Deserialize(openFileStream);
        openFileStream.Close();
        return sketchInfosFromFile;
    }
    
}