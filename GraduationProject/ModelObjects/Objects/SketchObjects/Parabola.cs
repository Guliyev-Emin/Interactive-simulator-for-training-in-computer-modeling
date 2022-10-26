using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Parabola : IParabola
{
    private const ushort Accuracy = 7;
    private double _xApex;
    private double _xCenter;
    private double _xEnd;
    private double _xFocus;
    private double _xStart;
    private double _yApex;
    private double _yCenter;
    private double _yEnd;
    private double _yFocus;
    private double _yStart;
    private double _zApex;
    private double _zCenter;
    private double _zEnd;
    private double _zFocus;
    private double _zStart;

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

    public double XFocus
    {
        get => Math.Round(_xFocus, Accuracy);
        set => _xFocus = value;
    }

    public double YFocus
    {
        get => Math.Round(_yFocus, Accuracy);
        set => _yFocus = value;
    }

    public double ZFocus
    {
        get => Math.Round(_zFocus, Accuracy);
        set => _zFocus = value;
    }

    public double XApex
    {
        get => Math.Round(_xApex, Accuracy);
        set => _xApex = value;
    }

    public double YApex
    {
        get => Math.Round(_yApex, Accuracy);
        set => _yApex = value;
    }

    public double ZApex
    {
        get => Math.Round(_zApex, Accuracy);
        set => _zApex = value;
    }
}