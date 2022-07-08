using System.Collections.Generic;

namespace GraduationProject.Controllers.IModels;

public interface ILine
{
    public bool LineStatus { get; set; }
    public int LineCount { get; set; }
    public List<short> LineTypes { get; set; }
    public List<double> LineLengths { get; set; }
    public List<string> LineCoordinates { get; set; }
}