namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface IFace
{
    /// <summary>
    /// Наименование объекта
    /// </summary>
    public string FeatureName { get; set; }
    /// <summary>
    /// Параметр матрицы SolidWorks
    /// </summary>
    public double I { get; set; }
    /// <summary>
    /// Параметр матрицы SolidWorks
    /// </summary>
    public double J { get; set; }
    /// <summary>
    /// Параметр матрицы SolidWorks
    /// </summary>
    public double K { get; set; }
}