using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Parabola : IParabola
{
    public string Coordinate { get; set; }
    public decimal XStart { get; set; }
    public decimal YStart { get; set; }
    public decimal ZStart { get; set; }
    public decimal XEnd { get; set; }
    public decimal YEnd { get; set; }
    public decimal ZEnd { get; set; }
    public decimal XFocus { get; set; }
    public decimal YFocus { get; set; }
    public decimal ZFocus { get; set; }
    public decimal XApex { get; set; }
    public decimal YApex { get; set; }
    public decimal ZApex { get; set; }
}