using System.Collections.Generic;
using System.Linq;
using GraduationProject.CheckForms;
using GraduationProject.ModelObjects.IObjects.ICheckObjects;
using GraduationProject.ModelObjects.Objects.CheckObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.Controllers.CheckControllers.Controllers;

public abstract class TaskController
{
    private static List<ElementaryTask> ElementaryTasks => CheckForm.ElementaryTasks;
    private static List<DerivedTask> DerivedTasks => CheckForm.DerivedTasks;
    private static List<BaseTask> BaseTasks => CheckForm.BaseTasks;

    public static ElementaryTask GetElementaryTask(string name)
    {
        return ElementaryTasks.Find(t => t.TaskName.Equals(name));
    }

    public static uint GetId(string name, bool elementaryTask, bool baseTask, bool derivedTask)
    {
        uint id = 1;
        var tasks = new List<ITask>();
        if (elementaryTask)
            tasks = ElementaryTasks.Where(task => task.MethodName.Equals(name)).Cast<ITask>().ToList();
        if (baseTask)
            tasks = BaseTasks.Where(task => task.MethodName.Equals(name)).Cast<ITask>().ToList();
        if (derivedTask)
            tasks = DerivedTasks.Where(task => task.MethodName.Equals(name)).Cast<ITask>().ToList();
        
        while (tasks.Count != 0 && tasks.Any(task => task.Id == id))
            id++;
        return id;
    }
    
    public static List<Line> GetLinesWhereMinX(List<Line> lines)
    {
        var min = lines.Select(s => s.XStart).Min();
        return lines.Where(l => l.XStart.Equals(min) || l.XEnd.Equals(min)).ToList();
    }
    
    public static List<Line> GetLinesWhereMinY(List<Line> lines)
    {
        var minStart = lines.Select(s => s.YStart).Min();
        var minEnd = lines.Select(s => s.YEnd).Min();
        var list1 = lines.Where(l => l.YStart.Equals(minStart) || l.YEnd.Equals(minEnd)).ToList();
        var list2 = lines.Where(l => l.YStart.Equals(minEnd) || l.YEnd.Equals(minStart)).ToList();
        var list3 = list1.Concat(list2).Distinct().ToList();
        return list3;
    }
    
    public static List<Line> GetLinesWhereMaxX(List<Line> lines)
    {
        var max = lines.Select(s => s.XStart).Max();
        return lines.Where(l => l.XStart.Equals(max) || l.XEnd.Equals(max)).ToList();
    }
    
    public static List<Line> GetLinesWhereMaxY(List<Line> lines)
    {
        var max = lines.Select(s => s.YStart).Max();
        return lines.Where(l => l.YStart.Equals(max) || l.YEnd.Equals(max)).ToList();
    }

    public static List<Arc> GetArcWithMinRadius(List<Arc> arcs)
    {
        var minRadius = arcs.Select(a => a.ArcRadius).Min();
        return arcs.Where(a => a.ArcRadius.Equals(minRadius)).ToList();
    }

    public static List<Arc> GetArcWithMaxRadius(List<Arc> arcs)
    {
        var maxRadius = arcs.Select(a => a.ArcRadius).Max();
        return arcs.Where(a => a.ArcRadius.Equals(maxRadius)).ToList();
    }

    public static List<Arc> GetArcWithMinX(List<Arc> arcs)
    {
        var minCenter = arcs.Select(a => a.XCenter).Min();
        return arcs.Where(a => a.XCenter.Equals(minCenter)).ToList();   
    }
    
    public static List<Arc> GetArcWithMinY(List<Arc> arcs)
    {
        var minCenter = arcs.Select(a => a.YCenter).Min();
        return arcs.Where(a => a.YCenter.Equals(minCenter)).ToList();   
    }
    
    public static List<Arc> GetArcWithMaxX(List<Arc> arcs)
    {
        var maxCenter = arcs.Select(a => a.XCenter).Max();
        return arcs.Where(a => a.XCenter.Equals(maxCenter)).ToList();   
    }
    
    public static List<Arc> GetArcWithMaxY(List<Arc> arcs)
    {
        var maxCenter = arcs.Select(a => a.YCenter).Max();
        return arcs.Where(a => a.YCenter.Equals(maxCenter)).ToList();   
    }
}