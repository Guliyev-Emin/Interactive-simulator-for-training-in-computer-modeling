using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationProject.Controller;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public class Reader : Connection
    {
        private static Feature _featureNode;
        public static TreeNode TreeNode;
        private static bool _check;
        public static List<SketchInfo> SketchInfos;
        private static List<string> _startEndPoint;
        private static List<string> _startEndLine;
        private static List<string> _startEndArc;
        private static List<string> _startEndEllipse;
        private static List<string> _startEndParabola;

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

                if (_check & !nodeType.Equals("DetailCabinet") & !nodeType.Equals("MaterialFolder"))
                    TreeNode.LastNode.Nodes.Add(nodeName);
                else
                    TreeNode.Nodes.Add(nodeName);

                if (nodeType.Equals("ProfileFeature")) SketchListener(nodeName);

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

        private static void SketchListener(string sketch)
        {
            ModelDoc2.Extension.SelectByID2(sketch, "SKETCH", 0, 0, 0, false, 0, null, 0);
            var selectedSketch = (Sketch) _featureNode.GetSpecificFeature2();

            var lineCount = selectedSketch.GetLineCount();
            var arcCount = selectedSketch.GetArcCount();
            var ellipseCount = selectedSketch.GetEllipseCount();
            var parabolaCount = selectedSketch.GetParabolaCount();
            var pointCount = selectedSketch.GetUserPointsCount();

            var getLinesProperties = selectedSketch.GetLines2(1);
            var getArcsProperties = selectedSketch.GetArcs2();
            var getEllipseProperties = selectedSketch.GetEllipses3();
            var getParabolaProperties = selectedSketch.GetParabolas2();

            _startEndPoint = new List<string>();
            _startEndLine = new List<string>();
            _startEndArc = new List<string>();
            _startEndEllipse = new List<string>();
            _startEndParabola = new List<string>();
            string start;
            string end;

            ModelDoc2.DeSelectByID(sketch, "SKETCH", 0, 0, 0);

            if (getLinesProperties is IEnumerable lineEnumerable && lineCount != 0)
            {
                var line = lineEnumerable.Cast<double>().ToArray();

                for (var i = 0; i < lineCount; i++)
                {
                    TreeNode.LastNode.LastNode.Nodes.Add("Отрезок");

                    if (i == lineCount) continue;
                    start = "Начало: x = " + line[12 * i + 6] * 1000 + ", y = " + line[12 * i + 7] * 1000 +
                            ", z = " + line[12 * i + 8] * 1000 + ";";
                    end = "Конец: x = " + line[12 * i + 9] * 1000 + ", y = " + line[12 * i + 10] * 1000 + ", z = " +
                          line[12 * i + 11] * 1000 + ";";

                    _startEndLine.Add(start + "\n" + end);

                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                }
            }

            if (getArcsProperties is IEnumerable arcsEnumerable && arcCount != 0)
            {
                var arcs = arcsEnumerable.Cast<double>().ToArray();

                for (var i = 0; i < arcCount; i++)
                {
                    TreeNode.LastNode.LastNode.Nodes.Add("Дуга");

                    if (i == arcCount) continue;
                    start = "Начало: x = " + arcs[16 * i + 6] * 1000 + ", y = " + arcs[16 * i + 7] * 1000 +
                            ", z = " + arcs[16 * i + 8] * 1000 + ";";
                    end = "Конец: x = " + arcs[16 * i + 9] * 1000 + ", y = " + arcs[16 * i + 10] * 1000 + ", z = " +
                          arcs[16 * i + 11] * 1000 + ";";
                    var center = "Центр: x = " + arcs[16 * i + 12] * 1000 + ", y = " + arcs[16 * i + 13] * 1000 +
                                 ", z = " + arcs[16 * i + 14] * 1000 + ";";

                    _startEndArc.Add(start + "\n" + end + "\n" + center);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(center);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                }
            }

            if (getEllipseProperties is IEnumerable ellipseEnumerable && ellipseCount != 0)
            {
                var ellipse = ellipseEnumerable.Cast<double>().ToArray();

                for (var i = 0; i < ellipseCount; i++)
                {
                    TreeNode.LastNode.LastNode.Nodes.Add("Эллипс");

                    if (i == ellipseCount) continue;
                    start = "Начало: x = " + ellipse[16 * i + 6] * 1000 + ", y = " + ellipse[16 * i + 7] * 1000 +
                            ", z = " + ellipse[16 * i + 8] * 1000 + ";";
                    end = "Конец: x = " + ellipse[16 * i + 9] * 1000 + ", y = " + ellipse[16 * i + 10] * 1000 +
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

                    _startEndEllipse.Add(start + "\n" + end + "\n" + center + "\n" + majorPoint + "\n" + minorPoint);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(center);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(majorPoint);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(minorPoint);
                }
            }

            if (getParabolaProperties is IEnumerable parabolaEnumerable && parabolaCount != 0)
            {
                var parabola = parabolaEnumerable.Cast<double>().ToArray();

                for (var i = 0; i < parabolaCount; i++)
                {
                    TreeNode.LastNode.LastNode.Nodes.Add("Парабола");

                    if (i == parabolaCount) continue;

                    start = "Начало: x = " + parabola[18 * i + 6] * 1000 + ", y = " + parabola[18 * i + 7] * 1000 +
                            ", z = " + parabola[18 * i + 8] * 1000 + ";";
                    end = "Конец: x = " + parabola[18 * i + 9] * 1000 + ", y = " + parabola[18 * i + 10] * 1000 +
                          ", z = " +
                          parabola[18 * i + 11] * 1000 + ";";
                    var focusPoint = "Фокусная точка: x = " + parabola[18 * i + 12] * 1000 + ", y = " +
                                     parabola[18 * i + 13] * 1000 +
                                     ", z = " + parabola[18 * i + 14] * 1000 + ";";
                    var apexPoint = "Точка вершины: x = " + parabola[18 * i + 15] * 1000 + ", y = " +
                                    parabola[18 * i + 16] * 1000 +
                                    ", z = " + parabola[18 * i + 17] * 1000 + ";";
                    _startEndParabola.Add(start + "\n" + end + "\n" + focusPoint + "\n" + apexPoint);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(focusPoint);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(apexPoint);
                }
            }

            for (var i = 0; i < pointCount; i++) TreeNode.LastNode.LastNode.Nodes.Add("Точка");

            SketchInfos.Add(new SketchInfo
            {
                SketchName = sketch,
                PointStatus = pointCount != 0, PointCount = pointCount, PointCoordinates = _startEndPoint,
                LineStatus = lineCount != 0, LineCount = lineCount, LineCoordinates = _startEndLine,
                ArcStatus = arcCount != 0, ArcCount = arcCount, ArcCoordinates = _startEndArc,
                EllipseStatus = ellipseCount != 0, EllipseCount = ellipseCount, EllipseCoordinates = _startEndEllipse,
                ParabolaStatus = parabolaCount != 0, ParabolaCount = parabolaCount,
                ParabolaCoordinates = _startEndParabola
            });
        }

        public static string FindingPolygon(string sketchName)
        {
            var info = SketchInfos[SketchInfos.FindIndex(name => name.SketchName == sketchName)];
            var lineCoordinates = info.LineCoordinates;
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
                    {
                        if (line1X == startPointXFirstLine && line1Y == startPointYFirstLine)
                            isolation = true;
                    }
                    
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