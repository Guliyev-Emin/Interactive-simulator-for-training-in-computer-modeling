using System;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

namespace GraduationProject
{
    public class Remove : Connection
    {
        private static bool _boolstatus;
        private static Feature _feature;
        private static Feature _featureForSketch;
        private static int _step = 0;
        private static object[] _sketchContours = null;
        private static int _nbrSketchContours = 0;
        private static Sketch _swSketch = default(Sketch);

        public static void RemoveFeature()
        {
            try
            {
                for (int i = 0; i < _modelDoc2.GetFeatureCount() - 1; i++)
                {
                    _feature = (Feature) _modelDoc2.FeatureByPositionReverse(i);
                    _featureForSketch = (Feature) _modelDoc2.FeatureByPositionReverse(i + 1);
                    _swSketch = (Sketch) _featureForSketch.GetSpecificFeature2();
                    if (_feature != null)
                    {
                        _boolstatus = _modelDoc2.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0,
                            null, 0);
                        _modelDoc2.EditDelete();

                        if (_swSketch != null)
                        {
                            _sketchContours = (object[]) _swSketch.GetSketchContours();
                            _nbrSketchContours = _sketchContours.Length;

                            _boolstatus = _modelDoc2.Extension.SelectByID2(_featureForSketch.Name, "SKETCH", 0, 0, 0,
                                false, 0, null, 0);
                            _modelDoc2.EditDelete();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                
            }
        }

        public static void StepRemove()
        {
            _feature = (Feature) _modelDoc2.FeatureByPositionReverse(_step);
            _featureForSketch = (Feature) _modelDoc2.FeatureByPositionReverse(_step + 1);
            _swSketch = (Sketch) _featureForSketch.GetSpecificFeature2();
            if (_feature != null)
            {
                //MessageBox.Show(_feature.Name + @" [" + _feature.GetTypeName() + @"]");
                _boolstatus = _modelDoc2.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
                _modelDoc2.EditDelete();

                if (_swSketch != null)
                {
                    _sketchContours = (object[]) _swSketch.GetSketchContours();
                    _nbrSketchContours = _sketchContours.Length;

                    //MessageBox.Show(_featureForSketch.Name + @" [" + _featureForSketch.GetTypeName() + @"]");
                    _boolstatus = _modelDoc2.Extension.SelectByID2(_featureForSketch.Name, "SKETCH", 0, 0, 0, false, 0, null, 0);
                    _modelDoc2.EditDelete();
                    Drawing._step--;
                }
            }
        }
    }
}