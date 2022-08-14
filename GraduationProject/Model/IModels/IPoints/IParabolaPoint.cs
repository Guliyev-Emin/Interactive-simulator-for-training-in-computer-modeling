namespace GraduationProject.Model.IModels.IPoints;

public interface IParabolaPoint : ICenterPoint
{
    public double XFocus { get; set; }
    public double YFocus { get; set; }
    public double ZFocus { get; set; }
    public double XApex { get; set; }
    public double YApex { get; set; }
    public double ZApex { get; set; }
}