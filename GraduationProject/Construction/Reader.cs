using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraduationProject.Controllers;
using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.SketchObjects;
using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using Face = GraduationProject.ModelObjects.Objects.SketchObjects.Face;
using Sketch = GraduationProject.ModelObjects.Objects.SketchObjects.Sketch;

namespace GraduationProject.Construction;

[UsedImplicitly]
public class Reader : Connection
{
    private const byte XStartIndex = 6;
    private const byte YStartIndex = 7;
    private const byte ZStartIndex = 8;
    private const byte XEndIndex = 9;
    private const byte YEndIndex = 10;
    private const byte ZEndIndex = 11;
    private const byte XCenterIndex = 12;
    private const byte YCenterIndex = 13;
    private const byte ZCenterIndex = 14;
    private static TreeNode _swProjectTree;
    private static string _units;
    private static Model _model;
    private static List<TridimensionalOperation> _features;
    private static List<Feature> _swFeatures;
    private static Feature _swFeature;
    public static List<Sketch> Sketches;
    private static Face _faces;
    private static List<UserPoint> _userPoints;
    private static List<Line> _lines;
    private static List<Arc> _arcs;
    private static List<Parabola> _parabolas;
    private static List<Ellipse> _ellipses;
    private static bool _checkChild;
    private static string _plane;
    private static string _topWord = string.Empty;
    private static string _frontWord = string.Empty;
    private static string _rightWord = string.Empty;

    /// <summary>
    ///     Функция возвращающая параметры модель
    /// </summary>
    /// <returns>Объекта класса модель</returns>
    public static Model GetModel()
    {
        return _model;
    }

    /// <summary>
    ///     Процедура инициализации модели
    /// </summary>
    private static void ModelInizialize()
    {
        _model = new Model();
        _features = new List<TridimensionalOperation>();
        _model.Name = GetModelName();
        _model.Features = _features;
    }

    /// <summary>
    ///     Функция по чтению документа SolidWorks
    /// </summary>
    /// <param name="swProjectTree">Ссылочный объект TreeView</param>
    /// <returns>Возвращает булевское значение выполненной работы</returns>
    public static bool GetProjectTree(ref TreeView swProjectTree)
    {
        if (!ConnectionTest())
            return false;
        swProjectTree.Nodes.Clear();
        swProjectTree.BeginUpdate();
        GetUnits();
        _swProjectTree = new TreeNode("Дерево проекта");
        _features = new List<TridimensionalOperation>();
        Sketches = new List<Sketch>();
        ModelInizialize();
        PlaneWordInitialize();
        _swFeatures = new List<Feature>();
        var nodes = ProjectReading(SwFeatureManager.GetFeatureTreeRootItem2((int)swFeatMgrPane_e.swFeatMgrPaneBottom));
        if (_swFeatures.Count != 0)
            SwitchMirrorAndFilletInformation();
        nodes.Expand();
        swProjectTree.Nodes.Add(nodes);
        swProjectTree.EndUpdate();
        return true;
    }

    /// <summary>
    ///     Функция по нахождению узлов в проекте SolidWorks
    /// </summary>
    /// <param name="rootNode">Узел</param>
    /// <returns>Узлы дерева проекта SolidWorks и свойства узлов</returns>
    private static TreeNode ProjectReading(ITreeControlItem rootNode)
    {
        var nodeObjectType = rootNode.ObjectType;
        var nodeObject = rootNode.Object;
        var nodeType = "";
        var nodeName = "";
        if (nodeObject != null)
        {
            switch (nodeObjectType)
            {
                case (int)swTreeControlItemType_e.swFeatureManagerItem_Feature:
                    _swFeature = (Feature)nodeObject;
                    nodeType = _swFeature.GetTypeName();
                    nodeName = _swFeature.Name;
                    break;
            }

            if (_checkChild & !nodeType.Equals("DetailCabinet") & !nodeType.Equals("MaterialFolder") &
                !nodeType.Equals("HistoryFolder") & !nodeType.Equals("SensorFolder"))
                _swProjectTree.LastNode.Nodes.Add(nodeName);
            else
                switch (nodeType)
                {
                    case "MirrorPattern" or "Fillet":
                        _swProjectTree.Nodes.Add(nodeName);
                        _swFeatures.Add(_swFeature);
                        break;
                    default:
                        _swProjectTree.Nodes.Add(nodeName);
                        break;
                }

            if (nodeType.Equals("ProfileFeature"))
                SketchListener(nodeName);
            rootNode.Expanded = false;
        }

        var childNode = rootNode.GetFirstChild();
        _checkChild = childNode != null;
        while (childNode != null && !nodeType.Equals("HistoryFolder") && !nodeType.Equals("DetailCabinet"))
        {
            ProjectReading(childNode);
            childNode = childNode.GetNext();
        }

        return _swProjectTree;
    }

    /// <summary>
    ///     Функция для инициализации трехмерных операций
    /// </summary>
    /// <param name="swFeature">Объект IFeature</param>
    /// <param name="sketch">Эскиз с параметрами, может быть пустым</param>
    /// <param name="mirror">Объект Mirror, может быть пустым</param>
    /// <returns>Объект с информацией о трехмерной операцией</returns>
    private static TridimensionalOperation FeatureListener(IFeature swFeature,
        [CanBeNull] Sketch sketch, [CanBeNull] Mirror mirror)
    {
        var feature = new TridimensionalOperation
        {
            Name = swFeature.Name,
            Type = swFeature.GetTypeName(),
            Sketch = sketch,
            Mirror = mirror
        };
        switch (feature.Type)
        {
            case "MirrorPattern" or "Fillet":
                break;
            default:
                feature.Depth = DepthListener(swFeature);
                break;
        }

        return feature;
    }

    private static void GetUnits()
    {
        _units = SwModel.LengthUnit switch
        {
            (int)swLengthUnit_e.swMM => "мм",
            (int)swLengthUnit_e.swCM => "см",
            (int)swLengthUnit_e.swMETER => "м",
            _ => _units
        };
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат двухмерных объектов в эскизе
    /// </summary>
    /// <param name="sketchName">Название эскиза</param>
    private static void SketchListener(string sketchName)
    {
        var selectedSketch = (SolidWorks.Interop.sldworks.Sketch)_swFeature.GetSpecificFeature2();
        var parentFeature = _swFeature.GetOwnerFeature();
        var lineCount = selectedSketch.GetLineCount();
        var arcCount = selectedSketch.GetArcCount();
        var ellipseCount = selectedSketch.GetEllipseCount();
        var parabolaCount = selectedSketch.GetParabolaCount();
        var pointCount = selectedSketch.GetUserPointsCount();
        _arcs = new List<Arc>();
        _lines = new List<Line>();
        _userPoints = new List<UserPoint>();
        _parabolas = new List<Parabola>();
        _ellipses = new List<Ellipse>();
        _plane = null;
        _faces = null;
        var nEntType = 0;
        var entity = selectedSketch.GetReferenceEntity(ref nEntType);
        switch (nEntType)
        {
            case (int)swSelectType_e.swSelDATUMPLANES:
                _plane = GetPlane(selectedSketch);
                break;
            case (int)swSelectType_e.swSelFACES:
                _faces = GetFace((Entity)entity);
                break;
        }

        if (lineCount != 0)
            LineListener(selectedSketch, lineCount);

        if (ellipseCount != 0)
            EllipseListener(selectedSketch, ellipseCount);

        if (arcCount != 0)
            ArcListener(selectedSketch, arcCount);

        if (parabolaCount != 0)
            ParabolaListener(selectedSketch, parabolaCount);

        if (pointCount != 0)
            PointListener(selectedSketch, pointCount);

        var sketch = new Sketch
        {
            SketchName = sketchName, Plane = _plane, Face = _faces, Arcs = _arcs, Lines = _lines,
            UserPoints = _userPoints, Ellipses = _ellipses, Parabolas = _parabolas
        };
        Sketches.Add(sketch);
        _features.Add(FeatureListener(parentFeature, sketch, null));
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат точек
    /// </summary>
    /// <param name="sketch">Объект типа Sketch</param>
    /// <param name="pointCount">Количество точек в эскизе</param>
    private static void PointListener(ISketch sketch, int pointCount)
    {
        const byte pointArrayLength = 16;
        const byte xPoint = 5;
        const byte yPoint = 6;
        const byte zPoint = 7;

        var points = GetObjectsDoubleArrayInformation(sketch.GetUserPoints2());
        if (points is null) return;
        for (var index = 0; index < pointCount; index++)
        {
            _swProjectTree.LastNode.LastNode.Nodes.Add("Точка");
            if (index == pointCount) continue;
            var x = points[pointArrayLength * index + xPoint];
            var y = points[pointArrayLength * index + yPoint];
            var z = points[pointArrayLength * index + zPoint];
            var pointCoordinate = $"Координаты: x = {x}, y = {y}, z = {z};";
            var point = new UserPoint
            {
                X = x,
                Y = y,
                Z = z,
                Coordinate = pointCoordinate
            };
            _userPoints.Add(point);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(pointCoordinate);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальной и конечной точек отрезка
    /// </summary>
    /// <param name="sketch">Объект типа Sketch</param>
    /// <param name="lineCount">Количество линий в эскизе</param>
    private static void LineListener(ISketch sketch, int lineCount)
    {
        const byte lineArrayLength = 12;
        const byte lineStyleIndex = 2;
        var lineArrayInfo = GetObjectsDoubleArrayInformation(sketch.GetLines2(4));
        if (lineArrayInfo is null) return;

        var vSketchSeg = sketch.GetSketchSegments();
        var sketchSegEnum = (IEnumerable)vSketchSeg;
        var sketchSegments = sketchSegEnum.Cast<SketchSegment>().ToArray();
        var j = 0;
        for (var index = 0; index < lineCount; index++)
        {
            _swProjectTree.LastNode.LastNode.Nodes.Add("Отрезок");

            if (index == lineCount) continue;
            var lineStyle = (short)lineArrayInfo[lineArrayLength * index + lineStyleIndex];
            var xStart = lineArrayInfo[lineArrayLength * index + XStartIndex];
            var yStart = lineArrayInfo[lineArrayLength * index + YStartIndex];
            var zStart = lineArrayInfo[lineArrayLength * index + ZStartIndex];
            var xEnd = lineArrayInfo[lineArrayLength * index + XEndIndex];
            var yEnd = lineArrayInfo[lineArrayLength * index + YEndIndex];
            var zEnd = lineArrayInfo[lineArrayLength * index + ZEndIndex];
            var start = $"Начало: x = {xStart}, y = {yStart}, z = {zStart};";
            var end = $"Конец: x = {xEnd}, y = {yEnd}, z = {zEnd};";
            var sketchSegment = sketchSegments[j];
            while (sketchSegment.GetType() != (int)swSketchSegments_e.swSketchLINE)
            {
                j++;
                sketchSegment = sketchSegments[j];
            }

            j++;
            var lineLength = sketchSegment.GetLength();
            var line = new Line
            {
                LineLength = lineLength,
                LineType = lineStyle,
                XStart = xStart,
                YStart = yStart,
                ZStart = zStart,
                XEnd = xEnd,
                YEnd = yEnd,
                ZEnd = zEnd,
                Coordinate = start + "\n" + end
            };
            line.LineArrangement = Controller.GetLineArrangement(line);
            _lines.Add(line);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add($"Длина: {lineLength} {_units}");
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add($"Расположение: {line.LineArrangement}");
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальных, конечных и центральных точек дуг.
    /// </summary>
    /// <param name="sketch">Объект типа Sketch.</param>
    /// <param name="arcCount">Количество дуг в эскизе.</param>
    private static void ArcListener(ISketch sketch, int arcCount)
    {
        const byte arcArrayLength = 16;
        const byte directionIndex = 15;
        var arcs = GetObjectsDoubleArrayInformation(sketch.GetArcs2());
        var vSketchSeg = sketch.GetSketchSegments();
        var sketchSegEnum = (IEnumerable)vSketchSeg;
        var sketchSegments = sketchSegEnum.Cast<SketchSegment>().ToArray();
        var j = 0;
        for (var index = 0; index < arcCount; index++)
        {
            _swProjectTree.LastNode.LastNode.Nodes.Add("Дуга");
            if (index == arcCount) continue;
            var xStart = arcs[arcArrayLength * index + XStartIndex];
            var yStart = arcs[arcArrayLength * index + YStartIndex];
            var zStart = arcs[arcArrayLength * index + ZStartIndex];
            var xEnd = arcs[arcArrayLength * index + XEndIndex];
            var yEnd = arcs[arcArrayLength * index + YEndIndex];
            var zEnd = arcs[arcArrayLength * index + ZEndIndex];
            var xCenter = arcs[arcArrayLength * index + XCenterIndex];
            var yCenter = arcs[arcArrayLength * index + YCenterIndex];
            var zCenter = arcs[arcArrayLength * index + ZCenterIndex];
            var direction = (short)arcs[arcArrayLength * index + directionIndex];
            var start = $"Начало: x = {xStart}, y = {yStart}, z = {zStart};";
            var end = $"Конец: x = {xEnd}, y = {yEnd}, z = {zEnd};";
            var center = $"Центр: x = {xCenter}, y = {yCenter}, z = {zCenter};";
            var sketchSegment = sketchSegments[j];
            while (sketchSegment.GetType() != (int)swSketchSegments_e.swSketchARC)
            {
                j++;
                sketchSegment = sketchSegments[j];
            }

            j++;
            // ReSharper disable once SuspiciousTypeConversion.Global
            var arcSketch = (SketchArc)sketchSegment;
            var radius = arcSketch.GetRadius();
            var arc = new Arc
            {
                XStart = xStart,
                YStart = yStart,
                ZStart = zStart,
                XEnd = xEnd,
                YEnd = yEnd,
                ZEnd = zEnd,
                XCenter = xCenter,
                YCenter = yCenter,
                ZCenter = zCenter,
                Direction = direction,
                ArcRadius = radius,
                Coordinate = start + "\n" + end + "\n" + center
            };
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(center);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add($"Радиус: {radius} {_units}");
            _arcs.Add(arc);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальных, конечных, фокусных и вершин точек параболы
    /// </summary>
    /// <param name="sketch">Объект типа Sketch</param>
    /// <param name="parabolaCount">Количество параболов в эскизе</param>
    private static void ParabolaListener(ISketch sketch, int parabolaCount)
    {
        const byte parabolaArrayLength = 18;
        const byte xFocusIndex = 12;
        const byte yFocusIndex = 13;
        const byte zFocusIndex = 14;
        const byte xApexIndex = 15;
        const byte yApexIndex = 16;
        const byte zApexIndex = 17;
        var parabolas = GetObjectsDoubleArrayInformation(sketch.GetParabolas2());
        if (parabolas is null) return;
        for (var index = 0; index < parabolaCount; index++)
        {
            _swProjectTree.LastNode.LastNode.Nodes.Add("Парабола");
            if (index == parabolaCount) continue;
            var xStart = parabolas[parabolaArrayLength * index + XStartIndex];
            var yStart = parabolas[parabolaArrayLength * index + YStartIndex];
            var zStart = parabolas[parabolaArrayLength * index + ZStartIndex];
            var xEnd = parabolas[parabolaArrayLength * index + XEndIndex];
            var yEnd = parabolas[parabolaArrayLength * index + YEndIndex];
            var zEnd = parabolas[parabolaArrayLength * index + ZEndIndex];
            var xFocus = parabolas[parabolaArrayLength * index + xFocusIndex];
            var yFocus = parabolas[parabolaArrayLength * index + yFocusIndex];
            var zFocus = parabolas[parabolaArrayLength * index + zFocusIndex];
            var xApex = parabolas[parabolaArrayLength * index + xApexIndex];
            var yApex = parabolas[parabolaArrayLength * index + yApexIndex];
            var zApex = parabolas[parabolaArrayLength * index + zApexIndex];
            var start = $"Начало: x = {xStart}, y = {yStart}, z = {zStart};";
            var end = $"Конец: x = {xEnd}, y = {yEnd}, z = {zEnd};";
            var focusPoint = $"Фокусная точка: x = {xFocus}, y = {yFocus}, z = {zFocus};";
            var apexPoint = $"Точка вершины: x = {xApex}, y = {yApex}, z = {zApex};";
            var parabola = new Parabola
            {
                XStart = xStart,
                YStart = yStart,
                ZStart = zStart,
                XEnd = xEnd,
                YEnd = yEnd,
                ZEnd = zEnd,
                XFocus = xFocus,
                YFocus = yFocus,
                ZFocus = zFocus,
                XApex = xApex,
                YApex = yApex,
                ZApex = zApex,
                Coordinate = start + "\n" + end + "\n" + focusPoint + "\n" + apexPoint
            };
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(focusPoint);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(apexPoint);
            _parabolas.Add(parabola);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальной, конечной, центральной,
    ///     на большой оси X и на малой оси X точек эллипса
    /// </summary>
    /// <param name="sketch">Объект типа Sketch</param>
    /// <param name="ellipseCount">Количество эллипсов в эскизе</param>
    private static void EllipseListener(ISketch sketch, int ellipseCount)
    {
        const byte ellipseArrayLength = 16;
        const byte xMajorIndex = 15;
        const byte yMajorIndex = 16;
        const byte zMajorIndex = 17;
        const byte xMinorIndex = 18;
        const byte yMinorIndex = 19;
        const byte zMinorIndex = 20;
        var ellipses = GetObjectsDoubleArrayInformation(sketch.GetEllipses3());
        if (ellipses is null) return;
        for (var index = 0; index < ellipseCount; index++)
        {
            _swProjectTree.LastNode.LastNode.Nodes.Add("Эллипс");
            if (index == ellipseCount) continue;
            var xStart = ellipses[ellipseArrayLength * index + XStartIndex];
            var yStart = ellipses[ellipseArrayLength * index + YStartIndex];
            var zStart = ellipses[ellipseArrayLength * index + ZStartIndex];
            var xEnd = ellipses[ellipseArrayLength * index + XEndIndex];
            var yEnd = ellipses[ellipseArrayLength * index + YEndIndex];
            var zEnd = ellipses[ellipseArrayLength * index + ZEndIndex];
            var xCenter = ellipses[ellipseArrayLength * index + XCenterIndex];
            var yCenter = ellipses[ellipseArrayLength * index + YCenterIndex];
            var zCenter = ellipses[ellipseArrayLength * index + ZCenterIndex];
            var xMajor = ellipses[ellipseArrayLength * index + xMajorIndex];
            var yMajor = ellipses[ellipseArrayLength * index + yMajorIndex];
            var zMajor = ellipses[ellipseArrayLength * index + zMajorIndex];
            var xMinor = ellipses[ellipseArrayLength * index + xMinorIndex];
            var yMinor = ellipses[ellipseArrayLength * index + yMinorIndex];
            var zMinor = ellipses[ellipseArrayLength * index + zMinorIndex];
            var start = $"Начало: x = {xStart}, y = {yStart}, z = {zStart};";
            var end = $"Конец: x = {xEnd}, y = {yEnd}, z = {zEnd};";
            var center = $"Центр: x = {xCenter}, y = {yCenter}, z = {zCenter};";
            var majorPoint = $"Точка на большой оси: x = {xMajor}, y = {yMajor}, z = {zMajor};";
            var minorPoint = $"Точка на малой оси: x = {xMinor}, y = {yMinor}, z = {zMinor};";
            var ellipse = new Ellipse
            {
                XStart = xStart,
                YStart = yStart,
                ZStart = zStart,
                XEnd = xEnd,
                YEnd = yEnd,
                ZEnd = zEnd,
                XCenter = xCenter,
                YCenter = yCenter,
                ZCenter = zCenter,
                XMajor = xMajor,
                YMajor = yMajor,
                ZMajor = zMajor,
                Coordinate = start + "\n" + end + "\n" + center + "\n" + majorPoint + "\n" + minorPoint
            };
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(center);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(majorPoint);
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add(minorPoint);
            _ellipses.Add(ellipse);
        }
    }

    private static double GetDepth(IFeature feature)
    {
        return feature.GetTypeName().Equals("Rib") ? GetRibThickness(feature) : GetExtrusionThickness(feature);
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения выдавливания эскиза
    /// </summary>
    /// <param name="feature">Объект типа IFeature</param>
    /// <returns>Глубина выдавливания</returns>
    private static double DepthListener(IFeature feature)
    {
        var depth = GetDepth(feature);
        var operation = feature.GetTypeName().Equals("Cut") ? "Вырез" : "Выдавливание";
        _swProjectTree.LastNode.Nodes.Insert(0, $"{operation}: {depth} {_units}");
        return depth;
    }

    /// <summary>
    ///     Процедура чтения выдавливания трехмерных объектов
    /// </summary>
    /// <param name="feature">Объект типа IFeature</param>
    /// <returns>Глубину выдавливания для обычных трехмерных объектов</returns>
    private static double GetExtrusionThickness(IFeature feature)
    {
        var extrudeData = (ExtrudeFeatureData2)feature.GetDefinition();
        var depth = extrudeData.GetDepth(!extrudeData.ReverseDirection);
        return extrudeData.BothDirections ? depth * 2.0 : depth;
    }

    /// <summary>
    ///     Функция чтения глубины ребра
    /// </summary>
    /// <param name="feature">Объект типа IFeature</param>
    /// <returns>Глубина выдавливания ребра</returns>
    private static double GetRibThickness(IFeature feature)
    {
        var swRibFeat = (RibFeatureData2)feature.GetDefinition();
        var thickness = swRibFeat.Thickness;
        return swRibFeat.IsTwoSided ? thickness * 2.0 : thickness;
    }

    /// <summary>
    ///     Процедура для чтения зеркального отражения
    /// </summary>
    /// <param name="feature">Объект типа IFeature</param>
    private static void MirrorListener(IFeature feature)
    {
        const byte planeType = 1;
        var mirror = new Mirror
        {
            FeatureNames = new List<string>(),
            Name = feature.Name
        };
        var mirrorData = (IMirrorPatternFeatureData)feature.GetDefinition();

        mirrorData.AccessSelections(SwModel, null);
        var patternArray = (object[])mirrorData.PatternFeatureArray;
        if (mirrorData.GetMirrorPlaneType().Equals(planeType))
        {
            var swFeature = (Feature)mirrorData.Plane;
            mirror.Plane = swFeature.Name;
        }

        var index = -1;
        foreach (TreeNode node in _swProjectTree.Nodes)
        {
            index++;
            if (node.Text.Equals(feature.Name))
                break;
        }

        _swProjectTree.Nodes[index].Nodes.Add($"Плоскость: {mirror.Plane}");
        _swProjectTree.Nodes[index].Nodes.Add("Объекты");

        foreach (Feature pattern in patternArray)
        {
            mirror.FeatureNames.Add(pattern.Name);
            _swProjectTree.Nodes[index].LastNode.Nodes.Add(pattern.Name);
        }

        mirrorData.ReleaseSelectionAccess();

        _features.Add(FeatureListener(feature, null, mirror));
    }

    /// <summary>
    /// </summary>
    /// <param name="object"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static double[] GetObjectsDoubleArrayInformation<T>(T @object)
    {
        return @object is not IEnumerable objectEnumerable ? null : objectEnumerable.Cast<double>().ToArray();
    }

    /// <summary>
    ///     Процедура по нахождению зеркальных и скругления объектов
    /// </summary>
    private static void SwitchMirrorAndFilletInformation()
    {
        foreach (var swFeature in _swFeatures)
            switch (swFeature.GetTypeName2())
            {
                case "MirrorPattern":
                    MirrorListener(swFeature);
                    break;
                case "Fillet":
                    FilletListener(swFeature);
                    break;
                default:
                    continue;
            }
    }

    /// <summary>
    ///     Инициализация плоскостей с учетом языка меню SolidWorks
    /// </summary>
    private static void PlaneWordInitialize()
    {
        switch (SwApp.GetCurrentLanguage())
        {
            case "russian":
                _topWord = "Сверху";
                _frontWord = "Спереди";
                _rightWord = "Справа";
                break;
            case "english":
                _topWord = "Top Plane";
                _frontWord = "Front Plane";
                _rightWord = "Right Plane";
                break;
        }
    }

    /// <summary>
    ///     Функция определения грани эскиза
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Объект пользовательского типа Face с именем трехмерного объекта и нормалью</returns>
    private static Face GetFace(Entity entity)
    {
        var sketchFace = entity as Face2;
        var feature = (Feature)sketchFace?.GetFeature()!;
        var sketchFaceNormal = (double[])sketchFace!.Normal;
        return new Face
        {
            FeatureName = feature.Name,
            I = sketchFaceNormal[0],
            J = sketchFaceNormal[1],
            K = sketchFaceNormal[2]
        };
    }

    /// <summary>
    ///     Процедура для определения плоскости
    /// </summary>
    /// <param name="sketch">Объект типа ISketch</param>
    /// <returns>Наименование плоскости</returns>
    private static string GetPlane(ISketch sketch)
    {
        var transformationMatrix = sketch.ModelToSketchTransform;
        var transformationMatrixData = (double[])transformationMatrix.ArrayData;
        var topPlaneMatrixData = new double[] { 1, 0, 0, 0, 0, 1, 0, -1, 0, 0, 0, 0, 1, 0, 0, 0 };
        var frontPlaneMatrixData = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 };
        var rightPlaneMatrixData = new double[] { 0, 0, 1, 0, 1, 0, -1, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
        if (transformationMatrixData.SequenceEqual(topPlaneMatrixData))
            return _topWord;
        if (transformationMatrixData.SequenceEqual(frontPlaneMatrixData))
            return _frontWord;
        if (transformationMatrixData.SequenceEqual(rightPlaneMatrixData))
            return _rightWord;
        return null;
    }

    /// <summary>
    ///     Тестовая процедура чтения типов объектов скругливания
    /// </summary>
    /// <param name="feature">Объект типа IFeature</param>
    private static void FilletListener(IFeature feature)
    {
        var swFillet = (SimpleFilletFeatureData2)feature.GetDefinition();

        var radius = swFillet.DefaultRadius;
        swFillet.AccessSelections(SwModel, null);

        swFillet.ReleaseSelectionAccess();
    }
}