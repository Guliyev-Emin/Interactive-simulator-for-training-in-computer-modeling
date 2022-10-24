using System.Collections.Generic;
using GraduationProject.ModelObjects.Objects;

namespace GraduationProject.Controllers;

public class ComparerTest
{
    public static void ModelObjectsComparision(Model userModel, Model correctModel)
    {
        if (userModel.NumberOf3DOperations.Equals(correctModel.NumberOf3DOperations))
        {
            FeaturesComparision(userModel.Features, correctModel.Features);
            return;
        }
        Message.ErrorMessage("Количество пользовательских трехмерных операций не соответствует количеству правильных трехмерных операций!");
    }

    private static void FeaturesComparision(List<TridimensionalOperation> userFeatures,
        List<TridimensionalOperation> correctFeatures)
    {
        var index = 0;
        
    }
    
}