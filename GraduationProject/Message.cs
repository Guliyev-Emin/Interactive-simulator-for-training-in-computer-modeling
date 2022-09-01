using System.Windows.Forms;

namespace GraduationProject;

public static class Message
{
    public static void ErrorMessage(string text)
    {
        MessageBox.Show(text, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void WarningMessage(string text)
    {
        MessageBox.Show(text, @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void InformationMessage(string text, string caption)
    {
        MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}