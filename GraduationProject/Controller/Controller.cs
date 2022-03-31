using System.Windows.Forms;

namespace GraduationProject.Controller
{
    public class Controller
    {
        private bool ControllerLength(int n)
        {
            bool res;
            string message;
            if (n == Reader.LineCount)
            {
                message = "Содержит " + n + " отрезков.";
                res = true;
            }
            else
            {
                res = false;
                var i = n > Reader.LineCount ? n - Reader.LineCount : Reader.LineCount - n;
                message = @"Не содержит " + n + " отрезков.\n" + "Не хватает " + i + " отрезкоы!";
            }

            MessageBox.Show(message);
            return res;
        }
        
    }
}