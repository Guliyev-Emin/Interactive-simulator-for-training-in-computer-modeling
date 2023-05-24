using System;
using GraduationProject.ModelObjects.IObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.ModelObjects.Objects;

[Serializable]
public record TridimensionalOperation : ITridimensionalOperation
{
    private decimal _depth;
    public string Name { get; set; }
    public string Type { get; set; }
    public Sketch Sketch { get; set; }
    public Mirror Mirror { get; set; }

    public decimal Depth
    {
        get => _depth;
        set => _depth = value;
    }
}