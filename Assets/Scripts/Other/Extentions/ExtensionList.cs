using System;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionList {

    ///<summary>list-г хоосон байна уу шалгана</summary>
    public static bool IsEmpty<T>(this List<T> a) {
        return a.Count == 0;
    }

    ///<summary>array-г хуулна</summary>
    public static List<T> Cln<T>(this List<T> a) {
        return a.GetRange(0, a.Count);
    }

    ///<summary>list-н idx-р элментийг авна</summary>
    public static T RepIdx<T>(this List<T> a, int idx) {
        return a[M.RepIdx(idx, a.Count)];
    }

    ///<summary>list-н сүүлээс idx-р элментийг авна</summary>
    public static T Last<T>(this List<T> a, int idx = 0) {
        return a[a.Count - idx - 1];
    }

    ///<summary>list-г хэвлэнэ</summary>
    public static void Print<T>(this List<T> a, string separator = ", ") {
        Debug.Log(string.Join(separator, a));
    }

    ///<summary>list-н төрөл хувиргана</summary>
    public static List<V> TypeCast<T, V>(this List<T> a, Func<T, V> func) {
        List<V> res = new List<V>();
        a.ForEach(x => res.Add(func(x)));
        return res;
    }

    ///<summary>list-н төрөл хувиргана</summary>
    public static List<V> TypeCast<T, V>(this List<T> a) {
        return a.TypeCast<T, V>(x => (V)(object)x);
    }

    ///<summary>list дээр list нэмнэ</summary>
    public static List<T> Add<T>(this List<T> a, List<T> add) {
        return a = A.Add2List(a, add);
    }

    ///<summary>list дээр array нэмнэ</summary>
    public static List<T> Add<T>(this List<T> a, T[] add) {
        return a = A.Add2List(a, add.Lis());
    }

    ///<summary>string list-г хөрвүүлнэ</summary>
    public static List<T> Parse<T>(this List<string> a, Func<string, T> func) {
        List<T> res = new List<T>();
        for (int i = 0; i < a.Count; i++)
            if (!a[i].IsNullOrEmpty())
                res.Add(func(a[i]));
        return res;
    }

    ///<summary>string list-с null утгыг устгана</summary>
    public static List<string> RmvNull(this List<string> a) {
        return a.Parse<string>(x => x);
    }

    ///<summary>string list-н string-н зайг устгана</summary>
    public static List<string> RmvSpc(this List<string> a) {
        return a.Parse<string>(x => x.RmvWhiteSpace());
    }

    ///<summary>string list-н string-н зайг устгана</summary>
    public static string RmvSpcStr(this List<string> a, string separator = ", ") {
        return a.RmvSpc().Str(separator);
    }
};