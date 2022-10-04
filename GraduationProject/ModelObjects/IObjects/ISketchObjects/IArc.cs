using GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface IArc : ICenterPoint, IPoint
{
    public double ArcRadius { get; set; }
    public short Direction { get; set; }
}