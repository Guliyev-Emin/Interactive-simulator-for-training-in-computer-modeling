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
    private short _objectNumber;

    /// <summary>
    ///     Функция проверки правильных эскизов с пользовательскими эскизами
    /// </summary>
    /// <param name="correctSketch">Правильный эскиз</param>
    /// <param name="userSketch">Пользовательский эскиз</param>
    /// <returns>Возвращает кортеж с правильными и неправильными примитивами в пользовательском эскизе</returns>
    public List<List<(List<string> correct, List<string> error)>> SketchComparer(SketchInfo correctSketch,
        SketchInfo userSketch)
    {
        _name = userSketch.SketchName;
        var comparerFinalResult = new List<List<(List<string> correct, List<string> error)>>();

        ComparerDeepth(correctSketch.Depth, userSketch.Depth, out var comparerResults);
        comparerFinalResult.Add(comparerResults);


        if (correctSketch.Lines?.Count != 0)
        {
            ComparerParameters(correctSketch.Lines, userSketch.Lines, out comparerResults);
            comparerFinalResult.Add(comparerResults);
        }


        if (correctSketch.Arcs?.Count != 0)
        {
            ComparerParameters(correctSketch.Arcs, userSketch.Arcs, out comparerResults);
            comparerFinalResult.Add(comparerResults);
        }


        if (correctSketch.Ellipses?.Count != 0)
        {
            ComparerParameters(correctSketch.Ellipses, userSketch.Ellipses, out comparerResults);
            comparerFinalResult.Add(comparerResults);
        }

        if (correctSketch.Parabolas?.Count != 0)
        {
            ComparerParameters(correctSketch.Parabolas, userSketch.Parabolas, out comparerResults);
            comparerFinalResult.Add(comparerResults);
        }

        return comparerFinalResult;
    }

    private void ComparerDeepth(double correctDeepth, double userDeepth,
        out List<(List<string> correct, List<string> error)> comparerResults)
    {
        var comparer = new List<(List<string> correct, List<string> error)>();
        var comparerResult = (correct: new List<string>(), error: new List<string>());

        if (userDeepth.Equals(correctDeepth))
        {
            if (!comparerResult.correct.Exists(sketchName => sketchName.Equals("\n" + _name)))
                comparerResult.correct.Add("\n" + _name);
            comparerResult.correct.Add("\n\tВыдавливание правильно: " + userDeepth + " мм");
        }

        if (!userDeepth.Equals(correctDeepth))
        {
            if (!comparerResult.error.Exists(sketchName => sketchName.Equals("\n" + _name)))
                comparerResult.error.Add("\n" + _name);
            comparerResult.error.Add("\n\tВыдавливание не правильно: " + userDeepth + " мм");
        }

        comparer.Add(comparerResult);
        comparerResults = comparer;
    }

    /// <summary>
    ///     Процедура определения пользовательского объекта
    /// </summary>
    /// <param name="correctParameters">Правильные параметры примитива</param>
    /// <param name="userParameters">Пользовательские параметры примитива</param>
    /// <param name="comparerResults"></param>
    /// <typeparam name="T">Класс примитива</typeparam>
    private void ComparerParameters<T>(ICollection<T> correctParameters,
        List<T> userParameters, out List<(List<string> correct, List<string> error)> comparerResults)
    {
        _objectNumber = 1;
        var arc = typeof(T).Name.Equals("Arc");
        var line = typeof(T).Name.Equals("Line");
        var ellipse = typeof(T).Name.Equals("Ellipse");
        var parabola = typeof(T).Name.Equals("Parabola");
        var index = (short)0;
        var comparer = new List<(List<string> correct, List<string> error)>();
        foreach (var userParameter in userParameters)
        {
            var objectIsRight = false;
            foreach (var correctParameter in correctParameters.Where(correctParameter =>
                         userParameter.Equals(correctParameter)))
            {
                correctParameters.Remove(correctParameter);
                objectIsRight = true;
                break;
            }

            if (line)
                comparer.Add(GetProperties(correctParameters as List<Line>, userParameter as Line, "Отрезок ", ++index,
                    objectIsRight,
                    true));
            if (arc)
                comparer.Add(GetProperties(correctParameters as List<Arc>, userParameter as Arc, "Дуга ", ++index,
                    objectIsRight, line,
                    true));
            if (ellipse)
                comparer.Add(GetProperties(correctParameters as List<Ellipse>, userParameter as Ellipse, "Эллипс ",
                    ++index, objectIsRight, line,
                    arc, true));
            if (parabola)
                comparer.Add(GetProperties(correctParameters as List<Parabola>, userParameter as Parabola, "Парабола ",
                    ++index, objectIsRight, line,
                    arc, ellipse, true));
        }

        comparerResults = comparer;
    }


    /// <summary>
    ///     Функция получения параметров результата проверки пользовательских объектов
    /// </summary>
    /// <param name="correctParameters">Правильные параметры примитива</param>
    /// <param name="userParameter">Пользовательские параметры примитива</param>
    /// <param name="index">Номер объекта примитива</param>
    /// <param name="type">Тип объекта примитива</param>
    /// <param name="result">Результат проверки пользователького объекта</param>
    /// <param name="line">Объект "Отрезок"</param>
    /// <param name="arc">Объект "Дуга"</param>
    /// <param name="ellipse">Объект "Эллипс"</param>
    /// <param name="parabola">Объект "Парабола"</param>
    /// <typeparam name="T">Класс примитива</typeparam>
    /// <returns>Возвращает кортеж правильных и неправильных пользовательских объектов</returns>
    private (List<string> correct, List<string> error) GetProperties<T>(IEnumerable<T> correctParameters,
        T userParameter, string type, short index,
        bool result, bool line = false, bool arc = false, bool ellipse = false, bool parabola = false)
    {
        var comparerResult = (correct: new List<string>(), error: new List<string>());

        if (result)
        {
            var userCoordinates = userParameter as IPoint;
            comparerResult.correct.Add(GetCorrectProperties(type, index, userCoordinates!.Coordinate));
            return comparerResult;
        }

        if (!comparerResult.error.Exists(sketchName => sketchName.Equals("\n" + _name)))
            comparerResult.error.Add("\n" + _name);

        if (line)
        {
            var userLine = userParameter as Line;
            var correctLines = correctParameters as List<Line>;
            var error = new StringBuilder();
            error.Append("\n\t" + type + _objectNumber + ":");
            if (!userLine!.LineLength.Equals(correctLines?[_objectNumber - 1]!.LineLength))
                error.Append("\n\t\tНеверная длина: " + userLine!.LineLength + " мм");
            error.Append(GetErrorCoordinates(correctLines?[_objectNumber - 1], userLine));
            comparerResult.error.Add(error.ToString());
            _objectNumber++;
        }

        if (arc)
        {
            var userArc = userParameter as Arc;
            var correctArcs = correctParameters as List<Arc>;
            var error = new StringBuilder();
            error.Append("\n\t" + type + _objectNumber + ":");
            if (!userArc!.ArcRadius.Equals(correctArcs?[_objectNumber - 1]!.ArcRadius))
                error.Append("\n\t\tНеверный радиус: " + userArc!.ArcRadius + " мм\n");
            error.Append(GetErrorCoordinates(correctArcs?[_objectNumber - 1], userArc));
            comparerResult.error.Add(error.ToString());
            _objectNumber++;
        }

        if (ellipse)
        {
            var userEllipse = userParameter as Ellipse;
            var correctEllipses = correctParameters as List<Ellipse>;
            foreach (var correctEllipse in correctEllipses!)
            {
                var error = new StringBuilder();
                error.Append("\n\t" + type + _objectNumber++ + ":\n");
                error.Append(GetErrorCoordinates(correctEllipse, userEllipse));
                comparerResult.error.Add(error.ToString());
            }
        }

        if (parabola)
        {
            var userParabola = userParameter as Ellipse;
            var correctParabolas = correctParameters as List<Ellipse>;
            foreach (var correctParabola in correctParabolas!)
            {
                var error = new StringBuilder();
                error.Append("\n\t" + type + _objectNumber++ + ":\n");
                error.Append(GetErrorCoordinates(correctParabola, userParabola));
                comparerResult.error.Add(error.ToString());
            }
        }

        return comparerResult;
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
    private static string GetErrorCoordinates<T>(T correctCoordinates, T userCoordinates)
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