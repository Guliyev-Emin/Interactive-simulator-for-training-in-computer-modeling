using System.Collections.Generic;
using GradProj.Models;
using GraduationProject.ModelObjects.IObjects.ICheckObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.ModelObjects.Objects.CheckObjects;

public class BaseTask : ITask
{
    public List<ElementaryTask> ElementaryTasks { get; set; }
    public List<BaseTask> BaseTasks { get; set; }
    public string MethodName { get; set; }
    public List<string> Sequence { get; set; }
    public uint Id { get; set; }
    public string TaskName { get; set; }
    public string TaskContent { get; set; }
    public string TaskTrueResult { get; set; }
    public string TaskFalseResult { get; set; }
    public List<Line> Lines { get; set; }
    public List<Arc> Arcs { get; set; }
}