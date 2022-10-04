using System;
using System.Collections.Generic;
using GraduationProject.ModelObjects.IObjects;

namespace GraduationProject.ModelObjects.Objects;

[Serializable]
public record Model : IModel
{
    public short NumberOf3DOperations => (short)(Features.Count + Mirrors.Count);
    public string Name { get; set; }
    public List<TridimensionalOperation> Features { get; set; }

    public List<Mirror> Mirrors { get; set; }
    //public List<IFillet> Fillets { get; set; }
}