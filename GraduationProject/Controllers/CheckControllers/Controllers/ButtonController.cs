using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GradProj.Models;
using GraduationProject.CheckForms;
using GraduationProject.CheckForms.FormConstructors;
using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.CheckObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.Controllers.CheckControllers.Controllers;

public abstract class ButtonController : ConstructorForm
{
    private static List<ElementaryTask> ElementaryTasks => CheckForm.ElementaryTasks;
    private static List<BaseTask> BaseTasks => CheckForm.BaseTasks;
    private static List<DerivedTask> DerivedTasks => CheckForm.DerivedTasks;

    public static void ElementaryCountTaskAdd(string text, TableLayoutControlCollection controls,
        CheckBox checkBox)
    {
        var data = ReadData(controls, checkBox, true);
        var id = TaskController.GetId(text, true, false, false);
        var taskName = data.TaskName;
        if (CheckForMatches(taskName, ReadyMadeElementaryTasks))
            taskName += $" - {id}";
        data.TaskName = taskName;
        data.Type = CheckForm.GetType(text);
        data.Id = id;
        data.MethodName = text;
        data.CheckType = CheckForm.GetCheckType(text);
        ElementaryTasks.Add(data);
        ReadyMadeElementaryTasks.Items.Add(taskName);
    }

    public static void ElementaryTaskEdit(string oldTaskName, bool? result, TableLayoutControlCollection controls,
        CheckBox checkBox)
    {
        var data = ReadData(controls, checkBox, true);
        var taskName = data.TaskName;
        ElementaryTask task;
        switch (result)
        {
            case true:
                task = ElementaryTasks.Find(t => t.TaskName.Equals(oldTaskName));
                var findIndex = ReadyMadeElementaryTasks.Items.Cast<string>().ToList()
                    .FindIndex(name => name.Equals(task.TaskName));
                ReadyMadeElementaryTasks.Items[findIndex] = taskName;
                task.TaskName = taskName;
                task.TaskName = data.TaskName;
                task.TaskContent = data.TaskContent;
                if (data.CountTask is not null)
                    task.CountTask.ObjectCount = data.CountTask!.ObjectCount;
                else
                    task.PointTask = data.PointTask;
                task.TaskTrueResult = data.TaskTrueResult;
                task.TaskFalseResult = data.TaskFalseResult;
                task.Reverse = data.Reverse;
                break;
            case false:
                var methodName = ElementaryTasks.Find(t => t.TaskName.Equals(oldTaskName)).MethodName;
                var id = TaskController.GetId(methodName, true, false, false);
                task = new ElementaryTask
                {
                    Id = id,
                    MethodName = methodName,
                    TaskContent = data.TaskContent,
                    TaskTrueResult = data.TaskTrueResult,
                    TaskFalseResult = data.TaskFalseResult,
                    Type = CheckForm.GetType(methodName),
                    Reverse = data.Reverse,
                    CheckType = CheckForm.GetCheckType(methodName)
                };
                if (data.CountTask is not null)
                    task.CountTask.ObjectCount = data.CountTask!.ObjectCount;
                else
                    task.PointTask = data.PointTask;
                if (CheckForMatches(data.TaskName, ReadyMadeElementaryTasks))
                    taskName = data.TaskName + $" - {id}";
                task.TaskName = taskName;
                ReadyMadeElementaryTasks.Items.Add(taskName);
                ElementaryTasks.Add(task);
                break;
        }
    }

    public static BaseTask BaseTaskEdit(string oldTaskName, bool? result, TableLayoutControlCollection controls)
    {
        // var data = ReadData(controls);
        // var taskName = data.TaskName;
        // BaseTask baseTask;
        // switch (result)
        // {
        //     case true:
        //         baseTask = BaseTasks.Find(t => t.TaskName.Equals(oldTaskName));
        //         var findIndex = ReadyMadeBaseTasks.Items.Cast<string>().ToList()
        //             .FindIndex(name => name.Equals(baseTask.TaskName));
        //         ReadyMadeBaseTasks.Items[findIndex] = taskName;
        //         baseTask.TaskName = data.TaskName;
        //         baseTask.TaskContent = data.TaskContent;
        //         baseTask.TaskTrueResult = data.TaskTrueResult;
        //         baseTask.TaskFalseResult = data.TaskFalseResult;
        //         break;
        //     case false:
        //         break;
        //     default:
        //         break;
        // }
        //
        // return baseTask;
        return null;
    }

    public static DerivedTask DerivedTaskEdit()
    {
        return new DerivedTask();
    }

    private static BaseTask ReadData(TableLayoutControlCollection controls)
    {
        var task = new BaseTask();
        foreach (Control control in controls)
        {
            switch (control.Name)
            {
                case TaskName:
                    task.TaskName = control.Text;
                    break;
                case TaskContent:
                    task.TaskContent = control.Text;
                    break;
                case TaskTrueResult:
                    task.TaskTrueResult = control.Text;
                    break;
                case TaskFalseResult:
                    task.TaskFalseResult = control.Text;
                    break;
                case TasksForBaseTasks:
                    MessageBox.Show(control.Text);
                    break;
                    //task.Sequence = 
                default:
                    continue;
            }
        }

        return task;
    }

    private static ElementaryTask ReadData(TableLayoutControlCollection controls, CheckBox checkBox, bool cls)
    {
        var task = new ElementaryTask();
        foreach (Control control in controls)
        {
            switch (control.Name)
            {
                case TaskName:
                    task.TaskName = control.Text;
                    break;
                case TaskContent:
                    task.TaskContent = control.Text;
                    break;
                case TaskObjectCount:
                    task.CountTask ??= new CountTask();
                    task.CountTask.ObjectCount = Convert.ToUInt32(control.Text);
                    break;
                case TaskTrueResult:
                    task.TaskTrueResult = control.Text;
                    break;
                case TaskFalseResult:
                    task.TaskFalseResult = control.Text;
                    break;
                case TaskButtonsPanel:
                    task.Reverse = checkBox.Checked;
                    break;
                case PointXAxis:
                    task.PointTask ??= new PointTask();
                    task.PointTask.Point ??= new UserPoint();
                    task.PointTask.Point.X = Convert.ToDecimal(control.Text);
                    break;
                case PointYAxis:
                    task.PointTask.Point.Y = Convert.ToDecimal(control.Text);
                    break;
                case PointZAxis:
                    task.PointTask.Point.Z = Convert.ToDecimal(control.Text);
                    break;
                case LineStartX:
                    task.PointTask ??= new PointTask();
                    task.PointTask.Line ??= new Line();
                    task.PointTask.Line.XStart = (decimal)Convert.ToDouble(control.Text);
                    break;
                case LineStartY:
                    task.PointTask.Line.YStart = (decimal)Convert.ToDouble(control.Text);
                    break;
                case LineStartZ:
                    task.PointTask.Line.ZStart = (decimal)Convert.ToDouble(control.Text);
                    break;
                case LineEndX:
                    task.PointTask.Line.XEnd = (decimal)Convert.ToDouble(control.Text);
                    break;
                case LineEndY:
                    task.PointTask.Line.YEnd = (decimal)Convert.ToDouble(control.Text);
                    break;
                case LineEndZ:
                    task.PointTask.Line.ZEnd = (decimal)Convert.ToDouble(control.Text);
                    break;
                case LineSize:
                    task.PointTask ??= new PointTask();
                    task.PointTask.Line ??= new Line();
                    task.PointTask.Line.Length = (decimal)Convert.ToDouble(control.Text);
                    break;
                case ArcRadius:
                    task.PointTask ??= new PointTask();
                    task.PointTask.Arc ??= new Arc();
                    task.PointTask.Arc.ArcRadius = (decimal)Convert.ToDouble(control.Text);
                    break;
                case ExtrusionSize:
                    task.TridimensionalOperation ??= new TridimensionalOperation();
                    task.TridimensionalOperation.Depth = Convert.ToDecimal(control.Text);
                    break;
                case CutSize:
                    task.TridimensionalOperation ??= new TridimensionalOperation();
                    task.TridimensionalOperation.Depth = Convert.ToDecimal(control.Text);
                    break;
                default:
                    continue;
            }

            if (cls)
                control.Text = "";
        }

        return task;
    }

    public static void CloseButtonOnClick(string text, ref TableLayoutPanel panel)
    {
        panel.RowCount--;
        var index = panel.Controls.Cast<GroupBox>().Select(box => box.Text).ToList().IndexOf(text);
        panel.Controls.RemoveAt(index);
    }

    /// <summary>
    ///     Метод на проверку совпадений в листе задач
    /// </summary>
    /// <param name="text">Наименование задачи</param>
    /// <param name="listBox">Лист с задачами</param>
    /// <returns>Результат совпадения задачи с наименованием задачи</returns>
    private static bool CheckForMatches(string text, ListBox listBox)
    {
        return listBox.Items.Cast<string>().Any(t => t.Equals(text));
    }

    protected ButtonController(ref CheckedListBox readyMadeElementaryTasks, ref TableLayoutPanel elementaryTaskForms, ref TableLayoutPanel baseTaskForms, ref CheckedListBox readyMadeBaseTasks, ref TableLayoutPanel derivedTaskForms, ref CheckedListBox readyMadeDerivedTasks, ref ContextMenuStrip contextMenu) : base(ref readyMadeElementaryTasks, ref elementaryTaskForms, ref baseTaskForms, ref readyMadeBaseTasks, ref derivedTaskForms, ref readyMadeDerivedTasks, ref contextMenu)
    {
    }
}