using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Ellipse : IEllipse
{
    public string Coordinate { get; set; }
    public decimal XStart { get; set; }
    public decimal YStart { get; set; }
    public decimal ZStart { get; set; }
    public decimal XEnd { get; set; }
    public decimal YEnd { get; set; }
    public decimal ZEnd { get; set; }
    public decimal XCenter { get; set; }
    public decimal YCenter { get; set; }
    public decimal ZCenter { get; set; }
    public decimal XMajor { get; set; }
    public decimal YMajor { get; set; }
    public decimal ZMajor { get; set; }
    public decimal XMinor { get; set; }
    public decimal YMinor { get; set; }
    public decimal ZMinor { get; set; }
}