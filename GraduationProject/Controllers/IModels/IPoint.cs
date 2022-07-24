using System.Collections.Generic;

namespace GraduationProject.Controllers.IModels;

public interface IPoint
{
    public List<double> XStart { get; set; }
    public List<double> YStart { get; set; }
    public List<double> ZStart { get; set; }
    public List<double> XEnd { get; set; }
    public List<double> YEnd { get; set; }
    public List<double> ZEnd { get; set; }
}