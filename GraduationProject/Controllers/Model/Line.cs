using System.Collections.Generic;
using GraduationProject.Controllers.IModels;

namespace GraduationProject.Controllers.Model;

public class Line : ILine
{
    public bool LineStatus { get; set; }
    public int LineCount { get; set; }
    public List<short> LineTypes { get; set; }
    public List<double> LineLengths { get; set; }
    public List<string> LineCoordinates { get; set; }
    public List<double> XStart { get; set; }
    public List<double> YStart { get; set; }
    public List<double> ZStart { get; set; }
    public List<double> XEnd { get; set; }
    public List<double> YEnd { get; set; }
    public List<double> ZEnd { get; set; }
}