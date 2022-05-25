using System.IO;
using GraduationProject.Construction;

namespace GraduationProject.Controller
{
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
            //var path = "C:\\Users\\eming\\Desktop\\Свойства модели.txt";
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
    }
}