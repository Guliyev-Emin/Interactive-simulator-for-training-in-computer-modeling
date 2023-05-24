using GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface IArc : ICenterPoint, IPoint
{
    /// <summary>
    /// Радиус окружности
    /// </summary>
    public decimal ArcRadius { get; set; }
    /// <summary>
    /// Направление окружности
    /// </summary>
    public short Direction { get; set; }
}