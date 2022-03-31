using System;
using System.Windows.Forms;
using SolidWorks.Interop.swconst;

namespace GraduationProject
{
    public partial class ReadForm : Form
    {
        public ReadForm()
        {
            InitializeComponent();
        }

        public void Forms()
        {
            treeView1.BeginUpdate();
            Reader.TreeNode = new TreeNode("Открыть дерево проекта");
            var treeNode = Reader.ProjectReading(
                Connection.FeatureManager.GetFeatureTreeRootItem2((int) swFeatMgrPane_e.swFeatMgrPaneBottom));
            
            treeView1.Nodes.Add(treeNode);
            treeView1.EndUpdate();
        }

        private void exit_buttonClick(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}