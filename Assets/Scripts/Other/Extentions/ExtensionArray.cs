using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionArray {

    ///<summary>array-г хоосон байна уу шалгана</summary>
    public static bool IsEmpty<T>(this T[] a) {
        return a.Length == 0;
    }

    ///<summary>array-г хуулна</summary>
    public static T[] Cln<T>(this T[] a) {
        return (T[])a.Clone();
    }

    ///<summary>array-н idx-р элментийг авна</summary>
    public static T RepIdx<T>(this T[] a, int idx) {
        return a[M.RepIdx(idx, a.Length)];
    }

    ///<summary>array-н сүүлээс idx-р элментийг авна</summary>
    public static T Last<T>(this T[] a, int idx = 0) {
        return a[a.Length - idx - 1];
    }

    ///<summary>array-г хэвлэнэ</summary>
    public static void Print<T>(this T[] a, string separator = ", ") {
        Debug.Log(string.Join(separator, a));
    }

    ///<summary>array-н төрөл хувиргана</summary>
    public static V[] TypeCast<T, V>(this T[] a, Func<T, V> func) {
        return a.Lis().TypeCast<T, V>(func).Arr();
    }

    ///<summary>array-н төрөл хувиргана</summary>
    public static V[] TypeCast<T, V>(this T[] a) {
        return a.TypeCast<T, V>(x => (V)(object)x);
    }

    ///<summary>array дээр list нэмнэ</summary>
    public static T[] Add<T>(this T[] a, List<T> add) {
        return a = A.Add2List(a.Lis(), add).Arr();
    }

    ///<summary>array дээр array нэмнэ</summary>
    public static T[] Add<T>(this T[] a, T[] add) {
        return a = A.Add2List(a.Lis(), add.Lis()).Arr();
    }

    ///<summary>string array-г хөрвүүлнэ</summary>
    public static T[] Parse<T>(this string[] a, Func<string, T> func) {
        return a.Lis().Parse<T>(func).Arr();
    }

    ///<summary>string array-с null утгыг устгана</summary>
    public static string[] RmvNull(this string[] a) {
        return a.Lis().RmvNull().Arr();
    }

    ///<summary>string array-н string-н зайг устгана</summary>
    public static string[] RmvSpc(this string[] a) {
        return a.Lis().RmvSpc().Arr();
    }

    ///<summary>string array-н string-н зайг устгана</summary>
    public static string RmvSpcStr(this string[] a, string separator = ", ") {
        return a.Lis().RmvSpcStr(separator);
    }
};