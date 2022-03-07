using System.Runtime.InteropServices;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public class Connection
    {
        public static ModelDoc2 _modelDoc2;
        public static SketchManager _sketchManager;
        public static FeatureManager _featureManager;
        public static SldWorks _app;

        public static void AppConnection()
        {
            _app = null;
            _modelDoc2 = null;

            try
            {
                _app = (SldWorks) Marshal.GetActiveObject("SldWorks.Application");
            }
            catch
            {
                // ignored
            }

            if (_app != null)
            {
                try
                {
                    _modelDoc2 = (ModelDoc2) _app.GetFirstDocument();
                }
                catch
                {
                    // ignored
                }

                if (_modelDoc2 != null)
                {
                    MessageBox.Show("Подключение выполнено. Документ найден.");

                    var pref_toggle = (int) swUserPreferenceToggle_e.swInputDimValOnCreate;

                    _app.SetUserPreferenceToggle(pref_toggle, false);

                    _sketchManager = _modelDoc2.SketchManager;
                    _featureManager = _modelDoc2.FeatureManager;
                }
                else
                {
                    MessageBox.Show("Документ не найден");
                }
            }
            else
            {
                MessageBox.Show("Не удалось подключиться");
            }
        }

        public static bool ConnectionTest()
        {
            if (_modelDoc2 is null)
            {
                MessageBox.Show("Документ не найден!");
                return false;
            }

            return true;
        }
    }
}