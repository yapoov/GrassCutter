using UnityEngine;

public static class ExtensionString {

    ///<summary>sub string</summary>
    public static string SubStrLast(this string a, int idx, int lastIdx) {
        return a.Substring(idx, a.Length - idx - lastIdx);
    }

    ///<summary>sub string</summary>
    public static string SubStr(this string a, int idx, int n) {
        return a.Substring(idx, n);
    }

    ///<summary>sub string</summary>
    public static string SubStr(this string a, int idx) {
        return a.Substring(idx);
    }

    ///<summary>arr-д байна уу шалгана</summary>
    public static bool Contains(this string a, params string[] arr) {
        return arr.Lis().Contains(a);
    }

    ///<summary>зайг арилгана</summary>
    public static string RmvWhiteSpace(this string a) {
        return Rgx.Replace(a, "\\s+", "");
    }

    ///<summary>pattern-р хуваана</summary>
    public static string[] RgxSplit(this string a, string pattern) {
        return Rgx.Split(a, pattern);
    }

    ///<summary>үгийг салгаж авна</summary>
    public static string[] RgxSplitWord(this string a) {
        return Rgx.Split(a, "\\W+");
    }

    ///<summary>pattern-тай таарч байна уу шалгана</summary>
    public static bool RgxIsMatch(this string a, string pattern) {
        return Rgx.IsMatch(a, pattern);
    }

    ///<summary>pattern-г replacement-р дарна</summary>
    public static string RgxReplace(this string a, string pattern, string replacement) {
        return Rgx.Replace(a, pattern, replacement);
    }

    ///<summary></summary>
    public static bool IsNullOrEmpty(this string a) {
        return string.IsNullOrEmpty(a);
    }

    ///<summary></summary>
    public static bool IsNullOrWhiteSpace(this string a) {
        return string.IsNullOrWhiteSpace(a);
    }

    ///<summary></summary>
    public static string RplStaEndWth(this string a, string oldStr, string newStr) {
        return a.RplStaWth(oldStr, newStr).RplEndWth(oldStr, newStr);
    }

    ///<summary></summary>
    public static string RplStaWth(this string a, string oldStr, string newStr) {
        return a.StartsWith(oldStr) ? newStr + a.SubStr(oldStr.Length, a.Length - oldStr.Length) : a;
    }

    ///<summary></summary>
    public static string RplEndWth(this string a, string oldStr, string newStr) {
        return a.EndsWith(oldStr) ? a.SubStr(0, a.Length - oldStr.Length) + newStr : a;
    }
};