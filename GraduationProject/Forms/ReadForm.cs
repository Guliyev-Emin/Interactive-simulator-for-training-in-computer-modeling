using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GraduationProject.Construction;
using GraduationProject.Controller;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public partial class ReadForm : Form
    {
        public ReadForm()
        {
            InitializeComponent();
            
            var toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(lineCountTextBox, "Количество отрезков в эскизе");
        }

        public void Forms()
        {
            treeView1.BeginUpdate();
            Reader.TreeNode = new TreeNode("Открыть дерево проекта");
            Reader.SketchInfos = new List<SketchInfo>();
            var treeNode = Reader.ProjectReading(
                Connection.FeatureManager.GetFeatureTreeRootItem2((int) swFeatMgrPane_e.swFeatMgrPaneBottom));
            treeNode.Expand();
            treeView1.Nodes.Add(treeNode);
            treeView1.EndUpdate();
            foreach (var sketchName in Reader.SketchInfos)
            {
                sketchNameComboBox.Items.Add(sketchName.SketchName);
            }
        }

        private void exit_buttonClick(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void checkLine_Click(object sender, EventArgs e)
        {
            if (!Connection.ConnectionTest()) return;
            if ((sketchNameComboBox.SelectedItem is null) || lineCountTextBox.Text == "") return;
            var selectedState = sketchNameComboBox.SelectedItem?.ToString();
            var lineCount = lineCountTextBox.Text;
            var line = Controller.Controller.ControllerLineLength(selectedState, int.Parse(lineCount));
            MessageBox.Show(line);
            var controller = Controller.Controller.ControllerLinePosition(selectedState);
            MessageBox.Show(controller);
        }

        private void reReading_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Forms();
        }

        private void checkButtonModel_Click(object sender, EventArgs e)
        {
            var qualityControl = new QualityControl();
            qualityControl.Show();
        }

        private void writeToFile_Click(object sender, EventArgs e)
        {
            Reader.SavingModelPropertiesToAFile();
        }
    }
}