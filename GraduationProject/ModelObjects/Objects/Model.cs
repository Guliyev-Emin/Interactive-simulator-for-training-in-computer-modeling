using System;
using System.Collections.Generic;
using GraduationProject.ModelObjects.IObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.ModelObjects.Objects;

[Serializable]
public record Model : IModel
{
    public short NumberOf3DOperations => (short)Features.Count;
    public string Name { get; set; }
    public List<TridimensionalOperation> Features { get; set; }
    public List<Sketch> Sketches { get; set; }
}