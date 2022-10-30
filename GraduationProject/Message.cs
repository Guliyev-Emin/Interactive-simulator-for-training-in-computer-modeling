using System.Windows.Forms;

namespace GraduationProject;

public static class Message
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    public static void ErrorMessage(string text)
    {
        MessageBox.Show(text, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    public static void WarningMessage(string text)
    {
        MessageBox.Show(text, @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="caption"></param>
    public static void InformationMessage(string text, string caption)
    {
        MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}