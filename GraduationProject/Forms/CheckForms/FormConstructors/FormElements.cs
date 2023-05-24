using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using GraduationProject.Controllers.CheckControllers.Controllers;

namespace GraduationProject.CheckForms.FormConstructors;

public class FormElements
{
    protected const string TaskName = "TaskName";
    protected const string TaskContent = "TaskContent";
    protected const string TaskObjectCount = "TaskCountObject";
    protected const string TaskTrueResult = "TaskTrueResult";
    protected const string TaskFalseResult = "TaskFalseResult";
    protected const string PointXAxis = "PointXAxis";
    protected const string PointYAxis = "PointYAxis";
    protected const string PointZAxis = "PointZAxis";
    protected const string LineStartX = "LineStartX";
    protected const string LineStartY = "LineStartY";
    protected const string LineStartZ = "LineStartZ";
    protected const string LineEndX = "LineEndX";
    protected const string LineEndY = "LineEndY";
    protected const string LineEndZ = "LineEndZ";
    protected const string LineSize = "LineSize";
    protected const string ArcRadius = "ArcRadius";
    protected const string TaskButtonsPanel = "ButtonPanel";
    protected const string Minimum = "Минимум";
    protected const string Maximum = "Максимум";
    protected const string Size = "Size";
    protected const string Axis = "Axis";
    protected const string TasksForBaseTasks = "tasksForBaseTasks";
    protected const string ExtrusionSize = "ExtrusionSize";
    protected const string CutSize = "CutSize";

    protected static NumericUpDown CreateNumericUpDown(string name, bool decimalValue)
    {
        var numeric = new NumericUpDown
        {
            Maximum = 100000,
            Minimum = -100000,
            Name = name,
            UpDownAlign = LeftRightAlignment.Left,
            Dock = DockStyle.Fill,
            Value = 0
        };
        if (!decimalValue) return numeric;
        numeric.DecimalPlaces = 7;
        return numeric;
    }

    protected static ComboBox CreateComboBox(string name)
    {
        return new ComboBox
        {
            Dock = DockStyle.Fill,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Name = name
        };
    }
    
    protected static ComboBox CreateComboBox(string name, List<string> items)
    {
        var cb = CreateComboBox(name);
        items.ForEach(item => cb.Items.Add(item));
        return cb;
    }

    protected static TextBox CreateTextBox(string name)
    {
        return new TextBox
        {
            Dock = DockStyle.Fill,
            Name = name
        };
    }

    protected static TextBox CreateTextBox(string name, string text)
    {
        return new TextBox
        {
            Dock = DockStyle.Fill,
            Name = name,
            Text = text,
            ReadOnly = true
        };
    }

    protected static Label CreateLabel(string text)
    {
        return new Label
        {
            Dock = DockStyle.Fill,
            Text = text,
            TextAlign = ContentAlignment.MiddleCenter
        };
    }

    protected static Button CreateButton(string name, string text)
    {
        return new Button
        {
            Text = text,
            Name = name,
            Dock = DockStyle.Fill,
            AutoSize = true
        };
    }

    protected static CheckBox CreateCheckBox(string name, string text)
    {
        return new CheckBox
        {
            Name = name,
            Text = text,
            AutoSize = true,
            Dock = DockStyle.Fill
        };
    }

    protected static GroupBox CreateGroupBox(string name, string text)
    {
        return new GroupBox
        {
            Name = name,
            Text = text,
            Dock = DockStyle.Fill,
            AutoSize = true
        };
    }

    protected static TableLayoutPanel CreateTableLayoutPanel(string name, uint column, uint row)
    {
        return new TableLayoutPanel
        {
            ColumnCount = (int)column,
            RowCount = (int)row,
            Dock = DockStyle.Fill,
            Name = name,
            AutoSize = true,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        };
    }
    
    public void StandartLabelForm(ref TableLayoutPanel panel, params Control[] labels)
    {
        panel.Controls.Add(CreateLabel("Наименование задачи"), 0, 0);
        panel.Controls.Add(CreateLabel("Содержание задачи"), 0, 1);
        var row = 2;
        foreach (var control in labels)
        {
            panel.Controls.Add(control, 0, row++);
        }
        panel.Controls.Add(CreateLabel("Правильный результат"), 0, panel.RowCount - 3);
        panel.Controls.Add(CreateLabel("Неправильный результат"), 0, panel.RowCount - 2);
    }
    
    public void StandartLabelForm(ref TableLayoutPanel panel)
    {
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.Controls.Add(CreateLabel("Наименование задачи"), 0, 0);
        panel.Controls.Add(CreateLabel("Содержание задачи"), 0, 1);
        panel.Controls.Add(CreateLabel("Правильный результат"), 0, 2);
        panel.Controls.Add(CreateLabel("Неправильный результат"), 0, 3);
    }

    public void StandartInnerForm(ref TableLayoutPanel panel, params Control[] controls)
    {
        panel.Controls.Add(CreateTextBox(TaskName), 1, 0);
        panel.Controls.Add(CreateTextBox(TaskContent), 1, 1);
        var row = 2;
        foreach (var control in controls)
        {
            panel.Controls.Add(control, 1, row++);
        }
        panel.Controls.Add(CreateTextBox(TaskTrueResult), 1, panel.RowCount - 3);
        panel.Controls.Add(CreateTextBox(TaskFalseResult), 1, panel.RowCount - 2);
    }
    
    public void StandartInnerForm(ref TableLayoutPanel panel)
    {
        panel.Controls.Add(CreateTextBox(TaskName), 1, 0);
        panel.Controls.Add(CreateTextBox(TaskContent), 1, 1);
        panel.Controls.Add(CreateTextBox(TaskTrueResult), 1, 2);
        panel.Controls.Add(CreateTextBox(TaskFalseResult), 1, 3);
    }

    protected static TableLayoutPanel CreateMainTableLayotPanel(string name, uint column, uint row)
    {
        var taskPanel = CreateTableLayoutPanel(name, column, row);
        taskPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        taskPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        for (var i = 0; i < taskPanel.RowCount; i++)
        {
            if (i == taskPanel.RowCount - 1)
            {
                taskPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                continue;
            }
            taskPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        }
        return taskPanel;
    }

    protected static bool? DialogWindow()
    {
        var result = MessageBox.Show(@"Перезаписать данные в существующую задачу?", @"Уведомление",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        return result switch
        {
            DialogResult.Yes => true,
            DialogResult.No => false,
            _ => null
        };
    }

    protected static void LoadDataInTextBox(string name, TableLayoutControlCollection controls, CheckBox checkBox)
    {
        var task = TaskController.GetElementaryTask(name);
        checkBox.Checked = task.Reverse;
        foreach (Control control in controls)
            switch (control.Name)
            {
                case TaskName:
                    control.Text = task.TaskName;
                    continue;
                case TaskContent:
                    control.Text = task.TaskContent;
                    continue;
                case TaskObjectCount:
                    control.Text = task.CountTask.ObjectCount.ToString();
                    continue;
                case TaskTrueResult:
                    control.Text = task.TaskTrueResult;
                    continue;
                case TaskFalseResult:
                    control.Text = task.TaskFalseResult;
                    continue;
                case PointXAxis:
                    control.Text = task.PointTask.Point.X.ToString(CultureInfo.InvariantCulture);
                    continue;
                case PointYAxis:
                    control.Text = task.PointTask.Point.Y.ToString(CultureInfo.InvariantCulture);
                    continue;
                case PointZAxis:
                    control.Text = task.PointTask.Point.Z.ToString(CultureInfo.InvariantCulture);
                    continue;
            }
    }

    
}