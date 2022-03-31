using System.Collections;
using System.Linq;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public class Reader : Connection
    {
        private static Feature _featureNode;
        public static TreeNode TreeNode;
        private static bool _check;

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

                if (nodeType.Equals("ProfileFeature")) LineListener(nodeName);

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

        public static int LineCount;
        public static int ArcCount;
        public static int SplineCount;
        public static int EllipseCount;
        public static int ParabolaCount;
        public static int PointCount;

        private static void LineListener(string sketch)
        {
            ModelDoc2.Extension.SelectByID2(sketch, "SKETCH", 0, 0, 0, false, 0, null, 0);
            var selectedSketch = (Sketch) _featureNode.GetSpecificFeature2();
            
            LineCount = selectedSketch.GetLineCount();
            ArcCount = selectedSketch.GetArcCount();
            SplineCount = selectedSketch.GetSplineCount(0);
            EllipseCount = selectedSketch.GetEllipseCount();
            ParabolaCount = selectedSketch.GetParabolaCount();
            PointCount = selectedSketch.GetUserPointsCount();

            var getLinesProperties = selectedSketch.GetLines2(1);
            var getArcsProperties = selectedSketch.GetArcs2();
            var getSplineProperties = selectedSketch.GetSplines();
            
            //SplineParamData splineParamData = (SplineParamData) selectedSketch.GetSplineParams4(true);

            ModelDoc2.DeSelectByID(sketch, "SKETCH", 0, 0, 0);

            if (getLinesProperties is IEnumerable lineEnumerable)
            {
                var line = lineEnumerable.Cast<double>().ToArray();

                for (var i = 0; i < LineCount; i++)
                {
                    TreeNode.LastNode.LastNode.Nodes.Add("Отрезок");

                    if (i == LineCount) continue;
                    var start = "Начало: x = " + line[12 * i + 6] * 1000 + ", y = " + line[12 * i + 7] * 1000 +
                                ", z = " + line[12 * i + 8] * 1000 + ";";
                    var end = "Конец: x = " + line[12 * i + 9] * 1000 + ", y = " + line[12 * i + 10] * 1000 + ", z = " +
                              line[12 * i + 11] * 1000 + ";";

                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                }
            }

            if (getArcsProperties is IEnumerable arcsEnumerable)
            {
                var arcs = arcsEnumerable.Cast<double>().ToArray();

                for (var i = 0; i < ArcCount; i++)
                {
                    TreeNode.LastNode.LastNode.Nodes.Add("Дуга");

                    if (i == ArcCount) continue;
                    var start = "Начало: x = " + arcs[16 * i + 6] * 1000 + ", y = " + arcs[16 * i + 7] * 1000 +
                                ", z = " + arcs[16 * i + 8] * 1000 + ";";
                    var end = "Конец: x = " + arcs[16 * i + 9] * 1000 + ", y = " + arcs[16 * i + 10] * 1000 + ", z = " +
                              arcs[16 * i + 11] * 1000 + ";";
                    var center = "Центр: x = " + arcs[16 * i + 12] * 1000 + ", y = " + arcs[16 * i + 13] * 1000 +
                                 ", z = " + arcs[16 * i + 14] * 1000 + ";";

                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(center);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(start);
                    TreeNode.LastNode.LastNode.LastNode.Nodes.Add(end);
                }
            }

            if (getSplineProperties is IEnumerable splineEnumerable)
            {
            
                var spline = splineEnumerable.Cast<double>().ToArray();
            }

            for (var i = 0; i < EllipseCount; i++) TreeNode.LastNode.LastNode.Nodes.Add("Эллипс");

            for (var i = 0; i < ParabolaCount; i++) TreeNode.LastNode.LastNode.Nodes.Add("Парабола");

            for (var i = 0; i < PointCount; i++) TreeNode.LastNode.LastNode.Nodes.Add("Точка");
        }
    }
}