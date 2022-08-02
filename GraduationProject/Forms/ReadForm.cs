using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GraduationProject.Construction;
using GraduationProject.Controllers;
using GraduationProject.Model.Models;
using SolidWorks.Interop.swconst;
using Comparer = GraduationProject.Controllers.Comparer;

namespace GraduationProject
{
    public partial class ReadForm : Form
    {
        public ReadForm()
        {
            InitializeComponent();
        }

        public void SetSolidWorksProjectTree()
        {
            SolidWorksProjectTree.BeginUpdate();
            Reader.SolidWorksProjectTree = new TreeNode("Открыть дерево проекта");
            Reader.SketchInfos = new List<SketchInfo>();
            var treeNode = Reader.ProjectReading(
                Connection.FeatureManager.GetFeatureTreeRootItem2((int) swFeatMgrPane_e.swFeatMgrPaneBottom));
            treeNode.Expand();
            SolidWorksProjectTree.Nodes.Add(treeNode);
            SolidWorksProjectTree.EndUpdate();
        }

        private void exit_buttonClick(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void reReading_Click(object sender, EventArgs e)
        {
            SolidWorksProjectTree.Nodes.Clear();
            SetSolidWorksProjectTree();
        }

        private void checkButtonModel_Click(object sender, EventArgs e)
        {
            initialModelPropertiesTextBox.Text = File.ReadAllText(@"..\..\Files\Свойства модели.txt").Replace("\n", Environment.NewLine);
            userModelPropertiesTextBox.Text = Controller.CreateTemplateModelProperties().Replace("\n", Environment.NewLine);
            Controller.GetLines();
            foreach (var result in Comparer.ComparerResults)
            {
                correctQualityResult.Text += result.Replace("\n", Environment.NewLine);
            }
            foreach (var result in Comparer.ErrorResult.Distinct())
            {
                errorQualityResultTextBox.Text += result.Replace("\n", Environment.NewLine);
            }
           
        }

        private void writeToFile_Click(object sender, EventArgs e)
        {
            Controller.CreateTemplateModelProperties();
            Controller.SavingModelPropertiesToAFile(Controller.CreateTemplateModelProperties());
        }
    }
}