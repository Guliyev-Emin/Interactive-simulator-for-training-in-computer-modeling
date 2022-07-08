using System.Collections.Generic;

namespace GraduationProject.Controllers.IModels;

public interface IParabola: IPoint
{
    public bool ParabolaStatus { get; set; }
    public int ParabolaCount { get; set; }
    public List<string> ParabolaCoordinates { get; set; }
}