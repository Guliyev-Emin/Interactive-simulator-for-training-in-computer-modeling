using System;
using System.Collections.Generic;
using GraduationProject.ModelObjects.IObjects;

namespace GraduationProject.ModelObjects.Objects;

[Serializable]
public record Mirror : IMirror
{
    public string Name { get; set; }
    public string Plane { get; set; }
    public List<string> FeatureNames { get; set; }
}