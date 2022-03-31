using System.Text.RegularExpressions;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

namespace GraduationProject
{
    public class Remove : Connection
    {
        private static bool _boolstatus;
        private static Feature _feature;
        private static Feature _featureForSketch;
        private static readonly int _step = 0;
        private static object[] _sketchContours;
        private static int _nbrSketchContours;
        private static Sketch _swSketch = default;

        public static void RemoveFeature()
        {
            try
            {
                for (var i = 0; i < _modelDoc2.GetFeatureCount() - 1; i++)
                {
                    _feature = (Feature) _modelDoc2.FeatureByPositionReverse(i);
                    _featureForSketch = (Feature) _modelDoc2.FeatureByPositionReverse(i + 1);
                    _swSketch = (Sketch) _featureForSketch.GetSpecificFeature2();
                    if (_feature != null)
                    {
                        MessageBox.Show(_feature.Name + "-----" + _feature.GetTypeName() + "------" + _feature.GetTypeName2());
                        
                        if (new Regex(@"Эскиз(\w*)").Match(_feature.Name).Success)
                        {
                            _boolstatus = _modelDoc2.Extension.SelectByID2(_feature.Name, "SKETCH", 0, 0, 0,
                                false, 0, null, 0);
                            _modelDoc2.EditDelete();
                        }
                        else
                        {
                            _boolstatus = _modelDoc2.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0,
                                null, 0);
                            _modelDoc2.EditDelete();
                        }

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
            catch
            {
                // ignored
            }
        }
        
        public static void StepRemove()
        {
            _feature = (Feature) _modelDoc2.FeatureByPositionReverse(_step);
            _featureForSketch = (Feature) _modelDoc2.FeatureByPositionReverse(_step + 1);
            _swSketch = (Sketch) _featureForSketch.GetSpecificFeature2();

            if (_feature != null)
            {
                _boolstatus =
                    _modelDoc2.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
                _modelDoc2.EditDelete();

                if (_swSketch != null)
                {
                    _sketchContours = (object[]) _swSketch.GetSketchContours();
                    _nbrSketchContours = _sketchContours.Length;
                    // SKETCHSEGMENT - может это использовать   
                    _boolstatus = _modelDoc2.Extension.SelectByID2(_featureForSketch.Name, "SKETCH", 0, 0, 0, false, 0,
                        null, 0);
                    _modelDoc2.EditDelete();
                    MessageBox.Show(@"Элемент: " + _feature.Name + @" ,типа: " + _feature.GetTypeName() + @" был успешно удален!");
                    Drawing.Step--;
                }
            }
        }
    }
}