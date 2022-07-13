using UnityEngine;

public class Singleton<T> : MB where T : MB
{
    private static object lockObj = new object();
    private static T _Instance;
    public static T Instance
    {
        get
        {
            lock (lockObj)
            {
                if (!_Instance)
                {
                    _Instance = (T)FindObjectOfType(typeof(T));
                    if (!_Instance)
                    {
                        var obj = new GameObject();
                        _Instance = obj.AddComponent<T>();
                        obj.name = typeof(T).ToString();
                        DontDestroyOnLoad(obj);
                    }
                }
                return _Instance;
            }
        }
    }
}