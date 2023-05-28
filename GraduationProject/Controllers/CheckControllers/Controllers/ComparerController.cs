using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraduationProject.CheckForms;
using GraduationProject.ModelObjects.IObjects.ICheckObjects;
using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.CheckObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;
using GraduationProject.SolidWorks_Algorithms;

namespace GraduationProject.Controllers.CheckControllers.Controllers;

public class ComparerController
{
    private static DataGridView _comparerContent;
    private static Model _model;

    public ComparerController(ref DataGridView dataGridView)
    {
        _comparerContent = dataGridView;
        _model = ReadingModel.GetModel();
    }

    public bool ElementaryComparer(ElementaryTask task)
    {
        var resultBool = false;
        double? outData = null;
        var model = ReadingModel.GetModel();
        Sketch sketch;
        switch (task.CheckType)
        {
            case CheckForm.CountMatch:
                sketch = model.Sketches.Any(s => s.SketchName.Equals(CheckForm.FeatureName))
                    ? model.Sketches.First(s => s.SketchName.Equals(CheckForm.FeatureName))
                    : model.Features.First(s => s.Sketch!.SketchName.Equals(CheckForm.FeatureName)).Sketch;

                switch (task.Type)
                {
                    case CheckForm.Point:
                        resultBool = task.CountTask.ObjectCount.Equals((uint)sketch!.UserPoints.Count);
                        outData = (uint?)sketch.UserPoints!.Count;
                        break;
                    case CheckForm.Line:
                        resultBool = task.CountTask.ObjectCount.Equals((uint)sketch!.Lines!.Count);
                        outData = (uint?)sketch.Lines!.Count;
                        break;
                    case CheckForm.Arc:
                        resultBool = task.CountTask.ObjectCount.Equals((uint)sketch!.Arcs!.Count);
                        outData = (uint)sketch.Arcs!.Count;
                        break;
                    case CheckForm.Horizontal:
                        var horizontalCount = sketch!.Lines.Count(point =>
                            point.Arrangement.Equals(CheckForm.HorizontalRussian));

                        resultBool = task.CountTask.ObjectCount.Equals((uint?)horizontalCount);
                        outData = (uint?)horizontalCount;
                        break;
                    case CheckForm.Vertical:
                        var verticalCount = sketch!.Lines.Count(point =>
                            point.Arrangement.Equals(CheckForm.VerticalRussian));
                        resultBool = task.CountTask.ObjectCount.Equals((uint?)verticalCount);
                        outData = (uint?)verticalCount;
                        break;
                    case CheckForm.Sloped:
                        var slopedCount = sketch!.Lines.Count(point =>
                            point.Arrangement.Equals(CheckForm.SlopedRussian));
                        resultBool = task.CountTask.ObjectCount.Equals((uint?)slopedCount);
                        outData = (uint?)slopedCount;
                        break;
                }

                break;
            case CheckForm.PointMatch:
                sketch = model.Sketches.Any(s => s.SketchName.Equals(CheckForm.FeatureName))
                    ? model.Sketches.First(s => s.SketchName.Equals(CheckForm.FeatureName))
                    : model.Features.First(s => s.Sketch!.SketchName.Equals(CheckForm.FeatureName)).Sketch;
                switch (task.Type)
                {
                    case CheckForm.Point:
                        if (sketch!.UserPoints.Any(point => task.PointTask.Point.Equals(point)))
                            resultBool = true;
                        break;
                    case CheckForm.Line:
                        if (task.PointTask.Line.Length != 0)
                            MessageBox.Show($@"Длина отрезка равен {task.PointTask.Line.Length}");

                        break;
                }
                break;
            case CheckForm.Extrusion:
                var tridOper = model.Features.First(f => f.Name.Equals(CheckForm.FeatureName));
                resultBool = task.TridimensionalOperation.Depth.Equals(tridOper.Depth);
                outData = (double?)tridOper.Depth;
                break;
        }

        string resultString;
        if (task.Reverse)
        {
            resultString = !resultBool ? task.TaskTrueResult : task.TaskFalseResult;
            resultBool = !resultBool;
        }
        else
        {
            resultString = resultBool ? task.TaskTrueResult : task.TaskFalseResult;
        }

        _comparerContent.Rows.Add(task.MethodName, task.TaskName, resultBool, resultString, outData);
        return resultBool;
    }

    private static void GetComaprerResult(ITask task, bool reverse, List<bool> comparerResults, out bool rstBool,
        out string rstStr)
    {
        rstBool = comparerResults.Count(b => b.Equals(false)).Equals(0);
        if (reverse)
        {
            rstStr = !rstBool ? task.TaskTrueResult : task.TaskFalseResult;
            rstBool = !rstBool;
        }
        else
        {
            rstStr = rstBool ? task.TaskTrueResult : task.TaskFalseResult;
        }
    }

    private static bool BaseTaskComparer(ref BaseTask baseTask, bool add, string text)
    {
        baseTask.Lines ??= new List<Line>();
        baseTask.Arcs ??= new List<Arc>();
        var resultBools = new List<bool>();
        var outResult = "NULL";
        foreach (var taskName in baseTask.Sequence)
        {
            List<Line> lines;
            switch (taskName)
            {
                case CheckForm.ControllingGetHorizontalArrayLine:
                    resultBools.Add(true);
                    lines = TaskController.GetLines(CheckForm.HorizontalRussian);
                    baseTask.Lines.AddRange(lines);
                    continue;
                case CheckForm.ControllingGetLinesWithProperties:
                    continue;
                case CheckForm.ControllingGetVerticalArrayLine:
                    resultBools.Add(true);
                    lines = TaskController.GetLines(CheckForm.VerticalRussian);
                    baseTask.Lines.AddRange(lines);
                    continue;
                case CheckForm.ControllingGetLineWithMinX:
                    lines = TaskController.GetLinesWhereMinX(baseTask.Lines);
                    baseTask.Lines = lines;
                    continue;
                case CheckForm.ControllingGetLineWithMaxX:
                    lines = TaskController.GetLinesWhereMaxX(baseTask.Lines);
                    baseTask.Lines = lines;
                    continue;
                case CheckForm.ControllingGetLineWithMinY:
                    lines = TaskController.GetLinesWhereMinY(baseTask.Lines);
                    baseTask.Lines = lines;
                    continue;
                case CheckForm.ControllingGetLineWithMaxY:
                    lines = TaskController.GetLinesWhereMaxY(baseTask.Lines);
                    baseTask.Lines = lines;
                    continue;
                case CheckForm.ControllingGetArcWithMinRadius:
                    baseTask.Arcs = TaskController.GetArcWithMinRadius(baseTask.Arcs);
                    continue;
                case CheckForm.ControllingGetArcWithMaxRadius:
                    baseTask.Arcs = TaskController.GetArcWithMaxRadius(baseTask.Arcs);
                    continue;
                case CheckForm.ControllingGetArcWithMinX:
                    baseTask.Arcs = TaskController.GetArcWithMinX(baseTask.Arcs);
                    continue;
                case CheckForm.ControllingGetArcWithMaxX:
                    baseTask.Arcs = TaskController.GetArcWithMaxX(baseTask.Arcs);
                    continue;
                case CheckForm.ControllingGetArcWithMinY:
                    baseTask.Arcs = TaskController.GetArcWithMinY(baseTask.Arcs);
                    continue;
                case CheckForm.ControllingGetArcWithMaxY:
                    baseTask.Arcs = TaskController.GetArcWithMaxY(baseTask.Arcs);
                    continue;
                default:
                    if (baseTask.BaseTasks is not null)
                        try
                        {
                            var task = baseTask.BaseTasks.First(task => task.TaskName.Equals(taskName));
                            BaseTaskComparer(ref task, true, task.TaskTrueResult);
                            baseTask.BaseTasks[baseTask.BaseTasks.FindIndex(taskN => taskN.TaskName.Equals(taskName))] =
                                task;
                        }
                        catch
                        {
                            // ignored
                        }

                    if (baseTask.ElementaryTasks is not null)
                        try
                        {
                            var elemTask = baseTask.ElementaryTasks.First(task => task.TaskName.Equals(taskName));
                            string parentBt;
                            BaseTask bt;
                            switch (elemTask.MethodName)
                            {
                                case CheckForm.ControllingLineSize:
                                    parentBt = baseTask.Sequence[0];
                                    bt = baseTask.BaseTasks.First(b => b.TaskName.Equals(parentBt));
                                    resultBools.Add(LengthCheck(bt.Lines, elemTask.PointTask.Line.Length));
                                    break;
                                case CheckForm.ControllingSetRadiusArc:
                                    parentBt = baseTask.Sequence[0];
                                    bt = baseTask.BaseTasks.First(b => b.TaskName.Equals(parentBt));
                                    resultBools.Add(RadiusCheck(bt.Arcs, elemTask.PointTask.Arc.ArcRadius));
                                    break;
                            }
                        }
                        catch
                        {
                            //ignored
                        }

                    continue;
            }
        }

        GetComaprerResult(baseTask, false, resultBools, out var resBool, out var resStr);
        if (add)
            resStr = text;
        _comparerContent.Rows.Add(baseTask.MethodName, baseTask.TaskName, resBool, resStr);
        return resultBools.Count(b => b.Equals(false)).Equals(0);
    }

    private static bool LengthCheck(List<Line> lines, decimal length)
    {
        var boolList = lines.Select(line => line.Length == length * (decimal)0.001).ToList();
        return boolList.Count(b => b == false) == 0;
    }

    private static bool RadiusCheck(List<Arc> arcs, decimal radius)
    {
        var boolList = arcs.Select(arc => arc.ArcRadius == radius * (decimal)0.001).ToList();
        return boolList.Count(b => b == false) == 0;
    }

    public bool DerivedComparer(DerivedTask derivedTask)
    {
        var resultBools = new List<bool>();
        foreach (var taskSequence in derivedTask.Sequence)
        {
            if (derivedTask.ElementaryTasks is not null &&
                derivedTask.ElementaryTasks.Any(task => task.TaskName.Equals(taskSequence)))
                resultBools.Add(
                    ElementaryComparer(
                        derivedTask.ElementaryTasks.First(task => task.TaskName.Equals(taskSequence))));

            if (derivedTask.DerivedTasks is not null &&
                derivedTask.DerivedTasks.Any(task => task.TaskName.Equals(taskSequence)))
                resultBools.Add(
                    DerivedComparer(derivedTask.DerivedTasks.First(task => task.TaskName.Equals(taskSequence))));

            if (derivedTask.BaseTasks is null ||
                !derivedTask.BaseTasks.Any(task => task.TaskName.Equals(taskSequence))) continue;
            {
                var baseTask = derivedTask.BaseTasks.First(task => task.TaskName.Equals(taskSequence));
                resultBools.Add(BaseTaskComparer(ref baseTask, false, null));
                var index = derivedTask.BaseTasks.FindIndex(task => task.TaskName.Equals(taskSequence));
                derivedTask.BaseTasks[index] = baseTask;
            }
        }
        return resultBools.Count(b => b.Equals(false)).Equals(0);
    }
}