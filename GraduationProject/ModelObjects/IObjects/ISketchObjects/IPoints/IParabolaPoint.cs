namespace GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

public interface IParabolaPoint : IPoint
{
    public double XFocus { get; set; }
    public double YFocus { get; set; }
    public double ZFocus { get; set; }
    public double XApex { get; set; }
    public double YApex { get; set; }
    public double ZApex { get; set; }
}