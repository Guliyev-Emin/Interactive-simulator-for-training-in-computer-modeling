using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Arc : IArc
{
    public double ArcRadius { get; set; }
    public short Direction { get; set; }
    public string Coordinate { get; set; }
    public double XStart { get; set; }
    public double YStart { get; set; }
    public double ZStart { get; set; }
    public double XEnd { get; set; }
    public double YEnd { get; set; }
    public double ZEnd { get; set; }
    public double XCenter { get; set; }
    public double YCenter { get; set; }
    public double ZCenter { get; set; }
}