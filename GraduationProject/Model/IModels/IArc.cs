using GraduationProject.Model.IModels.IPoints;

namespace GraduationProject.Model.IModels;

public interface IArc : ICenterPoint, IPoint
{
    public double ArcRadius { get; set; }
}