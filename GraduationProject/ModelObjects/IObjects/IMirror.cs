using System.Collections.Generic;

namespace GraduationProject.ModelObjects.IObjects;

public interface IMirror
{
    public string Name { get; set; }
    public string Plane { get; set; }
    public List<string> FeatureNames { get; set; }
}