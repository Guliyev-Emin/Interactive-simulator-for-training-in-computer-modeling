using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GraduationProject.Construction;
using JetBrains.Annotations;

namespace GraduationProject.Controllers
{
    [UsedImplicitly]
    public class Controller : Connection
    {
        public static string ControllerLineLength(string sketchName, int lineCount)
        {
            var message = "";

            if (Reader.SketchInfos == null) return message;
            var sketchInfo = Reader.SketchInfos[Reader.SketchInfos.FindIndex(name => name.SketchName == sketchName)];
            message = sketchInfo.SketchName + "\n";

            if (lineCount == sketchInfo.LineCount)
            {
                message += "\nСодержит " + lineCount + " отрезков.";
            }
            else
            {
                var i = lineCount > sketchInfo.LineCount
                    ? lineCount - sketchInfo.LineCount
                    : sketchInfo.LineCount - lineCount;
                message += @"Не содержит " + lineCount + " отрезков.\n" + "Не хватает " + i + " отрезков!";
            }

            return message;
        }


        public static string ControllerLinePosition(string sketchName)
        {
            var info = Reader.SketchInfos[Reader.SketchInfos.FindIndex(name => name.SketchName == sketchName)];
            var lineCoordinates = info.LineCoordinates;
            var count = info.LineCoordinates.Count;
            var result = "";

            for (var index = 0; index < count; index++)
            {
                var start = lineCoordinates[index].Split('\n')[0].Split(' ');

                var xStart = start[3];
                xStart = xStart.Remove(xStart.Length - 1);
                var yStart = start[6];
                yStart = yStart.Remove(yStart.Length - 1);
                var zStart = start[9];
                zStart = zStart.Remove(zStart.Length - 1);

                var end = lineCoordinates[index].Split('\n')[1].Split(' ');

                var xEnd = end[3];
                xEnd = xEnd.Remove(xEnd.Length - 1);
                var yEnd = end[6];
                yEnd = yEnd.Remove(yEnd.Length - 1);
                var zEnd = end[9];
                zEnd = zEnd.Remove(zEnd.Length - 1);

                if (xStart == xEnd && yStart != yEnd)
                    result += "Отрезок вертикальный.\n";
                else if (xStart != xEnd && yStart == yEnd)
                    result += "Отрезок горизонтальный.\n";
                else
                    result += "Отрезок наклонный.\n";
            }

            return result;
        }

        /// <summary>
        ///     Процедура проверки двумерных примитивов эскиза пользователя
        ///     с правильными примитивами.
        /// </summary>
        /// <param name="initialInformationOfTheModel">Исходная информация модели</param>
        /// <param name="initialInformationOfTheUserModel">Ссылка на исходную информацию пользовательской модели</param>
        /// <param name="numberOfCorrectResults">Ссылка на количество верных результатов</param>
        public static void Comparison(TextBox initialInformationOfTheModel,
            ref RichTextBox initialInformationOfTheUserModel, ref int numberOfCorrectResults)
        {
            var initialInformationOfTheUserModelArray =
                initialInformationOfTheUserModel.Text.Split(new[] {"Имя эскиза:"},
                    StringSplitOptions.RemoveEmptyEntries);
            var initialInformationOfTheModelArray =
                initialInformationOfTheModel.Text.Split(new[] {"Имя эскиза:"}, StringSplitOptions.RemoveEmptyEntries);
            var index = 0;
            var checkBreak = false;
            foreach (var sketchPropertiesFromInitialModelInformation in initialInformationOfTheModelArray)
            {
                var sketchPropertiesFromInitialUserModelInformation =
                    new List<string>(initialInformationOfTheUserModelArray[index++].Split('\n'));
                foreach (var sketchPropertiesInitialModel in sketchPropertiesFromInitialModelInformation.Split('\n'))
                {
                    var properties = sketchPropertiesInitialModel.Replace("\r", null);
                    if (sketchPropertiesInitialModel.IndexOf("Эскиз", StringComparison.Ordinal) != -1) continue;
                    foreach (var sketchPropertiesInitialUserModel in sketchPropertiesFromInitialUserModelInformation)
                    {
                        if (sketchPropertiesInitialUserModel.Equals(sketchPropertiesFromInitialUserModelInformation
                                .First())) continue;
                        var regex = new Regex(sketchPropertiesInitialUserModel);
                        foreach (Match match in regex.Matches(initialInformationOfTheUserModel.Text))
                        {
                            initialInformationOfTheUserModel.Select(match.Index,
                                sketchPropertiesInitialUserModel.Length);
                            if (properties.Equals(sketchPropertiesInitialUserModel))
                            {
                                if (initialInformationOfTheUserModel.SelectionBackColor.Name.Equals("LightGreen"))
                                    continue;
                                initialInformationOfTheUserModel.SelectionBackColor = Color.LightGreen;
                                checkBreak = true;
                                numberOfCorrectResults++;
                                break;
                            }
                            if (initialInformationOfTheUserModel.SelectionBackColor.Name is "LightGreen" or "White")
                                continue;
                            initialInformationOfTheUserModel.SelectionBackColor = Color.Red;
                        }
                        if (!checkBreak) continue;
                        checkBreak = false;
                        break;
                    }
                }
            }
        }
        
        /// <summary>
        ///     Функция по определению количество углов в фигуре.
        /// </summary>
        /// <param name="sketchName">Название эскиза.</param>
        /// <returns>Возвращает количество углов.</returns>
        public static string FindingPolygon(string sketchName)
        {
            var sketchInfo = Reader.SketchInfos[Reader.SketchInfos.FindIndex(name => name.SketchName == sketchName)];
            var lineTypes = sketchInfo.LineTypes;
            var lineCoordinates = sketchInfo.LineCoordinates;
            var result = "";
            var line1X = lineCoordinates[0].Split('\n')[1].Split(' ')[3];
            var line1Y = lineCoordinates[0].Split('\n')[1].Split(' ')[6];
            var startPointXFirstLine = lineCoordinates[0].Split('\n')[0].Split(' ')[3];
            var startPointYFirstLine = lineCoordinates[0].Split('\n')[0].Split(' ')[6];
            var switchStartEnd = false;
            var countFigure = 1;
            var ind = 0;
            var i = 0;
            lineCoordinates.RemoveAt(0);
            var isolation = false;
            while (lineCoordinates.Count != 0)
            {
                // от конца точки линии ищем начало из этой точки новую линию
                string line2X;
                string line2Y;
                if (!switchStartEnd)
                {
                    line2X = lineCoordinates[i].Split('\n')[0].Split(' ')[3];
                    line2Y = lineCoordinates[i].Split('\n')[0].Split(' ')[6];
                    if (line1X == line2X && line1Y == line2Y)
                    {
                        line1X = lineCoordinates[i].Split('\n')[1].Split(' ')[3];
                        line1Y = lineCoordinates[i].Split('\n')[1].Split(' ')[6];
                        countFigure++;
                        lineCoordinates.RemoveAt(i);
                    }

                    if (i >= lineCoordinates.Count - 1)
                    {
                        switchStartEnd = true;
                        i = 0;
                        continue;
                    }
                }

                // тут от начало точки линии до конца новой точки линии
                if (switchStartEnd)
                {
                    line2X = lineCoordinates[i].Split('\n')[1].Split(' ')[3];
                    line2Y = lineCoordinates[i].Split('\n')[1].Split(' ')[6];
                    if (line1X == line2X && line1Y == line2Y)
                    {
                        line1X = lineCoordinates[i].Split('\n')[0].Split(' ')[3];
                        line1Y = lineCoordinates[i].Split('\n')[0].Split(' ')[6];
                        countFigure++;
                        lineCoordinates.RemoveAt(i);
                    }

                    if (lineCoordinates.Count == 0)
                        if (line1X == startPointXFirstLine && line1Y == startPointYFirstLine)
                            isolation = true;

                    if (i >= lineCoordinates.Count - 1)
                    {
                        switchStartEnd = false;
                        i = 0;
                        continue;
                    }
                }

                ind++;
                i++;
                if (ind != 30) continue;
                MessageBox.Show(@"Много итераций");
                break;
            }

            if (isolation)
                MessageBox.Show(countFigure.ToString());
            return result;
        }
    }
}