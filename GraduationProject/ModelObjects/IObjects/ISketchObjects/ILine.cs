using GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface ILine : IPoint
{
    /// <summary>
    /// Код типа линии
    /// </summary>
    public short Type { get; set; }
    /// <summary>
    /// Расположение отрезка
    /// </summary>
    public string Arrangement { get; set; }
    /// <summary>
    /// Длина отрезка
    /// </summary>
    public decimal Length { get; set; }
}