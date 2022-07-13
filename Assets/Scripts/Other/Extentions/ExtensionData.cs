using UnityEngine;

public static class ExtensionData {

    ///<summary>PlayerPrefs-д хадгалсан data-г авна</summary>
    public static T Get<T>(this Data key) {
        object res = null;
        if (GameController.Datas.ContainsKey(key)) {
            System.Type type = GameController.Datas[key].GetType();
            if (type == typeof(bool))
                res = PlayerPrefs.GetInt("" + key, (bool)GameController.Datas[key] ? 1 : 0) == 1;
            else if (type == typeof(int))
                res = PlayerPrefs.GetInt("" + key, (int)GameController.Datas[key]);
            else if (type == typeof(float))
                res = PlayerPrefs.GetFloat("" + key, (float)GameController.Datas[key]);
            else if (type == typeof(string))
                res = PlayerPrefs.GetString("" + key, (string)GameController.Datas[key]);
            else if (type == typeof(Vector2))
                res = PlayerPrefs.GetString("" + key, ((Vector2)GameController.Datas[key]).Str()).V2();
            else if (type == typeof(Vector2Int))
                res = PlayerPrefs.GetString("" + key, ((Vector2Int)GameController.Datas[key]).Str()).V2I();
            else if (type == typeof(Vector3))
                res = PlayerPrefs.GetString("" + key, ((Vector3)GameController.Datas[key]).Str()).V3();
            else if (type == typeof(Vector3Int))
                res = PlayerPrefs.GetString("" + key, ((Vector3Int)GameController.Datas[key]).Str()).V3I();
            else if (type == typeof(Vector4))
                res = PlayerPrefs.GetString("" + key, ((Vector4)GameController.Datas[key]).Str()).V4();
            else if (type == typeof(Color))
                res = PlayerPrefs.GetString("" + key, ((Color)GameController.Datas[key]).Str()).Col();
        }
        return (T)res;
    }

    ///<summary>PlayerPrefs-д data-г хадгална</summary>
    public static void Set(this Data key, object value) {
        if (GameController.Datas.ContainsKey(key)) {
            System.Type type = GameController.Datas[key].GetType();
            if (type == typeof(bool))
                PlayerPrefs.SetInt("" + key, (bool)value ? 1 : 0);
            else if (type == typeof(int))
                PlayerPrefs.SetInt("" + key, (int)value);
            else if (type == typeof(float))
                PlayerPrefs.SetFloat("" + key, (float)value);
            else if (type == typeof(string))
                PlayerPrefs.SetString("" + key, (string)value);
            else if (type == typeof(Vector2))
                PlayerPrefs.SetString("" + key, ((Vector2)value).Str());
            else if (type == typeof(Vector2Int))
                PlayerPrefs.SetString("" + key, ((Vector2Int)value).Str());
            else if (type == typeof(Vector3))
                PlayerPrefs.SetString("" + key, ((Vector3)value).Str());
            else if (type == typeof(Vector3Int))
                PlayerPrefs.SetString("" + key, ((Vector3Int)value).Str());
            else if (type == typeof(Vector4))
                PlayerPrefs.SetString("" + key, ((Vector4)value).Str());
            else if (type == typeof(Color))
                PlayerPrefs.SetString("" + key, ((Color)value).Str());
        }
    }
}