using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.SketchObjects;
using JetBrains.Annotations;

namespace GraduationProject.ModelObjects.IObjects;

public interface ITridimensionalOperation
{
    public string Name { get; set; }
    public string Type { get; set; }
    [CanBeNull] public Sketch Sketch { get; set; }
    [CanBeNull] public Mirror Mirror { get; set; }
    [CanBeNull] public decimal Depth { get; set; }
}