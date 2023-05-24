using System.Windows.Forms;
using GraduationProject.CheckForms.FormConstructors;
using GraduationProject.ModelObjects.Objects.CheckObjects;

namespace GraduationProject.CheckForms;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        InitializeComponent();
    }
    
    public void ElementaryAdd(ElementaryTask task)
    {
        tableLayoutPanel1.Controls.Add(ConstructorForm.GetElementaryView(task));
    }

    public void AddDerivedTask(DerivedTask derivedTask)
    {
        foreach (var groupBox in ConstructorForm.GetDerivedView(derivedTask)) tableLayoutPanel1.Controls.Add(groupBox);
    }
}