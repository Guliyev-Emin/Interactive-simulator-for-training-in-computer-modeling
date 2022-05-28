using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraduationProject.Controller;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject.Construction
{
    public class Reader : Connection
    {
        private static Feature _featureNode;
        public static TreeNode TreeNode;
        private static bool _check;
        public static List<SketchInfo> SketchInfos;
        private static double _deepth;
        private static List<string> _pointCoordinates;
        private static List<string> _lineCoordinates;
        private static List<short> _lineTypes;
        private static List<double> _lineLengths;
        private static List<string> _arcCoordinates;
        private static List<double> _arcRadius;
        private static List<string> _ellipseCoordinates;
        private static List<string> _parabolaCoordinates;

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

            if (nodeObject != null)
            {
                switch (nodeObjectType)
                {
                    case (int) swTreeControlItemType_e.swFeatureManagerItem_Feature:
                        _featureNode = (Feature) nodeObject;
                        nodeType = _featureNode.GetTypeName();
                        nodeName = _featureNode.Name;
                        break;
                }

                if (_check & !nodeType.Equals("DetailCabinet") & !nodeType.Equals("MaterialFolder") & !nodeType.Equals("HistoryFolder") & !nodeType.Equals("SensorFolder"))
                    TreeNode.LastNode.Nodes.Add(nodeName);
                else
                    TreeNode.Nodes.Add(nodeName);

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

            return TreeNode;
        }

        /// <summary>
        ///     Процедура позволяющая извлекать значения координат двухмерных объектов в эскизе.
        /// </summary>
        /// <param name="sketch">Название эскиза.</param>
        private static void SketchListener(string sketch)
        {
            var selectedSketch = (Sketch) _featureNode.GetSpecificFeature2();

            var lineCount = selectedSketch.GetLineCount();
            var arcCount = selectedSketch.GetArcCount();
            var ellipseCount = selectedSketch.GetEllipseCount();
            var parabolaCount = selectedSketch.GetParabolaCount();
            var pointCount = selectedSketch.GetUserPointsCount();
            _deepth = new double();
            _pointCoordinates = new List<string>();
            _lineCoordinates = new List<string>();
            _lineTypes = new List<short>();
            _lineLengths = new List<double>();
            _arcCoordinates = new List<string>();
            _arcRadius = new List<double>();
            _ellipseCoordinates = new List<string>();
            _parabolaCoordinates = new List<string>();

            /*
            * Получение глубины фигуры, нужно много тестов.
            */
            var featureName = TreeNode.LastNode.Text;
            var dimension = (Dimension) ModelDoc2.Parameter("D1@" + featureName);
            if (dimension != null)
            {
                var deepth = (double[]) dimension.GetSystemValue3((int) swInConfigurationOpts_e.swAllConfiguration, featureName);
                TreeNode.LastNode.Nodes.Insert(0, "Глубина: " + deepth[0] * 1000 + @" мм");
                _deepth = deepth[0] * 1000;
            }
            
            if (lineCount != 0)
                LineListener(selectedSketch, lineCount);

            if (ellipseCount != 0)
                EllipseListener(selectedSketch, ellipseCount);

            if (arcCount != 0)
                ArcListener(selectedSketch, arcCount);

            if (parabolaCount != 0)
                ParabolaListener(selectedSketch, parabolaCount);

            for (var i = 0; i < pointCount; i++) TreeNode.LastNode.LastNode.Nodes.Add("Точка");

            SketchInfos.Add(new SketchInfo
            {
                SketchName = sketch, Deepth = _deepth,
                PointStatus = pointCount != 0, PointCount = pointCount, PointCoordinates = _pointCoordinates,
                LineStatus = lineCount != 0, LineCount = lineCount, LineCoordinates = _lineCoordinates, LineTypes = _lineTypes, LineLengths = _lineLengths,
                ArcStatus = arcCount != 0, ArcCount = arcCount, ArcCoordinates = _arcCoordinates, ArcRadius = _arcRadius,
                EllipseStatus = ellipseCount != 0, EllipseCount = ellipseCount,
                EllipseCoordinates = _ellipseCoordinates,
                ParabolaStatus = parabolaCount != 0, ParabolaCount = parabolaCount,
                ParabolaCoordinates = _parabolaCoordinates
            });
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
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add("Парабола");
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
                _parabolaCoordinates.Add(start + "\n" + end + "\n" + focusPoint + "\n" + apexPoint);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(focusPoint);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(apexPoint);
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
            var sketchSegEnum = (IEnumerable) vSketchSeg;
            var sketchSegments = sketchSegEnum.Cast<SketchSegment>().ToArray();
            for (var i = 0; i < arcCount; i++)
            {
                TreeNode.LastNode.LastNode.Nodes.Add("Дуга");
                var j = i;
                if (i == arcCount) continue;
                var start = "Начало: x = " + arcs[16 * i + 6] * 1000 + ", y = " + arcs[16 * i + 7] * 1000 +
                            ", z = " + arcs[16 * i + 8] * 1000 + ";";
                var end = "Конец: x = " + arcs[16 * i + 9] * 1000 + ", y = " + arcs[16 * i + 10] * 1000 + ", z = " +
                          arcs[16 * i + 11] * 1000 + ";";
                var center = "Центр: x = " + arcs[16 * i + 12] * 1000 + ", y = " + arcs[16 * i + 13] * 1000 +
                             ", z = " + arcs[16 * i + 14] * 1000 + ";";
                
                var sketchSegment = sketchSegments[j];
                
                while (sketchSegment.GetType() != (int) swSketchSegments_e.swSketchARC)
                {
                    j++;
                    sketchSegment = sketchSegments[j];
                }

                var arcSketch = (SketchArc) sketchSegment;
                var radius = arcSketch.GetRadius() * 1000;

                _arcRadius.Add(radius);
                _arcCoordinates.Add(start + "\n" + end + "\n" + center);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(center);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add("Радиус: " + radius + "мм");
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
            var line = lineEnumerable.Cast<double>().ToArray();
            var vSketchSeg = sketch.GetSketchSegments();
            var sketchSegEnum = (IEnumerable) vSketchSeg;
            var sketchSegments = sketchSegEnum.Cast<SketchSegment>().ToArray();
            for (var i = 0; i < lineCount; i++)
            {
                TreeNode.LastNode.LastNode.Nodes.Add("Отрезок");
                var j = i;
                if (i == lineCount) continue;
                var lineStyle = (short) line[12 * i + 2];
                var start = "Начало: x = " + line[12 * i + 6] * 1000 + ", y = " + line[12 * i + 7] * 1000 +
                            ", z = " + line[12 * i + 8] * 1000 + ";";
                var end = "Конец: x = " + line[12 * i + 9] * 1000 + ", y = " + line[12 * i + 10] * 1000 + ", z = " +
                          line[12 * i + 11] * 1000 + ";";
                var sketchSegment = sketchSegments[j];
                
                while (sketchSegment.GetType() != (int) swSketchSegments_e.swSketchLINE)
                {
                    j++;
                    sketchSegment = sketchSegments[j];
                }
                var lineLength = sketchSegment.GetLength() * 1000.0;

                _lineTypes.Add(lineStyle);
                _lineCoordinates.Add(start + "\n" + end);
                _lineLengths.Add(lineLength);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add("Длина: " + lineLength + " мм");
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
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
                TreeNode.LastNode.LastNode.Nodes.Add("Эллипс");
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
                _ellipseCoordinates.Add(start + "\n" + end + "\n" + center + "\n" + majorPoint + "\n" + minorPoint);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(center);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(majorPoint);
                TreeNode.LastNode.LastNode.LastNode.Nodes.Add(minorPoint);
            }
        }

        /// <summary>
        ///     Функция по определению количество углов в фигуре.
        /// </summary>
        /// <param name="sketchName">Название эскиза.</param>
        /// <returns>Возвращает количество углов.</returns>
        public static string FindingPolygon(string sketchName)
        {
            var sketchInfo = SketchInfos[SketchInfos.FindIndex(name => name.SketchName == sketchName)];
            var lineType = sketchInfo.LineTypes;
            var lineCoordinates = sketchInfo.LineCoordinates;
            var result = "";
            var line1X = lineCoordinates[0].Split('\n')[1].Split(' ')[3];
            var line1Y = lineCoordinates[0].Split('\n')[1].Split(' ')[6];
            var startPointXFirstLine = lineCoordinates[0].Split('\n')[0].Split(' ')[3];
            var startPointYFirstLine = lineCoordinates[0].Split('\n')[0].Split(' ')[6];
            var switchStartEnd = false;
            var countFigure = 1;
            var ind = 0;
            var i = 0;
            lineCoordinates.RemoveAt(0);
            var isolation = false;
            while (lineCoordinates.Count != 0)
            {
                // от конца точки линии ищем начало из этой точки новую линию
                string line2X;
                string line2Y;
                if (!switchStartEnd)
                {
                    line2X = lineCoordinates[i].Split('\n')[0].Split(' ')[3];
                    line2Y = lineCoordinates[i].Split('\n')[0].Split(' ')[6];
                    if (line1X == line2X && line1Y == line2Y)
                    {
                        line1X = lineCoordinates[i].Split('\n')[1].Split(' ')[3];
                        line1Y = lineCoordinates[i].Split('\n')[1].Split(' ')[6];
                        countFigure++;
                        lineCoordinates.RemoveAt(i);
                    }

                    if (i >= lineCoordinates.Count - 1)
                    {
                        switchStartEnd = true;
                        i = 0;
                        continue;
                    }
                }

                // тут от начало точки линии до конца новой точки линии
                if (switchStartEnd)
                {
                    line2X = lineCoordinates[i].Split('\n')[1].Split(' ')[3];
                    line2Y = lineCoordinates[i].Split('\n')[1].Split(' ')[6];
                    if (line1X == line2X && line1Y == line2Y)
                    {
                        line1X = lineCoordinates[i].Split('\n')[0].Split(' ')[3];
                        line1Y = lineCoordinates[i].Split('\n')[0].Split(' ')[6];
                        countFigure++;
                        lineCoordinates.RemoveAt(i);
                    }

                    if (lineCoordinates.Count == 0)
                        if (line1X == startPointXFirstLine && line1Y == startPointYFirstLine)
                            isolation = true;

                    if (i >= lineCoordinates.Count - 1)
                    {
                        switchStartEnd = false;
                        i = 0;
                        continue;
                    }
                }

                ind++;
                i++;
                if (ind != 30) continue;
                MessageBox.Show(@"Много итераций");
                break;
            }

            if (isolation)
                MessageBox.Show(countFigure.ToString());

            return result;
        }
    }
}