namespace GraduationProject.Controller
{
    public class Controller : Connection
    {
        public static string ControllerLineLength(int lineCount)
        {
            var message = "";

            if (Reader.SketchNames == null) return message;
            foreach (var sketchInfo in Reader.SketchNames)
            {
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
            }

            return message;
        }

        public static string ControllerLinePosition(string sketchName)
        {
            var info = Reader.SketchNames[Reader.SketchNames.FindIndex(name => name.SketchName == sketchName)];
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
                    result += "Отрезок кривой.\n";
            }

            return result;
        }
    }
}