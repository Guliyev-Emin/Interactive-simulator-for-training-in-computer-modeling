using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationProject.Controllers;
using GraduationProject.Model.Models;
using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using Environment = System.Environment;

namespace GraduationProject.Construction;

[UsedImplicitly]
public class Reader : Connection
{
    public static List<SketchInfo> SketchInfos;
    public static TreeNode SolidWorksProjectTree;
    private static bool _check;
    private static double _depth;
    private static Feature _featureNode;
    private static List<Arc> _arcs;
    private static List<Line> _lines;
    private static List<UserPoint> _userPoints;
    private static List<Parabola> _parabolas;
    private static List<Ellipse> _ellipses;
    

    /// <summary>
    ///     Функция по нахождению узлов в проекте SolidWorks.
    /// </summary>
    /// <param name="rootNode">Узел</param>
    /// <returns>Возвращает узлы дерева проекта SolidWorks и свойства узлов.</returns>
    public static TreeNode ProjectReading(TreeControlItem rootNode)
    {
        var nodeObjectType = rootNode.ObjectType;
        var nodeObject = rootNode.Object;
        var nodeType = "";
        var nodeName = "";
        //l = 
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
            
            if (_check & !nodeType.Equals("DetailCabinet") & !nodeType.Equals("MaterialFolder") &
                !nodeType.Equals("HistoryFolder") & !nodeType.Equals("SensorFolder"))
                SolidWorksProjectTree.LastNode.Nodes.Add(nodeName);
            else
                switch (nodeType)
                {
                    // case "MirrorPattern":
                    //     MirrorListener(_featureNode);
                    //     break;
                    // case "Fillet":
                    //     FilletListener(_featureNode);
                    //     break;
                    default:
                        SolidWorksProjectTree.Nodes.Add(nodeName);
                        break;
                }
            
            if (nodeType.Equals("ProfileFeature"))
                SketchListener(nodeName);
            rootNode.Expanded = false;
        }

        var childNode = rootNode.GetFirstChild();
        _check = childNode != null;
        while (childNode != null && !nodeType.Equals("HistoryFolder") && !nodeType.Equals("DetailCabinet"))
        {
            ProjectReading(childNode);
            childNode = childNode.GetNext();
        }

        return SolidWorksProjectTree;
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат двухмерных объектов в эскизе.
    /// </summary>
    /// <param name="sketch">Название эскиза.</param>
    private static void SketchListener(string sketch)
    {
        var selectedSketch = (Sketch)_featureNode.GetSpecificFeature2();
        var feature = _featureNode.GetOwnerFeature();
        var lineCount = selectedSketch.GetLineCount();
        var arcCount = selectedSketch.GetArcCount();
        var ellipseCount = selectedSketch.GetEllipseCount();
        var parabolaCount = selectedSketch.GetParabolaCount();
        var pointCount = selectedSketch.GetUserPointsCount();
        _depth = DepthListener(feature);
        _arcs = new List<Arc>();
        _lines = new List<Line>();
        _userPoints = new List<UserPoint>();
        _parabolas = new List<Parabola>();
        _ellipses = new List<Ellipse>();

        GetPlanesAndFaces(selectedSketch);

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

        SketchInfos.Add(new SketchInfo
        {
            SketchName = sketch, Depth = _depth, Arcs = _arcs, Lines = _lines,
            UserPoints = _userPoints, Ellipses = _ellipses, Parabolas = _parabolas
        });
    }
    
    /// <summary>
    ///     Процедура позволяющая извлекать значения выдавливания эскиза.
    /// </summary>
    /// <param name="feature">Объект типа IFeature</param>
    /// <returns>Глубина выдавливания</returns>
    private static double DepthListener(IFeature feature)
    {
        var depth = feature.GetTypeName().Equals("Rib") ? GetRibThickness(feature) : GetExtrusionThickness(feature);
        var operation = feature.GetTypeName().Equals("Cut") ? "Вырез" : "Выдавливание";

        SolidWorksProjectTree.LastNode.Nodes.Insert(0, @$"{operation}: {depth}" + @" мм");
        return depth;
    }

    /// <summary>
    /// Процедура чтения выдавливания трехмерных объектов
    /// </summary>
    /// <param name="feature"></param>
    /// <returns>Глубину выдавливания для обычных трехмерных объектов</returns>
    private static double GetExtrusionThickness(IFeature feature)
    {
        var extrudeData = (ExtrudeFeatureData2)feature.GetDefinition();
        var depth = extrudeData.GetDepth(!extrudeData.ReverseDirection) * 1000.00;
        var depth1 = extrudeData.GetDepth(false) * 1000.00;
        return extrudeData.BothDirections ? depth * 2.0 : depth;
    }

    /// <summary>
    /// Функция чтения глубины ребра
    /// </summary>
    /// <param name="feature"></param>
    /// <returns>Глубина выдавливания</returns>
    private static double GetRibThickness(IFeature feature)
    {
        var swRibFeat = (RibFeatureData2)feature.GetDefinition();
        var thickness = swRibFeat.Thickness * 1000;
        return swRibFeat.IsTwoSided ? thickness * 2 : thickness;
    }

    

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат точек.
    /// </summary>
    /// <param name="sketch">Объект типа Sketch.</param>
    /// <param name="pointCount">Количество точек в эскизе</param>
    private static void PointListener(ISketch sketch, int pointCount)
    {
        var getPointProperties = sketch.GetUserPoints2();
        if (getPointProperties is not IEnumerable pointEnumerable) return;
        var point = pointEnumerable.Cast<double>().ToArray();
        for (var index = 0; index < pointCount; index++)
        {
            SolidWorksProjectTree.LastNode.LastNode.Nodes.Add("Точка");
            if (index == pointCount) continue;
            var pointCoordinate = "Координаты: x = " + point[8 * index + 5] * 1000 + ", y = " +
                                  point[8 * index + 6] * 1000 + ", z = " + point[8 * index + 7] * 1000 + ";";
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(pointCoordinate);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальных, конечных, фокусных и вершин точек параболы.
    /// </summary>
    /// <param name="sketch">Объект типа Sketch.</param>
    /// <param name="parabolaCount">Количество параболов в эскизе.</param>
    private static void ParabolaListener(ISketch sketch, int parabolaCount)
    {
        var getParabolaProperties = sketch.GetParabolas2();
        if (getParabolaProperties is not IEnumerable parabolaEnumerable) return;
        var parabola = parabolaEnumerable.Cast<double>().ToArray();
        for (var i = 0; i < parabolaCount; i++)
        {
            SolidWorksProjectTree.LastNode.LastNode.Nodes.Add("Парабола");
            if (i == parabolaCount) continue;
            var start = "Начало: x = " + parabola[18 * i + 6] * 1000 + ", y = " + parabola[18 * i + 7] * 1000 +
                        ", z = " + parabola[18 * i + 8] * 1000 + ";";
            var end = "Конец: x = " + parabola[18 * i + 9] * 1000 + ", y = " + parabola[18 * i + 10] * 1000 +
                      ", z = " +
                      parabola[18 * i + 11] * 1000 + ";";
            var focusPoint = "Фокусная точка: x = " + parabola[18 * i + 12] * 1000 + ", y = " +
                             parabola[18 * i + 13] * 1000 +
                             ", z = " + parabola[18 * i + 14] * 1000 + ";";
            var apexPoint = "Точка вершины: x = " + parabola[18 * i + 15] * 1000 + ", y = " +
                            parabola[18 * i + 16] * 1000 +
                            ", z = " + parabola[18 * i + 17] * 1000 + ";";
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(focusPoint);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(apexPoint);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальных, конечных и центральных точек дуг.
    /// </summary>
    /// <param name="sketch">Объект типа Sketch.</param>
    /// <param name="arcCount">Количество дуг в эскизе.</param>
    private static void ArcListener(ISketch sketch, int arcCount)
    {
        var getArcsProperties = sketch.GetArcs2();
        if (getArcsProperties is not IEnumerable arcsEnumerable) return;
        var arcs = arcsEnumerable.Cast<double>().ToArray();

        var vSketchSeg = sketch.GetSketchSegments();
        var sketchSegEnum = (IEnumerable)vSketchSeg;
        var sketchSegments = sketchSegEnum.Cast<SketchSegment>().ToArray();
        for (var i = 0; i < arcCount; i++)
        {
            var arc = new Arc();

            SolidWorksProjectTree.LastNode.LastNode.Nodes.Add("Дуга");
            var j = i;
            if (i == arcCount) continue;

            var xStart = arcs[16 * i + 6] * 1000;
            var yStart = arcs[16 * i + 7] * 1000;
            var zStart = arcs[16 * i + 8] * 1000;
            var xEnd = arcs[16 * i + 9] * 1000;
            var yEnd = arcs[16 * i + 10] * 1000;
            var zEnd = arcs[16 * i + 11] * 1000;
            var xCenter = arcs[16 * i + 12] * 1000;
            var yCenter = arcs[16 * i + 13] * 1000;
            var zCenter = arcs[16 * i + 14] * 1000;

            var start = "Начало: x = " + xStart + ", y = " + yStart +
                        ", z = " + zStart + ";";
            var end = "Конец: x = " + xEnd + ", y = " + yEnd + ", z = " +
                      zEnd + ";";
            var center = "Центр: x = " + xCenter + ", y = " + yCenter +
                         ", z = " + zCenter + ";";

            var sketchSegment = sketchSegments[j];

            while (sketchSegment.GetType() != (int)swSketchSegments_e.swSketchARC)
            {
                j++;
                sketchSegment = sketchSegments[j];
            }

            // ReSharper disable once SuspiciousTypeConversion.Global
            var arcSketch = (SketchArc)sketchSegment;
            var radius = arcSketch.GetRadius() * 1000;

            arc.XStart = xStart;
            arc.YStart = yStart;
            arc.ZStart = zStart;
            arc.XEnd = xEnd;
            arc.YEnd = yEnd;
            arc.ZEnd = zEnd;
            arc.XCenter = xCenter;
            arc.YCenter = yCenter;
            arc.ZCenter = zCenter;
            arc.ArcRadius = radius;
            arc.Coordinate = start + "\n" + end + "\n" + center;

            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(center);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add("Радиус: " + radius + " мм");
            _arcs.Add(arc);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальной и конечной точек отрезка.
    /// </summary>
    /// <param name="sketch">Объект типа Sketch.</param>
    /// <param name="lineCount">Количество линий в эскизе.</param>
    private static void LineListener(ISketch sketch, int lineCount)
    {
        var getLinesProperties = sketch.GetLines2(4);
        if (getLinesProperties is not IEnumerable lineEnumerable) return;
        var lineArrayInfo = lineEnumerable.Cast<double>().ToArray();

        var vSketchSeg = sketch.GetSketchSegments();
        var sketchSegEnum = (IEnumerable)vSketchSeg;
        var sketchSegments = sketchSegEnum.Cast<SketchSegment>().ToArray();

        for (var i = 0; i < lineCount; i++)
        {
            var line = new Line();

            SolidWorksProjectTree.LastNode.LastNode.Nodes.Add("Отрезок");
            var j = i;
            if (i == lineCount) continue;
            var lineStyle = (short)lineArrayInfo[12 * i + 2];
            var xStart = lineArrayInfo[12 * i + 6] * 1000;
            var yStart = lineArrayInfo[12 * i + 7] * 1000;
            var zStart = lineArrayInfo[12 * i + 8] * 1000;
            var xEnd = lineArrayInfo[12 * i + 9] * 1000;
            var yEnd = lineArrayInfo[12 * i + 10] * 1000;
            var zEnd = lineArrayInfo[12 * i + 11] * 1000;
            var start = "Начало: x = " + xStart + ", y = " + yStart + ", z = " + zStart + ";";
            var end = "Конец: x = " + xEnd + ", y = " + yEnd + ", z = " + zEnd + ";";
            var sketchSegment = sketchSegments[j];
            while (sketchSegment.GetType() != (int)swSketchSegments_e.swSketchLINE)
            {
                j++;
                sketchSegment = sketchSegments[j];
            }

            var lineLength = sketchSegment.GetLength() * 1000.0;

            line.LineLength = lineLength;
            line.LineType = lineStyle;
            line.XStart = xStart;
            line.YStart = yStart;
            line.ZStart = zStart;
            line.XEnd = xEnd;
            line.YEnd = yEnd;
            line.ZEnd = zEnd;
            line.Coordinate = start + "\n" + end;
            line.LineArrangement = Controller.GetLineArrangement(line);
            _lines.Add(line);

            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add("Длина: " + lineLength + " мм");
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add("Расположение: " + line.LineArrangement);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
        }
    }

    /// <summary>
    ///     Процедура позволяющая извлекать значения координат начальной, конечной, центральной,
    ///     на большой оси X и на малой оси X точек эллипса.
    /// </summary>
    /// <param name="sketch">Объект типа Sketch.</param>
    /// <param name="ellipseCount">Количество эллипсов в эскизе.</param>
    private static void EllipseListener(ISketch sketch, int ellipseCount)
    {
        var getEllipseProperties = sketch.GetEllipses3();
        if (getEllipseProperties is not IEnumerable ellipseEnumerable) return;
        var ellipse = ellipseEnumerable.Cast<double>().ToArray();
        for (var i = 0; i < ellipseCount; i++)
        {
            SolidWorksProjectTree.LastNode.LastNode.Nodes.Add("Эллипс");
            if (i == ellipseCount) continue;
            var start = "Начало: x = " + ellipse[16 * i + 6] * 1000 + ", y = " + ellipse[16 * i + 7] * 1000 +
                        ", z = " + ellipse[16 * i + 8] * 1000 + ";";
            var end = "Конец: x = " + ellipse[16 * i + 9] * 1000 + ", y = " + ellipse[16 * i + 10] * 1000 +
                      ", z = " +
                      ellipse[16 * i + 11] * 1000 + ";";
            var center = "Центр: x = " + ellipse[16 * i + 12] * 1000 + ", y = " + ellipse[16 * i + 13] * 1000 +
                         ", z = " + ellipse[16 * i + 14] * 1000 + ";";
            var majorPoint = "Точка на большой оси: x = " + ellipse[16 * i + 15] * 1000 + ", y = " +
                             ellipse[16 * i + 16] * 1000 + ", z = " +
                             ellipse[16 * i + 17] * 1000 + ";";
            var minorPoint = "Точка на малой оси: x = " + ellipse[16 * i + 18] * 1000 + ", y = " +
                             ellipse[16 * i + 19] * 1000 + ", z = " +
                             ellipse[16 * i + 20] * 1000 + ";";
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(center);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(start);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(end);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(majorPoint);
            SolidWorksProjectTree.LastNode.LastNode.LastNode.Nodes.Add(minorPoint);
        }
    }
    
    
    // TODO ТЕСТОВЫЕ МЕТОДЫ, ТРЕБУЮЩИЕ ДАЛЬНЕЙШЕЙ РАЗРАБОТКИ
    
    /// <summary>
    /// Процедура для чтения зеркального отражения
    /// </summary>
    /// <param name="feature"></param>
    private static void MirrorListener(IFeature feature)
    {
        // MirrorPattern
        var swModel = SwModel;
        var mirrorData = (IMirrorPatternFeatureData)feature.GetDefinition();
        var geometryPattern = "Geometry pattern: " + mirrorData.GeometryPattern + Environment.NewLine;
        var faceCount = "Number of mirrored faces: " + mirrorData.GetMirrorFaceCount() + Environment.NewLine;
        var planeType = "Type of mirrored plane (0 = face; 1 = plane): " + mirrorData.GetMirrorPlaneType() +
                        Environment.NewLine;
        var featureCount = "Number of patterned features: " + mirrorData.GetPatternFeatureCount() + Environment.NewLine;
        var plane = "Plane: ";

        mirrorData.AccessSelections(swModel, null);

        if (mirrorData.GetMirrorPlaneType().Equals(1))
        {
            var swFeature = (Feature)mirrorData.Plane;
            plane += swFeature.Name + Environment.NewLine;
        }
        else
        {
            var swEntity = (Entity)mirrorData.Plane;
            
        }

        var mirrorFeature = new StringBuilder();
        var patternArray = (object[])mirrorData.PatternFeatureArray;
        foreach (Feature pattern in patternArray)
            mirrorFeature.Append("Feature: " + pattern.Name + Environment.NewLine);

        mirrorData.ReleaseSelectionAccess();
        Message.InformationMessage(geometryPattern + faceCount + planeType + featureCount + plane + mirrorFeature,
            "Уведомление");
    }

    /// <summary>
    /// Процедура для определения плоскости
    /// </summary>
    /// <param name="sketch"></param>
    private static void GetPlanesAndFaces(ISketch sketch)
    {
        var transformationMatrix = sketch.ModelToSketchTransform;
        var transformationMatrixData = (double[])transformationMatrix.ArrayData;
        var top = new double[] { 1, 0, 0, 0, 0, 1, 0, -1, 0, 0, 0, 0, 1, 0, 0, 0 };
        //if (transformationMatrixData.SequenceEqual(top))
        //MessageBox.Show("Сверху");
        var s = transformationMatrixData.Aggregate("", (current, data) => current + "|" + data);
    }
    
    /// <summary>
    /// Тестовая процедура чтения тип объектов скругливания
    /// </summary>
    /// <param name="feature"></param>
    private static void FilletListener(IFeature feature)
    {
        var swFillet = (SimpleFilletFeatureData2)feature.GetDefinition();
        var filletInformation = "Constant width = " + swFillet.ConstantWidth + "\nCurvature continuous = " +
                   swFillet.CurvatureContinuous +
                   "\nDefault radius = " + swFillet.DefaultRadius + "\nNumber of fillet items = " +
                   swFillet.FilletItemsCount +
                   "\nMultiple radii = " + swFillet.IsMultipleRadius + "\nKeep existing features = " +
                   swFillet.KeepFeatures +
                   "\nApply fillet to attachment edges = " + swFillet.OmitAttachedEdges + "\nOverflow type = " +
                   swFillet.OverflowType +
                   "\nExtend fillet to all affected parts = " + swFillet.PropagateFeatureToParts +
                   "\nExtend fillet to all tangent faces = " + swFillet.PropagateToTangentFaces +
                   "\nReverse normal = " + swFillet.get_ReverseFaceNormal(0) + "\nRound fillet corners = " +
                   swFillet.RoundCorners +
                   "\nTrim and attach to surfaces = " + swFillet.TrimAndAttachSurfaces + "\nType of fillet = " +
                   swFillet.Type +
                   "\nNumber of faces associated with this fillet = " +
                   swFillet.GetFaceCount((int)swSimpleFilletWhichFaces_e.swSimpleFilletSingleRadius);

        var filletCount = swFillet.FilletItemsCount;
        filletInformation += "\nFillet items count = " + filletCount;
        var filletObjectType = swFillet.GetFilletItemAtIndex(-1);
        filletInformation += "\nRadius = " + swFillet.GetRadius(filletObjectType);
        var filletFeatureCount = swFillet.GetFeatureCount();
        filletInformation += "\nFillet feature count = " + filletFeatureCount;
        
        
        Message.InformationMessage(filletInformation, "Fillet information");
    }
    
}