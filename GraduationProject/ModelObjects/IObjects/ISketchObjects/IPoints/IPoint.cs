namespace GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

public interface IPoint
{
    public string Coordinate { get; set; }
    public decimal XStart { get; set; }
    public decimal YStart { get; set; }
    public decimal ZStart { get; set; }
    public decimal XEnd { get; set; }
    public decimal YEnd { get; set; }
    public decimal ZEnd { get; set; }
}