using System.Collections.Generic;
using GraduationProject.Construction;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;
using JetBrains.Annotations;

namespace GraduationProject.Controllers;

[UsedImplicitly]
public class Controller : Connection
{
    public static void ModelValidationController(string modelVarian)
    {
        var userModel = Reader.GetModel();
        var correctModel = FileController.GetModelObjectFromFile(modelVarian);
        Comparer.ModelObjectsComparision(userModel, correctModel);

    }

    public static string GetLineArrangement(ILine userLine)
    {
        if (userLine.XStart.Equals(userLine.XEnd) && !userLine.YStart.Equals(userLine.YEnd))
            return "Вертикальный";
        if (!userLine.XStart.Equals(userLine.XEnd) && userLine.YStart.Equals(userLine.YEnd))
            return "Горизонтальный";

        return "Наклонный";
    }
}