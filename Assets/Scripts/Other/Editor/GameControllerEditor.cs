using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameController))]
public class GameControllerEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Sprites Screenshot"))
            A.Screenshot("Assets/Sprites", A.GC.screenshotName);

        if (GUILayout.Button("Screenshot"))
            A.Screenshot("Screenshots/", "Screenshot" + System.DateTime.Now.ToString("_yyyy-MM-dd_hh-mm-ss"));
        
        if (GUILayout.Button("Sprites Read")) {
            A.GC.icon = A.LoadAsset<Texture2D>("Assets/Sprites/icon.png");
            A.GC.iPhoneLaunchScreen = A.LoadAsset<Texture2D>("Assets/Sprites/iphone.png");
            A.GC.iPadLaunchScreen = A.LoadAsset<Texture2D>("Assets/Sprites/ipad.png");
        }
        
        if (GUILayout.Button("Player Settings Change"))
            A.PlayerSettingsChange();
        
        if (GUILayout.Button("Delete PlayerPrefs"))
            PlayerPrefs.DeleteAll();
    }
}