using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject.Construction;

public class TestClass:Connection
{
    private static Feature _firstFeature, _secondFeature, _feature;
        private static dynamic _faces;
        private static Entity _entity;
        private static readonly SketchManager SketchManager = SwSketchManager;

        private static Feature FeatureExtrusion(double deepth, bool dir = false)
        {
            
            return SwModel.FeatureManager.FeatureExtrusion2(true, false, dir,
                (int) swEndConditions_e.swEndCondBlind, (int) swEndConditions_e.swEndCondBlind,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, true,
                true, true, 0, 0, false);
        }

        private static void SelectPlane(string name, string obj = "PLANE")
        {
            SwModel.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
        }

        private static void FeatureCut(double deepth, bool flip = false,
            swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
        {
            SwModel.FeatureManager.FeatureCut2(true, flip, false, (int) mode, (int) mode,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
                false, false, false, false, false);
        }

        public static void Step1()
        {
            SelectPlane("Справа");
            SketchManager.InsertSketch(true);
            SketchManager.CreateCornerRectangle(0, 0.055, 0, 0.085, 0, 0); 
            _firstFeature = FeatureExtrusion(0.11);
            SwModel.ClearSelection();
            SwModel.ClearSelection2(true);

        }

        public static void Step2()
        {
            SelectPlane("Справа");
            SketchManager.InsertSketch(false);
            SketchManager.CreateCornerRectangle(0.045, 0.105, 0, 0.085, 0.055, 0);
            _secondFeature = FeatureExtrusion(0.11);
            SwModel.ClearSelection();
        }

        public static void Step3()
        {
            _faces = (dynamic[]) _secondFeature.GetFaces();
            _entity = _faces[4] as Entity;
            _entity!.Select(true);
            SketchManager.InsertSketch(false);
            SketchManager.CreateArc(-0.055, 0.105, 0, -0.022, 0.105, 0, -0.088, 0.105, 0, -1);
            SketchManager.CreateLine(-0.022, 0.105, 0, -0.088, 0.105, 0);
            FeatureCut(0.04);
            SwModel.ClearSelection();
        }

        public static void Step4()
        {
            SelectPlane("Справа");
            SketchManager.InsertSketch(true);

            SketchManager.CreateLine(0.045, 0.085, 0, 0.025, 0.055, 0);

            // создаем ребро (rib)
            SwModel.FeatureManager.InsertRib(false, false, 0.01, 
                0, true, false, true, 
                0, false, false);
            SwModel.ClearSelection();
            SwModel.ClearSelection2(true);
        }

        public static void Step5()
        {
            _faces = (dynamic[]) _firstFeature.GetFaces();
            _entity = _faces[5] as Entity;
            _entity!.Select(true);
            SketchManager.InsertSketch(false);
            SketchManager.CreateCornerRectangle(0.025, 0.055, 0, 0.085, 0, 0);
            FeatureCut(0.015);
            SwModel.ClearSelection();
        }
}