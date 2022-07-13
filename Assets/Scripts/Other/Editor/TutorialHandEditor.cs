using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(TutorialHand))]
public class TutorialHandEditor : Editor {
    TutorialHand hand;

    void OnEnable() {
        hand = (TutorialHand)target;
    }

    void OnSceneGUI() {
        Handles.color = Col.black;
        List<Vector3> lis = Crv.CatmullRomSpline(hand.points, hand.smooth, hand.spacing);
        for (int i = 1; i < lis.Count; i++)
            Handles.DrawLine(hand.TfPnt(lis[i - 1]), hand.TfPnt(lis[i]));

        Handles.color = Col.red;
        for (int i = 0; i < hand.points.Count; i++)
            hand.points[i] = hand.TfInvPnt(
                Handles.FreeMoveHandle(
                    hand.TfPnt(hand.points[i]),
                    Q.O, 25, V3.O, Handles.CylinderHandleCap
                )
            );
    }
}