namespace GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

public interface IEllipsePoint : ICenterPoint
{
    public decimal XMajor { get; set; }
    public decimal YMajor { get; set; }
    public decimal ZMajor { get; set; }
    public decimal XMinor { get; set; }
    public decimal YMinor { get; set; }
    public decimal ZMinor { get; set; }
}