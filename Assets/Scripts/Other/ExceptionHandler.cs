using UnityEngine;

public class ExceptionHandler : MB {
    public AnimationCurve curve = AnimationCurve.EaseInOut(0, 1, 1, 0);
    public Color foregroundColor = Color.red;
    public Color backgroundColor = Color.white;
    public int fontSize = 30;
    public float time = 3;
    float dt, t;
    string error;
    GUIStyle style = new GUIStyle();
    void Awake() {
        dt = time;
        style.wordWrap = true;
    }
    void OnEnable() {
        Application.logMessageReceived += HandleLog;
    }
    void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }
    void HandleLog(string logStr, string stackTrace, LogType type) {
        if ((type == LogType.Exception || type == LogType.Error) && !Application.isEditor) {
            error = string.Format("{0}: {1}\n{2}", type, logStr, stackTrace);
            dt = 0;
        }
    }
    void Update() {
        dt = M.Clamp(dt + DT, 0, time);
        t = curve.Evaluate(dt / time);
        style.fontSize = fontSize;
        style.normal.textColor = Col.A(foregroundColor, foregroundColor.a * t);
        style.normal.background = FillTexture(1, 1, Col.A(backgroundColor, backgroundColor.a * t));
    }
    void OnGUI() {
        GUILayout.Label(error, style);
    }
    Texture2D FillTexture(int width, int height, Color color) {
        Color[] pixels = new Color[width * height];
        for (int i = 0; i < pixels.Length; i++) {
            pixels[i] = color;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pixels);
        result.Apply();
        return result;
    }
}