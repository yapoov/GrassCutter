using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UIChange))]
public class UIChangeEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Init"))
            ((UIChange)target).Alpha();
        if (GUILayout.Button("Color"))
            ((UIChange)target).Color();
        if (GUILayout.Button("Font"))
            ((UIChange)target).Font();
    }
}