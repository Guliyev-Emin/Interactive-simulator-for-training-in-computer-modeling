namespace GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

public interface IParabolaPoint : IPoint
{
    public decimal XFocus { get; set; }
    public decimal YFocus { get; set; }
    public decimal ZFocus { get; set; }
    public decimal XApex { get; set; }
    public decimal YApex { get; set; }
    public decimal ZApex { get; set; }
}