using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GraduationProject.CheckForms;

public partial class AddTasksForm : Form
{
    public AddTasksForm()
    {
        InitializeComponent();
    }
    
    public void AddNames(List<string> formNames)
    {
        formNames.ForEach(name => comboBox1.Items.Add(name));
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        CheckForm.AddFormName = comboBox1.SelectedItem.ToString();
    }
}