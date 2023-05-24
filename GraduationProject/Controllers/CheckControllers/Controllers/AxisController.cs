using GraduationProject.ModelObjects.IObjects.ISketchObjects;

namespace GraduationProject.Controllers.CheckControllers.Controllers;

public static class AxisController
{
    public static string GetArrangement(ILine line)
    {
        if (line.XStart.Equals(line.XEnd) && !line.YStart.Equals(line.YEnd))
            return "Вертикальный";
        if (!line.XStart.Equals(line.XEnd) && line.YStart.Equals(line.YEnd))
            return "Горизонтальный";
        return "Наклонный";
    }
}