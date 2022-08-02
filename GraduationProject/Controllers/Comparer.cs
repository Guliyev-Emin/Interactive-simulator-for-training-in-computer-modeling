using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraduationProject.Model.IModels;
using GraduationProject.Model.Models;

namespace GraduationProject.Controllers;

public static class Comparer
{
    public static List<string> ComparerResults;
    public static List<string> ErrorResult;
    private static short _lineIndex = 1;

    public static void SketchComparer(SketchInfo correctSketch, SketchInfo userSketch)
    {
        if (correctSketch.UserPoints?.Count != 0)
        {
            
        }
            
        if (correctSketch.Lines?.Count != 0)
        {
            _lineIndex = 1;
            LineComparer(correctSketch.Lines, userSketch.Lines);
        }

        if (correctSketch.Arcs?.Count != 0)
        {
            //Comparers(correctSketch.Arcs, userSketch.Arcs);
        }
    }
    
    private static void LineComparer(List<Line> correctLines, List<Line> userLines)
    {
        var index = (short) 0;
        foreach (var userLine in userLines)
        {
            var lineIsRight = false;
            foreach (var correctLine in correctLines.Where(correctLine => userLine.Equals(correctLine)))
            {
                correctLines.Remove(correctLine);
                lineIsRight = true;
                break;
            }
            GetLineProperties(correctLines, userLine, ++index, lineIsRight);
        }
    }

    private static void GetLineProperties(List<Line> correctLines, ILine userLine, short index, bool result)
    {
        var error = new StringBuilder();
        if (result)
        {
            var d = "\nОтрезок " + index + " построен верно:" + "\n\t" +
                    "Координаты: \n\t\t" +
                    userLine.LineCoordinate.Replace("\n", "\n\t\t") +
                    "\n\tДлина: " + userLine.LineLength + " мм";
            ComparerResults.Add(d);
            return;
        }

        foreach (var correctLine in correctLines)
        {
            if (!userLine.LineLength.Equals(correctLine.LineLength))
                error.Append($"Неверная длина {_lineIndex}-го отрезка: " + userLine.LineLength + " мм\n");
            if (!userLine.LineCoordinate.Split('\n')[0].Equals(correctLine.LineCoordinate.Split('\n')[0]))
            {
                error.Append("\t" + userLine.LineCoordinate.Split('\n')[0] + "\n\t");
                if (!userLine.XStart.Equals(correctLine.XStart))
                    error.Append("\tx: " + userLine.XStart + "\n\t");
                if (!userLine.YStart.Equals(correctLine.YStart))
                    error.Append("\ty: " + userLine.YStart + "\n");
                if (!userLine.ZStart.Equals(correctLine.ZStart))
                    error.Append("\tz: " + userLine.ZStart + "\n\t");
            }
            if (!userLine.LineCoordinate.Split('\n')[1].Equals(correctLine.LineCoordinate.Split('\n')[1]))
            {
                error.Append("\t" + userLine.LineCoordinate.Split('\n')[1] + "\n\t");
                if (!userLine.XEnd.Equals(correctLine.XEnd))
                    error.Append("\tx: " + userLine.XEnd + "\n\t");
                if (!userLine.YEnd.Equals(correctLine.YEnd))
                    error.Append("\ty: " + userLine.YEnd + "\n");
                if (!userLine.ZEnd.Equals(correctLine.ZEnd))
                    error.Append("\tz: " + userLine.ZEnd + "\n\t");
            }

            _lineIndex++;
            break;
        }
        ErrorResult.Add(error.ToString());
    }

    
}
