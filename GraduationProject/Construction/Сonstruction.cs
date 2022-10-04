using GraduationProject.Controllers;
using GraduationProject.ModelObjects.IObjects;
using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject.Construction;

[UsedImplicitly]
public class Сonstruction : Connection
{
    private const double Millimeter = 0.001;
    private static Feature _feature;
    private static Entity _entity;

    private static Feature FeatureExtrusion(double deepth, bool sd = true, bool dir = false)
    {
        // если Sd = true, то вытягивание в одну сторону, если ложь, тогда в обе стороны!
        if (sd)
            return SwModel.FeatureManager.FeatureExtrusion2(true, false, dir,
                (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, true,
                true, true, 0, 0, false);
        return SwModel.FeatureManager.FeatureExtrusion2(false, false, dir,
            (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
            deepth, deepth, false, false, false, false, 0, 0, false, false, false, false, true,
            true, true, 0, 0, false);
    }

    public static void SelectFace(string featureName, string featureType, int index)
    {
        var faces = (dynamic[])_feature.GetFaces();
        _entity = faces[index] as Entity;
        _entity!.Select(true);
    }

    private static void SelectPlane(string name, string obj = "PLANE")
    {
        SwModel.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
    }

    private static void FeatureCut(double deepth, bool flip = false,
        swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
    {
        SwModel.FeatureManager.FeatureCut2(true, flip, false, (int)mode, (int)mode,
            deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
            false, false, false, false, false);
    }

    public static void Selected()
    {
        SwModel.Extension.SelectByID2("Бобышка-Вытянуть2", "BOSS", 0, 0, 1, false, 0, null, 0);
    }

    public static void Drawing()
    {
        IModel model = FileController.GetModelObjectFromFile("13");

        foreach (var feature in model.Features)
        {
            var sketch = feature.Sketch;
            if (sketch.Plane is not null)
                SelectPlane(sketch.Plane);
            else
                SelectFace(sketch.Face.Item1, sketch.Face.Item2, sketch.Face.Item3);
            SwSketchManager.InsertSketch(true);

            if (sketch.UserPoints.Count != 0)
                foreach (var userPoint in sketch.UserPoints)
                    SwSketchManager.CreatePoint(userPoint.X, userPoint.Y, userPoint.Z);

            if (sketch.Arcs.Count != 0)
                foreach (var arc in sketch.Arcs)
                    SwSketchManager.CreateArc(arc.XCenter * Millimeter, arc.YCenter * Millimeter,
                        arc.ZCenter * Millimeter, arc.XStart * Millimeter, arc.YStart * Millimeter,
                        arc.ZStart * Millimeter, arc.XEnd * Millimeter, arc.YEnd * Millimeter, arc.ZEnd * Millimeter,
                        arc.Direction);

            if (sketch.Lines.Count != 0)
                foreach (var line in sketch.Lines)
                {
                    var swSketchSegment = SwSketchManager.CreateLine(line.XStart * Millimeter, line.YStart * Millimeter,
                        line.ZStart, line.XEnd * Millimeter, line.YEnd * Millimeter, line.ZEnd * Millimeter);
                    if (line.LineType.Equals(4))
                    {
                        swSketchSegment.Style = line.LineType;
                        SwSketchManager.CreateConstructionGeometry();
                    }
                }

            if (feature.Type.Equals("Extrusion") || feature.Type.Equals("Boss"))
                _feature = FeatureExtrusion(feature.Depth * Millimeter);
            if (feature.Type.Equals("Cut"))
                FeatureCut(feature.Depth * Millimeter);
            SwModel.ClearSelection();
        }
    }
}