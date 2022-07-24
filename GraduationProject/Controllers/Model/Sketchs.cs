using System.Collections.Generic;
using GraduationProject.Controllers.IModels;

namespace GraduationProject.Controllers.Model;

public class Sketchs : ISketchInfo
{
    public string SketchName { get; set; }
    public double Deepth { get; set; }

    public IUserPoint UserPoint { get; set; }
    public ILine Line { get; set; }
    public IArc Arc { get; set; }
    public IEllipse Ellipse { get; set; }
    public IParabola Parabola { get; set; }
}