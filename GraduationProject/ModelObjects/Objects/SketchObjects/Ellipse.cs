using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Ellipse : IEllipse
{
    private const ushort Accuracy = 7;
    private double _xCenter;
    private double _xEnd;
    private double _xMajor;
    private double _xMinor;
    private double _xStart;
    private double _yCenter;
    private double _yEnd;
    private double _yMajor;
    private double _yMinor;
    private double _yStart;
    private double _zCenter;
    private double _zEnd;
    private double _zMajor;
    private double _zMinor;
    private double _zStart;
    public string Coordinate { get; set; }

    public double XStart
    {
        get => Math.Round(_xStart, Accuracy);
        set => _xStart = value;
    }

    public double YStart
    {
        get => Math.Round(_yStart, Accuracy);
        set => _yStart = value;
    }

    public double ZStart
    {
        get => Math.Round(_zStart, Accuracy);
        set => _zStart = value;
    }

    public double XEnd
    {
        get => Math.Round(_xEnd, Accuracy);
        set => _xEnd = value;
    }

    public double YEnd
    {
        get => Math.Round(_yEnd, Accuracy);
        set => _yEnd = value;
    }

    public double ZEnd
    {
        get => Math.Round(_zEnd, Accuracy);
        set => _zEnd = value;
    }

    public double XCenter
    {
        get => Math.Round(_xCenter, Accuracy);
        set => _xCenter = value;
    }

    public double YCenter
    {
        get => Math.Round(_yCenter, Accuracy);
        set => _yCenter = value;
    }

    public double ZCenter
    {
        get => Math.Round(_zCenter, Accuracy);
        set => _zCenter = value;
    }

    public double XMajor
    {
        get => Math.Round(_xMajor, Accuracy);
        set => _xMajor = value;
    }

    public double YMajor
    {
        get => Math.Round(_yMajor, Accuracy);
        set => _yMajor = value;
    }

    public double ZMajor
    {
        get => Math.Round(_zMajor, Accuracy);
        set => _zMajor = value;
    }

    public double XMinor
    {
        get => Math.Round(_xMinor, Accuracy);
        set => _xMinor = value;
    }

    public double YMinor
    {
        get => Math.Round(_yMinor, Accuracy);
        set => _yMinor = value;
    }

    public double ZMinor
    {
        get => Math.Round(_zMinor, Accuracy);
        set => _zMinor = value;
    }
}