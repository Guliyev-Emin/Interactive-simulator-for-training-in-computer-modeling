using GraduationProject.Model.IModels.IPoints;

namespace GraduationProject.Model.IModels;

public interface ILine : IPoint
{
    public short LineType { get; set; }
    public string LineArrangement { get; set; }
    public double LineLength { get; set; }
}