namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface IUserPoint
{
    public string Coordinate { get; set; }
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }
}