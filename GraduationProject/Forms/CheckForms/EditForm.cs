using System.Collections.Generic;
using System.Windows.Forms;

namespace GraduationProject.CheckForms;

public partial class EditForm : Form
{
    public EditForm()
    {
        InitializeComponent();
    }
    
    public void GetEditForm(List<GroupBox> gb)
    {
        InitializeComponent();
        foreach (var groupBox in gb)
        {
            AddEditForm(groupBox);
        }
    }

    public void AddEditForm(GroupBox gb)
    {
        editPanel.RowCount++;
        editPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        editPanel.Controls.Add(gb);
    }

    public void CloseEditForm(GroupBox gb)
    {
        editPanel.Controls.Remove(gb);
        editPanel.RowCount--;
    }
}