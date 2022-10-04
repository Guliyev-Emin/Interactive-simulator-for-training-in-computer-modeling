using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Ellipse : IEllipse
{
    public string Coordinate { get; set; }
    public double XStart { get; set; }
    public double YStart { get; set; }
    public double ZStart { get; set; }
    public double XEnd { get; set; }
    public double YEnd { get; set; }
    public double ZEnd { get; set; }
    public double XMajor { get; set; }
    public double YMajor { get; set; }
    public double ZMajor { get; set; }
    public double XMinor { get; set; }
    public double YMinor { get; set; }
    public double ZMinor { get; set; }
    public double XCenter { get; set; }
    public double YCenter { get; set; }
    public double ZCenter { get; set; }
}