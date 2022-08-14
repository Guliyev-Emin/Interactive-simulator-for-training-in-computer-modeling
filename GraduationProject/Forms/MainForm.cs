using System;
using System.Windows.Forms;
using GraduationProject.Construction;

namespace GraduationProject;

public partial class MainForm : Form
{
    public static int Step;

    public MainForm()
    {
        InitializeComponent();
    }

    private void ConnectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Connection.AppConnection();
    }


    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
        Environment.Exit(0);
    }

    private void StepDrawingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Connection.ConnectionTest()) return;
        switch (Step)
        {
            case 0:
            {
                Сonstruction.Step1();
                Step++;
                break;
            }
            case 1:
            {
                Сonstruction.Step2();
                //Сonstruction.Step5();
                Step++;
                break;
            }
            case 2:
            {
                Сonstruction.Step3();
                //Сonstruction.Step2();
                Step++;
                break;
            }
            case 3:
            {
                Сonstruction.Step4();
                //Сonstruction.Step3();
                Step++;
                break;
            }
            case 4:
            {
                Сonstruction.Step5();
                //Сonstruction.Step4();
                Step++;
                break;
            }
        }
    }

    private void FullDrawingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Connection.ConnectionTest()) return;
        Сonstruction.Step1();
        Сonstruction.Step2();
        Сonstruction.Step3();
        Сonstruction.Step4();
        Сonstruction.Step5();
    }

    private void StepDeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Connection.ConnectionTest())
            Remove.StepRemove();
    }

    private void FullDeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Connection.ConnectionTest())
            Remove.RemoveFeature();
    }

    private void TreeReadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Connection.ConnectionTest()) return;
        var readForm = new ReadForm();
        readForm.Show();
        readForm.SetSolidWorksProjectTree();
    }
}