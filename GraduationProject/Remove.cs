using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

namespace GraduationProject
{
    public class Remove : Connection
    {
        private static Sketch _sketch;
        private static bool _boolstatus;
        private static Feature _feature;
        private static int i;

        public static void RemoveFeature()
        {
            for (i = 0; i < _modelDoc2.GetFeatureCount() - 1; i++)
            {
                _feature = (Feature) _modelDoc2.FeatureByPositionReverse(i);
                
                if (_feature != null)
                {
                    MessageBox.Show(_feature.Name + @" [" + _feature.GetTypeName() + @"]");
                    _boolstatus = _modelDoc2.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
                    _modelDoc2.EditDelete();
                    //Drawing._step--;
                    
                    swSketch = (Sketch) _feature.GetSpecificFeature2();

                    if (swSketch != null)
                    {
                        sketchContours = (object[]) swSketch.GetSketchContours();
                        nbrSketchContours = sketchContours.Length;

                        MessageBox.Show(_feature.Name + @"123234 [" + _feature.GetTypeName() + @"]");
                        _boolstatus = _modelDoc2.Extension.SelectByID2(_feature.Name, "SKETCH", 0, 0, 0, false, 0, null, 0);
                        _modelDoc2.EditDelete();
                    }
                    
                    
                    
                    
                }
            }
        }

        static object[] sketchContours = null;
        static int nbrSketchContours = 0;
        static Sketch swSketch = default(Sketch);

        public static void RemoveSketch()
        {
            for (i = 0; i < _modelDoc2.GetFeatureCount() - 1; i++)
            {
                //_feature = (Feature) _modelDoc2.FeatureByPositionReverse(i);
                _feature = (Feature) _modelDoc2.FeatureByPositionReverse(i);

                swSketch = (Sketch) _feature.GetSpecificFeature2();

                if (swSketch != null)
                {
                    sketchContours = (object[]) swSketch.GetSketchContours();
                    nbrSketchContours = sketchContours.Length;

                    MessageBox.Show(_feature.Name + @" [" + _feature.GetTypeName() + @"]");
                    _boolstatus = _modelDoc2.Extension.SelectByID2(_feature.Name, "SKETCH", 0, 0, 0, false, 0, null, 0);
                    _modelDoc2.EditDelete();
                }
            }
        }
    }
}