using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject;

public class Connection
{
    protected static ModelDoc2 SwModel;
    protected static SketchManager SwSketchManager;
    public static FeatureManager SwFeatureManager;
    private static SldWorks _app;

    public static void AppConnection()
    {
        _app = null;
        SwModel = null;

        try
        {
            _app = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
        }
        catch
        {
            // ignored
        }

        if (_app != null)
        {
            try
            {
                SwModel = (ModelDoc2)_app.GetFirstDocument();
            }
            catch
            {
                // ignored
            }

            if (SwModel != null)
            {
                var text = $@"Подключение к ""{SwModel.GetTitle()}"" выполнено успешно!";
                Message.InformationMessage(text, @"Подключение к модели");

                const int prefToggle = (int)swUserPreferenceToggle_e.swInputDimValOnCreate;

                _app.SetUserPreferenceToggle(prefToggle, false);

                SwSketchManager = SwModel.SketchManager;
                SwFeatureManager = SwModel.FeatureManager;
            }
            else
            {
                Message.InformationMessage(@"Документ не найден!", @"Подключение к модели");
            }
        }
        else
        {
            Message.WarningMessage(@"Не удалось подключиться к документу!");
        }
    }

    public static bool ConnectionTest()
    {
        if (SwModel is not null) return true;
        Message.InformationMessage("Документ не найден!\nВыполните подключение к документу!", @"Подключение к модели");
        return false;
    }
}