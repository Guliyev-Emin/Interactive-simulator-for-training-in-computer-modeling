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
    public static Tuple<List<string>, List<string>> GetLines(ref Comparer comparer)
    {
        var userSketches = Reader.SketchInfos;
        var correctSketches = GetModelSketchesFromFile();
        var ind = 0;
        comparer.CorrectResults = new List<string>();
        comparer.ErrorResult = new List<string>();
        foreach (var userSketch in userSketches) comparer.SketchComparer(correctSketches[ind++], userSketch);

        return new Tuple<List<string>, List<string>>(new List<string>(), new List<string>());
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

    public static List<SketchInfo> GetModelSketchesFromFile()
    {
        const string pathBin = @"..\..\Files/Свойства модели.bin";
        Stream openFileStream = File.OpenRead(pathBin);
        var deserializer = new BinaryFormatter();
        var sketchInfosFromFile = (List<SketchInfo>)deserializer.Deserialize(openFileStream);
        openFileStream.Close();
        return sketchInfosFromFile;
    }

    // public static string ControllerLineLength(string sketchName, int lineCount)
    // {
    //     var message = "";
    //
    //     if (Reader.SketchInfos == null) return message;
    //     var sketchInfo = Reader.SketchInfos[Reader.SketchInfos.FindIndex(name => name.SketchName == sketchName)];
    //     message = sketchInfo.SketchName + "\n";
    //
    //     if (lineCount == sketchInfo.LineCount)
    //     {
    //         message += "\nСодержит " + lineCount + " отрезков.";
    //     }
    //     else
    //     {
    //         var i = lineCount > sketchInfo.LineCount
    //             ? lineCount - sketchInfo.LineCount
    //             : sketchInfo.LineCount - lineCount;
    //         message += @"Не содержит " + lineCount + " отрезков.\n" + "Не хватает " + i + " отрезков!";
    //     }
    //
    //     return message;
    // }
    //
    //

    // /// <summary>
    // ///     Процедура проверки двумерных примитивов эскиза пользователя
    // ///     с правильными примитивами.
    // /// </summary>
    // /// <param name="initialInformationOfTheModel">Исходная информация модели</param>
    // /// <param name="initialInformationOfTheUserModel">Ссылка на исходную информацию пользовательской модели</param>
    // /// <param name="numberOfCorrectResults">Ссылка на количество верных результатов</param>
    // public static void Comparison(TextBox initialInformationOfTheModel,
    //     ref RichTextBox initialInformationOfTheUserModel, ref int numberOfCorrectResults)
    // {
    //     var initialInformationOfTheUserModelArray =
    //         initialInformationOfTheUserModel.Text.Split(new[] {"Имя эскиза:"},
    //             StringSplitOptions.RemoveEmptyEntries);
    //     var initialInformationOfTheModelArray =
    //         initialInformationOfTheModel.Text.Split(new[] {"Имя эскиза:"}, StringSplitOptions.RemoveEmptyEntries);
    //     var index = 0;
    //     var checkBreak = false;
    //     foreach (var sketchPropertiesFromInitialModelInformation in initialInformationOfTheModelArray)
    //     {
    //         var sketchPropertiesFromInitialUserModelInformation =
    //             new List<string>(initialInformationOfTheUserModelArray[index++].Split('\n'));
    //         foreach (var sketchPropertiesInitialModel in sketchPropertiesFromInitialModelInformation.Split('\n'))
    //         {
    //             var properties = sketchPropertiesInitialModel.Replace("\r", null);
    //             if (sketchPropertiesInitialModel.IndexOf("Эскиз", StringComparison.Ordinal) != -1) continue;
    //             foreach (var sketchPropertiesInitialUserModel in sketchPropertiesFromInitialUserModelInformation)
    //             {
    //                 if (sketchPropertiesInitialUserModel.Equals(sketchPropertiesFromInitialUserModelInformation
    //                         .First())) continue;
    //                 var regex = new Regex(sketchPropertiesInitialUserModel);
    //                 foreach (Match match in regex.Matches(initialInformationOfTheUserModel.Text))
    //                 {
    //                     initialInformationOfTheUserModel.Select(match.Index,
    //                         sketchPropertiesInitialUserModel.Length);
    //                     if (properties.Equals(sketchPropertiesInitialUserModel))
    //                     {
    //                         if (initialInformationOfTheUserModel.SelectionBackColor.Name.Equals("LightGreen"))
    //                             continue;
    //                         initialInformationOfTheUserModel.SelectionBackColor = Color.LightGreen;
    //                         checkBreak = true;
    //                         numberOfCorrectResults++;
    //                         break;
    //                     }
    //                     if (initialInformationOfTheUserModel.SelectionBackColor.Name is "LightGreen" or "White")
    //                         continue;
    //                     initialInformationOfTheUserModel.SelectionBackColor = Color.Red;
    //                 }
    //                 if (!checkBreak) continue;
    //                 checkBreak = false;
    //                 break;
    //             }
    //         }
    //     }
    // }
    //
    // /// <summary>
    // ///     Функция по определению количество углов в фигуре.
    // /// </summary>
    // /// <param name="sketchName">Название эскиза.</param>
    // /// <returns>Возвращает количество углов.</returns>
    // public static string FindingPolygon(string sketchName)
    // {
    //     var sketchInfo = Reader.SketchInfos[Reader.SketchInfos.FindIndex(name => name.SketchName == sketchName)];
    //     var lineTypes = sketchInfo.LineTypes;
    //     var lineCoordinates = sketchInfo.LineCoordinates;
    //     var result = "";
    //     var line1X = lineCoordinates[0].Split('\n')[1].Split(' ')[3];
    //     var line1Y = lineCoordinates[0].Split('\n')[1].Split(' ')[6];
    //     var startPointXFirstLine = lineCoordinates[0].Split('\n')[0].Split(' ')[3];
    //     var startPointYFirstLine = lineCoordinates[0].Split('\n')[0].Split(' ')[6];
    //     var switchStartEnd = false;
    //     var countFigure = 1;
    //     var ind = 0;
    //     var i = 0;
    //     lineCoordinates.RemoveAt(0);
    //     var isolation = false;
    //     while (lineCoordinates.Count != 0)
    //     {
    //         // от конца точки линии ищем начало из этой точки новую линию
    //         string line2X;
    //         string line2Y;
    //         if (!switchStartEnd)
    //         {
    //             line2X = lineCoordinates[i].Split('\n')[0].Split(' ')[3];
    //             line2Y = lineCoordinates[i].Split('\n')[0].Split(' ')[6];
    //             if (line1X == line2X && line1Y == line2Y)
    //             {
    //                 line1X = lineCoordinates[i].Split('\n')[1].Split(' ')[3];
    //                 line1Y = lineCoordinates[i].Split('\n')[1].Split(' ')[6];
    //                 countFigure++;
    //                 lineCoordinates.RemoveAt(i);
    //             }
    //
    //             if (i >= lineCoordinates.Count - 1)
    //             {
    //                 switchStartEnd = true;
    //                 i = 0;
    //                 continue;
    //             }
    //         }
    //
    //         // тут от начало точки линии до конца новой точки линии
    //         if (switchStartEnd)
    //         {
    //             line2X = lineCoordinates[i].Split('\n')[1].Split(' ')[3];
    //             line2Y = lineCoordinates[i].Split('\n')[1].Split(' ')[6];
    //             if (line1X == line2X && line1Y == line2Y)
    //             {
    //                 line1X = lineCoordinates[i].Split('\n')[0].Split(' ')[3];
    //                 line1Y = lineCoordinates[i].Split('\n')[0].Split(' ')[6];
    //                 countFigure++;
    //                 lineCoordinates.RemoveAt(i);
    //             }
    //
    //             if (lineCoordinates.Count == 0)
    //                 if (line1X == startPointXFirstLine && line1Y == startPointYFirstLine)
    //                     isolation = true;
    //
    //             if (i >= lineCoordinates.Count - 1)
    //             {
    //                 switchStartEnd = false;
    //                 i = 0;
    //                 continue;
    //             }
    //         }
    //
    //         ind++;
    //         i++;
    //         if (ind != 30) continue;
    //         MessageBox.Show(@"Много итераций");
    //         break;
    //     }
    //
    //     if (isolation)
    //         MessageBox.Show(countFigure.ToString());
    //     return result;
    // }
}