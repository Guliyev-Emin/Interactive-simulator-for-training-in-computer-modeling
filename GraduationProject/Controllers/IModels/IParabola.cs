using System.Collections.Generic;

namespace GraduationProject.Controllers.IModels;

public interface IParabola
{
    public bool ParabolaStatus { get; set; }
    public int ParabolaCount { get; set; }
    public List<string> ParabolaCoordinates { get; set; }
}