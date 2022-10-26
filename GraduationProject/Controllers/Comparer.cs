using System.Collections.Generic;
using System.Windows.Forms;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;
using GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;
using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.Controllers;

public static class Comparer
{
    private const byte StartPt = 0;
    private const byte EndPt = 1;
    private const byte CenterPt = 2;
    private const byte FocusPt = 2;
    private const byte ApexPt = 3;
    private const byte MajorPt = 3;
    private const byte MinorPt = 4;
    private static bool _firstSketchChecking;
    public static TreeNode CorrectNodes;
    public static TreeNode ErrorNodes;

    /// <summary>
    /// </summary>
    /// <param name="userModel"></param>
    /// <param name="correctModel"></param>
    public static void ModelObjectsComparision(Model userModel, Model correctModel)
    {
        if (!userModel.NumberOf3DOperations.Equals(correctModel.NumberOf3DOperations))
        {
            Message.ErrorMessage(
                "Количество пользовательских трехмерных операций не соответствует количеству правильных трехмерных операций!");
            return;
        }

        CorrectNodes = new TreeNode("Правильные элементы");
        ErrorNodes = new TreeNode("Ошибки в эскизе");
        _firstSketchChecking = true;
        FeaturesComparision(userModel.Features, correctModel.Features);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userFeatures"></param>
    /// <param name="correctFeatures"></param>
    private static void FeaturesComparision(List<TridimensionalOperation> userFeatures,
        List<TridimensionalOperation> correctFeatures)
    {
        var index = 0;
        if (_firstSketchChecking)
        {
            var startSketchPlane = CheckingSketchPlane(userFeatures[0].Sketch, correctFeatures[0].Sketch);
            _firstSketchChecking = false;
            if (!startSketchPlane)
            {
                Message.ErrorMessage("Первый эскиз был начерчен не верно! Проверка приостановлена!");
                return;
            }
        }

        foreach (var userFeature in userFeatures)
        {
            CorrectNodes.Nodes.Add(userFeature.Name);
            ErrorNodes.Nodes.Add(userFeature.Name);
            var correctFeature = correctFeatures[index];
            if (correctFeature.Sketch is not null)
            {
                FindingAnErrorInASketch(userFeature.Sketch, correctFeature.Sketch);
            }

            index++;
            if (userFeature.Depth.Equals(correctFeature.Depth))
                CorrectNodes.LastNode.Nodes.Insert(0, $"Глубина: {userFeature.Depth} мм");
            else
                ErrorNodes.LastNode.Nodes.Insert(0, $"Глубина: {userFeature.Depth} мм");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userSketch"></param>
    /// <param name="correctSketch"></param>
    private static void FindingAnErrorInASketch(ISketch userSketch, ISketch correctSketch)
    {
        CorrectNodes.LastNode.Nodes.Add(userSketch!.SketchName);
        ErrorNodes.LastNode.Nodes.Add(userSketch!.SketchName);
        if (userSketch.Face is not null)
            CheckingSketchFace(userSketch.Face, correctSketch.Face);
        if (userSketch.Plane is not null)
            CheckingSketchPlane(userSketch, correctSketch);
        if (userSketch.LineIsTrue && correctSketch.LineIsTrue && userSketch.LineCount.Equals(correctSketch.LineCount))
            ComparerParameters(userSketch.Lines, correctSketch.Lines);
        if (userSketch.ArcIsTrue && correctSketch.ArcIsTrue && userSketch.ArcCount.Equals(correctSketch.ArcCount))
            ComparerParameters(userSketch.Arcs, correctSketch.Arcs);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userSketch"></param>
    /// <param name="correctSketch"></param>
    /// <returns></returns>
    private static bool CheckingSketchPlane(ISketch userSketch, ISketch correctSketch)
    {
        if (userSketch.Plane is null || correctSketch.Plane is null) return false;
        var plane = userSketch.Plane.Equals(correctSketch.Plane);
        switch (plane)
        {
            case true when !_firstSketchChecking:
                CorrectNodes.LastNode.LastNode.Nodes.Add($"Плоскость: {userSketch.Plane}");
                break;
            case false when !_firstSketchChecking:
                ErrorNodes.LastNode.LastNode.Nodes.Add($"Плоскость: {userSketch.Plane}");
                break;
        }
        return plane;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userFace"></param>
    /// <param name="correctFace"></param>
    private static void CheckingSketchFace(Face userFace, Face correctFace)
    {
        if (userFace.Equals(correctFace))
        {
            CorrectNodes.LastNode.LastNode.Nodes.Add("Грань");
            CorrectNodes.LastNode.LastNode.LastNode.Nodes.Add($"Объект: {correctFace.FeatureName}");
            CorrectNodes.LastNode.LastNode.LastNode.Nodes.Add($"I: {correctFace.I}");
            CorrectNodes.LastNode.LastNode.LastNode.Nodes.Add($"J: {correctFace.J}");
            CorrectNodes.LastNode.LastNode.LastNode.Nodes.Add($"K: {correctFace.K}");
            return;
        }
        ErrorNodes.LastNode.LastNode.Nodes.Add("Грань");
        ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add($"Объект: {correctFace.FeatureName}");
        ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add($"I: {correctFace.I}");
        ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add($"J: {correctFace.J}");
        ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add($"K: {correctFace.K}");
    }

    /// <summary>
    ///     Процедура определения пользовательского объекта
    /// </summary>
    /// <param name="correctParameters">Правильные параметры примитива</param>
    /// <param name="userParameters">Пользовательские параметры примитива</param>
    /// <typeparam name="T">Класс примитива</typeparam>
    private static void ComparerParameters<T>(IReadOnlyList<T> userParameters, IReadOnlyList<T> correctParameters)
    {
        var lineObjectNumber = 1;
        var arcObjectNumber = 1;
        for (var index = 0; index < userParameters.Count; index++)
        {
            var userParam = userParameters[index];
            var correctParam = correctParameters[index];
            string objectType;
            bool result;
            switch (typeof(T).Name)
            {
                case "Line":
                    var userLine = userParam as Line;
                    var correctLine = correctParam as Line;
                    objectType = "Отрезок";
                    result = CheckCoordinates(objectType, lineObjectNumber, userLine!.Coordinate, correctLine!.Coordinate);
                    if (result)
                        GetCorrectCoordinates(userLine.Coordinate);
                    else
                        GetErrorCoordinates(userLine, correctLine);
                    CheckValues(objectType, lineObjectNumber, userLine.LineLength, correctLine.LineLength, "Длина");
                    lineObjectNumber++;
                    break;
                case "Arc":
                    var userArc = userParam as Arc;
                    var correctArc = correctParam as Arc;
                    objectType = "Дуга";
                    result = CheckCoordinates(objectType, arcObjectNumber, userArc!.Coordinate, correctArc!.Coordinate);
                    if (result)
                        GetCorrectCoordinates(userArc.Coordinate);
                    else
                        GetErrorCoordinates(userArc, correctArc);
                    CheckValues(objectType, arcObjectNumber, userArc.ArcRadius, correctArc.ArcRadius, "Радиус");
                    arcObjectNumber++;
                    break;
                case "Ellipse":
                    break;
                case "Parabola":
                    break;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="objectNumber"></param>
    /// <param name="userCoordinate"></param>
    /// <param name="correctCoordinate"></param>
    /// <returns></returns>
    private static bool CheckCoordinates(string objectType, int objectNumber, string userCoordinate, string correctCoordinate)
    {
        if (userCoordinate.Equals(correctCoordinate))
        {
            CorrectNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
            return true;
        }
        ErrorNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="objectNumber"></param>
    /// <param name="userValue"></param>
    /// <param name="correctValue"></param>
    /// <param name="valueType"></param>
    private static void CheckValues(string objectType, int objectNumber, double userValue, double correctValue, string valueType)
    {
        if (userValue.Equals(correctValue))
        {
            if (CorrectNodes.LastNode.LastNode.LastNode is null ||
                !CorrectNodes.LastNode.LastNode.LastNode.Text.Equals($"{objectType} {objectNumber}"))
                CorrectNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
            CorrectNodes.LastNode.LastNode.LastNode!.Nodes.Insert(0, $"{valueType}: {userValue} мм");
        }
        else
        {
            if (ErrorNodes.LastNode.LastNode.LastNode is null ||
                !ErrorNodes.LastNode.LastNode.LastNode.Text.Equals($"{objectType} {objectNumber}"))
                ErrorNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
            ErrorNodes.LastNode.LastNode.LastNode!.Nodes.Insert(0,
                $"{valueType}: {userValue} мм");
        }
    }

    
    /// <summary>
    ///     Функция вывода информации о правильности пользовательского объекта
    /// </summary>
    /// <param name="userCoordinates">Координаты объекта</param>
    /// <returns>Возвращает информацию правильности пользовательского объекта</returns>
    private static void GetCorrectCoordinates(string userCoordinates)
    {
        var coordinates = userCoordinates.Split('\n');
        foreach (var coordinate in coordinates)
            CorrectNodes.LastNode.LastNode.LastNode.Nodes.Add(coordinate);
    }

    /// <summary>
    ///     Функция сравнения координат объектов
    /// </summary>
    /// <param name="correctCoordinates">Правильный объект примитива</param>
    /// <param name="userCoordinates">Пользовательский объект примитива</param>
    /// <typeparam name="T">Класс примитива</typeparam>
    /// <returns>Возвращает тип string с неверными координатами</returns>
    private static void GetErrorCoordinates<T>(T userCoordinates, T correctCoordinates)
    {
        var userCoordinate = (IPoint)userCoordinates;
        var correctCoordinate = (IPoint)correctCoordinates;
        var arc = typeof(T).Name.Equals("Arc");
        var ellipse = typeof(T).Name.Equals("Ellipse");
        var parabola = typeof(T).Name.Equals("Parabola");

        if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, StartPt)
                .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, StartPt)))
        {
            ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add(GetCoordinateValueFromSplit(userCoordinate!.Coordinate,
                StartPt));
            if (!userCoordinate!.XStart.Equals(correctCoordinate!.XStart))
                ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userCoordinate.XStart}");
            if (!userCoordinate!.YStart.Equals(correctCoordinate!.YStart))
                ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userCoordinate.YStart}");
            if (!userCoordinate!.ZStart.Equals(correctCoordinate!.ZStart))
                ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userCoordinate.ZStart}");
        }

        if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, EndPt)
                .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, EndPt)))
        {
            ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add(GetCoordinateValueFromSplit(userCoordinate!.Coordinate,
                EndPt));
            if (!userCoordinate!.XEnd.Equals(correctCoordinate!.XEnd))
                ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userCoordinate.XEnd}");
            if (!userCoordinate!.YEnd.Equals(correctCoordinate!.YEnd))
                ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userCoordinate.YEnd}");
            if (!userCoordinate!.ZEnd.Equals(correctCoordinate!.ZEnd))
                ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userCoordinate.ZEnd}");
        }

        if (arc | ellipse | parabola)
        {
            if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, CenterPt)
                    .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, CenterPt)))
            {
                var userCenterPoint = userCoordinates as ICenterPoint;
                var correctCenterPoint = correctCoordinates as ICenterPoint;

                ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                    GetCoordinateValueFromSplit(userCoordinate!.Coordinate, CenterPt));
                if (!userCenterPoint!.XCenter.Equals(correctCenterPoint!.XCenter))
                    ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userCenterPoint.XCenter}");
                if (!userCenterPoint!.YCenter.Equals(correctCenterPoint!.YCenter))
                    ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userCenterPoint.YCenter}");
                if (!userCenterPoint!.ZCenter.Equals(correctCenterPoint!.ZCenter))
                    ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userCenterPoint.ZCenter}");
            }

            if (ellipse)
            {
                var userEllipsePoints = userCoordinates as IEllipsePoint;
                var correctEllipsePoints = correctCoordinates as IEllipsePoint;

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MajorPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, MajorPt)))
                {
                    ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MajorPt));
                    if (!userEllipsePoints!.XMajor.Equals(correctEllipsePoints!.XMajor))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userEllipsePoints!.XMajor}");
                    if (!userEllipsePoints!.YMajor.Equals(correctEllipsePoints!.YMajor))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userEllipsePoints!.YMajor}");
                    if (!userEllipsePoints!.ZMajor.Equals(correctEllipsePoints!.ZMajor))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userEllipsePoints!.ZMajor}");
                }

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MinorPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, MinorPt)))
                {
                    ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MinorPt));
                    if (!userEllipsePoints!.XMinor.Equals(correctEllipsePoints!.XMinor))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userEllipsePoints!.XMinor}");
                    if (!userEllipsePoints!.YMinor.Equals(correctEllipsePoints!.YMinor))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userEllipsePoints!.YMinor}");
                    if (!userEllipsePoints!.ZMinor.Equals(correctEllipsePoints!.ZMinor))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userEllipsePoints!.ZMinor}");
                }
            }

            if (parabola)
            {
                var userParabolaPoints = userCoordinates as IParabolaPoint;
                var correctParabolaPoints = correctCoordinates as IParabolaPoint;

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, FocusPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, FocusPt)))
                {
                    ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, FocusPt));
                    if (!userParabolaPoints!.XFocus.Equals(correctParabolaPoints!.XFocus))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userParabolaPoints!.XFocus}");
                    if (!userParabolaPoints!.YFocus.Equals(correctParabolaPoints!.YFocus))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userParabolaPoints!.YFocus}");
                    if (!userParabolaPoints!.ZFocus.Equals(correctParabolaPoints!.ZFocus))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userParabolaPoints!.ZFocus}");
                }

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, ApexPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, ApexPt)))
                {
                    ErrorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, ApexPt));
                    if (!userParabolaPoints!.XApex.Equals(correctParabolaPoints!.XApex))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userParabolaPoints!.XApex}");
                    if (!userParabolaPoints!.YApex.Equals(correctParabolaPoints!.YApex))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userParabolaPoints!.YApex}");
                    if (!userParabolaPoints!.ZApex.Equals(correctParabolaPoints!.ZApex))
                        ErrorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userParabolaPoints!.ZApex}");
                }
            }
        }
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