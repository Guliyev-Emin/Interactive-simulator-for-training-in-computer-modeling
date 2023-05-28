using GraduationProject.ModelObjects.IObjects.ICheckObjects;

namespace GraduationProject.ModelObjects.Objects.CheckObjects;

/// <summary>
/// 
/// </summary>
public class ElementaryTask : ITask
{
    public bool Reverse { get; set; }
    public CountTask CountTask { get; set; }
    public PointTask PointTask { get; set; }
    public TridimensionalOperation TridimensionalOperation { get; set; }
    public string MethodName { get; set; }
    public string Type { get; set; }
    public string CheckType { get; set; }
    public uint Id { get; set; }
    public string TaskName { get; set; }
    public string TaskContent { get; set; }
    public string TaskTrueResult { get; set; }
    public string TaskFalseResult { get; set; }
}