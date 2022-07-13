using System.Collections.Generic;
using UnityEngine;

public class Crt {

    ///<summary>Effect үүсгэнэ</summary>
    public static void Effect(Vector3 pos, Color col) {
        GameObject effectGo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main/Effect"), pos, Q.O, A.GC.transform);
        effectGo.RenMatCol(col);
        MonoBehaviour.Destroy(effectGo, 1);
    }

    ///<summary>PrimitiveType-тай обект үүсгэнэ</summary>
    public static GameObject Pri(PrimitiveType type, Tf tf, Color col = default(Color), string name = "", Transform parTf = null) {
        GameObject go = GameObject.CreatePrimitive(type);
        go.transform.position = tf.t;
        go.transform.rotation = tf.q;
        go.transform.localScale = tf.s;
        go.Gc<Renderer>().material.color = col.IsDefault() ? Color.white : col;
        if (!name.IsNullOrEmpty())
            go.name = name;
        go.transform.parent = parTf;
        return go;
    }

    ///<summary>обект үүсгэнэ</summary>
    public static T Go<T>(GameObject goPf, Tf tf, string name = "", Transform parTf = null) {
        GameObject go = MonoBehaviour.Instantiate(goPf, tf.t, tf.q, parTf);
        go.transform.localScale = tf.s;
        if (!name.IsNullOrEmpty())
            go.name = name;
        return go.Gc<T>();
    }

    ///<summary>обект үүсгээд устгана</summary>
    public static T DstGo<T>(GameObject goPf, Tf tf, float time, string name = "", Transform parTf = null) {
        GameObject go = Go<GameObject>(goPf, tf, name, parTf);
        MonoBehaviour.Destroy(go, time);
        return go.Gc<T>();
    }

    ///<summary>обект үүсгээд хүүхдийг авна</summary>
    public static T GoChild<T>(GameObject goPf, Tf tf, string childs = "", string name = "", Transform parTf = null) {
        GameObject go = Go<GameObject>(goPf, tf, name, parTf);
        return go.Child<T>(childs);
    }

    ///<summary>обект үүсгээд хүүхдийг аваад устгана</summary>
    public static T DstGoChild<T>(GameObject goPf, Tf tf, float time, string childs = "", string name = "", Transform parTf = null) {
        GameObject go = Go<GameObject>(goPf, tf, name, parTf);
        MonoBehaviour.Destroy(go, time);
        return go.Child<T>(childs);
    }

    ///<summary>random обектууд үүсгэнэ</summary>
    public static List<GameObject> RndGos(Vector3 a, Vector3 b, List<GameObject> goPfs, int n,
        RotType rt = RotType.Def, Quaternion rot = default(Quaternion), Transform parTf = null) {
        List<GameObject> res = new List<GameObject>();
        for (int i = 0; i < n; i++)
            res.Add(RndGo(a, b, goPfs, rt, rot, parTf));
        return res;
    }

    ///<summary>random обектууд давхцахгүйгаар үүсгэнэ</summary>
    public static List<GameObject> RndGos(Vector3 a, Vector3 b, List<GameObject> goPfs, int n, float dis,
        RotType rt = RotType.Def, Quaternion rot = default(Quaternion), Transform parTf = null) {
        return RndGos(a, b, null, goPfs, n, dis, rt, rot, parTf);
    }

    ///<summary>random обектууд давхцахгүйгаар үүсгэнэ</summary>
    public static List<GameObject> RndGos(Vector3 a, Vector3 b, List<GameObject> gos, List<GameObject> goPfs, int n, float dis,
        RotType rt = RotType.Def, Quaternion rot = default(Quaternion), Transform parTf = null) {
        List<GameObject> res = new List<GameObject>();
        List<Vector3> pnts = new List<Vector3>();
        if (gos.NotNull() && gos.Count > 0)
            gos.ForEach(x => pnts.Add(x.transform.position));
        for (int i = 0; i < 100000 && pnts.Count < n; i++) {
            Vector3 rnd = Rnd.Pos(a, b);
            if (pnts.FindIndex(0, pnts.Count, x => Vector3.Distance(x, rnd) < dis) < 0) {
                pnts.Add(rnd);
                res.Add(RndGo(Rnd.Pos(a, b), goPfs, rt, rot, parTf));
            }
        }
        return res;
    }

    ///<summary>random обект үүсгэнэ [a, b]</summary>
    public static GameObject RndGo(Vector3 a, Vector3 b, List<GameObject> goPfs,
        RotType rt = RotType.Def, Quaternion rot = default(Quaternion), Transform parTf = null) {
        return RndGo(Rnd.Pos(a, b), goPfs, rt, rot, parTf);
    }

    ///<summary>random обект үүсгэнэ</summary>
    public static GameObject RndGo(Vector3 pos, List<GameObject> goPfs,
        RotType rt = RotType.Def, Quaternion rot = default(Quaternion), Transform parTf = null) {
        GameObject goPf = Rnd.List<GameObject>(goPfs);
        if (rt == RotType.Def) rot = goPf.transform.rotation;
        else if (rt == RotType.Rnd) rot = Q.Euler(0, Rnd.Ang, 0);
        return MonoBehaviour.Instantiate(goPf, pos, rot, parTf);
    }
}