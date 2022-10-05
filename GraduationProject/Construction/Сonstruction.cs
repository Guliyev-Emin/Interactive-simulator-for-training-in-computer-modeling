﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    private const double MillimetersToMeters = 0.001;
    private static Feature _feature;
    private static List<Feature> _features = new();
    private static Entity _entity;

    private static void Draw(ITridimensionalOperation feature)
    {
        var sketch = feature.Sketch;
        if (sketch is not null)
        {
            if (sketch.Plane is not null)
                SelectPlane(sketch.Plane);
            else if (sketch.Face != null) SelectFace(sketch.Face);
            SwSketchManager.InsertSketch(false);

            if (sketch.UserPoints.Count != 0)
                foreach (var userPoint in sketch.UserPoints!)
                    SwSketchManager.CreatePoint(userPoint.X, userPoint.Y, userPoint.Z);

            if (sketch.Arcs.Count != 0)
                foreach (var arc in sketch.Arcs!)
                {
                    if (CircleCheck(arc))
                    {
                        SwSketchManager.CreateCircleByRadius(arc.XCenter * MillimetersToMeters,
                            arc.YCenter * MillimetersToMeters,
                            arc.ZCenter * MillimetersToMeters, arc.ArcRadius * MillimetersToMeters);
                        continue;
                    }

                    SwSketchManager.CreateArc(arc.XCenter * MillimetersToMeters, arc.YCenter * MillimetersToMeters,
                        arc.ZCenter * MillimetersToMeters, arc.XStart * MillimetersToMeters,
                        arc.YStart * MillimetersToMeters,
                        arc.ZStart * MillimetersToMeters, arc.XEnd * MillimetersToMeters,
                        arc.YEnd * MillimetersToMeters, arc.ZEnd * MillimetersToMeters,
                        arc.Direction);
                }

            if (sketch.Lines.Count != 0)
                foreach (var line in sketch.Lines!)
                {
                    var swSketchSegment = SwSketchManager.CreateLine(line.XStart * MillimetersToMeters,
                        line.YStart * MillimetersToMeters,
                        line.ZStart, line.XEnd * MillimetersToMeters, line.YEnd * MillimetersToMeters,
                        line.ZEnd * MillimetersToMeters);
                    if (!line.LineType.Equals(4)) continue;
                    swSketchSegment.Style = line.LineType;
                    SwSketchManager.CreateConstructionGeometry();
                }
        }

        switch (feature.Type)
        {
            case "Extrusion":
            case "Boss":
                _feature = Extrusion(feature.Depth * MillimetersToMeters);
                break;
            case "MirrorPattern":
                _feature = Mirror(feature.Mirror);
                break;
            case "Rib":
                Rib(feature.Depth);
                _feature = null;
                break;
            case "Cut":
                _feature = Cut(feature.Depth * MillimetersToMeters);
                break;
        }

        if (_feature is not null)
        {
            _feature.Name = feature.Name;
            _features.Add(_feature);
        }

        SwModel.ClearSelection2(true);
    }

    public static void StepDrawing(IModel model)
    {
    }

    public static void Drawing(string modelVariant)
    {
        _features = new List<Feature>();
        IModel model = FileController.GetModelObjectFromFile(modelVariant);
        foreach (var feature in model.Features) Draw(feature);
    }
    
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

    private static Feature Cut(double deepth, bool flip = false,
        swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
    {
        return SwModel.FeatureManager.FeatureCut2(true, flip, false, (int)mode, (int)mode,
            deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
            false, false, false, false, false);
    }

    private static void Rib(double depth)
    {
        SwModel.FeatureManager.InsertRib(false, true, depth * MillimetersToMeters,
            0, false, false, true,
            0, false, false);
    }

    private static Feature Mirror(IMirror mirror)
    {
        foreach (var featureName in mirror.FeatureNames)
            SwModel.Extension.SelectByID2(featureName, "BODYFEATURE", 0, 0, 0, false, 1, null, 0);
        Thread.Sleep(3000);
        SwModel.Extension.SelectByID2(mirror.Plane, "PLANE", 0, 0, 0, true, 2, null, 0);
        var feature = SwModel.FeatureManager.InsertMirrorFeature2(false, false, false, false,
            (int)swFeatureScope_e.swFeatureScope_AllBodies);
        return feature;
    }

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

    private static void SelectPlane(string name, string obj = "PLANE")
    {
        SwModel.Extension.SelectByID2(name, obj, 0, 0, 0, false, 0, null, 0);
    }

    private static bool CircleCheck(IPoint arc)
    {
        return arc.XStart.Equals(arc.XEnd) && arc.YStart.Equals(arc.YEnd) && arc.ZStart.Equals(arc.ZEnd);
    }
}