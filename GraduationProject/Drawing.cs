using System;
using System.Windows.Forms;

namespace GraduationProject
{
    public partial class Drawing : Form
    {
        public Drawing()
        {
            InitializeComponent();
        }

        public static int Step;

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
                    StepDrawing.Step1();
                    Step++;
                    break;
                }
                case 1:
                {
                    StepDrawing.Step2();
                    Step++;
                    break;
                }
                case 2:
                {
                    StepDrawing.Step3();
                    Step++;
                    break;
                }
                case 3:
                {
                    StepDrawing.Step4();
                    Step++;
                    break;
                }
                case 4:
                {
                    StepDrawing.Step5();
                    Step++;
                    break;
                }
            }
        }

        private void FullDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Connection.ConnectionTest()) return;
            StepDrawing.Step1();
            StepDrawing.Step2();
            StepDrawing.Step3();
            StepDrawing.Step4();
            StepDrawing.Step5();
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
            readForm.Forms();
        }
        
    }
}