using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RotModel))]
public class RotModelEditor : Editor {
    RotModel model;

    void OnEnable() {
        model = (RotModel)target;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Button")) {
            RotModel obj = (RotModel)target;
            ObjExporter.MeshToFile(obj.Gc<MeshFilter>(), "Assets/" + obj.name + ".obj");
        }
    }

    void OnSceneGUI() {
        // input
        Event e = Event.current;
        Vector2 pos = model.TfInvPnt(HandleUtility.GUIPointToWorldRay(e.mousePosition).origin);

        // select index segment
        int selIdx = -1, selSeg = -1;
        for (int i = 0; i < model.points.Count; i++) {
            if (V3.Dis(model.points[i], pos) < 0.1f)
                selIdx = i;
            if (i == 0 && HandleUtility.DistancePointLine(pos, model.points[i], V2.X(model.points[i], 0)) < 0.1f)
                selSeg = 0;
            if (i >= 1 && HandleUtility.DistancePointLine(pos, model.points[i - 1], model.points[i]) < 0.1f)
                selSeg = i;
        }

        // add point
        if (e.type == EventType.MouseDown && e.button == 0 && e.shift)
            model.points.Insert(selSeg >= 0 ? selSeg : model.points.Count, pos);

        // delete point
        if (e.type == EventType.MouseDown && e.button == 1 && selIdx >= 0)
            model.points.RemoveAt(selIdx);

        // draw
        Handles.color = Col.red;
        for (int i = 0; i < model.points.Count; i++)
            model.points[i] = model.TfInvPnt(
                Handles.FreeMoveHandle(
                    model.TfInvPnt(model.points[i]),
                    Q.O, 0.1f, V3.O, Handles.CylinderHandleCap
                )
            );
        model.UpdateMesh();
    }
}