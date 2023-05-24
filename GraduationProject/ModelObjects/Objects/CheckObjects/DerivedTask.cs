using System.Collections.Generic;
using GraduationProject.ModelObjects.IObjects.ICheckObjects;

namespace GraduationProject.ModelObjects.Objects.CheckObjects;

public class DerivedTask : ITask
{
    public string MethodName { get; set; }
    public List<string> Sequence { get; set; }
    public List<ElementaryTask> ElementaryTasks { get; set; }
    public List<DerivedTask> DerivedTasks { get; set; }
    public List<BaseTask> BaseTasks { get; set; }
    public uint Id { get; set; }
    public string TaskName { get; set; }
    public string TaskContent { get; set; }
    public string TaskTrueResult { get; set; }
    public string TaskFalseResult { get; set; }
}