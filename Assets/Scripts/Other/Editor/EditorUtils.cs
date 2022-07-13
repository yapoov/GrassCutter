using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class EditorUtils {
    public const string Ctrl = "%", Shift = "#", Alt = "&",
        Left = "LEFT", Right = "RIGHT", Up = "UP", Down = "DOWN",
        F1 = "F1", F2 = "F2", F3 = "F3", F4 = "F4", F5 = "F5", F6 = "F6", F7 = "F7", F8 = "F8", F9 = "F9", F10 = "F10", F11 = "F11", F12 = "F12",
        Home = "HOME", End = "END", PgUp = "PGUP", PgDn = "PGDN",
        CtrlShiftAlt = Ctrl + Shift + Alt, CtrlShift = Ctrl + Shift, CtrlAlt = Ctrl + Alt, ShiftAlt = Shift + Alt;

    [MenuItem("Utils/Screenshot")]
    public static void Screenshot() {
        A.Screenshot("Screenshots/", "Screenshot" + System.DateTime.Now.ToString("_yyyy-MM-dd_hh-mm-ss"));
    }

    [MenuItem("Utils/DeletePlayerPrefs")]
    public static void DeletePlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    static void Active(GameObject go) {
        Selection.activeGameObject = go;
    }

    static void Focus() {
        SceneView.FrameLastActiveSceneView();
    }

    static void ActiveFocus(GameObject go) {
        Active(go);
        Focus();
    }

    // l r f b t b => y90 y-90 y180 y0 x90 x-90
    static void SceneViewNavigation(float x, float y, float z) {
        SceneView.lastActiveSceneView.rotation = Q.Euler(x, y, z);
    }

    static void SceneViewNavigation(Vector3 rot) {
        SceneView.lastActiveSceneView.rotation = Q.Euler(rot);
    }

    // l r u d => y -y x -x
    static void SceneViewNavigationRotate(float x, float y, float z) {
        SceneViewNavigation(SceneView.lastActiveSceneView.rotation.eulerAngles + new Vector3(x, y, z));
    }
}