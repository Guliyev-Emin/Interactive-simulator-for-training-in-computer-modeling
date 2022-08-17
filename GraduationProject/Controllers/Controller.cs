using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using GraduationProject.Construction;
using GraduationProject.Model.IModels;
using GraduationProject.Model.Models;
using JetBrains.Annotations;

namespace GraduationProject.Controllers;

[UsedImplicitly]
public class Controller : Connection
{
    public static List<List<List<(List<string> correct, List<string> error)>>> Comparer(string modelVariant)
    {
        var userSketches = Reader.SketchInfos;
        var correctSketches = FileController.GetModelObjectSketchesFromFile(modelVariant);
        if (correctSketches is null) return null;
        var comparerResults = new List<List<List<(List<string> correct, List<string> error)>>>();
        var index = 0;
        foreach (var userSketch in userSketches)
        {
            comparerResults.Add(new Comparer().SketchComparer(correctSketches[index++], userSketch));
        }

        return comparerResults;
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