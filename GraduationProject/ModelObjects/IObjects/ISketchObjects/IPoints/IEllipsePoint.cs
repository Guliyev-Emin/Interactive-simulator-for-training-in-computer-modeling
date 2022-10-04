namespace GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

public interface IEllipsePoint : ICenterPoint
{
    public double XMajor { get; set; }
    public double YMajor { get; set; }
    public double ZMajor { get; set; }
    public double XMinor { get; set; }
    public double YMinor { get; set; }
    public double ZMinor { get; set; }
}