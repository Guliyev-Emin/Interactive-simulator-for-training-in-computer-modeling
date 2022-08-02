namespace GraduationProject.Model.IModels;

public interface IArc : IPoint
{
    public double ArcRadius { get; set; }
    public string ArcCoordinate { get; set; }

    public double XCenter { get; set; }
    public double YCenter { get; set; }
    public double ZCenter { get; set; }
}