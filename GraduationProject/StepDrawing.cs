using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public class StepDrawing : Connection
    {
        private static Feature _firstFeature, _secondFeature, _feature;
        private static dynamic _faces;
        private static Entity _entity;

        private static Feature FeatureExtrusion(double deepth, bool Sd = true, bool dir = false)
        {
            // если Sd = true, то вытягивание в одну сторону, если ложь, тогда в обе стороны!
            // НЕ ТРОГАТЬ!!!!!
            if (Sd)
                return _modelDoc2.FeatureManager.FeatureExtrusion2(Sd, false, dir,
                (int) swEndConditions_e.swEndCondBlind, (int) swEndConditions_e.swEndCondBlind,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, true,
                true, true, 0, 0, false);
            return _modelDoc2.FeatureManager.FeatureExtrusion2(false, false, dir,
                (int) swEndConditions_e.swEndCondBlind, (int) swEndConditions_e.swEndCondBlind,
                deepth, deepth, false, false, false, false, 0, 0, false, false, false, false, true,
                true, true, 0, 0, false);
        }

        // Тут все понятно!
        private static void SelectPlane(string name, string obj = "PLANE")
        {
            _modelDoc2.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
        }

        // Легче научиться танком упровлять!
        private static void FeatureCut(double deepth, bool flip = false,
            swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
        {
            _modelDoc2.FeatureManager.FeatureCut2(true, flip, false, (int) mode, (int) mode,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
                false, false, false, false, false);
        }

        // первый прямоуголник
        public static void Step1()
        {
            SelectPlane("Сверху");
            _sketchManager.InsertSketch(true);
            //_sketchManager.CreateCornerRectangle(0, 0.055, 0, 0.085, 0, 0); 
            // Лучше промолчать!!!
            _sketchManager.CreateCenterRectangle(0, 0, 0, 0.055, 0.085 / 2, 0);
            _firstFeature = FeatureExtrusion(0.11/2);
            _modelDoc2.ClearSelection();
            _modelDoc2.ClearSelection2(true);
            
        }

        public static void Step2()
        {
            SelectPlane("Справа");
            _sketchManager.InsertSketch(false);
            // *Цензура*
            _sketchManager.CreateCornerRectangle((0.085/2), 0.055, 0, (0.085/2) - 0.04, 0.105, 0.04);
            //вытягивание в две стороны
            _secondFeature = FeatureExtrusion(0.11/2, false);
            _modelDoc2.ClearSelection();
        }

        public static void Step3()
        {
            // Конченный GetFaces?! Про него даже в документации не написано!
            _faces = (dynamic[]) _firstFeature.GetFaces();
            _entity = _faces[3] as Entity;
            _entity!.Select(true);
            _sketchManager.InsertSketch(true);
            _sketchManager.CreateLine(-(0.085 / 2) + 0.04, 0.085, 0, (0.085 / 2) - 0.025, 0.055, 0);
            // создаем ребро (rib)
            // P.S. спустя 3 дня перестал работать!! Так что, тоже фиг знает как работает!
            // P.S. 5 дней спустя: *Цензура*
            _modelDoc2.FeatureManager.InsertRib(false, true, 0.01, 
                 0, false, false, true, 
                 0, false, false);

            // _modelDoc2.Extension.SelectByID2("Справа", "PLANE", 0, 0, 0, false, 0, null, 0);
            // _modelDoc2.Extension.SelectByID2("Ребро1", "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
            //
            // _modelDoc2.ClearSelection2(true);
            
            // КОНЧЕННЫЙ ВЫБОР ПЛОСКОСТИ И ФИГУРЫ!!!!! *Цензура*
            _modelDoc2.Extension.SelectByID2("Справа", "PLANE", 0, 0, 0, false, 2, null, 0);
            // ОБЯЗАТЕЛЬНО!!! SOLIDBODY!!!! *Цензура*
            _modelDoc2.Extension.SelectByID2("Ребро1", "SOLIDBODY", 0, 0, 0, true, 256, null, 0);
            // С*ка! Как оно РАБОТАЕТ!!!!!!
            _feature = (Feature) _featureManager.InsertMirrorFeature2(true, true, true, false,
                (int) swFeatureScope_e.swFeatureScope_AllBodies);
            
            _modelDoc2.ClearSelection2(true);
        }

        public static void Step4()
        {
            _faces = (dynamic[]) _secondFeature.GetFaces();
            _entity = _faces[1] as Entity;
            _entity!.Select(true);
            _sketchManager.InsertSketch(false);
            _sketchManager.CreateArc(0, 0.105, 0, -0.033, 0.105, 0, 0.033, 0.105, 0, +1);
            _sketchManager.CreateLine(-0.033, 0.105, 0, 0.033, 0.105, 0);
            FeatureCut(0.04);
            _modelDoc2.ClearSelection();
        }

        public static void Step5()
        {
            _faces = (dynamic[]) _firstFeature.GetFaces();
            _entity = _faces[2] as Entity;
            _entity!.Select(true);
            _sketchManager.InsertSketch(false);
            _sketchManager.CreateCornerRectangle(-0.03, 0.055, 0, 0.03, 0, 0);
            FeatureCut(0.015);
            _modelDoc2.ClearSelection();
        }
    }
}