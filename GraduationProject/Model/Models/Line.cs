using System;
using GraduationProject.Model.IModels;

namespace GraduationProject.Model.Models;

[Serializable]
public record Line : ILine
{
    public short LineType { get; set; }
    public string LineArrangement { get; set; }
    public double LineLength { get; set; }
    public string Coordinate { get; set; }
    public double XStart { get; set; }
    public double YStart { get; set; }
    public double ZStart { get; set; }
    public double XEnd { get; set; }
    public double YEnd { get; set; }
    public double ZEnd { get; set; }
}