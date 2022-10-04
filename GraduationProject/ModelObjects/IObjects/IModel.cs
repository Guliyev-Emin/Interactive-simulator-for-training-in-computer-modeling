using System.Collections.Generic;
using GraduationProject.ModelObjects.Objects;

namespace GraduationProject.ModelObjects.IObjects;

public interface IModel
{
    public short NumberOf3DOperations { get; }

    public string Name { get; set; }
    public List<TridimensionalOperation> Features { get; set; }

    public List<Mirror> Mirrors { get; set; }
    //public List<IFillet> Fillets { get; set; }
}