using GraduationProject.ModelObjects.IObjects.ICheckObjects;

namespace GraduationProject.ModelObjects.Objects.CheckObjects;

public abstract class CoordinateProperties : ITask
{
    public string StartX { get; set; }
    public string StartY { get; set; }
    public string StartZ { get; set; }
    public string EndX { get; set; }
    public string EndY { get; set; }
    public string EndZ { get; set; }
    public string Type { get; set; }
    public uint Id { get; set; }
    public string TaskName { get; set; }
    public string TaskContent { get; set; }
    public string TaskTrueResult { get; set; }
    public string TaskFalseResult { get; set; }
}