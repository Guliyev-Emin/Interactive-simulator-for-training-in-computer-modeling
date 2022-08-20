using System.Windows.Forms;

namespace GraduationProject;

public class Message
{
    public static void ErrorMessage(string text)
    {
        MessageBox.Show(text, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void WarningMessage(string text)
    {
        MessageBox.Show(text, @"Уведмление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}