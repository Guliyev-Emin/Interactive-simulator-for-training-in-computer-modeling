using System.Collections.Generic;
using System.Linq;
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
        if (correctSketches.Count.Equals(userSketches.Count))
            return (from userSketch in userSketches
                let correctSketch = GetCorrectSketch(ref correctSketches, userSketch)
                where correctSketch is not null
                select new Comparer().SketchComparer(correctSketch, userSketch)).ToList();
        Message.ErrorMessage(
            "Проверка не будет выполнена, так как количество пользователских эскизов, не совпадает с количеством правильных эскизов!");
        return null;
    }

    private static SketchInfo GetCorrectSketch(ref List<SketchInfo> correctSketches, ISketchInfo userSketch)
    {
        var correctSketch = correctSketches.Where(correct =>
            correct.Lines.Count.Equals(userSketch.Lines.Count)
            && correct.Arcs.Count.Equals(userSketch.Arcs.Count)
            && correct.Ellipses.Count.Equals(userSketch.Ellipses.Count)
            && correct.Parabolas.Count.Equals(userSketch.Parabolas.Count)).ToList();

        switch (correctSketch.Count)
        {
            case 0:
                Message.ErrorMessage(userSketch.SketchName + " не соответвует ни одному из правильных эскизов!");
                return null;
            case 1:
            {
                correctSketches.Remove(correctSketch.First());
                return correctSketch.First();
            }
            default:
            {
                var corrects = correctSketch.Where(correct => correct.Depth.Equals(userSketch.Depth)).ToList();
                if (corrects.Count is not (> 1 or 0))
                {
                    correctSketches.Remove(corrects.First());
                    return corrects.First();
                }

                foreach (var correct in correctSketch)
                {
                    correctSketches.Remove(correct);
                    return correct;
                }
    
                Message.ErrorMessage(
                    "Количестово правильных эскизов превышен! " +
                    "Ошибка нахождения правильности эскиза, пожалуйста обратитесь к разработчику программы!" +
                    "\n\tКласс: Controller\n\tФункция: GetCorrectSketch");
                return null;
            }
        }
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