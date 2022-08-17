using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject.Construction;

[UsedImplicitly]
public class Сonstruction : Connection
{
    private static Feature _firstFeature, _secondFeature, _feature;
    private static dynamic _faces;
    private static Entity _entity;

    private static Feature FeatureExtrusion(double deepth, bool sd = true, bool dir = false)
    {
        // если Sd = true, то вытягивание в одну сторону, если ложь, тогда в обе стороны!
        if (sd)
            return ModelDoc2.FeatureManager.FeatureExtrusion2(true, false, dir,
                (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, true,
                true, true, 0, 0, false);
        return ModelDoc2.FeatureManager.FeatureExtrusion2(false, false, dir,
            (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
            deepth, deepth, false, false, false, false, 0, 0, false, false, false, false, true,
            true, true, 0, 0, false);
    }

    private static void SelectPlane(string name, string obj = "PLANE")
    {
        ModelDoc2.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
    }

    private static void FeatureCut(double deepth, bool flip = false,
        swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
    {
        ModelDoc2.FeatureManager.FeatureCut2(true, flip, false, (int)mode, (int)mode,
            deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
            false, false, false, false, false);
    }

    public static void Step1()
    {
        SelectPlane("Сверху");
        SketchManager.InsertSketch(true);
        SketchManager.CreateCenterRectangle(0, 0, 0, 0.055, 0.085 / 2.0, 0);
        _firstFeature = FeatureExtrusion(0.11 / 2);
        ModelDoc2.ClearSelection();
        ModelDoc2.ClearSelection2(false);
    }

    // public static void Step2()
    // {
    //     SelectPlane("Сверху");
    //     SketchManager.InsertSketch(true);
    //     SketchManager.CreateCornerRectangle(-0.11/2, 0.085/2, 0, 0.11/2, 0.0025, 0);
    //     _secondFeature = FeatureExtrusion(0.105);
    //     ModelDoc2.ClearSelection();
    // }
    //
    // public static void Step3()
    // {
    //     _faces = (dynamic[]) _firstFeature.GetFaces();
    //     _entity = _faces[3] as Entity;
    //     _entity!.Select(true);
    //     SketchManager.InsertSketch(true);
    //     SketchManager.CreateLine(-(0.085 / 2) + 0.04, 0.085, 0, 0.085 / 2 - 0.025, 0.055, 0);
    //     ModelDoc2.FeatureManager.InsertRib(false, true, 0.01,
    //         0, false, false, true,
    //         0, false, false);
    //     _feature = ModelDoc2.Extension.GetLastFeatureAdded();
    //     ModelDoc2.Extension.SelectByID2("Справа", "PLANE", 0, 0, 0, false, 2, null, 0);
    //     // ОБЯЗАТЕЛЬНО!!! SOLIDBODY!!!! 
    //     ModelDoc2.Extension.SelectByID2(_feature.Name, "SOLIDBODY", 0, 0, 0, true, 256, null, 0);
    //     _feature = FeatureManager.InsertMirrorFeature2(true, true, true, false,
    //         (int) swFeatureScope_e.swFeatureScope_AllBodies);
    //     ModelDoc2.ClearSelection2(true);
    // }
    //
    // public static void Step4()
    // {
    //     _faces = (dynamic[]) _secondFeature.GetFaces();
    //     _entity = _faces[1] as Entity;
    //     _entity!.Select(true);
    //     SketchManager.InsertSketch(false);
    //     SketchManager.CreateArc(0, 0.105, 0, -0.033, 0.105, 0, 0.033, 0.105, 0, +1);
    //     SketchManager.CreateLine(-0.033, 0.105, 0, 0.033, 0.105, 0);
    //     FeatureCut(0.04);
    //     ModelDoc2.ClearSelection();
    // }
    //
    // public static void Step5()
    // {
    //     _faces = (dynamic[]) _firstFeature.GetFaces();
    //     _entity = _faces[0] as Entity;
    //     _entity!.Select(true);
    //     SketchManager.InsertSketch(false);
    //     SketchManager.CreateCornerRectangle(-0.03, 0.055, 0, 0.03, 0, 0);
    //     FeatureCut(0.015);
    //     ModelDoc2.ClearSelection();
    // }


    public static void Step2()
    {
        SelectPlane("Справа");
        SketchManager.InsertSketch(false);

        SketchManager.CreateCornerRectangle(0.085 / 2, 0.055, 0, 0.085 / 2 - 0.04, 0.105, 0.04);
        //вытягивание в две стороны
        _secondFeature = FeatureExtrusion(0.11 / 2, false);
        ModelDoc2.ClearSelection();
    }

    public static void Step3()
    {
        _faces = (dynamic[])_firstFeature.GetFaces();
        _entity = _faces[3] as Entity;
        _entity!.Select(true);
        SketchManager.InsertSketch(true);
        SketchManager.CreateLine(-(0.085 / 2) + 0.04, 0.085, 0, 0.085 / 2 - 0.025, 0.055, 0);
        // создаем ребро (rib)
        ModelDoc2.FeatureManager.InsertRib(false, true, 0.01,
            0, false, false, true,
            0, false, false);

        _feature = ModelDoc2.Extension.GetLastFeatureAdded();

        ModelDoc2.Extension.SelectByID2("Справа", "PLANE", 0, 0, 0, false, 2, null, 0);
        // ОБЯЗАТЕЛЬНО!!! SOLIDBODY!!!! 
        ModelDoc2.Extension.SelectByID2(_feature.Name, "SOLIDBODY", 0, 0, 0, true, 256, null, 0);

        _feature = FeatureManager.InsertMirrorFeature2(true, true, true, false,
            (int)swFeatureScope_e.swFeatureScope_AllBodies);

        ModelDoc2.ClearSelection2(true);
    }

    public static void Step4()
    {
        _faces = (dynamic[])_secondFeature.GetFaces();
        _entity = _faces[1] as Entity;
        _entity!.Select(true);
        SketchManager.InsertSketch(false);
        var yCenter = 0.110f;
        //var yCenter = 0.105f;
        SketchManager.CreateArc(0, yCenter, 0, -0.033, yCenter, 0, 0.033, yCenter, 0, +1);
        SketchManager.CreateLine(-0.033, yCenter, 0, 0.033, yCenter, 0);
        FeatureCut(0.04);
        ModelDoc2.ClearSelection();
    }

    public static void Step5()
    {
        _faces = (dynamic[])_firstFeature.GetFaces();
        _entity = _faces[2] as Entity;
        _entity!.Select(true);
        SketchManager.InsertSketch(false);
        SketchManager.CreateCornerRectangle(-0.03, 0.055, 0, 0.04, 0, 0);
        FeatureCut(0.015);
        ModelDoc2.ClearSelection();
    }
}