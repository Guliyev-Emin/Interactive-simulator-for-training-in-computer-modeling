using System;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.ModelObjects.Objects.SketchObjects;

[Serializable]
public record Line : ILine
{
    public short Type { get; set; }
    public string Arrangement { get; set; }
    public decimal Length { get; set; }
    public string Coordinate { get; set; }
    public decimal XStart { get; set; }
    public decimal YStart { get; set; }
    public decimal ZStart { get; set; }
    public decimal XEnd { get; set; }
    public decimal YEnd { get; set; }
    public decimal ZEnd { get; set; }
}