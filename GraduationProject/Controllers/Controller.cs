using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
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

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
            MessageBox.Show(@"RunTime " + elapsedTime);
        }
    }
}