using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraduationProject.Model.IModels.IPoints;
using GraduationProject.Model.Models;

namespace GraduationProject.Controllers;

public class Comparer
{
    private const byte StartPt = 0;
    private const byte EndPt = 1;
    private const byte CenterPt = 2;
    private const byte FocusPt = 2;
    private const byte ApexPt = 3;
    private const byte MajorPt = 3;
    private const byte MinorPt = 4;
    private static string _name;
    private short _lineIndex;
    public List<string> CorrectResults;
    public List<string> ErrorResult;

    /// <summary>
    /// </summary>
    /// <param name="correctSketch">Правильный эскиз</param>
    /// <param name="userSketch">Пользовательский эскиз</param>
    public void SketchComparer(SketchInfo correctSketch, SketchInfo userSketch)
    {
        _name = userSketch.SketchName;
        if (correctSketch.UserPoints?.Count != 0)
        {
        }

        if (correctSketch.Lines?.Count != 0)
        {
            _lineIndex = 1;
            ComparerParameters(correctSketch.Lines, userSketch.Lines);
        }

        if (correctSketch.Arcs?.Count != 0)
        {
            _lineIndex = 1;
            ComparerParameters(correctSketch.Arcs, userSketch.Arcs);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="correctParameters">Правильные параметры примитива</param>
    /// <param name="userParameters">Пользовательские параметры примитива</param>
    /// <typeparam name="T">Класс примитива</typeparam>
    private void ComparerParameters<T>(ICollection<T> correctParameters, List<T> userParameters)
    {
        var arc = typeof(T).Name.Equals("Arc");
        var line = typeof(T).Name.Equals("Line");
        var index = (short)0;
        foreach (var userLine in userParameters)
        {
            var lineIsRight = false;
            foreach (var correctLine in correctParameters.Where(correctLine => userLine.Equals(correctLine)))
            {
                correctParameters.Remove(correctLine);
                lineIsRight = true;
                break;
            }

            if (line)
                GetProperties(correctParameters as List<Line>, userLine as Line, ++index, "Отрезок ", lineIsRight,
                    true);
            if (arc)
                GetProperties(correctParameters as List<Arc>, userLine as Arc, ++index, "Дуга ", lineIsRight, line,
                    true);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="correctParameters"></param>
    /// <param name="userParameters"></param>
    /// <param name="index"></param>
    /// <param name="type"></param>
    /// <param name="result"></param>
    /// <param name="line"></param>
    /// <param name="arc"></param>
    /// <param name="ellipse"></param>
    /// <param name="parabola"></param>
    /// <typeparam name="T"></typeparam>
    private void GetProperties<T>(IEnumerable<T> correctParameters, T userParameters, short index, string type,
        bool result, bool line = false, bool arc = false, bool ellipse = false, bool parabola = false)
    {
        var userCoordinates = userParameters as IPoint;
        if (result)
        {
            if (!CorrectResults.Exists(sketchName => sketchName.Equals("\n" + _name)))
                CorrectResults.Add("\n" + _name);

            var correctResult = "\n\t" + type + index + " построен верно:" + "\n\t\t" +
                                "Координаты: \n\t\t\t" +
                                userCoordinates!.Coordinate.Replace("\n", "\n\t\t\t");
            CorrectResults.Add(correctResult);
            return;
        }

        if (!ErrorResult.Exists(sketchName => sketchName.Equals("\n" + _name)))
            ErrorResult.Add("\n" + _name);

        if (line)
        {
            var userLine = userParameters as Line;
            var correctLines = correctParameters as List<Line>;
            foreach (var correctLine in correctLines!)
            {
                var error = new StringBuilder();
                error.Append("\n\t" + type + _lineIndex++ + ":");
                if (!userLine!.LineLength.Equals(correctLine!.LineLength))
                    error.Append("\n\t\tНеверная длина: " + userLine!.LineLength + " мм");
                error.Append(CoordinateComparer(correctLine, userLine));
                ErrorResult.Add(error.ToString());
            }
        }

        if (arc)
        {
            var userArc = userParameters as Arc;
            var correctArcs = correctParameters as List<Arc>;
            foreach (var correctArc in correctArcs!)
            {
                var error = new StringBuilder();
                error.Append("\n\t" + type + _lineIndex++ + ":");
                if (!userArc!.ArcRadius.Equals(correctArc!.ArcRadius))
                    error.Append("\n\t\tНеверный радиус: " + userArc!.ArcRadius + " мм\n");
                error.Append(CoordinateComparer(correctArc, userArc));
                ErrorResult.Add(error.ToString());
            }
        }

        if (ellipse)
        {
            // ignore
        }

        if (parabola)
        {
            // ignore
        }
    }

    /// <summary>
    ///     Функция сравнения координат объектов
    /// </summary>
    /// <param name="correctCoordinates">Правильный объект примитива</param>
    /// <param name="userCoordinates">Пользовательский объект примитива</param>
    /// <typeparam name="T">Класс примитива</typeparam>
    /// <returns>Возвращает тип string с неверными координатами</returns>
    private static string CoordinateComparer<T>(T correctCoordinates, T userCoordinates)
    {
        var userCoordinate = (IPoint)userCoordinates;
        var correctCoordinate = (IPoint)correctCoordinates;

        var error = new StringBuilder();

        var arc = typeof(T).Name.Equals("Arc");
        var ellipse = typeof(T).Name.Equals("Ellipse");
        var parabola = typeof(T).Name.Equals("Parabola");

        if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, StartPt)
                .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, StartPt)))
        {
            error.Append("\n\t\t" + GetCoordinateValueFromSplit(userCoordinate!.Coordinate, StartPt));
            if (!userCoordinate!.XStart.Equals(correctCoordinate!.XStart))
                error.Append("\n\t\t\tx: " + userCoordinate.XStart);
            if (!userCoordinate!.YStart.Equals(correctCoordinate!.YStart))
                error.Append("\n\t\t\ty: " + userCoordinate!.YStart);
            if (!userCoordinate!.ZStart.Equals(correctCoordinate!.ZStart))
                error.Append("\n\t\t\tz: " + userCoordinate!.ZStart);
        }

        if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, EndPt)
                .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, EndPt)))
        {
            error.Append("\n\t\t" + GetCoordinateValueFromSplit(userCoordinate!.Coordinate, EndPt));
            if (!userCoordinate!.XEnd.Equals(correctCoordinate!.XEnd))
                error.Append("\n\t\t\tx: " + userCoordinate!.XEnd);
            if (!userCoordinate!.YEnd.Equals(correctCoordinate!.YEnd))
                error.Append("\n\t\t\ty: " + userCoordinate!.YEnd);
            if (!userCoordinate!.ZEnd.Equals(correctCoordinate!.ZEnd))
                error.Append("\n\t\t\tz: " + userCoordinate!.ZEnd);
        }

        if (arc | ellipse | parabola)
        {
            if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, CenterPt)
                    .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, CenterPt)))
            {
                var userCenterPoint = userCoordinates as ICenterPoint;
                var correctCenterPoint = correctCoordinates as ICenterPoint;

                error.Append("\n\t\t" + GetCoordinateValueFromSplit(userCoordinate!.Coordinate, CenterPt));
                if (!userCenterPoint!.XCenter.Equals(correctCenterPoint!.XCenter))
                    error.Append("\n\t\t\tx: " + userCenterPoint!.XCenter);
                if (!userCenterPoint!.YCenter.Equals(correctCenterPoint!.YCenter))
                    error.Append("\n\t\t\ty: " + userCenterPoint!.YCenter);
                if (!userCenterPoint!.ZCenter.Equals(correctCenterPoint!.ZCenter))
                    error.Append("\n\t\t\tz: " + userCenterPoint!.ZCenter);
            }

            if (ellipse)
            {
                var userEllipsePoints = userCoordinates as IEllipsePoint;
                var correctEllipsePoints = correctCoordinates as IEllipsePoint;

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MajorPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, MajorPt)))
                {
                    error.Append("\n\t\t" + GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MajorPt));
                    if (!userEllipsePoints!.XMajor.Equals(correctEllipsePoints!.XMajor))
                        error.Append("\n\t\t\tx: " + userEllipsePoints!.XMajor);
                    if (!userEllipsePoints!.YMajor.Equals(correctEllipsePoints!.YMajor))
                        error.Append("\n\t\t\ty: " + userEllipsePoints!.YMajor);
                    if (!userEllipsePoints!.ZMajor.Equals(correctEllipsePoints!.ZMajor))
                        error.Append("\n\t\t\tz: " + userEllipsePoints!.ZMajor);
                }

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MinorPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, MinorPt)))
                {
                    error.Append("\n\t\t" + GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MinorPt));
                    if (!userEllipsePoints!.XMinor.Equals(correctEllipsePoints!.XMinor))
                        error.Append("\n\t\t\tx: " + userEllipsePoints!.XMinor);
                    if (!userEllipsePoints!.YMinor.Equals(correctEllipsePoints!.YMinor))
                        error.Append("\n\t\t\ty: " + userEllipsePoints!.YMinor);
                    if (!userEllipsePoints!.ZMinor.Equals(correctEllipsePoints!.ZMinor))
                        error.Append("\n\t\t\tz: " + userEllipsePoints!.ZMinor);
                }
            }

            if (parabola)
            {
                var userParabolaPoints = userCoordinates as IParabolaPoint;
                var correctParabolaPoints = correctCoordinates as IParabolaPoint;

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, FocusPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, FocusPt)))
                {
                    error.Append("\n\t\t" + GetCoordinateValueFromSplit(userCoordinate!.Coordinate, FocusPt));
                    if (!userParabolaPoints!.XFocus.Equals(correctParabolaPoints!.XFocus))
                        error.Append("\n\t\t\tx: " + userParabolaPoints!.XFocus);
                    if (!userParabolaPoints!.YFocus.Equals(correctParabolaPoints!.YFocus))
                        error.Append("\n\t\t\ty: " + userParabolaPoints!.YFocus);
                    if (!userParabolaPoints!.ZFocus.Equals(correctParabolaPoints!.ZFocus))
                        error.Append("\n\t\t\tz: " + userParabolaPoints!.ZFocus);
                }

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, ApexPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, ApexPt)))
                {
                    error.Append("\n\t\t" + GetCoordinateValueFromSplit(userCoordinate!.Coordinate, ApexPt));
                    if (!userParabolaPoints!.XApex.Equals(correctParabolaPoints!.XApex))
                        error.Append("\n\t\t\tx: " + userParabolaPoints!.XApex);
                    if (!userParabolaPoints!.YApex.Equals(correctParabolaPoints!.YApex))
                        error.Append("\n\t\t\ty: " + userParabolaPoints!.YApex);
                    if (!userParabolaPoints!.ZApex.Equals(correctParabolaPoints!.ZApex))
                        error.Append("\n\t\t\tz: " + userParabolaPoints!.ZApex);
                }
            }
        }

        return error.ToString();
    }

    private static string GetCoordinateValueFromSplit(string coordinate, byte index)
    {
        var coordinates = coordinate.Split('\n');
        return coordinates.Length - 1 < index ? string.Empty : coordinates[index];
    }
}