using System;
using GraduationProject.ModelObjects.IObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;
using JetBrains.Annotations;

namespace GraduationProject.ModelObjects.Objects;

[Serializable]
public record TridimensionalOperation : ITridimensionalOperation
{
    public string Name { get; set; }
    public string Type { get; set; }
    public Sketch Sketch { get; set; }
    public Mirror Mirror { get; set; }
    public double Depth { get; set; }
}