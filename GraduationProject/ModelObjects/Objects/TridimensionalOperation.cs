﻿using System;
using GraduationProject.ModelObjects.IObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.ModelObjects.Objects;

[Serializable]
public record TridimensionalOperation : ITridimensionalOperation
{
    private const ushort Accuracy = 7;
    private double _depth;
    public string Name { get; set; }
    public string Type { get; set; }
    public Sketch Sketch { get; set; }
    public Mirror Mirror { get; set; }
    public double Depth { get => Math.Round(_depth, Accuracy);
        set => _depth = value; }
}