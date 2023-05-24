namespace GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;

public interface IPoint
{
    /// <summary>
    /// Координаты для вывода
    /// </summary>
    public string Coordinate { get; set; }
    /// <summary>
    /// Начало координат по оси X
    /// </summary>
    public decimal XStart { get; set; }
    /// <summary>
    /// Начало координат по оси Y
    /// </summary>
    public decimal YStart { get; set; }
    /// <summary>
    /// Начало координат по оси Z
    /// </summary>
    public decimal ZStart { get; set; }
    /// <summary>
    /// Конец координат по оси X
    /// </summary>
    public decimal XEnd { get; set; }
    /// <summary>
    /// Конец координат по оси Y
    /// </summary>
    public decimal YEnd { get; set; }
    /// <summary>
    /// Конец координат по оси Z
    /// </summary>
    public decimal ZEnd { get; set; }
}