using System.Runtime.InteropServices;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public class Connection
    {
        protected static ModelDoc2 ModelDoc2;
        protected static SketchManager SketchManager;
        public static FeatureManager FeatureManager;
        private static SldWorks _app;

        public static void AppConnection()
        {
            _app = null;
            ModelDoc2 = null;

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
                    ModelDoc2 = (ModelDoc2) _app.GetFirstDocument();
                }
                catch
                {
                    // ignored
                }

                if (ModelDoc2 != null)
                {
                    MessageBox.Show(@"Подключение выполнено. Документ найден.");

                    var pref_toggle = (int) swUserPreferenceToggle_e.swInputDimValOnCreate;

                    _app.SetUserPreferenceToggle(pref_toggle, false);

                    SketchManager = ModelDoc2.SketchManager;
                    FeatureManager = ModelDoc2.FeatureManager;
                }
                else
                {
                    MessageBox.Show(@"Документ не найден");
                }
            }
            else
            {
                MessageBox.Show(@"Не удалось подключиться");
            }
        }

        public static bool ConnectionTest()
        {
            if (ModelDoc2 is null)
            {
                MessageBox.Show(@"Документ не найден!");
                return false;
            }

            return true;
        }
    }
}