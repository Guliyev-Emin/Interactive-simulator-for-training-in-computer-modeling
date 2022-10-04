using GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface ILine : IPoint
{
    public short LineType { get; set; }
    public string LineArrangement { get; set; }
    public double LineLength { get; set; }
}