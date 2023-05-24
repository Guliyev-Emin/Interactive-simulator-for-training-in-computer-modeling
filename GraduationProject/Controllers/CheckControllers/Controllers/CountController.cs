namespace GraduationProject.Controllers.CheckControllers.Controllers;

public static class CountController
{
    public static bool CountIsTrue(uint inData, uint userData, out uint data, bool flag)
    {
        var @true = true;
        var @false = false;
        if (flag)
        {
            @true = false;
            @false = true;
        }

        if (userData == inData)
        {
            data = userData;
            return @true;
        }

        if (inData > userData)
        {
            data = userData;
            return @false;
        }

        if (inData < userData)
        {
            data = userData;
            return @false;
        }

        data = 0;
        return @false;
    }

    public static bool PointCountIsTrue(uint inData, uint userData, out uint data, bool flag)
    {
        return CountIsTrue(inData, userData, out data, flag);
    }

    public static bool LineCountIsTrue(uint inData, uint userData, out uint data, bool flag)
    {
        return CountIsTrue(inData, userData, out data, flag);
    }

    public static bool ArcCountIsTrue(uint inData, uint userData, out uint data, bool flag)
    {
        return CountIsTrue(inData, userData, out data, flag);
    }
}