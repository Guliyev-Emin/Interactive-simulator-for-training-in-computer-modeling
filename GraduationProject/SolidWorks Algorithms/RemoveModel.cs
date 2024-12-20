﻿using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;

namespace GraduationProject.SolidWorks_Algorithms;

[UsedImplicitly]
public class RemoveModel : Connection
{
    private static Feature _feature;

    /// <summary>
    /// </summary>
    public static void RemoveFeature()
    {
        var modelIsTrue = true;
        while (modelIsTrue) modelIsTrue = StepRemove();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static bool StepRemove()
    {
        _feature = (Feature)SwModel.FeatureByPositionReverse(0);
        if (_feature.GetTypeName().Equals("OriginProfileFeature")) return false;
        if (_feature != null && !_feature.GetTypeName().Equals("ProfileFeature"))
        {
            SwModel.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
            SwModel.EditDelete();
        }

        _feature = (Feature)SwModel.FeatureByPositionReverse(0);
        if (_feature == null || !_feature.GetTypeName().Equals("ProfileFeature")) return false;
        SwModel.Extension.SelectByID2(_feature.Name, "SKETCH", 0, 0, 0, false, 0, null, 0);
        SwModel.EditDelete();
        return true;
    }
}