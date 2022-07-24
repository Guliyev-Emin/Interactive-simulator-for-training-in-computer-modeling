using System.Collections.Generic;
using GraduationProject.Controllers.IModels;

namespace GraduationProject.Controllers;

public class SketchInfo : ISketchInfo
{
    public IUserPoint UserPoint { get; set; }
    public ILine Line { get; set; }
    public IArc Arc { get; set; }
    public IEllipse Ellipse { get; set; }
    public IParabola Parabola { get; set; }
    public string SketchName { get; set; }
    public double Deepth { get; set; }
    public bool PointStatus { get; set; }
    public int PointCount { get; set; }
    public List<string> PointCoordinates { get; set; }
    public bool LineStatus { get; set; }
    public int LineCount { get; set; }
    public List<short> LineTypes { get; set; }
    public List<double> LineLengths { get; set; }
    public List<string> LineCoordinates { get; set; }
    public bool ArcStatus { get; set; }
    public int ArcCount { get; set; }
    public List<double> ArcRadius { get; set; }
    public List<string> ArcCoordinates { get; set; }
    public bool EllipseStatus { get; set; }
    public int EllipseCount { get; set; }
    public List<string> EllipseCoordinates { get; set; }
    public bool ParabolaStatus { get; set; }
    public int ParabolaCount { get; set; }
    public List<string> ParabolaCoordinates { get; set; }
    
    public List<double> XStart { get; set; }
    public List<double> YStart { get; set; }
    public List<double> ZStart { get; set; }
    public List<double> XEnd { get; set; }
    public List<double> YEnd { get; set; }
    public List<double> ZEnd { get; set; }
}