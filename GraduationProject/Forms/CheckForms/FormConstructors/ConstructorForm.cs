using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GraduationProject.Controllers.CheckControllers.Controllers;
using GraduationProject.ModelObjects.Objects.CheckObjects;

namespace GraduationProject.CheckForms.FormConstructors;

public class ConstructorForm:FormElements
{
    protected static CheckedListBox ReadyMadeElementaryTasks;
    protected static CheckedListBox ReadyMadeBaseTasks;
    protected static CheckedListBox ReadyMadeDerivedTasks;
    protected static TableLayoutPanel ElementaryTaskForms;
    protected static TableLayoutPanel DerivedTaskForms;
    protected static TableLayoutPanel BaseTasksForms;
    protected readonly ContextMenuStrip _contextMenu;
    
    public ConstructorForm(ref CheckedListBox readyMadeElementaryTasks,
        ref TableLayoutPanel elementaryTaskForms, ref TableLayoutPanel baseTaskForms, ref CheckedListBox readyMadeBaseTasks,  ref TableLayoutPanel derivedTaskForms,
        ref CheckedListBox readyMadeDerivedTasks, ref ContextMenuStrip contextMenu)
    {
        ReadyMadeElementaryTasks = readyMadeElementaryTasks;
        ReadyMadeDerivedTasks = readyMadeDerivedTasks;
        ReadyMadeBaseTasks = readyMadeBaseTasks;
        BaseTasksForms = baseTaskForms;
        ElementaryTaskForms = elementaryTaskForms;
        DerivedTaskForms = derivedTaskForms;
        _contextMenu = contextMenu;
    }
    
    protected ConstructorForm(ref CheckedListBox readyMadeElementaryTasks,
        ref TableLayoutPanel elementaryTaskForms, ref TableLayoutPanel derivedTaskForms,
        ref CheckedListBox readyMadeDerivedTasks)
    {
        ReadyMadeElementaryTasks = readyMadeElementaryTasks;
        ReadyMadeDerivedTasks = readyMadeDerivedTasks;
        ElementaryTaskForms = elementaryTaskForms;
        DerivedTaskForms = derivedTaskForms;
    }
    
    public ConstructorForm(ref CheckedListBox readyMadeElementaryTasks,
        ref TableLayoutPanel elementaryTaskForms, ref TableLayoutPanel derivedTaskForms,
        ref CheckedListBox readyMadeDerivedTasks, ref ContextMenuStrip contextMenu)
    {
        ReadyMadeElementaryTasks = readyMadeElementaryTasks;
        ReadyMadeDerivedTasks = readyMadeDerivedTasks;
        ElementaryTaskForms = elementaryTaskForms;
        DerivedTaskForms = derivedTaskForms;
        _contextMenu = contextMenu;
    }

    public GroupBox CountMatchForm(string text, bool create)
    {
        var groupBox = CreateGroupBox("createElementaryTaskGroupBox", text);
        var mainTableLayotPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 6);
        AddingCountLabel(ref mainTableLayotPanel);
        mainTableLayotPanel.Controls.Add(CreateTextBox(TaskName));
        mainTableLayotPanel.Controls.Add(CreateTextBox(TaskContent));
        mainTableLayotPanel.Controls.Add(CreateLabel("Количество объеков"), 0, 2);
        mainTableLayotPanel.Controls.Add(CreateNumericUpDown(TaskObjectCount, false), 1, 2);
        mainTableLayotPanel.Controls.Add(CreateTextBox(TaskTrueResult));
        mainTableLayotPanel.Controls.Add(CreateTextBox(TaskFalseResult));
        mainTableLayotPanel.Controls.Add(CreateTaskButtonsPanel(text, mainTableLayotPanel.Controls, create), 1, 5);
        groupBox.Controls.Add(mainTableLayotPanel);
        return groupBox;
    }

    public GroupBox PointMatchForm(string text, bool add)
    {
        var groupBox = CreateGroupBox("pointMatch", text);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 8);
        layoutPanel.Controls.Add(CreateLabel("Наименование задачи"), 0, 0);
        layoutPanel.Controls.Add(CreateLabel("Содержание задачи"), 0, 1);
        layoutPanel.Controls.Add(CreateLabel("Значение по оси X"), 0, 2);
        layoutPanel.Controls.Add(CreateLabel("Значение по оси Y"), 0, 3);
        layoutPanel.Controls.Add(CreateLabel("Значение по оси Z"), 0, 4);
        layoutPanel.Controls.Add(CreateLabel("Правильный результат"), 0, 5);
        layoutPanel.Controls.Add(CreateLabel("Неправильный результат"), 0, 6);
        layoutPanel.Controls.Add(CreateTextBox(TaskName), 1, 0);
        layoutPanel.Controls.Add(CreateTextBox(TaskContent), 1, 1);
        layoutPanel.Controls.Add(CreateNumericUpDown(PointXAxis, true), 1, 2);
        layoutPanel.Controls.Add(CreateNumericUpDown(PointYAxis, true), 1, 3);
        layoutPanel.Controls.Add(CreateNumericUpDown(PointZAxis, true), 1, 4);
        layoutPanel.Controls.Add(CreateTextBox(TaskTrueResult), 1, 5);
        layoutPanel.Controls.Add(CreateTextBox(TaskFalseResult), 1, 6);
        layoutPanel.Controls.Add(CreateTaskButtonsPanel(groupBox.Text, layoutPanel.Controls, add), 1, 7);
        groupBox.Controls.Add(layoutPanel);
        return groupBox;
    }

    public GroupBox LocationPositionLineForm(string text, bool add)
    {
        var groupBox = CreateGroupBox("LocationPosition", text);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 7);
        layoutPanel.Controls.Add(CreateLabel("Наименование задачи"), 0, 0);
        layoutPanel.Controls.Add(CreateLabel("Содержание задачи"), 0, 1);
        layoutPanel.Controls.Add(CreateLabel("Ось"), 0, 2);
        layoutPanel.Controls.Add(CreateLabel("Значение"), 0, 3);
        layoutPanel.Controls.Add(CreateLabel("Правильный результат"), 0, 4);
        layoutPanel.Controls.Add(CreateLabel("Неправильный результат"), 0, 5);
        layoutPanel.Controls.Add(CreateTextBox(TaskName), 1, 0);
        layoutPanel.Controls.Add(CreateTextBox(TaskContent), 1, 1);
        layoutPanel.Controls.Add(CreateComboBox(Size, new List<string>{"X", "Y", "Z"}), 1, 2);
        layoutPanel.Controls.Add(CreateComboBox(Size, new List<string>{Minimum, Maximum}), 1, 3);
        layoutPanel.Controls.Add(CreateTextBox(TaskTrueResult), 1, 4);
        layoutPanel.Controls.Add(CreateTextBox(TaskFalseResult), 1, 5);
        layoutPanel.Controls.Add(CreateTaskButtonsPanel(groupBox.Text, layoutPanel.Controls, add), 1, 6);
        groupBox.Controls.Add(layoutPanel);
        return groupBox;
    }

    public GroupBox LineSizeForm(string text, bool add)
    {
        var groupBox = CreateGroupBox("LineSize", text);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 6);
        var sizeLabel = CreateLabel("Размер отрезка (мм)");
        var sizeInput = CreateNumericUpDown(LineSize, true);
        StandartLabelForm(ref layoutPanel, sizeLabel);
        StandartInnerForm(ref layoutPanel, sizeInput);
        StandartButtonsForm(ref layoutPanel, text, true);
        groupBox.Controls.Add(layoutPanel);
        return groupBox;
    }

    public GroupBox ExtrusionForm(string text)
    {
        var groupBox = CreateGroupBox("ExtrusionSize", text);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 6);
        var sizeLabel = CreateLabel("Длина выдавливания (мм)");
        var sizeInput = CreateNumericUpDown(ExtrusionSize, true);
        StandartLabelForm(ref layoutPanel, sizeLabel);
        StandartInnerForm(ref layoutPanel, sizeInput);
        StandartButtonsForm(ref layoutPanel, text, true);
        groupBox.Controls.Add(layoutPanel);
        return groupBox;
    }
    
    public GroupBox CutForm(string text)
    {
        var groupBox = CreateGroupBox("CutSize", text);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 6);
        var sizeLabel = CreateLabel("Длина выреза (мм)");
        var sizeInput = CreateNumericUpDown(CutSize, true);
        StandartLabelForm(ref layoutPanel, sizeLabel);
        StandartInnerForm(ref layoutPanel, sizeInput);
        StandartButtonsForm(ref layoutPanel, text, true);
        groupBox.Controls.Add(layoutPanel);
        return groupBox;
    }
    
    public GroupBox ArcRadiusForm(string text, bool add)
    {
        var groupBox = CreateGroupBox("ArcRadius", text);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 6);
        var sizeLabel = CreateLabel("Радиус окружности (мм)");
        var sizeInput = CreateNumericUpDown(ArcRadius, true);
        StandartLabelForm(ref layoutPanel, sizeLabel);
        StandartInnerForm(ref layoutPanel, sizeInput);
        StandartButtonsForm(ref layoutPanel, text, true);
        groupBox.Controls.Add(layoutPanel);
        return groupBox;
    }

    public GroupBox BaseTaskEdit(BaseTask task)
    {
        var gb = CreateGroupBox("editBaseTask", task.TaskName);
        var mainLayout = CreateTableLayoutPanel("mainLayout", 2, 2);
        var taskContentLayout = CreateTableLayoutPanel("contentLayout", 2, 4);
        var buttonsLayout = CreateTableLayoutPanel("buttonsLayout", 2, 1);
        var editButton = CreateButton("editButton", "Изменить");
        var lstBox = new ListBox
        {
            Name = "tasksForBaseTask",
            Dock = DockStyle.Fill,
            ContextMenuStrip = _contextMenu,
            HorizontalScrollbar = true
        };
        task.Sequence.ForEach(t => lstBox.Items.Add(t));
        StandartLabelForm(ref taskContentLayout);
        StandartInnerForm(ref taskContentLayout);
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        buttonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonsLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        
        editButton.Click += (sender, args) => 
        
        buttonsLayout.Controls.Add(new Button() {Text = "Изменить"});
        
        buttonsLayout.Controls.Add(new Button() {Text = "Закрыть"});
        mainLayout.Controls.Add(taskContentLayout, 0, 0);
        mainLayout.Controls.Add(lstBox, 1, 0);
        mainLayout.Controls.Add(buttonsLayout, 1, 1);
        gb.Controls.Add(mainLayout);
        return gb;
    }

    public GroupBox TestDerivedEdit(DerivedTask task)
    {
        var gb = CreateGroupBox("editDerivedTask", task.TaskName);
        var mainLayout = CreateTableLayoutPanel("mainLayout", 2, 2);
        var taskContentLayout = CreateTableLayoutPanel("contentLayout", 2, 4);
        var buttonsLayout = CreateTableLayoutPanel("buttonsLayout", 2, 1);
        var lstBox = new ListBox
        {
            Name = "tasksForDerivedTask",
            Dock = DockStyle.Fill,
            ContextMenuStrip = _contextMenu,
            HorizontalScrollbar = true
        };
        task.Sequence.ForEach(t => lstBox.Items.Add(t));
        StandartLabelForm(ref taskContentLayout);
        StandartInnerForm(ref taskContentLayout);
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        buttonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonsLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        buttonsLayout.Controls.Add(new Button() {Text = "Добавить"});
        buttonsLayout.Controls.Add(new Button() {Text = "Закрыть"});
        mainLayout.Controls.Add(taskContentLayout, 0, 0);
        mainLayout.Controls.Add(lstBox, 1, 0);
        mainLayout.Controls.Add(buttonsLayout, 1, 1);
        gb.Controls.Add(mainLayout);
        return gb;
    }

    public GroupBox GetDerivedEditForm(DerivedTask task)
    {
        // TODO: Реализовать редактирование производной задачи
        var groupBox = CreateGroupBox("editDerivedTaskGroupBox", task.TaskName);
        var mainTableLayotPanel = CreateTableLayoutPanel("editTaskTableLayoutPanel", 2, 2);
        var taskContentPanel = CreateTableLayoutPanel("derivedContentTask", 2, 4);
        var editButton = CreateButton("editDerived", "Изменить");
        var closeButton = CreateButton("closeDerived", "Закрыть");
        var buttonTableLayotPanel = CreateTableLayoutPanel("buttonTaskTableLayoutPanel", 2, 1);
        closeButton.Click += (_, _) => ButtonController.CloseButtonOnClick(task.TaskName, ref DerivedTaskForms);
        //editButton.Click += (_, _) =>  
        var taskName = CreateTextBox(TaskName);
        taskName.Text = task.TaskName;
        var taskContent = CreateTextBox(TaskContent);
        taskContent.Text = task.TaskContent;
        var taskTrue = CreateTextBox(TaskTrueResult);
        taskTrue.Text = task.TaskTrueResult;
        var taskFalse = CreateTextBox(TaskFalseResult);
        taskFalse.Text = task.TaskFalseResult;
        
        buttonTableLayotPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonTableLayotPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        buttonTableLayotPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        buttonTableLayotPanel.Controls.Add(closeButton);
        buttonTableLayotPanel.Controls.Add(editButton);
        mainTableLayotPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        mainTableLayotPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        mainTableLayotPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
        mainTableLayotPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        taskContentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
        taskContentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        for (var i = 0; i < taskContentPanel.RowCount; i++)
            taskContentPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        taskContentPanel.Controls.Add(CreateLabel("Наименование задачи"), 0, 0);
        taskContentPanel.Controls.Add(CreateLabel("Содержание задачи"), 0, 1);
        taskContentPanel.Controls.Add(CreateLabel("Правильный ответ"), 0, 2);
        taskContentPanel.Controls.Add(CreateLabel("Неправильный ответ"), 0, 3);
        taskContentPanel.Controls.Add(taskName, 1, 0);
        taskContentPanel.Controls.Add(taskContent, 1, 1);
        taskContentPanel.Controls.Add(taskTrue, 1, 2);
        taskContentPanel.Controls.Add(taskFalse, 1, 3);
        var lstBox = new ListBox
        {
            Name = "taskForDerivedTask",
            Dock = DockStyle.Fill,
            ContextMenuStrip = _contextMenu
        };
        task.Sequence.ForEach(t => lstBox.Items.Add(t));
        mainTableLayotPanel.Controls.Add(taskContentPanel, 0, 0);
        mainTableLayotPanel.Controls.Add(lstBox, 1, 0);
        mainTableLayotPanel.Controls.Add(buttonTableLayotPanel, 1, 1);
        groupBox.Controls.Add(mainTableLayotPanel);
        return groupBox;
    }
    
    public void StandartButtonsForm(ref TableLayoutPanel mainPanel, string text, bool create)
    {
        mainPanel.Controls.Add(CreateTaskButtonsPanel(text, mainPanel.Controls, create), 1, mainPanel.RowCount - 1);
    }

    private TableLayoutPanel CreateTaskButtonsPanel(string groupBoxText, TableLayoutControlCollection controls,
        bool addContent)
    {
        var checkBox = CreateCheckBox("createElementaryTaskReverse", "Обратное решение");
        var secondTLP = CreateTableLayoutPanel(TaskButtonsPanel, 3, 1);
        var closeButton = CreateButton("closeButton", "Закрыть");
        var controllerButton = addContent
            ? CreateButton("addButton", "Добавить")
            : CreateButton("editButton", "Изменить");
        secondTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        secondTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        secondTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        secondTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        closeButton.Click += (_, _) => ButtonController.CloseButtonOnClick(groupBoxText, ref ElementaryTaskForms);
        if (addContent)
        {
            controllerButton.Click +=
                (_, _) => ButtonController.ElementaryCountTaskAdd(groupBoxText, controls, checkBox);
        }
        else
        {
            LoadDataInTextBox(groupBoxText, controls, checkBox);
            controllerButton.Click += (_, _) =>
                ButtonController.ElementaryTaskEdit(groupBoxText, DialogWindow(), controls, checkBox);
        }

        secondTLP.Controls.Add(checkBox, 0, 0);
        secondTLP.Controls.Add(closeButton, 1, 0);
        secondTLP.Controls.Add(controllerButton, 2, 0);
        return secondTLP;
    }

    private static void AddingCountLabel(ref TableLayoutPanel panel)
    {
        panel.Controls.Add(CreateLabel("Название задачи"), 0, 0);
        panel.Controls.Add(CreateLabel("Содержание задачи"), 0, 1);
        panel.Controls.Add(CreateLabel("Правильный ответ"), 0, 3);
        panel.Controls.Add(CreateLabel("Неправильный ответ"), 0, 4);
    }
    
    public static GroupBox GetElementaryView(ElementaryTask task)
    {
        var groupBox = CreateGroupBox("createElementaryTaskGroupBox", task.TaskName);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 6);
        AddingCountLabel(ref layoutPanel);
        layoutPanel.Controls.Add(CreateTextBox(TaskName, task.TaskName), 1, 0);
        layoutPanel.Controls.Add(CreateTextBox(TaskContent, task.TaskContent), 1, 1); 
        switch (task.CheckType)
        {
            case CheckForm.ControllingOfTheNumberOfPoints:
            case CheckForm.ControllingOfTheNumberOfLines:
            case CheckForm.ControllingOfTheNumberOfArcs:
            case CheckForm.ControllingTheAmountOfHorizontalOfSegments:
            case CheckForm.ControllingTheAmountOfVerticalityOfSegments:
                layoutPanel.Controls.Add(CreateLabel("Количество объектов"), 0, 2);
                layoutPanel.Controls.Add(CreateTextBox(TaskObjectCount, task.CountTask!.ObjectCount.ToString()), 1, 2);
                break;
            case CheckForm.ControllingLineSize:
                layoutPanel.Controls.Add(CreateLabel("Длина отрезка (мм)"), 0, 2);
                layoutPanel.Controls.Add(CreateTextBox(LineSize, task.PointTask.Line.Length.ToString(CultureInfo.InvariantCulture)), 1, 2);
                break;
            case CheckForm.ControllingSetRadiusArc:
                layoutPanel.Controls.Add(CreateLabel("Радиус дуги (мм)"), 0, 2);
                layoutPanel.Controls.Add(CreateTextBox(ArcRadius, task.PointTask.Arc.ArcRadius.ToString(CultureInfo.InvariantCulture)), 1, 2);
                break;
            case CheckForm.ControllingSizeExtrusion:
                layoutPanel.Controls.Add(CreateLabel("Длина выдавливания (мм)"), 0, 2);
                layoutPanel.Controls.Add(CreateTextBox(ExtrusionSize, task.TridimensionalOperation.Depth.ToString(CultureInfo.InvariantCulture)), 1, 2);
                break;
            case CheckForm.ControllingSizeCut:
                layoutPanel.Controls.Add(CreateLabel("Длина выреза (мм)"), 0, 2);
                layoutPanel.Controls.Add(CreateTextBox(CutSize, task.TridimensionalOperation.Depth.ToString(CultureInfo.InvariantCulture)), 1, 2);
                break;
        }
        layoutPanel.Controls.Add(CreateTextBox(TaskTrueResult, task.TaskTrueResult), 1, 3);
        layoutPanel.Controls.Add(CreateTextBox(TaskFalseResult, task.TaskFalseResult), 1, 4);
        layoutPanel.Controls.Add(CreateLabel("Обратное решение"), 0, 5);
        layoutPanel.Controls.Add(CreateTextBox("Reverse", task.Reverse.ToString()), 1, 5);
        groupBox.Controls.Add(layoutPanel);
        return groupBox;
    }

    public static List<GroupBox> GetDerivedView(DerivedTask derivedTask)
    {
        var groupBox = CreateGroupBox("createElementaryTaskGroupBox", derivedTask.MethodName);
        var layoutPanel = CreateMainTableLayotPanel("createElementaryTaskTableLayoutPanel", 2, 6);
        layoutPanel.Controls.Add(CreateLabel("Название задачи"), 0, 0);
        layoutPanel.Controls.Add(CreateLabel("Содержание задачи"), 0, 1);
        layoutPanel.Controls.Add(CreateLabel("Правильный ответ"), 0, 2);
        layoutPanel.Controls.Add(CreateLabel("Неправильный ответ"), 0, 3);
        layoutPanel.Controls.Add(CreateLabel("Элементарные задачи"), 0, 4);
        layoutPanel.Controls.Add(CreateLabel("Производные задачи"), 0, 5);
        layoutPanel.Controls.Add(CreateTextBox(TaskName, derivedTask.TaskName));
        layoutPanel.Controls.Add(CreateTextBox(TaskContent, derivedTask.TaskContent));
        layoutPanel.Controls.Add(CreateTextBox(TaskTrueResult, derivedTask.TaskTrueResult));
        layoutPanel.Controls.Add(CreateTextBox(TaskFalseResult, derivedTask.TaskFalseResult));
        var elementaryNameTasks = "NULL";
        var derivedNameTasks = "NULL";
        if (derivedTask.ElementaryTasks is not null && !derivedTask.ElementaryTasks.Count.Equals(0))
            elementaryNameTasks =
                $@"{derivedTask.ElementaryTasks?.Select(task1 => task1.TaskName)!.Aggregate((first, second) => $"{first}, {second}")}";
        if (derivedTask.DerivedTasks is not null && !derivedTask.DerivedTasks.Count.Equals(0))
            derivedNameTasks =
                $@"{derivedTask.DerivedTasks?.Select(task1 => task1.MethodName)!.Aggregate((first, second) => $"{first}, {second}")}";
        layoutPanel.Controls.Add(CreateTextBox("ElementaryTasks", elementaryNameTasks));
        layoutPanel.Controls.Add(CreateTextBox("DerivedTasks", derivedNameTasks));
        groupBox.Controls.Add(layoutPanel);
        var groupBoxes = new List<GroupBox> { groupBox };
        if (derivedTask.ElementaryTasks != null)
            groupBoxes.AddRange(derivedTask.ElementaryTasks.Select(GetElementaryView));
        return groupBoxes;
    }
}