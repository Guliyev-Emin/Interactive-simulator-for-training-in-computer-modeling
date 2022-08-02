using System.Collections.Generic;
using GraduationProject.Model.Models;

namespace GraduationProject.Model.IModels;

public interface ISketchInfo
{
    public string SketchName { get; set; }
    public double Deepth { get; set; }

    public List<UserPoint> UserPoints { get; set; }
    public List<Line> Lines { get; set; }
    public List<Arc> Arcs { get; set; }
    public List<Ellipse> Ellipses { get; set; }
    public List<Parabola> Parabolas { get; set; }
}