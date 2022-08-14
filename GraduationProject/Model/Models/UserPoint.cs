using System;
using GraduationProject.Model.IModels;

namespace GraduationProject.Model.Models;

[Serializable]
public record UserPoint : IUserPoint
{
    public string Coordinate { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}