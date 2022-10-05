namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface IFace
{
    public string FeatureName { get; set; }
    public double I { get; set; }
    public double J { get; set; }
    public double K { get; set; }
}