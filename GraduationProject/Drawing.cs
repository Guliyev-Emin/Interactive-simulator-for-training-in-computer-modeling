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

        public static int _step;

        private void connect_button_Click(object sender, EventArgs eventArgs)
        {
            Connection.AppConnection();
        }

        private void step_button_Click(object sender, EventArgs eventArgs)
        {
            Connection.ConnectionTest();

            switch (_step)
            {
                case 0:
                {
                    StepDrawing.Step1();
                    _step++;
                    break;
                }
                case 1:
                {
                    StepDrawing.Step2();
                    _step++;
                    break;
                }
                case 2:
                {
                    StepDrawing.Step3();
                    _step++;
                    break;
                }
                case 3:
                {
                    StepDrawing.Step4();
                    _step++;
                    break;
                }
                case 4:
                {
                    StepDrawing.Step5();
                    _step++;
                    break;
                }
                // case 5:
                // {
                //     StepDrawing.Step6();
                //     _step++;
                //     break;
                // }
                // case 6:
                // {
                //     StepDrawing.Step7();
                //     _step++;
                //     break;
                // }
            }
        }

        private void immediately_button_Click(object sender, EventArgs eventArgs)
        {
            Connection.ConnectionTest();
            StepDrawing.Step1();
            StepDrawing.Step2();
            StepDrawing.Step3();
            StepDrawing.Step4();
            StepDrawing.Step5();
            // StepDrawing.Step6();
            // StepDrawing.Step7();
        }

        private void remove_button_Click(object sender, EventArgs eventArgs)
        {
            Connection.ConnectionTest();
            Remove.RemoveFeature();
        }
        
        private void remove_step_button_Click(object sender, EventArgs eventArgs)
        {
            Connection.ConnectionTest();
            Remove.StepRemove();
        }

        private void read_button_Click(object sender, EventArgs eventArgs)
        {
            
        }
    }
}