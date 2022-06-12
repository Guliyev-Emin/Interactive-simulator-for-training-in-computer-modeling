using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;

namespace GraduationProject.Construction
{
    [UsedImplicitly]
    public class Remove : Connection
    {
        private static Feature _feature;

        public static void RemoveFeature()
        {
            while (ModelDoc2.GetFeatureCount() > 12) StepRemove();
        }

        public static void StepRemove()
        {
            _feature = (Feature) ModelDoc2.FeatureByPositionReverse(0);

            if (_feature.GetTypeName().Equals("OriginProfileFeature")) return;
            if (_feature != null && !_feature.GetTypeName().Equals("ProfileFeature"))
            {
                ModelDoc2.Extension.SelectByID2(_feature.Name, "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
                ModelDoc2.EditDelete();
            }

            _feature = (Feature) ModelDoc2.FeatureByPositionReverse(0);
            if (_feature == null || !_feature.GetTypeName().Equals("ProfileFeature")) return;
            ModelDoc2.Extension.SelectByID2(_feature.Name, "SKETCH", 0, 0, 0, false, 0, null, 0);
            ModelDoc2.EditDelete();
        }
    }
}