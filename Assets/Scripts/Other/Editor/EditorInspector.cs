using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Test))]
public class TestEditor : Editor {
    int selectionGridIdx = 0;
    string[] selectionGridArr = new string[] { "SelectionGrid 0", "SelectionGrid 1", "SelectionGrid 2", "SelectionGrid 3" };
    int toolbarIdx = 0;
    string[] toolbarArr = new string[] { "Toolbar 0", "Toolbar 1", "Toolbar 2", "Toolbar 3" };
    string textArea = "TextArea TextArea TextArea TextArea TextArea TextArea TextArea TextArea TextArea TextArea ";
    string passwordField = "PasswordField";
    string textField = "TextField";
    bool isToggle = true;
    float horizontalSlider = 0, verticalSlider = 0;
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GUILayout.Label("Label");

        GUILayout.Space(20);

        isToggle = GUILayout.Toggle(isToggle, "Toggle");
        if (GUILayout.Button("Button")) {
            Debug.Log("Button");
            ((Test)target).Button();
        }
        if (GUILayout.RepeatButton("RepeatButton"))
            Debug.Log("RepeatButton");

        GUILayout.Space(20);

        selectionGridIdx = GUILayout.SelectionGrid(selectionGridIdx, selectionGridArr, 2);
        toolbarIdx = GUILayout.Toolbar(toolbarIdx, toolbarArr);

        GUILayout.Space(20);

        textField = GUILayout.TextField(textField, 25);
        textArea = GUILayout.TextArea(textArea, 200);
        passwordField = GUILayout.PasswordField(passwordField, "*"[0], 25);

        GUILayout.Space(20);

        horizontalSlider = GUILayout.HorizontalSlider(horizontalSlider, 0, 10);
        verticalSlider = GUILayout.VerticalSlider(verticalSlider, 10, 0);
    }
}