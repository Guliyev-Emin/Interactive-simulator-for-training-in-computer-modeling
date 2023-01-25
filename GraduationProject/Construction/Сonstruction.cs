using System.Collections.Generic;
using System.Linq;
using GraduationProject.Controllers;
using GraduationProject.ModelObjects.IObjects;
using GraduationProject.ModelObjects.IObjects.ISketchObjects.IPoints;
using JetBrains.Annotations;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using IFace = GraduationProject.ModelObjects.IObjects.ISketchObjects.IFace;

namespace GraduationProject.Construction;

[UsedImplicitly]
public class Сonstruction : Connection
{
    private static Feature _feature;
    private static List<Feature> _features = new();
    private static Entity _entity;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="feature"></param>
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
                    SwSketchManager.CreatePoint(userPoint.X, userPoint.Y, userPoint.Z);
            
            if (sketch.Lines.Count != 0)
                foreach (var line in sketch.Lines!)
                {
                    var swSketchSegment = SwSketchManager.CreateLine(line.XStart,
                        line.YStart,
                        line.ZStart,
                        line.XEnd,
                        line.YEnd,
                        line.ZEnd);
                    if (!line.LineType.Equals(4)) continue;
                    swSketchSegment.Style = line.LineType;
                    SwSketchManager.CreateConstructionGeometry();
                }

            
            if (sketch.Arcs.Count != 0)
                foreach (var arc in sketch.Arcs!)
                {
                    SwSketchManager.CreateArc(arc.XCenter,
                        arc.YCenter,
                        arc.ZCenter, arc.XStart,
                        arc.YStart,
                        arc.ZStart, arc.XEnd,
                        arc.YEnd, arc.ZEnd,
                        arc.Direction);
                }

            SwSketchManager.AddToDB = addToDbOrig;
        }

        switch (feature.Type)
        {
            case "Extrusion":
            case "Boss":
                _feature = Extrusion(feature.Depth);
                break;
            case "MirrorPattern":
                _feature = Mirror(feature.Mirror);
                break;
            case "Rib":
                Rib(feature.Depth);
                var rib = (Feature)SwModel.FeatureByPositionReverse(0);
                _feature = rib.GetTypeName().Equals(feature.Type) ? rib : null;
                break;
            case "Cut":
                _feature = Cut(feature.Depth);
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
    /// 
    /// </summary>
    /// <param name="model"></param>
    public static void StepDrawing(IModel model)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelVariant"></param>
    public static void Drawing(string modelVariant)
    {
        _features = new List<Feature>();
        IModel model = FileController.GetModelObjectFromFile(modelVariant);
        foreach (var feature in model.Features) Draw(feature);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deepth"></param>
    /// <param name="sd"></param>
    /// <param name="dir"></param>
    /// <returns></returns>
    private static Feature Extrusion(double deepth, bool sd = true, bool dir = false)
    {
        // если Sd = true, то вытягивание в одну сторону, если ложь, тогда в обе стороны!
        if (sd)
            return SwModel.FeatureManager.FeatureExtrusion2(true, false, dir,
                (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, true,
                true, true, 0, 0, false);
        return SwModel.FeatureManager.FeatureExtrusion2(false, false, dir,
            (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
            deepth, deepth, false, false, false, false, 0, 0, false, false, false, false, true,
            true, true, 0, 0, false);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="deepth"></param>
    /// <param name="flip"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    private static Feature Cut(double deepth, bool flip = false,
        swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
    {
        return SwModel.FeatureManager.FeatureCut2(true, flip, false, (int)mode, (int)mode,
            deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
            false, false, false, false, false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="depth"></param>
    private static void Rib(double depth)
    {
        SwModel.FeatureManager.InsertRib(false, true, depth,
            0, false, false, true,
            0, false, false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mirror"></param>
    /// <returns></returns>
    private static Feature Mirror(IMirror mirror)
    {
        foreach (var featureName in mirror.FeatureNames)
            SwModel.Extension.SelectByID2(featureName, "BODYFEATURE", 0, 0, 0, false, 1, null, 0);
        SwModel.Extension.SelectByID2(mirror.Plane, "PLANE", 0, 0, 0, true, 2, null, 0);
        var feature = SwModel.FeatureManager.InsertMirrorFeature2(false, false, false, false,
            (int)swFeatureScope_e.swFeatureScope_AllBodies);
        return feature;
    }

    private static void Fillet()
    {
        //SwFeatureManager.Fillet
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="face"></param>
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
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    private static void SelectPlane(string name, string obj = "PLANE")
    {
        SwModel.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
    }
    
}