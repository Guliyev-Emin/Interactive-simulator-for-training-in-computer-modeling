using System.Collections.Generic;

namespace GraduationProject.Controllers.IModels;

public interface IEllipse
{
    public bool EllipseStatus { get; set; }
    public int EllipseCount { get; set; }
    public List<string> EllipseCoordinates { get; set; }

}