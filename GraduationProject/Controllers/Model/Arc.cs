using System.Collections.Generic;
using GraduationProject.Controllers.IModels;

namespace GraduationProject.Controllers.Model;

public class Arc:IArc
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public bool ArcStatus { get; set; }
    public int ArcCount { get; set; }
    public List<double> ArcRadius { get; set; }
    public List<string> ArcCoordinates { get; set; }
}