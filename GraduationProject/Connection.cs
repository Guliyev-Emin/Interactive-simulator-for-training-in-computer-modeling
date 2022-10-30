using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GraduationProject;

public class Connection
{
    protected static ModelDoc2 SwModel;
    protected static SketchManager SwSketchManager;
    protected static FeatureManager SwFeatureManager;
    protected static SldWorks SwApp;

    /// <summary>
    /// 
    /// </summary>
    public static void AppConnection()
    {
        SwApp = null;
        SwModel = null;

        try
        {
            SwApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
        }
        catch
        {
            // ignored
        }

        if (SwApp != null)
        {
            try
            {
                SwModel = (ModelDoc2)SwApp.GetFirstDocument();
            }
            catch
            {
                // ignored
            }

            if (SwModel != null)
            {
                var text = $@"Подключение к ""{GetModelName()}"" выполнено успешно!";

                const int prefToggle = (int)swUserPreferenceToggle_e.swInputDimValOnCreate;

                SwApp.SetUserPreferenceToggle(prefToggle, false);

                SwSketchManager = SwModel.SketchManager;
                SwFeatureManager = SwModel.FeatureManager;
                Message.InformationMessage(text, @"Подключение к модели");
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected static string GetModelName()
    {
        return SwModel.GetTitle();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static bool ConnectionTest()
    {
        if (SwModel is not null) return true;
        Message.InformationMessage("Документ не найден!\nВыполните подключение к документу!", @"Подключение к модели");
        return false;
    }
}