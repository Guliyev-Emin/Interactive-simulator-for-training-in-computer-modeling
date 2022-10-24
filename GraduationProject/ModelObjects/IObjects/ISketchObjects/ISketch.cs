using System.Collections.Generic;
using GraduationProject.ModelObjects.Objects.SketchObjects;
using JetBrains.Annotations;

namespace GraduationProject.ModelObjects.IObjects.ISketchObjects;

public interface ISketch
{
    public string SketchName { get; set; }
    [CanBeNull] public string Plane { get; set; }
    public Face Face { get; set; }

    public List<UserPoint> UserPoints { get; set; }
    public List<Line> Lines { get; set; }
    public List<Arc> Arcs { get; set; }
    public List<Ellipse> Ellipses { get; set; }
    public List<Parabola> Parabolas { get; set; }

    public short UserPointCount { get; }
    public short LineCount { get; }
    public short ArcCount { get; }
    public short EllipseCount { get; }
    public short ParabolaCount { get; }

    public bool UserPointIsTrue { get; }
    public bool LineIsTrue { get; }
    public bool ArcIsTrue { get; }
    public bool EllipseIsTrue { get; }
    public bool ParabolaIsTrue { get; }
}