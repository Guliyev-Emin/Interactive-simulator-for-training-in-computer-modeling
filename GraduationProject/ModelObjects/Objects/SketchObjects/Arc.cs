using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Arc : IArc
{
    private double _arcRadius;

    private double _xCenter;
    private double _xEnd;
    private double _xStart;
    private double _yCenter;
    private double _yEnd;
    private double _yStart;
    private double _zCenter;
    private double _zEnd;
    private double _zStart;

    public double ArcRadius
    {
        get => _arcRadius;
        set => _arcRadius = value;
    }

    public short Direction { get; set; }
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

    public double XCenter
    {
        get => _xCenter;
        set => _xCenter = value;
    }

    public double YCenter
    {
        get => _yCenter;
        set => _yCenter = value;
    }

    public double ZCenter
    {
        get => _zCenter;
        set => _zCenter = value;
    }
}