using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;

namespace GraduationProject.Construction;

[UsedImplicitly]
public class Remove : Connection
{
    private static Feature _feature;

    public static void RemoveFeature()
    {
        while (SwModel.GetFeatureCount() > 12) StepRemove();
    }

    public static void StepRemove()
    {
        _feature = (Feature)SwModel.FeatureByPositionReverse(0);

        if (_feature.GetTypeName().Equals("OriginProfileFeature")) return;
        if (_feature != null && !_feature.GetTypeName().Equals("ProfileFeature"))
        {
            SwModel.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
            SwModel.EditDelete();
        }

        _feature = (Feature)SwModel.FeatureByPositionReverse(0);
        if (_feature == null || !_feature.GetTypeName().Equals("ProfileFeature")) return;
        SwModel.Extension.SelectByID2(_feature.Name, "SKETCH", 0, 0, 0, false, 0, null, 0);
        SwModel.EditDelete();
    }
}