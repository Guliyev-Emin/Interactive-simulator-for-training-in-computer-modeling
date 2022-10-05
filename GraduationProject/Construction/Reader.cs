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
    private const short MetersToMillimeters = 1000;
    public static List<Sketch> Sketches;
    private static TreeNode _swProjectTree;
    private static bool _checkChild;
    private static string _topWord = string.Empty;
    private static string _frontWord = string.Empty;
    private static string _rightWord = string.Empty;
    private static Model _model;
    private static Feature _featureNode;
    private static List<Arc> _arcs;
    private static List<Line> _lines;
    private static List<UserPoint> _userPoints;
    private static List<Parabola> _parabolas;
    private static List<Ellipse> _ellipses;
    private static List<TridimensionalOperation> _features;
    private static List<Feature> _swFeatures;
    private static Face _faces;
    private static string _plane;
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Model GetModel() => _model;

    /// <summary>
    /// 
    /// </summary>
    private static void ModelInizialize()
    {
        _model = new Model();
        _features = new List<TridimensionalOperation>();
        _model.Name = GetModelName();
        _model.Features = _features;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="swProjectTree"></param>
    /// <returns></returns>
    public static bool GetProjectTree(ref TreeView swProjectTree)
    {
        if (!ConnectionTest())
            return false;
        swProjectTree.Nodes.Clear();
        swProjectTree.BeginUpdate();
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
    /// <returns>Возвращает узлы дерева проекта SolidWorks и свойства узлов</returns>
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
                    _featureNode = (Feature)nodeObject;
                    nodeType = _featureNode.GetTypeName();
                    nodeName = _featureNode.Name;
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
                        _swFeatures.Add(_featureNode);
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
    /// 
    /// </summary>
    /// <param name="swFeature"></param>
    /// <param name="sketch"></param>
    /// <param name="mirror"></param>
    /// <returns></returns>
    private static TridimensionalOperation FeatureListener(IFeature swFeature,
        [CanBeNull] Sketch sketch, [CanBeNull]Mirror mirror)
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

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат двухмерных объектов в эскизе
    /// </summary>
    /// <param name="sketchName">Название эскиза</param>
    private static void SketchListener(string sketchName)
    {
        var selectedSketch = (SolidWorks.Interop.sldworks.Sketch)_featureNode.GetSpecificFeature2();
        var parentFeature = _featureNode.GetOwnerFeature();
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
            var x = points[pointArrayLength * index + xPoint] * MetersToMillimeters;
            var y = points[pointArrayLength * index + yPoint] * MetersToMillimeters;
            var z = points[pointArrayLength * index + zPoint] * MetersToMillimeters;
            var pointCoordinate = "Координаты: x = " + x + ", y = " + y + ", z = " + z + ";";
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

        for (var index = 0; index < lineCount; index++)
        {
            _swProjectTree.LastNode.LastNode.Nodes.Add("Отрезок");
            var j = index;
            if (index == lineCount) continue;
            var lineStyle = (short)lineArrayInfo[lineArrayLength * index + lineStyleIndex];
            var xStart = lineArrayInfo[lineArrayLength * index + XStartIndex] * MetersToMillimeters;
            var yStart = lineArrayInfo[lineArrayLength * index + YStartIndex] * MetersToMillimeters;
            var zStart = lineArrayInfo[lineArrayLength * index + ZStartIndex] * MetersToMillimeters;
            var xEnd = lineArrayInfo[lineArrayLength * index + XEndIndex] * MetersToMillimeters;
            var yEnd = lineArrayInfo[lineArrayLength * index + YEndIndex] * MetersToMillimeters;
            var zEnd = lineArrayInfo[lineArrayLength * index + ZEndIndex] * MetersToMillimeters;
            var start = "Начало: x = " + xStart + ", y = " + yStart + ", z = " + zStart + ";";
            var end = "Конец: x = " + xEnd + ", y = " + yEnd + ", z = " + zEnd + ";";
            var sketchSegment = sketchSegments[j];
            while (sketchSegment.GetType() != (int)swSketchSegments_e.swSketchLINE)
            {
                j++;
                sketchSegment = sketchSegments[j];
            }

            var lineLength = sketchSegment.GetLength() * MetersToMillimeters;
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
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add("Длина: " + lineLength + " мм");
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add("Расположение: " + line.LineArrangement);
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
        for (var index = 0; index < arcCount; index++)
        {
            _swProjectTree.LastNode.LastNode.Nodes.Add("Дуга");
            var j = index;
            if (index == arcCount) continue;
            var xStart = arcs[arcArrayLength * index + XStartIndex] * MetersToMillimeters;
            var yStart = arcs[arcArrayLength * index + YStartIndex] * MetersToMillimeters;
            var zStart = arcs[arcArrayLength * index + ZStartIndex] * MetersToMillimeters;
            var xEnd = arcs[arcArrayLength * index + XEndIndex] * MetersToMillimeters;
            var yEnd = arcs[arcArrayLength * index + YEndIndex] * MetersToMillimeters;
            var zEnd = arcs[arcArrayLength * index + ZEndIndex] * MetersToMillimeters;
            var xCenter = arcs[arcArrayLength * index + XCenterIndex] * MetersToMillimeters;
            var yCenter = arcs[arcArrayLength * index + YCenterIndex] * MetersToMillimeters;
            var zCenter = arcs[arcArrayLength * index + ZCenterIndex] * MetersToMillimeters;
            var direction = (short)arcs[arcArrayLength * index + directionIndex];
            var start = "Начало: x = " + xStart + ", y = " + yStart + ", z = " + zStart + ";";
            var end = "Конец: x = " + xEnd + ", y = " + yEnd + ", z = " + zEnd + ";";
            var center = "Центр: x = " + xCenter + ", y = " + yCenter + ", z = " + zCenter + ";";
            var sketchSegment = sketchSegments[j];
            while (sketchSegment.GetType() != (int)swSketchSegments_e.swSketchARC)
            {
                j++;
                sketchSegment = sketchSegments[j];
            }

            // ReSharper disable once SuspiciousTypeConversion.Global
            var arcSketch = (SketchArc)sketchSegment;
            var radius = arcSketch.GetRadius() * MetersToMillimeters;
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
            _swProjectTree.LastNode.LastNode.LastNode.Nodes.Add("Радиус: " + radius + " мм");
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
            var xStart = parabolas[parabolaArrayLength * index + XStartIndex] * MetersToMillimeters;
            var yStart = parabolas[parabolaArrayLength * index + YStartIndex] * MetersToMillimeters;
            var zStart = parabolas[parabolaArrayLength * index + ZStartIndex] * MetersToMillimeters;
            var xEnd = parabolas[parabolaArrayLength * index + XEndIndex] * MetersToMillimeters;
            var yEnd = parabolas[parabolaArrayLength * index + YEndIndex] * MetersToMillimeters;
            var zEnd = parabolas[parabolaArrayLength * index + ZEndIndex] * MetersToMillimeters;
            var xFocus = parabolas[parabolaArrayLength * index + xFocusIndex] * MetersToMillimeters;
            var yFocus = parabolas[parabolaArrayLength * index + yFocusIndex] * MetersToMillimeters;
            var zFocus = parabolas[parabolaArrayLength * index + zFocusIndex] * MetersToMillimeters;
            var xApex = parabolas[parabolaArrayLength * index + xApexIndex] * MetersToMillimeters;
            var yApex = parabolas[parabolaArrayLength * index + yApexIndex] * MetersToMillimeters;
            var zApex = parabolas[parabolaArrayLength * index + zApexIndex] * MetersToMillimeters;
            var start = "Начало: x = " + xStart + ", y = " + yStart + ", z = " + zStart + ";";
            var end = "Конец: x = " + xEnd + ", y = " + yEnd + ", z = " + zEnd + ";";
            var focusPoint = "Фокусная точка: x = " + xFocus + ", y = " + yFocus + ", z = " + zFocus + ";";
            var apexPoint = "Точка вершины: x = " + xApex + ", y = " + yApex + ", z = " + zApex + ";";
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
            var xStart = ellipses[ellipseArrayLength * index + XStartIndex] * MetersToMillimeters;
            var yStart = ellipses[ellipseArrayLength * index + YStartIndex] * MetersToMillimeters;
            var zStart = ellipses[ellipseArrayLength * index + ZStartIndex] * MetersToMillimeters;
            var xEnd = ellipses[ellipseArrayLength * index + XEndIndex] * MetersToMillimeters;
            var yEnd = ellipses[ellipseArrayLength * index + YEndIndex] * MetersToMillimeters;
            var zEnd = ellipses[ellipseArrayLength * index + ZEndIndex] * MetersToMillimeters;
            var xCenter = ellipses[ellipseArrayLength * index + XCenterIndex] * MetersToMillimeters;
            var yCenter = ellipses[ellipseArrayLength * index + YCenterIndex] * MetersToMillimeters;
            var zCenter = ellipses[ellipseArrayLength * index + ZCenterIndex] * MetersToMillimeters;
            var xMajor = ellipses[ellipseArrayLength * index + xMajorIndex] * MetersToMillimeters;
            var yMajor = ellipses[ellipseArrayLength * index + yMajorIndex] * MetersToMillimeters;
            var zMajor = ellipses[ellipseArrayLength * index + zMajorIndex] * MetersToMillimeters;
            var xMinor = ellipses[ellipseArrayLength * index + xMinorIndex] * MetersToMillimeters;
            var yMinor = ellipses[ellipseArrayLength * index + yMinorIndex] * MetersToMillimeters;
            var zMinor = ellipses[ellipseArrayLength * index + zMinorIndex] * MetersToMillimeters;
            var start = "Начало: x = " + xStart + ", y = " + yStart + ", z = " + zStart + ";";
            var end = "Конец: x = " + xEnd + ", y = " + yEnd + ", z = " + zEnd + ";";
            var center = "Центр: x = " + xCenter + ", y = " + yCenter + ", z = " + zCenter + ";";
            var majorPoint = "Точка на большой оси: x = " + xMajor + ", y = " + yMajor + ", z = " + zMajor + ";";
            var minorPoint = "Точка на малой оси: x = " + xMinor + ", y = " + yMinor + ", z = " + zMinor + ";";
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
        _swProjectTree.LastNode.Nodes.Insert(0, @$"{operation}: {depth}" + @" мм");
        return depth;
    }

    /// <summary>
    ///     Процедура чтения выдавливания трехмерных объектов
    /// </summary>
    /// <param name="feature"></param>
    /// <returns>Глубину выдавливания для обычных трехмерных объектов</returns>
    private static double GetExtrusionThickness(IFeature feature)
    {
        var extrudeData = (ExtrudeFeatureData2)feature.GetDefinition();
        var depth = extrudeData.GetDepth(!extrudeData.ReverseDirection) * MetersToMillimeters;
        return extrudeData.BothDirections ? depth * 2.0 : depth;
    }

    /// <summary>
    ///     Функция чтения глубины ребра
    /// </summary>
    /// <param name="feature"></param>
    /// <returns>Глубина выдавливания</returns>
    private static double GetRibThickness(IFeature feature)
    {
        var swRibFeat = (RibFeatureData2)feature.GetDefinition();
        var thickness = swRibFeat.Thickness * MetersToMillimeters;
        return swRibFeat.IsTwoSided ? thickness * 2.0 : thickness;
    }

    /// <summary>
    ///     Процедура для чтения зеркального отражения
    /// </summary>
    /// <param name="feature"></param>
    private static void MirrorListener(IFeature feature)
    {
        const byte planeType = 1;
        var mirror = new Mirror
        {
            FeatureNames = new List<string>(),
            Name = feature.Name
        };
        var mirrorData = (IMirrorPatternFeatureData)feature.GetDefinition();
        var patternArray = (object[])mirrorData.PatternFeatureArray;

        mirrorData.AccessSelections(SwModel, null);

        if (mirrorData.GetMirrorPlaneType().Equals(planeType))
        {
            var swFeature = (Feature)mirrorData.Plane;
            mirror.Plane = swFeature.Name;
        }

        foreach (Feature pattern in patternArray)
            mirror.FeatureNames.Add(pattern.Name);

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


    // TODO ТЕСТОВЫЕ МЕТОДЫ, ТРЕБУЮЩИЕ ДАЛЬНЕЙШЕЙ РАЗРАБОТКИ

    /// <summary>
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
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
    /// <param name="sketch"></param>
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
    /// <param name="feature"></param>
    private static void FilletListener(IFeature feature)
    {
        var swFillet = (SimpleFilletFeatureData2)feature.GetDefinition();
        var radius = swFillet.DefaultRadius * MetersToMillimeters;
        
        // swFillet.AccessSelections(SwModel, null);
        //
        // swFillet.ReleaseSelectionAccess();
    }
}