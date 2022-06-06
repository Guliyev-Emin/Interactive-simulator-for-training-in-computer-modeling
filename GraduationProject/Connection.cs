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
                    MessageBox.Show(@"Подключение выполнено. Документ найден.", @"Уведомление");

                    const int prefToggle = (int) swUserPreferenceToggle_e.swInputDimValOnCreate;

                    _app.SetUserPreferenceToggle(prefToggle, false);

                    SketchManager = ModelDoc2.SketchManager;
                    FeatureManager = ModelDoc2.FeatureManager;
                }
                else
                    MessageBox.Show(@"Документ не найден", @"Уведомление");
            }
            else
                MessageBox.Show(@"Не удалось подключиться", @"Уведомление");
        }

        public static bool ConnectionTest()
        {
            if (ModelDoc2 is not null) return true;
            MessageBox.Show(@"Документ не найден!", @"Уведомление");
            return false;
        }
    }
}