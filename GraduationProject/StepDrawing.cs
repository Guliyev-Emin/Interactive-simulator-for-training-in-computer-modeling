using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public class StepDrawing : Connection
    {
        private static Feature _firstFeature, _secondFeature, _feature;
        private static dynamic _faces;
        private static Entity _entity;

        private static Feature FeatureExtrusion(double deepth, bool dir = false)
        {
            return _modelDoc2.FeatureManager.FeatureExtrusion2(true, false, dir,
                (int) swEndConditions_e.swEndCondBlind, (int) swEndConditions_e.swEndCondBlind,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, true,
                true, true, 0, 0, false);
        }

        private static void SelectPlane(string name, string obj = "PLANE")
        {
            _modelDoc2.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
        }

        private static void FeatureCut(double deepth, bool flip = false,
            swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
        {
            _modelDoc2.FeatureManager.FeatureCut2(true, flip, false, (int) mode, (int) mode,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
                false, false, false, false, false);
        }

        public static void Step1()
        {
            SelectPlane("Справа");
            _sketchManager.InsertSketch(true);
            _sketchManager.CreateCornerRectangle(0, 0.055, 0, 0.085, 0, 0); 
            _firstFeature = FeatureExtrusion(0.11);
            _modelDoc2.ClearSelection();
            _modelDoc2.ClearSelection2(true);
            
        }

        public static void Step2()
        {
            SelectPlane("Справа");
            _sketchManager.InsertSketch(false);
            _sketchManager.CreateCornerRectangle(0.045, 0.105, 0, 0.085, 0.055, 0);
            _secondFeature = FeatureExtrusion(0.11);
            _modelDoc2.ClearSelection();
        }

        public static void Step3()
        {
            _faces = (dynamic[]) _secondFeature.GetFaces();
            _entity = _faces[4] as Entity;
            _entity!.Select(true);
            _sketchManager.InsertSketch(false);
            _sketchManager.CreateArc(-0.055, 0.105, 0, -0.022, 0.105, 0, -0.088, 0.105, 0, -1);
            _sketchManager.CreateLine(-0.022, 0.105, 0, -0.088, 0.105, 0);
            FeatureCut(0.04);
            _modelDoc2.ClearSelection();
        }

        public static void Step4()
        {
            SelectPlane("Справа");
            _sketchManager.InsertSketch(true);
            
            _sketchManager.CreateLine(0.045, 0.085, 0, 0.025, 0.055, 0);
            
            // создаем ребро (rib)
            _modelDoc2.FeatureManager.InsertRib(false, false, 0.01, 
                0, true, false, true, 
                0, false, false);
            _modelDoc2.ClearSelection();
            _modelDoc2.ClearSelection2(true);
        }

        public static void Step5()
        {
            _faces = (dynamic[]) _firstFeature.GetFaces();
            _entity = _faces[5] as Entity;
            _entity!.Select(true);
            _sketchManager.InsertSketch(false);
            _sketchManager.CreateCornerRectangle(0.025, 0.055, 0, 0.085, 0, 0);
            FeatureCut(0.015);
            _modelDoc2.ClearSelection();
        }
    }
}