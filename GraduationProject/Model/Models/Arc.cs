using System;
using GraduationProject.Model.IModels;

namespace GraduationProject.Model.Models;

[Serializable]
public record Arc : IArc
{
    public double ArcRadius { get; set; }
    public string ArcCoordinate { get; set; }
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