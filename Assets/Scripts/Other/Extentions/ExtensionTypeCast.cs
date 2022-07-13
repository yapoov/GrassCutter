using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class ExtensionTypeCast {

    // Data

    ///<summary>Data => bool</summary>
    public static bool B(this Data a) {
        return a.Get<bool>();
    }

    ///<summary>Data => int</summary>
    public static int I(this Data a) {
        return a.Get<int>();
    }

    ///<summary>Data => float</summary>
    public static float F(this Data a) {
        return a.Get<float>();
    }

    ///<summary>Data => string</summary>
    public static string Str(this Data a) {
        return a.Get<string>();
    }

    ///<summary>Data => Vector2</summary>
    public static Vector2 V2(this Data a) {
        return a.Get<Vector2>();
    }

    ///<summary>Data => Vector2Int</summary>
    public static Vector2Int V2I(this Data a) {
        return a.Get<Vector2Int>();
    }

    ///<summary>Data => Vector3</summary>
    public static Vector3 V3(this Data a) {
        return a.Get<Vector3>();
    }

    ///<summary>Data => Vector3Int</summary>
    public static Vector3Int V3I(this Data a) {
        return a.Get<Vector3Int>();
    }

    ///<summary>Data => Vector4</summary>
    public static Vector4 V4(this Data a) {
        return a.Get<Vector4>();
    }

    ///<summary>Data => Color</summary>
    public static Color Col(this Data a) {
        return a.Get<Color>();
    }

    // Vector2

    ///<summary>Vector2 => string</summary>
    public static string Str(this Vector2 a) {
        return "(" + a.x + ", " + a.y + ")";
    }

    ///<summary>Vector2 => Vector2Int</summary>
    public static Vector2 V2I(this Vector2 a) {
        return new Vector2Int((int)a.x, (int)a.y);
    }

    ///<summary>Vector2 => Vector3</summary>
    public static Vector3 V3(this Vector2 a) {
        return a;
    }

    ///<summary>Vector2 => Vector3Int</summary>
    public static Vector3Int V3I(this Vector2 a) {
        return new Vector3Int((int)a.x, (int)a.y, 0);
    }

    ///<summary>Vector2 => Vector4</summary>
    public static Vector4 V4(this Vector2 a) {
        return a;
    }

    // Vector2Int

    ///<summary>Vector2Int => string</summary>
    public static string Str(this Vector2Int a) {
        return "(" + a.x + ", " + a.y + ")";
    }

    ///<summary>Vector2Int => Vector2</summary>
    public static Vector2 V2(this Vector2Int a) {
        return a;
    }

    ///<summary>Vector2Int => Vector3</summary>
    public static Vector3 V3(this Vector2Int a) {
        return new Vector3(a.x, a.y, 0);
    }

    ///<summary>Vector2Int => Vector3Int</summary>
    public static Vector3Int V3I(this Vector2Int a) {
        return new Vector3Int(a.x, a.y, 0);
    }

    ///<summary>Vector2Int => Vector4</summary>
    public static Vector4 V4(this Vector2Int a) {
        return new Vector4(a.x, a.y, 0, 0);
    }

    // Vector3

    ///<summary>Vector3 => string</summary>
    public static string Str(this Vector3 a) {
        return "(" + a.x + ", " + a.y + ", " + a.z + ")";
    }

    ///<summary>Vector3 => Vector2</summary>
    public static Vector2 V2(this Vector3 a) {
        return a;
    }

    ///<summary>Vector3 => Vector2Int</summary>
    public static Vector2Int V2I(this Vector3 a) {
        return new Vector2Int((int)a.x, (int)a.y);
    }

    ///<summary>Vector3 => Vector3Int</summary>
    public static Vector3Int V3I(this Vector3 a) {
        return new Vector3Int((int)a.x, (int)a.y, (int)a.z);
    }

    ///<summary>Vector3 => Vector4</summary>
    public static Vector4 V4(this Vector3 a) {
        return a;
    }

    // Vector3Int

    ///<summary>Vector3Int => string</summary>
    public static string Str(this Vector3Int a) {
        return "(" + a.x + ", " + a.y + ", " + a.z + ")";
    }

    ///<summary>Vector3Int => Vector2</summary>
    public static Vector2 V2(this Vector3Int a) {
        return new Vector2(a.x, a.y);
    }

    ///<summary>Vector3Int => Vector2Int</summary>
    public static Vector2Int V2I(this Vector3Int a) {
        return new Vector2Int(a.x, a.y);
    }

    ///<summary>Vector3Int => Vector3</summary>
    public static Vector3 V3(this Vector3Int a) {
        return a;
    }

    ///<summary>Vector3Int => Vector4</summary>
    public static Vector4 V4(this Vector3Int a) {
        return new Vector4(a.x, a.y, a.z, 0);
    }

    // Vector4

    ///<summary>Vector4 => string</summary>
    public static string Str(this Vector4 a) {
        return "(" + a.x + ", " + a.y + ", " + a.z + ", " + a.w + ")";
    }

    ///<summary>Vector4 => Vector2</summary>
    public static Vector2 V2(this Vector4 a) {
        return a;
    }

    ///<summary>Vector4 => Vector2Int</summary>
    public static Vector2Int V2I(this Vector4 a) {
        return new Vector2Int((int)a.x, (int)a.y);
    }

    ///<summary>Vector4 => Vector3</summary>
    public static Vector3 V3(this Vector4 a) {
        return a;
    }

    ///<summary>Vector4 => Vector3Int</summary>
    public static Vector3Int V3I(this Vector4 a) {
        return new Vector3Int((int)a.x, (int)a.y, (int)a.z);
    }

    ///<summary>Vector4 => Color</summary>
    public static Color Col(this Vector4 a) {
        return a;
    }

    // Color

    ///<summary>Color => string</summary>
    public static string Str(this Color a) {
        return a.ToString();
    }

    ///<summary>Color => string [hex]</summary>
    public static string HexStr(this Color a, bool isA = true, bool isSharp = true) {
        return (isSharp ? "#" : "") + (isA ? ColorUtility.ToHtmlStringRGBA(a) : ColorUtility.ToHtmlStringRGB(a));
    }

    ///<summary>Color => Vector4</summary>
    public static Vector4 V4(this Color a) {
        return a;
    }

    // string

    ///<summary>string => Vector2</summary>
    public static Vector2 V2(this string a) {
        string[] arr = (a.StartsWith("(") && a.EndsWith(")") ? a.SubStr(1, a.Length - 2) : a).Split(',');
        return new Vector2(
            arr.Length > 0 ? float.Parse(arr[0]) : 0,
            arr.Length > 1 ? float.Parse(arr[1]) : 0
        );
    }

    ///<summary>string => Vector2Int</summary>
    public static Vector2Int V2I(this string a) {
        string[] arr = (a.StartsWith("(") && a.EndsWith(")") ? a.SubStr(1, a.Length - 2) : a).Split(',');
        return new Vector2Int(
            arr.Length > 0 ? int.Parse(arr[0]) : 0,
            arr.Length > 1 ? int.Parse(arr[1]) : 0
        );
    }

    ///<summary>string => Vector3</summary>
    public static Vector3 V3(this string a) {
        string[] arr = (a.StartsWith("(") && a.EndsWith(")") ? a.SubStr(1, a.Length - 2) : a).Split(',');
        return new Vector3(
            arr.Length > 0 ? float.Parse(arr[0]) : 0,
            arr.Length > 1 ? float.Parse(arr[1]) : 0,
            arr.Length > 2 ? float.Parse(arr[2]) : 0
        );
    }

    ///<summary>string => Vector3Int</summary>
    public static Vector3Int V3I(this string a) {
        string[] arr = (a.StartsWith("(") && a.EndsWith(")") ? a.SubStr(1, a.Length - 2) : a).Split(',');
        return new Vector3Int(
            arr.Length > 0 ? int.Parse(arr[0]) : 0,
            arr.Length > 1 ? int.Parse(arr[1]) : 0,
            arr.Length > 2 ? int.Parse(arr[2]) : 0
        );
    }

    ///<summary>string => Vector4</summary>
    public static Vector4 V4(this string a) {
        string[] arr = (a.StartsWith("(") && a.EndsWith(")") ? a.SubStr(1, a.Length - 2) : a).Split(',');
        return new Vector4(
            arr.Length > 0 ? float.Parse(arr[0]) : 0,
            arr.Length > 1 ? float.Parse(arr[1]) : 0,
            arr.Length > 2 ? float.Parse(arr[2]) : 0,
            arr.Length > 3 ? float.Parse(arr[3]) : 0
        );
    }

    ///<summary>string => Color</summary>
    public static Color Col(this string a) {
        string[] arr = (a.StartsWith("RGBA(") && a.EndsWith(")") ? a.SubStr(5, a.Length - 6) : a).Split(',');
        return new Color(
            arr.Length > 0 ? float.Parse(arr[0]) : 0,
            arr.Length > 1 ? float.Parse(arr[1]) : 0,
            arr.Length > 2 ? float.Parse(arr[2]) : 0,
            arr.Length > 3 ? float.Parse(arr[3]) : 0
        );
    }

    ///<summary>string [hex] => Color</summary>
    public static Color HexCol(string a) {
        if (Rgx.IsMatch(a.ToUpper(), Rgx.HexColor)) {
            Color res;
            if (ColorUtility.TryParseHtmlString(a[0] != '#' ? "#" + a : a, out res))
                return res;
        }
        return Color.clear;
    }

    ///<summary>string => int</summary>
    public static int I(this string a) {
        int res;
        if (int.TryParse(a, out res))
            return res;
        return 0;
    }

    ///<summary>string => float</summary>
    public static float F(this string a) {
        float res;
        if (float.TryParse(a, out res))
            return res;
        return 0f;
    }

    // Array

    ///<summary>Array => string</summary>
    public static string Str<T>(this T[] a, string separator = ", ") {
        return string.Join(separator, a);
    }

    ///<summary>Array => List</summary>
    public static List<T> Lis<T>(this T[] a) {
        return a.ToList();
    }

    // List

    ///<summary>List => string</summary>
    public static string Str<T>(this List<T> a, string separator = ", ") {
        return string.Join(separator, a);
    }

    ///<summary>List => Array</summary>
    public static T[] Arr<T>(this List<T> a) {
        return a.ToArray();
    }

    // bool

    ///<summary>bool => Sign</summary>
    public static int Sign(this bool a) {
        return a ? 1 : -1;
    }

    ///<summary>bool => int</summary>
    public static int I(this bool a) {
        return a ? 1 : 0;
    }

    ///<summary>bool => float</summary>
    public static float F(this bool a) {
        return a ? 1f : 0f;
    }

    // int

    ///<summary>int => Sign</summary>
    public static int Sign(this int a) {
        return a >= 0 ? 1 : -1;
    }

    ///<summary>int => float</summary>
    public static float F(this int a) {
        return a;
    }

    // float

    ///<summary>float => Sign</summary>
    public static int Sign(this float a) {
        return a >= 0f ? 1 : -1;
    }

    ///<summary>float => int</summary>
    public static int I(this float a) {
        return (int)a;
    }

    // Transform

    ///<summary>Transform => Tf</summary>
    public static Tf Tf(this Transform a, Space spc = Space.Self) {
        if (spc == Space.Self)
            return new Tf(a.localPosition, a.localRotation, a.localScale);
        return new Tf(a.position, a.rotation, a.lossyScale);
    }
}