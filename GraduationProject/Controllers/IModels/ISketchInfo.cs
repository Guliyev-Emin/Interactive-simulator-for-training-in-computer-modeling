namespace GraduationProject.Controllers.IModels;

public interface ISketchInfo : IPoint, ILine, IArc, IEllipse, IParabola
{
    public string SketchName { get; set; }
    public double Deepth { get; set; }
}