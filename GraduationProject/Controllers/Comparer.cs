using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;
using GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;
using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

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
    private static short _objectNumber;
    private static bool _firstSketchChecking;
    private static List<List<List<string>>> _correct;
    private static List<List<List<string>>> _wrong;

    public static List<(string SketchName, List<List<(List<string> correct, List<string> error)>>)> ModelObjectsComparision(Model userModel, Model correctModel)
    {
        if (userModel.NumberOf3DOperations.Equals(correctModel.NumberOf3DOperations))
        {
            _correct = new List<List<List<string>>>();
            _wrong = new List<List<List<string>>>();
            _firstSketchChecking = true;
            return FeaturesComparision(userModel.Features, correctModel.Features);
        }
        Message.ErrorMessage("Количество пользовательских трехмерных операций не соответствует количеству правильных трехмерных операций!");
        return null;
    }

    private static void FindCorrectFeature(TridimensionalOperation userFeature,
        List<TridimensionalOperation> correctFeatures)
    {
        foreach (var correctFeature in correctFeatures)
        {
            if (correctFeature.Type.Equals("MirrorPattern") || userFeature.Type.Equals("MirrorPattern")) continue;
            
            
        }
    }
    
    private static List<(string SketchName, List<List<(List<string> correct, List<string> error)>>)> FeaturesComparision(List<TridimensionalOperation> userFeatures,
        List<TridimensionalOperation> correctFeatures)
    {
        var s = new List<(string SketchName, List<List<(List<string> correct, List<string> error)>>)>();
        var index = 0;
        if (_firstSketchChecking)
        {
            var startSketchPlane = CheckingSketchPlane(userFeatures[0].Sketch, correctFeatures[0].Sketch);
            _firstSketchChecking = false;
            if (!startSketchPlane)
            {
                Message.ErrorMessage("Первый эскиз был начерчен не верно! Проверка приостановлена!");
                return null;
            }
        }
        
        foreach (var userFeature in userFeatures)
        {
            FindCorrectFeature(userFeature, correctFeatures);
            var correctFeature = correctFeatures[index];
            if (!userFeature.Depth.Equals(correctFeature.Depth))
            {
                // error
            }

            // true
            if (correctFeature.Sketch is not null)
            {
                var sketchComparerResult = (userFeature.Sketch!.SketchName, FindingAnErrorInASketch(userFeature.Sketch, correctFeature.Sketch));
                s.Add(sketchComparerResult);
                FindingAnErrorInASketch(userFeature.Sketch, correctFeature.Sketch);
                // Кортеж (string sketchName, List<True, False>) 
            }
            // true
            index++;
        }
        return s;
    }

    private static bool CheckingSketchPlane(ISketch userSketch, ISketch correctSketch)
    {
        if (userSketch.Plane is null || correctSketch.Plane is null) return false;
        var plane = userSketch.Plane.Equals(correctSketch.Plane);
        return plane;
    }

    private static List<List<(List<string> correct, List<string> error)>> FindingAnErrorInASketch(ISketch userSketch, ISketch correctSketch)
    {
        var comparerResult = new List<List<(List<string> correct, List<string> error)>>();
        if (userSketch.LineIsTrue && correctSketch.LineIsTrue && userSketch.LineCount.Equals(correctSketch.LineCount))
        {
            comparerResult.Add(ComparerParameters(userSketch.Lines, correctSketch.Lines));
        }

        if (userSketch.ArcIsTrue && correctSketch.ArcIsTrue && userSketch.ArcCount.Equals(correctSketch.ArcCount))
        {
            comparerResult.Add(ComparerParameters(userSketch.Arcs, correctSketch.Arcs));
        }
        
        return comparerResult;
    }

    /// <summary>
    ///     Процедура определения пользовательского объекта
    /// </summary>
    /// <param name="correctParameters">Правильные параметры примитива</param>
    /// <param name="userParameters">Пользовательские параметры примитива</param>
    /// <typeparam name="T">Класс примитива</typeparam>
    private static List<(List<string> correct, List<string> error)> ComparerParameters<T>(List<T> userParameters, IList<T> correctParameters)
    {
        _objectNumber = 1;
        var arc = typeof(T).Name.Equals("Arc");
        var line = typeof(T).Name.Equals("Line");
        var ellipse = typeof(T).Name.Equals("Ellipse");
        var parabola = typeof(T).Name.Equals("Parabola");
        var comparer = new List<(List<string> correct, List<string> error)>();
        var lineObjectNumber = 1;
        var arcObjectNumber = 1;
        for (var index = 0; index < userParameters.Count; index++)
        {
            var userParam = userParameters[index];
            var correctParam = correctParameters[index];
            var comparerResult = (correct: new List<string>(), error: new List<string>());
            switch (typeof(T).Name)
            {
                case "Line":
                    var userLine = userParam as Line;
                    var correctLine = correctParam as Line;
                    if (!userLine!.Coordinate.Equals(correctLine!.Coordinate) || !userLine.LineLength.Equals(userLine.LineLength))
                        comparerResult.error.Add("\n\tОбъект \"Отрезок " + lineObjectNumber++ + "\""  + " построен неверно:" + "\t\t" + GetErrorCoordinates(userLine, correctLine));
                    else
                        comparerResult.correct.Add(GetCorrectProperties("Отрезок ", (short)(lineObjectNumber++), userLine.Coordinate));
                    break;
                case "Arc":
                    var userArc = userParam as Arc;
                    var correctArc = correctParam as Arc;
                    if (!userArc!.Coordinate.Equals(correctArc!.Coordinate))
                        comparerResult.error.Add("\n\tОбъект \"Дуга " + arcObjectNumber++ + "\""  + " построен неверно:" + "\n\t\t" + GetErrorCoordinates(userArc, correctArc));
                    else 
                        comparerResult.correct.Add(GetCorrectProperties("Дуга ", (short)(arcObjectNumber++), userArc.Coordinate));
                    break;
                case "Ellipse":
                    break;
                case "Parabola":
                    break;
            }
            
            comparer.Add(comparerResult);
        }
        return comparer;
    }

    /// <summary>
    ///     Функция вывода информации о правильности пользовательского объекта
    /// </summary>
    /// <param name="type">Тип объекта</param>
    /// <param name="index">Номер объекта</param>
    /// <param name="userCoordinates">Координаты объекта</param>
    /// <returns>Возвращает информацию правильности пользовательского объекта</returns>
    private static string GetCorrectProperties(string type, short index, string userCoordinates)
    {
        return "\n\t" + type + index + " построен верно:" + "\n\t\t" +
               "Координаты: \n\t\t\t" +
               userCoordinates.Replace("\n", "\n\t\t\t");
    }

    /// <summary>
    ///     Функция сравнения координат объектов
    /// </summary>
    /// <param name="correctCoordinates">Правильный объект примитива</param>
    /// <param name="userCoordinates">Пользовательский объект примитива</param>
    /// <typeparam name="T">Класс примитива</typeparam>
    /// <returns>Возвращает тип string с неверными координатами</returns>
    private static string GetErrorCoordinates<T>(T userCoordinates, T correctCoordinates)
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

    /// <summary>
    ///     Функция получения нужных координат из строки с координатами объекта
    /// </summary>
    /// <param name="coordinate">Координаты объекта</param>
    /// <param name="index">Индекс нужных координат</param>
    /// <returns>Возвращает координаты под выбронным индексом</returns>
    private static string GetCoordinateValueFromSplit(string coordinate, byte index)
    {
        var coordinates = coordinate.Split('\n');
        return coordinates.Length - 1 < index ? string.Empty : coordinates[index];
    }
}