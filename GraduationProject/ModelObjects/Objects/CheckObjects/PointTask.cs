using System.Drawing;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.ModelObjects.Objects.CheckObjects;

public class PointTask
{
    public Arc Arc { get; set; }
    public Line Line { get; set; }
    public UserPoint Point { get; set; }
}