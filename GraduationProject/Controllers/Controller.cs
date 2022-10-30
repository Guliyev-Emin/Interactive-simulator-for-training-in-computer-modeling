using System.Collections.Generic;
using System.Windows.Forms;
using GraduationProject.Construction;
using GraduationProject.ModelObjects.IObjects.ISketchObjects;
using JetBrains.Annotations;

namespace GraduationProject.Controllers;

[UsedImplicitly]
public class Controller : Connection
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelVarian"></param>
    /// <returns></returns>
    public static (TreeNode CorrectNodes, TreeNode ErrorNodes)? ModelValidationController(string modelVarian)
    {
        var userModel = Reader.GetModel();
        var correctModel = FileController.GetModelObjectFromFile(modelVarian);
        return Comparer.ModelObjectsComparision(userModel, correctModel);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLine"></param>
    /// <returns></returns>
    public static string GetLineArrangement(ILine userLine)
    {
        if (userLine.XStart.Equals(userLine.XEnd) && !userLine.YStart.Equals(userLine.YEnd))
            return "Вертикальный";
        if (!userLine.XStart.Equals(userLine.XEnd) && userLine.YStart.Equals(userLine.YEnd))
            return "Горизонтальный";

        return "Наклонный";
    }
}