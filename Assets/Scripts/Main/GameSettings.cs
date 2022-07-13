using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerPrefsData {
    public Data key;
    public GameObject go;
}

public class GameSettings : Singleton<GameSettings> {

    public List<PlayerPrefsData> datas;

    GameObject panelSettings;

    GameState tmpState;

    void Awake() {
        panelSettings = transform.ChildGo(0);
        panelSettings.Hide();
    }

    public void Clear() {
        PlayerPrefs.DeleteAll();
        datas.ForEach(x => ResetData(x.key, x.go));
    }

    public void Show() {
        Time.timeScale = 0;
        panelSettings.Show();
        tmpState = GameController.State;
        GameController.State = GameState.Settings;
        datas.ForEach(x => ShowData(x.key, x.go));
    }

    public void Save() {
        datas.ForEach(x => SaveData(x.key, x.go));
    }

    public void Done() {
        Time.timeScale = 1;
        panelSettings.Hide();
        GameController.State = tmpState;
    }

    public void Settings() {
        if (panelSettings.activeSelf)
            Done();
        else Show();
    }

    void SetVecGo(GameObject go, params float[] vals) {
        for (int i = 0; i < vals.Length; i++)
            go.Child<InputField>(i).text = "" + vals[i];
    }

    void ResetData(Data key, GameObject go) {
        System.Reflection.FieldInfo f = A.Field<GameController>(A.GC, key.ToString());
        Type type = GameController.Datas[key].GetType();
        if (go.name == "ColorPicker")
            f.SetValue(A.GC, go.Gc<ColorPicker>().Color = key.Col());
        else if (go.name == "Dropdown")
            f.SetValue(A.GC, go.Gc<Dropdown>().value = key.I());
        else if (go.name == "InputField") {
            InputField inputField = go.Gc<InputField>();
            if (type == typeof(float))
                f.SetValue(A.GC, GetValSetInp<float>(inputField, key));
            else if (type == typeof(int))
                f.SetValue(A.GC, GetValSetInp<int>(inputField, key));
            else if (type == typeof(string))
                f.SetValue(A.GC, GetValSetInp<string>(inputField, key));
        } else if (go.name == "Slider")
            f.SetValue(A.GC, go.Gc<Slider>().value = key.F());
        else if (go.name == "Toggle")
            f.SetValue(A.GC, go.Gc<Toggle>().isOn = key.B());
        else if (go.name == "Vector") {
            if (type == typeof(Vector2)) {
                Vector2 v = key.V2();
                SetVecGo(go, v.x, v.y);
                f.SetValue(A.GC, v);
            } else if (type == typeof(Vector2Int)) {
                Vector2Int v = key.V2I();
                SetVecGo(go, v.x, v.y);
                f.SetValue(A.GC, v);
            } else if (type == typeof(Vector3)) {
                Vector3 v = key.V3();
                SetVecGo(go, v.x, v.y, v.z);
                f.SetValue(A.GC, v);
            } else if (type == typeof(Vector3Int)) {
                Vector3Int v = key.V3I();
                SetVecGo(go, v.x, v.y, v.z);
                f.SetValue(A.GC, v);
            } else if (type == typeof(Vector4)) {
                Vector4 v = key.V4();
                SetVecGo(go, v.x, v.y, v.z, v.w);
                f.SetValue(A.GC, v);
            }
        }
    }

    T GetValSetInp<T>(InputField inp, Data key) {
        T val = key.Get<T>();
        inp.text = "" + val;
        return val;
    }

    void ShowData(Data key, GameObject go) {
        System.Reflection.FieldInfo f = A.Field<GameController>(A.GC, key.ToString());
        Type type = GameController.Datas[key].GetType();
        if (go.name == "ColorPicker")
            go.Gc<ColorPicker>().Color = (Color)f.GetValue(A.GC);
        else if (go.name == "Dropdown")
            go.Gc<Dropdown>().value = (int)f.GetValue(A.GC);
        else if (go.name == "InputField") {
            InputField inputField = go.Gc<InputField>();
            if (type == typeof(int))
                inputField.text = "" + (int)f.GetValue(A.GC);
            else if (type == typeof(float))
                inputField.text = "" + (float)f.GetValue(A.GC);
            else if (type == typeof(string))
                inputField.text = "" + (string)f.GetValue(A.GC);
        } else if (go.name == "Slider")
            go.Gc<Slider>().value = (float)f.GetValue(A.GC);
        else if (go.name == "Toggle")
            go.Gc<Toggle>().isOn = (bool)f.GetValue(A.GC);
        else if (go.name == "Vector") {
            if (type == typeof(Vector2)) {
                Vector2 v = (Vector2)f.GetValue(A.GC);
                SetVecGo(go, v.x, v.y);
            } else if (type == typeof(Vector2Int)) {
                Vector2Int v = (Vector2Int)f.GetValue(A.GC);
                SetVecGo(go, v.x, v.y);
            } else if (type == typeof(Vector3)) {
                Vector3 v = (Vector3)f.GetValue(A.GC);
                SetVecGo(go, v.x, v.y, v.z);
            } else if (type == typeof(Vector3Int)) {
                Vector3Int v = (Vector3Int)f.GetValue(A.GC);
                SetVecGo(go, v.x, v.y, v.z);
            } else if (type == typeof(Vector4)) {
                Vector4 v = (Vector4)f.GetValue(A.GC);
                SetVecGo(go, v.x, v.y, v.z, v.w);
            }
        }
    }

    float InpVal(GameObject go, int i) {
        return go.Child<InputField>(i).text.F();
    }

    void SaveData(Data key, GameObject go) {
        System.Reflection.FieldInfo f = A.Field<GameController>(A.GC, key.ToString());
        Type type = GameController.Datas[key].GetType();
        if (go.name == "ColorPicker")
            f.SetValue(A.GC, go.Gc<ColorPicker>().Color);
        else if (go.name == "Dropdown")
            f.SetValue(A.GC, go.Gc<Dropdown>().value);
        else if (go.name == "InputField") {
            string text = go.Gc<InputField>().text;
            if (type == typeof(int))
                f.SetValue(A.GC, text.I());
            else if (type == typeof(float))
                f.SetValue(A.GC, text.F());
            else if (type == typeof(string))
                f.SetValue(A.GC, text);
        } else if (go.name == "Slider")
            f.SetValue(A.GC, go.Gc<Slider>().value);
        else if (go.name == "Toggle")
            f.SetValue(A.GC, go.Gc<Toggle>().isOn);
        else if (go.name == "Vector") {
            if (type == typeof(Vector2))
                f.SetValue(A.GC, new Vector2(InpVal(go, 0), InpVal(go, 1)));
            else if (type == typeof(Vector2Int))
                f.SetValue(A.GC, new Vector2(InpVal(go, 0), InpVal(go, 1)).V2I());
            else if (type == typeof(Vector3))
                f.SetValue(A.GC, new Vector3(InpVal(go, 0), InpVal(go, 1), InpVal(go, 2)));
            else if (type == typeof(Vector3Int))
                f.SetValue(A.GC, new Vector3(InpVal(go, 0), InpVal(go, 1), InpVal(go, 2)).V3I());
            else if (type == typeof(Vector4))
                f.SetValue(A.GC, new Vector4(InpVal(go, 0), InpVal(go, 1), InpVal(go, 2), InpVal(go, 3)));
        }
        key.Set(f.GetValue(A.GC));
    }
}