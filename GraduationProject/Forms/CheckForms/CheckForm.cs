using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraduationProject.CheckForms.FormConstructors;
using GraduationProject.Controllers;
using GraduationProject.Controllers.CheckControllers.Controllers;
using GraduationProject.ModelObjects.IObjects.ICheckObjects;
using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.CheckObjects;
using GraduationProject.SolidWorks_Algorithms;

namespace GraduationProject.CheckForms;

public partial class CheckForm : Form
{
    public const string ControllingOfTheNumberOfPoints = "Контроль количества точек";
    public const string ControllingOfTheNumberOfLines = "Контроль количества отрезков";
    public const string ControllingOfTheNumberOfArcs = "Контроль количества дуг";
    public const string ControllingTheAmountOfHorizontalOfSegments = "Контроль количества горизонтальности отрезков";
    public const string ControllingTheAmountOfVerticalityOfSegments = "Контроль количества вертикальности отрезков";
    public const string ControllingCoincidenceOfTwoPoints = "Контроль совпадения двух точек";
    public const string ControllingTheNumberOfSlopedSegments = "Контроль количества наклонных отрезков";
    public const string ControllingGetVerticalArrayLine = "Получить массив вертикальных отрезков";
    public const string ControllingGetHorizontalArrayLine = "Получить массив горизонтальных отрезков";
    public const string ControllingGetSlopedArrayLine = "Получить массив наклонных отрезков";
    public const string ControllingGetLinesWithProperties = "Получить массив отрезок с параметрами";
    public const string ControllingGetLineWithMinX = "Получить отрезок с минимальным X";
    public const string ControllingGetLineWithMaxX = "Получить отрезок с максимальным X";
    public const string ControllingGetLineWithMinY = "Получить отрезок с минимальным Y";
    public const string ControllingGetLineWithMaxY = "Получить отрезок с максимальным Y";
    public const string ControllingGetArcWithMinX = "Получить окружность с минимальным X";
    public const string ControllingGetArcWithMaxX = "Получить окружность с максимальным X";
    public const string ControllingGetArcWithMinY = "Получить окружность с минимальным Y";
    public const string ControllingGetArcWithMaxY = "Получить окружность с максимальным Y";
    public const string ControllingGetArcWithMinRadius = "Получить окружность с минимальным радиусом";
    public const string ControllingGetArcWithMaxRadius = "Получить окружность с максимальным радиусом";
    public const string ControllingCheckingTheClosedLoops = "Контроль связанности узлов";
    public const string ControllingSizeExtrusion = "Контроль длины выдавливания";
    public const string ControllingSizeCut = "Контроль длины выреза";
    public const string ControllingDistanceBetweenLines = "Контроль расстояния первого отрезка до второго отрезка";
    public const string ControllingLineSize = "Контроль размера отрезка";
    public const string ControllingSetRadiusArc = "Контроль радиуса окружности";
    public const string HorizontalRussian = "Горизонтальный";
    public const string VerticalRussian = "Вертикальный";
    public const string SlopedRussian = "Наклонный";
    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
    public const string Sloped = "Sloped";
    public const string Point = "Point";
    public const string Line = "Line";
    public const string Arc = "Arc";
    public const string ControllingTridimensionalOperation = "TridimensionalOperation";
    public const string Cut = "Cut";
    public const string Extrusion = "Extrusion";
    public const string CountMatch = "CountMatch";
    public const string LocationPosition = "LocationPosition";
    public const string PointMatch = "PointMatch";
    public static List<ElementaryTask> ElementaryTasks;
    public static List<DerivedTask> DerivedTasks;
    public static List<BaseTask> BaseTasks;
    public static TridimensionalOperation TridimensionalOperation;
    public static string AddFormName;
    private readonly ComparerController _comparer;
    private readonly ConstructorForm _constructorForm;
    private readonly ToolTip _toolTip = new();
    private readonly ViewForm _viewForm = new();
    private int _toolTipIndex;
    private static User User => AuthorizationForm.User;
    public static string FeatureName;
    
    public CheckForm()
    {
        InitializeComponent();
        
        checkedElementaryCheckMethods.Items.AddRange(new object[]
        {
            ControllingOfTheNumberOfPoints, ControllingOfTheNumberOfArcs, ControllingOfTheNumberOfLines,
            ControllingTheAmountOfHorizontalOfSegments, ControllingTheAmountOfVerticalityOfSegments,
            ControllingTheNumberOfSlopedSegments, ControllingCoincidenceOfTwoPoints, ControllingLineSize,
            ControllingSetRadiusArc,
            ControllingSizeCut, ControllingSizeExtrusion
        });
        elementaryTasksForBaseTaskСheckedListBox.Items.AddRange(new object[]
        {
            ControllingGetHorizontalArrayLine, ControllingGetVerticalArrayLine, ControllingGetSlopedArrayLine,
            ControllingGetLineWithMinX, ControllingGetLineWithMaxX,
            ControllingGetLineWithMinY, ControllingGetLineWithMaxY, ControllingDistanceBetweenLines,
            ControllingGetArcWithMinRadius, ControllingGetArcWithMaxRadius,
            ControllingGetArcWithMinX, ControllingGetArcWithMaxX, ControllingGetArcWithMinY, ControllingGetArcWithMaxY
        });
        ElementaryTasks = new List<ElementaryTask>();
        DerivedTasks = new List<DerivedTask>();
        BaseTasks = new List<BaseTask>();
        _toolTip.Active = true;
        _toolTip.AutoPopDelay = 10000;
        _toolTip.InitialDelay = 600;
        _toolTip.IsBalloon = true;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        checkedElementaryCheckMethods.MouseMove += ShowCheckBoxToolTip;
        ready_madeElementaryTasks.MouseMove += (_, args) => ShowTip(args, ready_madeElementaryTasks);
        ready_madeDerivedTasks.MouseMove += (_, args) => ShowTip(args, ready_madeDerivedTasks);
        elementaryTasksInDerivedTask.MouseMove += (_, args) => ShowTip(args, elementaryTasksInDerivedTask);
        tasksForDerivedTask.MouseMove += (_, args) => ShowTip(args, tasksForDerivedTask);
        tasksForDerivedTask.ContextMenuStrip = contextMenuStrip;
        derivedTasksInDerivedTask.MouseMove += (_, args) => ShowTip(args, derivedTasksInDerivedTask);
        taskCheckMethods.MouseMove += (_, args) => ShowTip(args, taskCheckMethods);
        ready_madeBaseTasks.MouseMove += (_, args) => ShowTip(args, ready_madeBaseTasks);

        _constructorForm = new ConstructorForm(ref ready_madeElementaryTasks, ref elementaryTaskForms, ref derivedTasks,
            ref ready_madeDerivedTasks, ref contextMenuStrip);
        _comparer = new ComparerController(ref dataGridView1);

        if (User.Type.Equals(AuthorizationForm.Student))
        {
            tabControl1.SelectTab(checkingPage);
            tasksPage.Text = "Задачи \uD83D\uDD12";
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        try
        {
            var model = ReadingModel.GetModel();
            model.Sketches!.ForEach(s => featureNames.Items.Add(s.SketchName));
            model.Features!.ForEach(f =>
            {
                featureNames.Items.Add(f.Name);
                if (f.Sketch is not null) featureNames.Items.Add(f.Sketch.SketchName);
            });
            
        }
        catch
        {
            //ignore
        }
    }
    
    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab != tabControl1.TabPages["tasksPage"]) return;
        tabControl1.SelectTab(checkingPage);
        MessageBox.Show(@"У Вас недостаточно прав для открытия данного окна", @"Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static string GetType(string name)
    {
        switch (name)
        {
            case ControllingOfTheNumberOfPoints:
            case ControllingCoincidenceOfTwoPoints:
                return Point;
            case ControllingOfTheNumberOfLines:
            case ControllingLineSize:
                return Line;
            case ControllingOfTheNumberOfArcs:
            case ControllingSetRadiusArc:
                return Arc;
            case ControllingTheAmountOfHorizontalOfSegments:
                return Horizontal;
            case ControllingTheAmountOfVerticalityOfSegments:
                return Vertical;
            case ControllingSizeExtrusion:
            case ControllingSizeCut:
                return ControllingTridimensionalOperation;
            default:
                return null;
        }
    }

    public static string GetCheckType(string name)
    {
        switch (name)
        {
            case ControllingOfTheNumberOfPoints:
            case ControllingOfTheNumberOfLines:
            case ControllingOfTheNumberOfArcs:
            case ControllingTheAmountOfHorizontalOfSegments:
            case ControllingTheAmountOfVerticalityOfSegments:
                return CountMatch;
            case ControllingCoincidenceOfTwoPoints:
            case ControllingLineSize:
            case ControllingSetRadiusArc:
                return PointMatch;
            case ControllingSizeExtrusion:
                return Extrusion;
            case ControllingSizeCut:
                return Cut;
            default:
                return null;
        }
    }

    private void ShowTip(MouseEventArgs e, ListBox control)
    {
        if (_toolTipIndex == control.IndexFromPoint(e.Location)) return;
        _toolTipIndex =
            control.IndexFromPoint(control.PointToClient(MousePosition));
        if (_toolTipIndex <= -1) return;
        var name = control.Items[_toolTipIndex].ToString();
        if (DerivedTasks.Select(task => task.TaskName).Any(task => task.Equals(name)))
        {
            GetDerivedToolTip(control);
            return;
        }

        if (!BaseTasks.Select(task => task.TaskName).Any(task => task.Equals(name))) return;
        GetBaseToolTip(control);

        if (!ElementaryTasks.Select(task => task.TaskName).Any(task => task.Equals(name))) return;
        GetElementaryToolTip(control);
    }

    private void ShowCheckBoxToolTip(object sender, MouseEventArgs e)
    {
        if (_toolTipIndex == checkedElementaryCheckMethods.IndexFromPoint(e.Location)) return;
        _toolTipIndex =
            checkedElementaryCheckMethods.IndexFromPoint(checkedElementaryCheckMethods.PointToClient(MousePosition));

        if (_toolTipIndex > -1)
            _toolTip.SetToolTip(checkedElementaryCheckMethods,
                checkedElementaryCheckMethods.Items[_toolTipIndex].ToString());
    }

    private string GetTaskInfo(ITask task)
    {
        var id = $@"Id: {task.Id}" + Environment.NewLine;
        var taskName = $@"Задача: {task.TaskName}" + Environment.NewLine;
        var content = $@"Содержание: {task.TaskContent}" + Environment.NewLine;
        var trueResult = $@"Правильный результат: {task.TaskTrueResult}" + Environment.NewLine;
        var falseResult = $@"Неправильный результат: {task.TaskFalseResult}" + Environment.NewLine;
        return id + taskName + content + trueResult + falseResult;
    }

    private void GetDerivedToolTip(ListBox control)
    {
        var index = DerivedTasks.FindIndex(elem => elem.TaskName.Equals(control.Items[_toolTipIndex].ToString()));
        var info = GetTaskInfo(DerivedTasks[index]);
        var elementaryNameTasks = "Элементарные задачи: NULL";
        var derivedNameTasks = "Производные задачи: NULL";
        if (DerivedTasks[index].ElementaryTasks is not null && !DerivedTasks[index].ElementaryTasks.Count.Equals(0))
            elementaryNameTasks =
                $@"Элементарные задачи: {DerivedTasks[index]?.ElementaryTasks?.Select(task1 => task1.TaskName)!.Aggregate((first, second) => $"{first}, {second}")}" +
                Environment.NewLine;
        if (DerivedTasks[index].DerivedTasks is not null && !DerivedTasks[index].DerivedTasks.Count.Equals(0))
            derivedNameTasks =
                $@"Производные задачи: {DerivedTasks[index]?.DerivedTasks?.Select(task1 => task1.MethodName)!.Aggregate((first, second) => $"{first}, {second}")}";
        _toolTip.SetToolTip(control, info + elementaryNameTasks + derivedNameTasks);
    }

    private void GetBaseToolTip(ListBox control)
    {
        var index = BaseTasks.FindIndex(@base => @base.TaskName.Equals(control.Items[_toolTipIndex].ToString()));
        string text;
        var info = GetTaskInfo(BaseTasks[index]);
        var sequence = BaseTasks[index].Sequence.Aggregate((first, second) => $"{first}, {second}") +
                       Environment.NewLine;
        _toolTip.SetToolTip(control, info + sequence);
    }

    private void GetElementaryToolTip(ListBox control)
    {
        var index = ElementaryTasks.FindIndex(elem =>
            elem.TaskName.Equals(control.Items[_toolTipIndex].ToString()));
        var text = "";
        var task = ElementaryTasks[index];
        var name = $@"Метод: {task.MethodName}" + Environment.NewLine;
        var info = GetTaskInfo(task);
        var reverse = $@"Обратное решение: {task.Reverse}" + Environment.NewLine;
        if (ElementaryTasks[index].CountTask is not null)
        {
            var objectCount = $@"Количество объектов: {task.CountTask.ObjectCount}";
            text = name + info + objectCount + reverse;
        }
        else if (task.PointTask.Point is not null)
        {
            var x = $@"X: {task.PointTask.Point.X}" + Environment.NewLine;
            var y = $@"Y: {task.PointTask.Point.Y}" + Environment.NewLine;
            var z = $@"Z: {task.PointTask.Point.Z}" + Environment.NewLine;
            text = name + info + x + y + z + reverse;
        }
        else
        {
            if (task.PointTask.Line?.Length != null)
            {
                var length = $@"Длина: {task.PointTask.Line?.Length} мм";
                text = name + info + length + reverse;
            }
        }

        _toolTip.SetToolTip(control, text);
    }


    private void RemoveRow(string name)
    {
        for (var index = 0; index < elementaryTaskForms.RowCount - 3; index++)
        {
            var cont = elementaryTaskForms.Controls[index];
            if (cont.Text != name) continue;
            elementaryTaskForms.Controls.RemoveAt(index);
            elementaryTaskForms.RowCount--;
            break;
        }
    }

    private void checkedElementaryCheckMethods_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!checkedElementaryCheckMethods.GetItemChecked(checkedElementaryCheckMethods.SelectedIndex))
        {
            RemoveRow(checkedElementaryCheckMethods.SelectedItem.ToString());
            return;
        }

        var task = checkedElementaryCheckMethods.SelectedItem.ToString();
        var gb = new GroupBox();
        switch (task)
        {
            case ControllingOfTheNumberOfPoints:
            case ControllingOfTheNumberOfLines:
            case ControllingOfTheNumberOfArcs:
            case ControllingTheAmountOfHorizontalOfSegments:
            case ControllingTheAmountOfVerticalityOfSegments:
                gb = _constructorForm.CountMatchForm(task, true);
                break;
            case ControllingCoincidenceOfTwoPoints:
                gb = _constructorForm.PointMatchForm(task, true);
                break;
            case ControllingLineSize:
                gb = _constructorForm.LineSizeForm(task, true);
                break;
            case ControllingSetRadiusArc:
                gb = _constructorForm.ArcRadiusForm(task, true);
                break;
            case ControllingSizeExtrusion:
                gb = _constructorForm.ExtrusionForm(task);
                break;
            case ControllingSizeCut:
                gb = _constructorForm.CutForm(task);
                break;
        }

        elementaryTaskForms.RowCount++;
        elementaryTaskForms.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        elementaryTaskForms.Controls.Add(gb, 0, elementaryTaskForms.RowCount - 3);
    }

    private void connect_Click(object sender, EventArgs e)
    {
        Connection.AppConnection();
    }

    private void elementaryTasksInDerivedTask_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (derivedTasks.Controls.Count.Equals(1))
        {
            AddElement(elementaryTasksInDerivedTask, ref tasksForDerivedTask);
        }
        else
        {
            var addTaskToDerivedTaskForm = new AddTasksForm();
            addTaskToDerivedTaskForm.AddNames(derivedTasks.Controls.Cast<GroupBox>().Select(gb => gb.Text).ToList());
            var result = addTaskToDerivedTaskForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                var toAddList = derivedTasks.Controls.Cast<GroupBox>().First(gb => gb.Text.Equals(AddFormName))
                    .Controls.Find("tasksForDerivedTask", true)[0] as ListBox;

                AddElement(elementaryTasksInDerivedTask, ref toAddList);
            }
        }
    }

    private void deleteStripItem_Click(object sender, EventArgs e)
    {
        while (tasksForDerivedTask.SelectedItems.Count != 0)
            tasksForDerivedTask.Items.Remove(tasksForDerivedTask.SelectedItems[0]);
    }

    private void addDerivedTask_Click(object sender, EventArgs e)
    {
        const string methodName = "Производная задача";
        var id = TaskController.GetId(methodName, false, false, true);
        DerivedTasks.Add(new DerivedTask
        {
            Id = id,
            MethodName = methodName,
            TaskName = derivedTaskName.Text,
            TaskContent = derivedTaskContent.Text,
            TaskTrueResult = derivedTaskTrueResult.Text,
            TaskFalseResult = derivedTaskFalseResult.Text,
            Sequence = tasksForDerivedTask.Items.Cast<string>().ToList(),
            ElementaryTasks = (from task in tasksForDerivedTask.Items.Cast<string>()
                where ElementaryTasks.Any(task1 => task1.TaskName.Equals(task))
                select ElementaryTasks.First(task1 => task1.TaskName.Equals(task))).ToList(),
            DerivedTasks = (from task in tasksForDerivedTask.Items.Cast<string>()
                where DerivedTasks.Any(task1 => task1.MethodName.Equals(task))
                select DerivedTasks.First(task1 => task1.MethodName.Equals(task))).ToList(),
            BaseTasks = (from task in tasksForDerivedTask.Items.Cast<string>()
                where BaseTasks.Any(task1 => task1.TaskName.Equals(task))
                select BaseTasks.First(task1 => task1.TaskName.Equals(task))).ToList()
        });
        ready_madeDerivedTasks.Items.Add(derivedTaskName.Text);
        derivedTasksInDerivedTask.Items.Add(derivedTaskName.Text);
        UnselectItems(elementaryTasksInDerivedTask);
        UnselectItems(derivedTasksInDerivedTask);
        tasksForDerivedTask.Items.Clear();
        derivedTaskName.Text = "";
        derivedTaskContent.Text = "";
        derivedTaskTrueResult.Text = "";
        derivedTaskFalseResult.Text = "";
    }

    private static void UnselectItems(CheckedListBox listBox)
    {
        for (var i = 0; i < listBox.Items.Count; i++)
            listBox.SetItemCheckState(i, CheckState.Unchecked);
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        switch (taskTabs.SelectedTab.Text)
        {
            case "Элементарная задача":
                elementaryTasksInDerivedTask.Items.Clear();
                foreach (var task in ElementaryTasks.Where(task =>
                             !elementaryTasksInDerivedTask.Items.Cast<string>()
                                 .Any(task1 => task1.Equals(task.TaskName))))
                    elementaryTasksInDerivedTask.Items.Add(task.TaskName);

                foreach (var item in ready_madeElementaryTasks.CheckedItems.Cast<string>())
                    if (!elementaryTasksForBaseTaskСheckedListBox.Items.Cast<string>().Any(n => n.Equals(item)))
                        elementaryTasksForBaseTaskСheckedListBox.Items.Add(item);
                break;
            case "Базовая задача":
                break;
            case "Производная задача":
                if (DerivedTasks.Count != 0)
                    XmlController.CreateDerivedFile("derivedTaskFile",
                        ready_madeDerivedTasks.CheckedItems.Cast<string>().ToList().Select(taskName =>
                            DerivedTasks.First(n => n.TaskName.Equals(taskName))).ToList());
                break;
        }
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        switch (taskTabs.SelectedTab.Text)
        {
            case "Элементарная задача":
                foreach (string checkedItem in ready_madeElementaryTasks.CheckedItems)
                {
                    var task = ElementaryTasks.First(taskName => taskName.TaskName.Equals(checkedItem));
                    var gb = new GroupBox();
                    if (elementaryTaskForms.Controls.Cast<GroupBox>().Select(box => box.Text)
                        .Any(taskName => taskName.Equals(task.TaskName)))
                        continue;
                    switch (task.CheckType)
                    {
                        case CountMatch:
                            gb = _constructorForm.CountMatchForm(checkedItem, false);
                            break;
                        case LocationPosition:
                            break;
                        case PointMatch:
                            gb = _constructorForm.PointMatchForm(task.TaskName, false);
                            break;
                    }

                    elementaryTaskForms.RowCount++;
                    elementaryTaskForms.Controls.Add(gb);
                }

                break;
            case "Базовая задача":
                foreach (string checkedItem in ready_madeBaseTasks.CheckedItems)
                {
                    var gb = _constructorForm.BaseTaskEdit(BaseTasks.First(task => task.TaskName.Equals(checkedItem)));
                    basesTasks.Controls.Add(gb);
                    basesTasks.RowCount++;
                    basesTasks.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }

                break;
            case "Производная задача":
                foreach (string checkedItem in ready_madeDerivedTasks.CheckedItems)
                {
                    var gb = _constructorForm.TestDerivedEdit(
                        DerivedTasks.First(task => task.TaskName.Equals(checkedItem)));
                    derivedTasks.Controls.Add(gb);
                    derivedTasks.RowCount++;
                    derivedTasks.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }

                break;
        }
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        switch (taskTabs.SelectedTab.Text)
        {
            case "Элементарная задача":
                while (ready_madeElementaryTasks.CheckedItems.Count != 0)
                {
                    ElementaryTasks.Remove(ElementaryTasks.First(item =>
                        item.MethodName.Equals(ready_madeElementaryTasks.CheckedItems[0])));
                    ready_madeElementaryTasks.Items.Remove(ready_madeElementaryTasks.CheckedItems[0]);
                }

                break;
            case "Базовая задача":
                break;
            case "Производная задача":
                while (ready_madeDerivedTasks.CheckedItems.Count != 0)
                {
                    var name = ready_madeDerivedTasks.CheckedItems[0].ToString();
                    DerivedTasks.Remove(DerivedTasks.First(item =>
                        item.MethodName.Equals(name)));
                    ready_madeDerivedTasks.Items.Remove(name);
                    derivedTasksInDerivedTask.Items.Remove(name);
                }

                break;
        }
    }

    private void viewButton_Click(object sender, EventArgs e)
    {
        switch (taskTabs.SelectedTab.Text)
        {
            case "Элементарная задача":
                foreach (string elementaryTaskName in ready_madeElementaryTasks.CheckedItems)
                    _viewForm.ElementaryAdd(ElementaryTasks.First(task => task.TaskName.Equals(elementaryTaskName)));
                break;
            case "Базовая задача":
                break;
            case "Производная задача":
                foreach (string derivedTaskObj in ready_madeDerivedTasks.CheckedItems)
                    _viewForm.AddDerivedTask(DerivedTasks.First(task => task.TaskName.Equals(derivedTaskObj)));
                break;
        }

        _viewForm.ShowDialog();
    }

    private void updateButton_Click(object sender, EventArgs e)
    {
        switch (taskTabs.SelectedTab.Text)
        {
            case "Элементарная задача":
                elementaryTaskForms.Controls.Clear();
                UnselectItems(checkedElementaryCheckMethods);
                UnselectItems(ready_madeElementaryTasks);
                break;
            case "Базовая задача":
                break;
            case "Производная задача":
                UnselectItems(elementaryTasksInDerivedTask);
                UnselectItems(baseTasksInDerivedTask);
                UnselectItems(derivedTasksInDerivedTask);
                break;
        }
    }

    private void exportButton_Click(object sender, EventArgs e)
    {
        var derivedTasksList = XmlController.ReadDerivedFile("derivedTaskFile");
        foreach (var derivedTaskObject in derivedTasksList)
        {
            if (DerivedTasks.Any(d => d.TaskName.Equals(derivedTaskObject.TaskName)))
                continue;

            derivedTaskObject.ElementaryTasks?.ForEach(t =>
            {
                ElementaryTasks.Add(t);
                ready_madeElementaryTasks.Items.Add(t.TaskName);
                elementaryTasksInDerivedTask.Items.Add(t.TaskName);
                elementaryTasksForBaseTaskСheckedListBox.Items.Add(t.TaskName);
            });
            derivedTaskObject.BaseTasks?.ForEach(t =>
            {
                BaseTasks.Add(t);
                ready_madeBaseTasks.Items.Add(t.TaskName);
                baseTasksInDerivedTask.Items.Add(t.TaskName);
                baseTasksForBaseTaskСheckedListBox.Items.Add(t.TaskName);
                t.ElementaryTasks?.ForEach(t1 =>
                {
                    ElementaryTasks.Add(t1);
                    ready_madeElementaryTasks.Items.Add(t1.TaskName);
                    elementaryTasksInDerivedTask.Items.Add(t1.TaskName);
                    elementaryTasksForBaseTaskСheckedListBox.Items.Add(t1.TaskName);
                });
            });
            DerivedTasks.Add(derivedTaskObject);
            taskCheckMethods.Items.Add(derivedTaskObject.TaskName);
            ready_madeDerivedTasks.Items.Add(derivedTaskObject.TaskName);
            derivedTasksInDerivedTask.Items.Add(derivedTaskObject.TaskName);
        }

        MessageBox.Show(@"Экспорт задач был успешно выполнен!", @"Экспорт задач", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Information);
    }

    private static void AddElement(CheckedListBox cntrl1, ref ListBox cntrl2)
    {
        try
        {
            var index = cntrl1.SelectedIndex;
            var name = cntrl1.Items[index];
            if (!cntrl1.GetItemChecked(index))
            {
                cntrl2.Items.RemoveAt(cntrl2.Items.IndexOf(name));
                return;
            }
        }
        catch
        {
            return;
        }

        foreach (var checkedItem in cntrl1.CheckedItems)
            if (!cntrl2.Items.Cast<string>()
                    .Any(listItem => listItem.Equals(checkedItem.ToString())))
                cntrl2.Items.Add(checkedItem.ToString());
    }

    private void derivedTasksInDerivedTask_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (derivedTasks.Controls.Count.Equals(1))
        {
            AddElement(derivedTasksInDerivedTask, ref tasksForDerivedTask);
        }
        else
        {
            var addTaskToDerivedTaskForm = new AddTasksForm();
            addTaskToDerivedTaskForm.AddNames(derivedTasks.Controls.Cast<GroupBox>().Select(gb => gb.Text).ToList());
            var result = addTaskToDerivedTaskForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                var toAddList = derivedTasks.Controls.Cast<GroupBox>().First(gb => gb.Text.Equals(AddFormName))
                    .Controls.Find("taskForDerivedTask", true)[0] as ListBox;

                AddElement(derivedTasksInDerivedTask, ref toAddList);
            }
        }
    }

    private void comparer_Click(object sender, EventArgs e)
    {
        if (Connection.ConnectionTest() == false)
            return;
        var name = taskCheckMethods.SelectedItem.ToString();
        var derivedTaskObj = DerivedTasks.First(task => task.TaskName.Equals(name));
        FeatureName = featureNames.SelectedItem.ToString();
        MessageBox.Show(FeatureName);
        foreach (string checkName in taskCheckMethods.CheckedItems)
        {
            var result = _comparer.DerivedComparer(DerivedTasks.First(task => task.TaskName.Equals(checkName)));
            dataGridView1.Rows.Add(CheckForm.FeatureName, derivedTaskObj.MethodName, derivedTaskObj.TaskName, result,
                result ? derivedTaskObj.TaskTrueResult : derivedTaskObj.TaskFalseResult, "NULL");
        }

        MessageBox.Show(@"Проверка модели выполнена!", @"Проверка модели", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Information);
    }

    private void viewButtonInCheckingWindow_Click(object sender, EventArgs e)
    {
        foreach (string derivedTaskObj in taskCheckMethods.CheckedItems)
        {
            var derTask = DerivedTasks.First(task => task.TaskName.Equals(derivedTaskObj));
            _viewForm.AddDerivedTask(derTask);
        }
        _viewForm.ShowDialog();
    }

    private void elementaryTasksForBaseTaskСheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (basesTasks.Controls.Count.Equals(1))
        {
            AddElement(elementaryTasksForBaseTaskСheckedListBox, ref tasksForBaseTasks);
        }
        else
        {
            var addTaskToDerivedTaskForm = new AddTasksForm();
            addTaskToDerivedTaskForm.AddNames(basesTasks.Controls.Cast<GroupBox>().Select(gb => gb.Text).ToList());
            var result = addTaskToDerivedTaskForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                var toAddList = basesTasks.Controls.Cast<GroupBox>().First(gb => gb.Text.Equals(AddFormName))
                    .Controls.Find("tasksForBaseTasks", true)[0] as ListBox;

                AddElement(baseTasksForBaseTaskСheckedListBox, ref toAddList);
            }
        }
    }

    private static List<ElementaryTask> GetElementaryTasksAdd(ListBox list)
    {
        return (from task in list.Items.Cast<string>()
            where ElementaryTasks.Any(task1 => task1.TaskName.Equals(task))
            select ElementaryTasks.First(task1 => task1.TaskName.Equals(task))).ToList();
    }

    private static List<BaseTask> GetBaseTaskAdd(ListBox list)
    {
        return (from task in list.Items.Cast<string>()
            where BaseTasks.Any(task1 => task1.TaskName.Equals(task))
            select BaseTasks.First(task1 => task1.TaskName.Equals(task))).ToList();
    }

    private void addBaseTask_Click(object sender, EventArgs e)
    {
        const string methodName = "Базовая задача";
        var id = TaskController.GetId(methodName, false, true, false);
        BaseTasks.Add(new BaseTask
        {
            Id = id,
            MethodName = methodName,
            TaskName = baseTaskName.Text,
            TaskContent = baseTaskContent.Text,
            TaskTrueResult = baseTrueResult.Text,
            TaskFalseResult = baseFalseResult.Text,
            ElementaryTasks = GetElementaryTasksAdd(tasksForBaseTasks),
            BaseTasks = GetBaseTaskAdd(tasksForBaseTasks),
            Sequence = tasksForBaseTasks.Items.Cast<string>().ToList()
        });
        ready_madeBaseTasks.Items.Add(baseTaskName.Text);
        baseTasksForBaseTaskСheckedListBox.Items.Add(baseTaskName.Text);
        baseTasksInDerivedTask.Items.Add(baseTaskName.Text);
        UnselectItems(elementaryTasksForBaseTaskСheckedListBox);
        UnselectItems(baseTasksForBaseTaskСheckedListBox);
        tasksForBaseTasks.Items.Clear();
        baseTaskName.Text = "";
        baseTaskContent.Text = "";
        baseTrueResult.Text = "";
        baseFalseResult.Text = "";
    }

    private void baseTasksInDerivedTask_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (derivedTasks.Controls.Count.Equals(1))
        {
            AddElement(baseTasksInDerivedTask, ref tasksForDerivedTask);
        }
        else
        {
            var addTaskToDerivedTaskForm = new AddTasksForm();
            addTaskToDerivedTaskForm.AddNames(derivedTasks.Controls.Cast<GroupBox>().Select(gb => gb.Text).ToList());
            var result = addTaskToDerivedTaskForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                var toAddList = derivedTasks.Controls.Cast<GroupBox>().First(gb => gb.Text.Equals(AddFormName))
                    .Controls.Find("taskForDerivedTask", true)[0] as ListBox;

                AddElement(baseTasksInDerivedTask, ref toAddList);
            }
        }
    }

    private void baseTasksForBaseTaskСheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (basesTasks.Controls.Count.Equals(1))
            AddElement(baseTasksForBaseTaskСheckedListBox, ref tasksForBaseTasks);
    }
}