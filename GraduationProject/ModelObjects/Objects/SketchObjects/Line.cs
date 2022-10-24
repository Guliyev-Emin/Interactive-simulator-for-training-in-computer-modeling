using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Line : ILine
{
    private double _xEnd;
    private double _xStart;
    private double _yEnd;
    private double _yStart;
    private double _zEnd;
    private double _zStart;

    public short LineType { get; set; }
    public string LineArrangement { get; set; }

    public double LineLength
    {
        get;
        set;
    }

    public string Coordinate { get; set; }

    public double XStart
    {
        get => _xStart;
        set => _xStart = value;
    }

    public double YStart
    {
        get => _yStart;
        set => _yStart = value;
    }

    public double ZStart
    {
        get => _zStart;
        set => _zStart = value;
    }

    public double XEnd
    {
        get => _xEnd;
        set => _xEnd = value;
    }

    public double YEnd
    {
        get => _yEnd;
        set => _yEnd = value;
    }

    public double ZEnd
    {
        get => _zEnd;
        set => _zEnd = value;
    }
}