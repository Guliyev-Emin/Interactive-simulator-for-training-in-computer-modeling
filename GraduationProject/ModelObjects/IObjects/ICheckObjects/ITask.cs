namespace GraduationProject.ModelObjects.IObjects.ICheckObjects;

public interface ITask
{
    public uint Id { get; set; }
    public string TaskName { get; set; }
    public string TaskContent { get; set; }
    public string TaskTrueResult { get; set; }
    public string TaskFalseResult { get; set; }
}