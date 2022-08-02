using System;
using GraduationProject.Model.IModels;

namespace GraduationProject.Model.Models;

[Serializable]
public record Ellipse : IEllipse
{
    public double XStart { get; set; }
    public double YStart { get; set; }
    public double ZStart { get; set; }
    public double XEnd { get; set; }
    public double YEnd { get; set; }
    public double ZEnd { get; set; }
    public string EllipseCoordinate { get; set; }
}