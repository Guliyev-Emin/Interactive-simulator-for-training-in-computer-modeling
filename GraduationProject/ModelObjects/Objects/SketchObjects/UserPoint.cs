using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record UserPoint : IUserPoint
{
    public string Coordinate { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}