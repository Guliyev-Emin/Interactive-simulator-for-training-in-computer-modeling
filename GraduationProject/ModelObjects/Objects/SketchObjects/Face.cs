using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Face : IFace
{
    public string FeatureName { get; set; }
    public double I { get; set; }
    public double J { get; set; }
    public double K { get; set; }
}