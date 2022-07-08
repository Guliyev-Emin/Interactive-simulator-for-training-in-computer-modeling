using System.Collections.Generic;
using GraduationProject.Controllers.IModels;

namespace GraduationProject.Controllers.Model;

public class Line : ILine
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public bool LineStatus { get; set; }
    public int LineCount { get; set; }
    public List<short> LineTypes { get; set; }
    public List<double> LineLengths { get; set; }
    public List<string> LineCoordinates { get; set; }
}