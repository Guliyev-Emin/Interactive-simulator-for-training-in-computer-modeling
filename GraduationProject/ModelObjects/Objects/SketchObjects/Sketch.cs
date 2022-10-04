using System;
using System.Collections.Generic;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Sketch : ISketch
{
    public string SketchName { get; set; }
    public string Plane { get; set; }
    public (string, string, int) Face { get; set; }
    public List<UserPoint> UserPoints { get; set; }
    public List<Line> Lines { get; set; }
    public List<Arc> Arcs { get; set; }
    public List<Ellipse> Ellipses { get; set; }
    public List<Parabola> Parabolas { get; set; }

    public short UserPointCount => (short)UserPoints.Count;
    public short LineCount => (short)Lines.Count;
    public short ArcCount => (short)Arcs.Count;
    public short EllipseCount => (short)Ellipses.Count;
    public short ParabolaCount => (short)Parabolas.Count;

    public bool UserPointIsTrue => UserPointCount != 0;
    public bool LineIsTrue => LineCount != 0;
    public bool ArcIsTrue => ArcCount != 0;
    public bool EllipseIsTrue => EllipseCount != 0;
    public bool ParabolaIsTrue => ParabolaCount != 0;
}