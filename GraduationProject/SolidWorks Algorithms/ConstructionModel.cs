using System.Collections.Generic;
using System.Linq;
using GraduationProject.Controllers;
using GraduationProject.ModelObjects.IObjects;
using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using IFace = GraduationProject.ModelObjects.IObjects.ISketchObjects.IFace;

namespace GraduationProject.SolidWorks_Algorithms;

[UsedImplicitly]
public class ConstructionModel : Connection
{
    private static Feature _feature;
    private static List<Feature> _features = new();
    private static Entity _entity;

    /// <summary>
    ///     Конструирование модели
    /// </summary>
    /// <param name="feature">Информация об модели</param>
    private static void Draw(ITridimensionalOperation feature)
    {
        var sketch = feature.Sketch;
        if (sketch is not null)
        {
            if (sketch.Plane is not null)
                SelectPlane(sketch.Plane);
            else if (sketch.Face != null) SelectFace(sketch.Face);
            SwSketchManager.InsertSketch(false);

            var addToDbOrig = SwSketchManager.AddToDB;
            SwSketchManager.AddToDB = true;

            if (sketch.UserPoints.Count != 0)
                foreach (var userPoint in sketch.UserPoints!)
                    SwSketchManager.CreatePoint((double)userPoint.X, (double)userPoint.Y, (double)userPoint.Z);

            if (sketch.Lines.Count != 0)
                foreach (var line in sketch.Lines!)
                {
                    var swSketchSegment = SwSketchManager.CreateLine((double)line.XStart,
                        (double)line.YStart,
                        (double)line.ZStart,
                        (double)line.XEnd,
                        (double)line.YEnd,
                        (double)line.ZEnd);
                    if (!line.Type.Equals(4)) continue;
                    swSketchSegment.Style = line.Type;
                    SwSketchManager.CreateConstructionGeometry();
                }


            if (sketch.Arcs.Count != 0)
                foreach (var arc in sketch.Arcs!)
                    SwSketchManager.CreateArc((double)arc.XCenter,
                        (double)arc.YCenter,
                        (double)arc.ZCenter, (double)arc.XStart,
                        (double)arc.YStart,
                        (double)arc.ZStart, (double)arc.XEnd,
                        (double)arc.YEnd, (double)arc.ZEnd,
                        arc.Direction);

            SwSketchManager.AddToDB = addToDbOrig;
        }

        switch (feature.Type)
        {
            case "Extrusion":
            case "Boss":
                _feature = Extrusion((double)feature.Depth);
                break;
            case "MirrorPattern":
                _feature = Mirror(feature.Mirror);
                break;
            case "Rib":
                Rib((double)feature.Depth);
                var rib = (Feature)SwModel.FeatureByPositionReverse(0);
                _feature = rib.GetTypeName().Equals(feature.Type) ? rib : null;
                break;
            case "Cut":
                _feature = Cut((double)feature.Depth);
                break;
        }

        if (_feature is not null)
        {
            _feature.Name = feature.Name;
            _features.Add(_feature);
        }

        SwModel.ClearSelection2(true);
    }

    /// <summary>
    ///     Процедура конструирвоания модели
    /// </summary>
    /// <param name="modelVariant">Вариант модели</param>
    public static void Drawing(string modelVariant)
    {
        _features = new List<Feature>();
        IModel model = FileController.GetModelObjectFromFile(modelVariant);
        foreach (var feature in model.Features) Draw(feature);
    }
    
    

    /// <summary>
    ///     Метод для выдавливания эскиза
    /// </summary>
    /// <param name="deepth">Длина выдавливания, м</param>
    /// <param name="sd">Bool-параметр для выдавливания в одну сторону или в обе стороны</param>
    /// <param name="dir">Направление выдавливания</param>
    /// <returns>Трехмерная операция</returns>
    private static Feature Extrusion(double deepth, bool sd = true, bool dir = false)
    {
        // если Sd = true, то вытягивание в одну сторону, если ложь, тогда в обе стороны!
        if (sd)
            return SwModel.FeatureManager.FeatureExtrusion2(true, false, dir,
                (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
                deepth, 0, false, false, false, false, 0, 0, false,
                false, false, false, true,
                true, true, 0, 0, false);
        return SwModel.FeatureManager.FeatureExtrusion2(false, false, dir,
            (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
            deepth, deepth, false, false, false, false, 0, 0, false,
            false, false, false, true,
            true, true, 0, 0, false);
    }

    /// <summary>
    ///     Метод для выреза
    /// </summary>
    /// <param name="deepth">Длина выдавливания, м</param>
    /// <param name="flip">Направление выреза</param>
    /// <param name="mode">Тип выреза</param>
    /// <returns></returns>
    private static Feature Cut(double deepth, bool flip = false,
        swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
    {
        return SwModel.FeatureManager.FeatureCut2(true, flip, false, (int)mode, (int)mode,
            deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
            false, false, false, false, false);
    }

    /// <summary>
    ///     Метод по созданию ребра
    /// </summary>
    /// <param name="depth">Глубина выдавливания</param>
    private static void Rib(double depth)
    {
        SwModel.FeatureManager.InsertRib(false, true, depth,
            0, false, false, true,
            0, false, false);
    }

    /// <summary>
    ///     Метод создания зеркального отражения
    /// </summary>
    /// <param name="mirror">Информация об зеркальном отражении</param>
    /// <returns>Трехмерную операцию</returns>
    private static Feature Mirror(IMirror mirror)
    {
        foreach (var featureName in mirror.FeatureNames)
            SwModel.Extension.SelectByID2(featureName, "BODYFEATURE", 0, 0, 0, false, 1, null, 0);
        SwModel.Extension.SelectByID2(mirror.Plane, "PLANE", 0, 0, 0, true, 2, null, 0);
        var feature = SwModel.FeatureManager.InsertMirrorFeature2(false, false, false, false,
            (int)swFeatureScope_e.swFeatureScope_AllBodies);
        return feature;
    }

    /// <summary>
    ///     Метод выбора грани
    /// </summary>
    /// <param name="face">Информация об грани</param>
    private static void SelectFace(IFace face)
    {
        var feature = _features.First(f => f.Name.Equals(face?.FeatureName));
        var faces = (dynamic[])feature.GetFaces();
        _entity = null;
        foreach (Face2 face2 in faces)
        {
            var face2Normal = (double[])face2.Normal;
            if (!face2Normal[0].Equals(face.I) || !face2Normal[1].Equals(face.J) ||
                !face2Normal[2].Equals(face.K)) continue;
            _entity = face2 as Entity;
            break;
        }

        if (_entity is null)
            return;
        _entity!.Select(true);
    }

    /// <summary>
    ///     Метод по выборе плоскости
    /// </summary>
    /// <param name="name">Наименование плоскости</param>
    /// <param name="obj">Объект плоскости</param>
    private static void SelectPlane(string name, string obj = "PLANE")
    {
        SwModel.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
    }
}