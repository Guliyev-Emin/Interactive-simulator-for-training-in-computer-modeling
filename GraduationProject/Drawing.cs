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

        private void connect_button_Click(object sender, EventArgs eventArgs)
        {
            Connection.AppConnection();
        }

        private void step_button_Click(object sender, EventArgs eventArgs)
        {
            if (Connection.ConnectionTest())
            {
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
        }

        private void immediately_button_Click(object sender, EventArgs eventArgs)
        {
            if (Connection.ConnectionTest())
            {
                StepDrawing.Step1();
                StepDrawing.Step2();
                StepDrawing.Step3();
                StepDrawing.Step4();
                StepDrawing.Step5();
            }
        }

        private void remove_button_Click(object sender, EventArgs eventArgs)
        {
            if (Connection.ConnectionTest())
                Remove.RemoveFeature();
        }
        
        private void remove_step_button_Click(object sender, EventArgs eventArgs)
        {
            if (Connection.ConnectionTest())
                Remove.StepRemove();
        }

        private void read_button_Click(object sender, EventArgs eventArgs)
        {
            if (Connection.ConnectionTest())
                Reader.Read();
        }
    }
}