using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Arc : IArc
{
    private decimal _arcRadius;

    private decimal _xCenter;
    private decimal _xEnd;
    private decimal _xStart;
    private decimal _yCenter;
    private decimal _yEnd;
    private decimal _yStart;
    private decimal _zCenter;
    private decimal _zEnd;
    private decimal _zStart;

    public decimal ArcRadius
    {
        get => _arcRadius;
        set => _arcRadius = value;
    }
    public short Direction { get; set; }
    public string Coordinate { get; set; }
    public decimal XStart
    {
        get => _xStart;
        set => _xStart = value;
    }
    public decimal YStart
    {
        get => _yStart;
        set => _yStart = value;
    }
    public decimal ZStart
    {
        get => _zStart;
        set => _zStart = value;
    }
    public decimal XEnd
    {
        get => _xEnd;
        set => _xEnd = value;
    }
    public decimal YEnd
    {
        get => _yEnd;
        set => _yEnd = value;
    }
    public decimal ZEnd
    {
        get => _zEnd;
        set => _zEnd = value;
    }
    public decimal XCenter
    {
        get => _xCenter;
        set => _xCenter = value;
    }
    public decimal YCenter
    {
        get => _yCenter;
        set => _yCenter = value;
    }
    public decimal ZCenter
    {
        get => _zCenter;
        set => _zCenter = value;
    }
}