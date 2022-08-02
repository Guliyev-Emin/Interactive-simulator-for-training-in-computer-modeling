using System;
using System.Collections.Generic;
using GraduationProject.Model.IModels;

namespace GraduationProject.Model.Models;

[Serializable]
public record SketchInfo : ISketchInfo
{
    public string SketchName { get; set; }
    public double Deepth { get; set; }
    public List<UserPoint> UserPoints { get; set; }
    public List<Line> Lines { get; set; }
    public List<Arc> Arcs { get; set; }
    public List<Ellipse> Ellipses { get; set; }
    public List<Parabola> Parabolas { get; set; }
}