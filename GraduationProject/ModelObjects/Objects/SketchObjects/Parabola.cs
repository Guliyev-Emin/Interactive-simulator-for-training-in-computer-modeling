using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Parabola : IParabola
{
    public double XStart { get; set; }
    public double YStart { get; set; }
    public double ZStart { get; set; }
    public double XEnd { get; set; }
    public double YEnd { get; set; }
    public double ZEnd { get; set; }
    public double XCenter { get; set; }
    public double YCenter { get; set; }
    public double ZCenter { get; set; }
    public string Coordinate { get; set; }
    public double XFocus { get; set; }
    public double YFocus { get; set; }
    public double ZFocus { get; set; }
    public double XApex { get; set; }
    public double YApex { get; set; }
    public double ZApex { get; set; }
}