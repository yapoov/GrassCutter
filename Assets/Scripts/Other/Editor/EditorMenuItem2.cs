using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public partial class EditorMenuItem : Editor {

    [MenuItem("GameObject/UI/ExceptionHandler")]
    public static void ExceptionHandler() {
        CreatePrefab("ExceptionHandler", "ExceptionHandler");
    }

    public static GameObject CreatePrefab(string path, string name) {
        GameObject go = (GameObject)PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>(path));
        go.name = name;
        go.transform.SetParent(UnityEditor.Selection.activeGameObject.transform, false);
        return go;
    }

    public static GameObject Create(string path, string name) {
        GameObject go = Instantiate(Resources.Load<GameObject>(path));
        go.name = name;
        go.transform.SetParent(UnityEditor.Selection.activeGameObject.transform, false);
        return go;
    }
}