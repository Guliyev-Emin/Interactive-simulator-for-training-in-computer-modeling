using System;
using System.Windows.Forms;
using GraduationProject.ModelObjects.Objects;

namespace GraduationProject;

public partial class AuthorizationForm : Form
{
    public const string Teacher = "Teacher";
    //private const string TeacherPassword = "!TeacheR@2023";
    private const string TeacherPassword = "1";
    public const string Student = "Student";
    //private const string StudentPassword = "student@1397";
    private const string StudentPassword = "1";
    public static User User;
    
    public AuthorizationForm()
    {
        InitializeComponent();
    }

    private void authorizationButton_Click(object sender, EventArgs e)
    {
        User = new User();
        switch (userNameText.Text)
        {
            case Teacher when passwordText.Text.Equals(TeacherPassword):
                User.Type = Teacher;
                break;
            case Student when passwordText.Text.Equals(StudentPassword):
                User.Type = Student;
                break;
            default:
                MessageBox.Show(@"Неправильный логин или пароль", @"Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameText.Text = string.Empty;
                passwordText.Text = string.Empty;
                return;
        }
        Hide();
        var mainForm = new MainForm();
        mainForm.Show();
        mainForm.Closed += (s, args) => Close();
    }
    
}