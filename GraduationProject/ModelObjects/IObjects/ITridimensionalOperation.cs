using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.ModelObjects.IObjects;

public interface ITridimensionalOperation
{
    public string Name { get; set; }
    public string Type { get; set; }
    public Sketch Sketch { get; set; }
    public double Depth { get; set; }
}