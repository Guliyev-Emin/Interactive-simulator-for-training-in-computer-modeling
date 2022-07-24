using System.Collections.Generic;
using GraduationProject.Controllers.IModels;

namespace GraduationProject.Controllers.Model;

public class Arc:IArc
{
    public bool ArcStatus { get; set; }
    public int ArcCount { get; set; }
    public List<double> ArcRadius { get; set; }
    public List<string> ArcCoordinates { get; set; }
    public List<double> XStart { get; set; }
    public List<double> YStart { get; set; }
    public List<double> ZStart { get; set; }
    public List<double> XEnd { get; set; }
    public List<double> YEnd { get; set; }
    public List<double> ZEnd { get; set; }
}