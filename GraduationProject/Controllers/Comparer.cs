using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraduationProject.ModelObjects.IObjects;
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
    private static TreeNode _correctNodes;
    private static TreeNode _errorNodes;
    private static string _featureName;
    private static string _sketchName;

    /// <summary>
    /// </summary>
    /// <param name="userModel"></param>
    /// <param name="correctModel"></param>
    public static (TreeNode CorrectNodes, TreeNode ErrorNodes)? ModelObjectsComparision(Model userModel,
        Model correctModel)
    {
        if (!userModel.NumberOf3DOperations.Equals(correctModel.NumberOf3DOperations))
        {
            Message.ErrorMessage(
                "Количество пользовательских трехмерных операций не соответствует количеству правильных трехмерных операций!");
            return null;
        }

        _correctNodes = new TreeNode("Правильные элементы");
        _errorNodes = new TreeNode("Ошибки в эскизе");
        _firstSketchChecking = true;
        FeaturesComparision(userModel.Features, correctModel.Features);
        return (CorrectNodes: _correctNodes, ErrorNodes: _errorNodes);
    }

    /// <summary>
    /// </summary>
    /// <param name="userFeatures"></param>
    /// <param name="correctFeatures"></param>
    private static void FeaturesComparision(List<TridimensionalOperation> userFeatures,
        List<TridimensionalOperation> correctFeatures)
    {
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
        var correctFeaturesCopy = correctFeatures;
        foreach (var userFeature in userFeatures)
        {
            var correctFeature = FindCorrectFeature(userFeature, ref correctFeaturesCopy);
            if (correctFeature is null)
            {
                _errorNodes.Nodes.Add(userFeature.Name);
                _errorNodes.LastNode.Nodes.Add("Ошибка! Не найдена данная операция или эскиз!");
                continue;
            }
            _featureName = userFeature.Name;
            correctFeaturesCopy.Remove(correctFeature);
            switch (userFeature.Type)
            {
                case "MirrorPattern":
                    MirrorComparer(userFeature.Mirror, correctFeature.Mirror);
                    continue;
                default:
                    if (correctFeature.Sketch is not null)
                        FindingAnErrorInASketch(userFeature.Sketch, correctFeature.Sketch);
                    if (userFeature.Depth.Equals(correctFeature.Depth))
                    {
                        ObjectNameIsTrue(_featureName, _correctNodes);
                        _correctNodes.LastNode.Nodes.Insert(0, $"Глубина: {userFeature.Depth} мм");
                    }
                    else
                    {
                        ObjectNameIsTrue(_featureName, _errorNodes);
                        _errorNodes.LastNode.Nodes.Insert(0, $"Глубина: {userFeature.Depth} мм");
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userFeature"></param>
    /// <param name="correctFeatures"></param>
    /// <returns></returns>
    private static TridimensionalOperation FindCorrectFeature(ITridimensionalOperation userFeature,
        ref List<TridimensionalOperation> correctFeatures)
    {
        var list = correctFeatures;
        var userSketch = userFeature.Sketch;
        var filtered3DOperations = correctFeatures.Where(correct =>
        {
            var correctSketch = correct.Sketch;
            if (userSketch is not null && correctSketch is not null)
                return correct.Type.Equals(userFeature.Type) &&
                       correctSketch.LineCount.Equals(userSketch.LineCount) &&
                       correctSketch.ArcCount.Equals(userSketch.ArcCount);

            if (userFeature.Mirror is null || correct.Mirror is null) return false;
            if (correct.Mirror.Plane.Equals(userFeature.Mirror.Plane) &&
                correct.Mirror.FeatureNames.Count.Equals(userFeature.Mirror.FeatureNames.Count))
                return true;
            var mirrors = list.Select(c => c.Mirror).ToList();
            if (mirrors.Count.Equals(1)) return true;

            return correct.Mirror.Plane.Equals(userFeature.Mirror.Plane) ||
                   correct.Mirror.FeatureNames.Count.Equals(userFeature.Mirror.FeatureNames.Count);
        }).ToList();

        switch (filtered3DOperations.Count)
        {
            case 0:
                return null;
            case 1:
                return filtered3DOperations.First();
            default:
                foreach (var tridimensionalOperation in filtered3DOperations)
                {
                    var correctSketch = tridimensionalOperation.Sketch;
                    if (userSketch is not null && correctSketch is not null)
                    {
                        var lineLenghtIsTrue = false;
                        var faceIsTrue = false;
                        if (correctSketch!.LineIsTrue && userSketch!.LineIsTrue)
                            lineLenghtIsTrue = userSketch.Lines.First().LineLength.Equals(correctSketch.Lines.First().LineLength);
                        
                        if (correctSketch.Face is not null && userSketch!.Face is not null)
                            faceIsTrue = userSketch.Face.I.Equals(correctSketch.Face.I) &&
                                         userSketch.Face.J.Equals(correctSketch.Face.J) &&
                                         userSketch.Face.K.Equals(correctSketch.Face.K);
                        if (lineLenghtIsTrue && faceIsTrue) return tridimensionalOperation;
                    }

                    if (userFeature.Mirror is null || tridimensionalOperation.Mirror is null) continue;
                    if (userFeature.Mirror.Plane.Equals(tridimensionalOperation.Mirror.Plane))
                        return tridimensionalOperation;
                }

                return filtered3DOperations.First();
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="userSketch"></param>
    /// <param name="correctSketch"></param>
    private static void FindingAnErrorInASketch(ISketch userSketch, ISketch correctSketch)
    {
        _sketchName = userSketch.SketchName;
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
                ObjectNameIsTrue(_featureName, _correctNodes);
                ObjectSketchNameIsTrue(_sketchName, _correctNodes);
                _correctNodes.LastNode.LastNode.Nodes.Add($"Плоскость: {userSketch.Plane}");
                break;
            case false when !_firstSketchChecking:
                ObjectNameIsTrue(_featureName, _errorNodes);
                ObjectSketchNameIsTrue(_sketchName, _errorNodes);
                _errorNodes.LastNode.LastNode.Nodes.Add($"Плоскость: {userSketch.Plane}");
                break;
        }

        return plane;
    }

    /// <summary>
    /// </summary>
    /// <param name="userFace"></param>
    /// <param name="correctFace"></param>
    private static void CheckingSketchFace(Face userFace, Face correctFace)
    {
        if (userFace.Equals(correctFace))
        {
            ObjectNameIsTrue(_featureName, _correctNodes);
            ObjectSketchNameIsTrue(_sketchName, _correctNodes);
            _correctNodes.LastNode.LastNode.Nodes.Add("Грань");
            _correctNodes.LastNode.LastNode.LastNode.Nodes.Add($"Объект: {correctFace.FeatureName}");
            _correctNodes.LastNode.LastNode.LastNode.Nodes.Add($"I: {correctFace.I}");
            _correctNodes.LastNode.LastNode.LastNode.Nodes.Add($"J: {correctFace.J}");
            _correctNodes.LastNode.LastNode.LastNode.Nodes.Add($"K: {correctFace.K}");
            return;
        }

        ObjectNameIsTrue(_featureName, _errorNodes);
        ObjectSketchNameIsTrue(_sketchName, _errorNodes);
        _errorNodes.LastNode.LastNode.Nodes.Add("Грань");
        _errorNodes.LastNode.LastNode.LastNode.Nodes.Add($"Объект: {correctFace.FeatureName}");
        _errorNodes.LastNode.LastNode.LastNode.Nodes.Add($"I: {correctFace.I}");
        _errorNodes.LastNode.LastNode.LastNode.Nodes.Add($"J: {correctFace.J}");
        _errorNodes.LastNode.LastNode.LastNode.Nodes.Add($"K: {correctFace.K}");
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
                    result = CheckCoordinates(objectType, lineObjectNumber, userLine!.Coordinate,
                        correctLine!.Coordinate);
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
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="objectNumber"></param>
    /// <param name="userCoordinate"></param>
    /// <param name="correctCoordinate"></param>
    /// <returns></returns>
    private static bool CheckCoordinates(string objectType, int objectNumber, string userCoordinate,
        string correctCoordinate)
    {
        if (userCoordinate.Equals(correctCoordinate))
        {
            _correctNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
            return true;
        }

        _errorNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
        return false;
    }

    /// <summary>
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="objectNumber"></param>
    /// <param name="userValue"></param>
    /// <param name="correctValue"></param>
    /// <param name="valueType"></param>
    private static void CheckValues(string objectType, int objectNumber, double userValue, double correctValue,
        string valueType)
    {
        if (userValue.Equals(correctValue))
        {
            if (_correctNodes.LastNode.LastNode.LastNode is null ||
                !_correctNodes.LastNode.LastNode.LastNode.Text.Equals($"{objectType} {objectNumber}"))
                _correctNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
            _correctNodes.LastNode.LastNode.LastNode!.Nodes.Insert(0, $"{valueType}: {userValue} мм");
        }
        else
        {
            if (_errorNodes.LastNode.LastNode.LastNode is null ||
                !_errorNodes.LastNode.LastNode.LastNode.Text.Equals($"{objectType} {objectNumber}"))
                _errorNodes.LastNode.LastNode.Nodes.Add($"{objectType} {objectNumber}");
            _errorNodes.LastNode.LastNode.LastNode!.Nodes.Insert(0,
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
            _correctNodes.LastNode.LastNode.LastNode.Nodes.Add(coordinate);
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
            _errorNodes.LastNode.LastNode.LastNode.Nodes.Add(GetCoordinateValueFromSplit(userCoordinate!.Coordinate,
                StartPt));
            if (!userCoordinate!.XStart.Equals(correctCoordinate!.XStart))
                _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userCoordinate.XStart}");
            if (!userCoordinate!.YStart.Equals(correctCoordinate!.YStart))
                _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userCoordinate.YStart}");
            if (!userCoordinate!.ZStart.Equals(correctCoordinate!.ZStart))
                _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userCoordinate.ZStart}");
        }

        if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, EndPt)
                .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, EndPt)))
        {
            _errorNodes.LastNode.LastNode.LastNode.Nodes.Add(GetCoordinateValueFromSplit(userCoordinate!.Coordinate,
                EndPt));
            if (!userCoordinate!.XEnd.Equals(correctCoordinate!.XEnd))
                _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userCoordinate.XEnd}");
            if (!userCoordinate!.YEnd.Equals(correctCoordinate!.YEnd))
                _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userCoordinate.YEnd}");
            if (!userCoordinate!.ZEnd.Equals(correctCoordinate!.ZEnd))
                _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userCoordinate.ZEnd}");
        }

        if (arc | ellipse | parabola)
        {
            if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, CenterPt)
                    .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, CenterPt)))
            {
                var userCenterPoint = userCoordinates as ICenterPoint;
                var correctCenterPoint = correctCoordinates as ICenterPoint;

                _errorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                    GetCoordinateValueFromSplit(userCoordinate!.Coordinate, CenterPt));
                if (!userCenterPoint!.XCenter.Equals(correctCenterPoint!.XCenter))
                    _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userCenterPoint.XCenter}");
                if (!userCenterPoint!.YCenter.Equals(correctCenterPoint!.YCenter))
                    _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userCenterPoint.YCenter}");
                if (!userCenterPoint!.ZCenter.Equals(correctCenterPoint!.ZCenter))
                    _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userCenterPoint.ZCenter}");
            }

            if (ellipse)
            {
                var userEllipsePoints = userCoordinates as IEllipsePoint;
                var correctEllipsePoints = correctCoordinates as IEllipsePoint;

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MajorPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, MajorPt)))
                {
                    _errorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MajorPt));
                    if (!userEllipsePoints!.XMajor.Equals(correctEllipsePoints!.XMajor))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userEllipsePoints!.XMajor}");
                    if (!userEllipsePoints!.YMajor.Equals(correctEllipsePoints!.YMajor))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userEllipsePoints!.YMajor}");
                    if (!userEllipsePoints!.ZMajor.Equals(correctEllipsePoints!.ZMajor))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userEllipsePoints!.ZMajor}");
                }

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MinorPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, MinorPt)))
                {
                    _errorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, MinorPt));
                    if (!userEllipsePoints!.XMinor.Equals(correctEllipsePoints!.XMinor))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userEllipsePoints!.XMinor}");
                    if (!userEllipsePoints!.YMinor.Equals(correctEllipsePoints!.YMinor))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userEllipsePoints!.YMinor}");
                    if (!userEllipsePoints!.ZMinor.Equals(correctEllipsePoints!.ZMinor))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userEllipsePoints!.ZMinor}");
                }
            }

            if (parabola)
            {
                var userParabolaPoints = userCoordinates as IParabolaPoint;
                var correctParabolaPoints = correctCoordinates as IParabolaPoint;

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, FocusPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, FocusPt)))
                {
                    _errorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, FocusPt));
                    if (!userParabolaPoints!.XFocus.Equals(correctParabolaPoints!.XFocus))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userParabolaPoints!.XFocus}");
                    if (!userParabolaPoints!.YFocus.Equals(correctParabolaPoints!.YFocus))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userParabolaPoints!.YFocus}");
                    if (!userParabolaPoints!.ZFocus.Equals(correctParabolaPoints!.ZFocus))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userParabolaPoints!.ZFocus}");
                }

                if (!GetCoordinateValueFromSplit(userCoordinate!.Coordinate, ApexPt)
                        .Equals(GetCoordinateValueFromSplit(correctCoordinate!.Coordinate, ApexPt)))
                {
                    _errorNodes.LastNode.LastNode.LastNode.Nodes.Add(
                        GetCoordinateValueFromSplit(userCoordinate!.Coordinate, ApexPt));
                    if (!userParabolaPoints!.XApex.Equals(correctParabolaPoints!.XApex))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"x = {userParabolaPoints!.XApex}");
                    if (!userParabolaPoints!.YApex.Equals(correctParabolaPoints!.YApex))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"y = {userParabolaPoints!.YApex}");
                    if (!userParabolaPoints!.ZApex.Equals(correctParabolaPoints!.ZApex))
                        _errorNodes.LastNode.LastNode.LastNode.LastNode.Nodes.Add($"z = {userParabolaPoints!.ZApex}");
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="correct"></param>
    private static void MirrorComparer(IMirror user, IMirror correct)
    {
        if (user.Plane.Equals(correct.Plane))
        {
            ObjectNameIsTrue(_featureName, _correctNodes);
            _correctNodes.LastNode.Nodes.Add($"Плоскость: {user.Plane}");
        }
        else
        {
            ObjectNameIsTrue(_featureName, _errorNodes);
            _errorNodes.LastNode.Nodes.Add($"Плоскость: {user.Plane}");
        }
        if (user.FeatureNames.Count.Equals(correct.FeatureNames.Count))
        {
            ObjectNameIsTrue(_featureName, _correctNodes);
            _correctNodes.LastNode.Nodes.Add("Объекты");
            foreach (var name in user.FeatureNames)
                _correctNodes.LastNode.LastNode.Nodes.Add(name);
        }
        else
        {
            ObjectNameIsTrue(_featureName, _errorNodes);
            _errorNodes.LastNode.Nodes.Add("Объекты");
            foreach (var name in user.FeatureNames)
                _errorNodes.LastNode.LastNode.Nodes.Add(name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="node"></param>
    private static void ObjectNameIsTrue(string name, TreeNode node)
    {
        var nodeIsTrue = node.Nodes.Cast<TreeNode>().Any(nodeName => nodeName.Text.Equals(name));
        if (!nodeIsTrue)
        {
            node.Nodes.Add(name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="node"></param>
    private static void ObjectSketchNameIsTrue(string name, TreeNode node)
    {
        var nodeIsTrue = node.LastNode.Nodes.Cast<TreeNode>().Any(nodeName => nodeName.Text.Equals(name));
        if (!nodeIsTrue)
        {
            node.LastNode.Nodes.Add(name);
        }
    }
}