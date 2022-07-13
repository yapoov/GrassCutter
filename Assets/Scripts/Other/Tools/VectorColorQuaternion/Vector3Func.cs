using System.Collections.Generic;
using UnityEngine;

public partial class V3 {

    ///<summary>v∈[a, b] шалгана</summary>
    public static bool IsBet(Vector3 v, Vector3 a, Vector3 b) {
        return M.IsBet(v.x, a.x, b.x) && M.IsBet(v.y, a.y, b.y) && M.IsBet(v.z, a.z, b.z);
    }

    ///<summary>v∈[a, b]</summary>
    public static Vector3 Clamp(Vector3 v, Vector3 a, Vector3 b) {
        return new Vector3(M.Clamp(v.x, a.x, b.x), M.Clamp(v.y, a.y, b.y), M.Clamp(v.z, a.z, b.z));
    }

    ///<summary>a, b-н хоорондох өнцөг</summary>
    public static float Ang(Vector3 a, Vector3 b) {
        return Vector3.Angle(a, b);
    }

    ///<summary>v-н уртыг d-р хязгаарлана</summary>
    public static Vector3 ClampMag(Vector3 v, float d) {
        return Vector3.ClampMagnitude(v, d);
    }

    ///<summary>axb</summary>
    public static Vector3 Cross(Vector3 a, Vector3 b) {
        return Vector3.Cross(a, b);
    }

    ///<summary>a, b-н хоорондох зай</summary>
    public static float Dis(Vector3 a, Vector3 b) {
        return Vector3.Distance(a, b);
    }

    ///<summary>a·b = ∑ab = a.xb.x+a.yb.y+a.zb.z</summary>
    public static float Dot(Vector3 lhs, Vector3 rhs) {
        return Vector3.Dot(lhs, rhs);
    }

    ///<summary>a-г b-рүү t хувиар ойртуулна [a, b]</summary>
    public static Vector3 Lerp(Vector3 a, Vector3 b, float t) {
        return Vector3.Lerp(a, b, t);
    }

    ///<summary>a-г b-рүү t хувиар ойртуулна</summary>
    public static Vector3 UnLerp(Vector3 a, Vector3 b, float t) {
        return Vector3.LerpUnclamped(a, b, t);
    }

    ///<summary>зэргийн lerp</summary>
    public static Vector3 DegLerp(float t, params Vector3[] arr) {
        List<float> xs = new List<float>(), ys = new List<float>(), zs = new List<float>();
        arr.Lis().ForEach(x => { xs.Add(x.x); ys.Add(x.y); zs.Add(x.z); });
        return new Vector3(M.DegLerp(t, xs.Arr()), M.DegLerp(t, ys.Arr()), M.DegLerp(t, zs.Arr()));
    }

    ///<summary>v-н урт
    public static float Mag(Vector3 v) {
        return Vector3.Magnitude(v);
    }

    ///<summary>a, b-н ХИ утгуудаар үүсгэнэ</summary>
    public static Vector3 Max(Vector3 a, Vector3 b) {
        return Vector3.Max(a, b);
    }

    ///<summary>a, b-н ХБ утгуудаар үүсгэнэ</summary>
    public static Vector3 Min(Vector3 a, Vector3 b) {
        return Vector3.Min(a, b);
    }

    ///<summary>lis-н ХИ ХБ утгуудаар үүсгэнэ</summary>
    public static void LisMinMax(List<Vector3> lis, ref Vector3 min, ref Vector3 max) {
        if (lis.Count > 0) {
            min = Vector3.positiveInfinity;
            max = Vector3.negativeInfinity;
            foreach (Vector3 v in lis) {
                min = Min(min, v);
                max = Min(max, v);
            }
        }
    }

    ///<summary>a-г b-рүү d-р ойртуулна</summary>
    public static Vector3 Move(Vector3 a, Vector3 b, float d) {
        return Vector3.MoveTowards(a, b, d);
    }

    ///<summary>v-н уртыг 1 болгоно
    public static Vector3 Nor(Vector3 v) {
        return Vector3.Normalize(v);
    }

    public static void OrthoNor(ref Vector3 nor, ref Vector3 tangent) {
        Vector3.OrthoNormalize(ref nor, ref tangent);
    }

    public static void OrthoNor(ref Vector3 nor, ref Vector3 tangent, ref Vector3 binor) {
        Vector3.OrthoNormalize(ref nor, ref tangent, ref binor);
    }

    public static Vector3 Project(Vector3 v, Vector3 onNor) {
        return Vector3.Project(v, onNor);
    }

    public static Vector3 ProjectOnPlane(Vector3 v, Vector3 plnNor) {
        return Vector3.ProjectOnPlane(v, plnNor);
    }

    public static Vector3 Reflect(Vector3 inDir, Vector3 inNor) {
        return Vector3.Reflect(inDir, inNor);
    }

    public static Vector3 Rot(Vector3 a, Vector3 b, float maxRadD, float maxMagD) {
        return Vector3.RotateTowards(a, b, maxRadD, maxMagD);
    }

    public static float SignAng(Vector3 a, Vector3 b, Vector3 axis) {
        return Vector3.SignedAngle(a, b, axis);
    }

    public static Vector3 Slerp(Vector3 a, Vector3 b, float t) {
        return Vector3.Slerp(a, b, t);
    }

    public static Vector3 UnSlerp(Vector3 a, Vector3 b, float t) {
        return Vector3.SlerpUnclamped(a, b, t);
    }

    ///<summary>Vector3-г Vector3-д үржинэ</summary>
    public static Vector3 Mul(params Vector3[] arr) {
        if (arr.Length == 0) return Vector3.zero;
        if (arr.Length == 1) return arr[0];
        if (arr.Length == 2) return Vector3.Scale(arr[0], arr[1]);
        Vector3 res = Vector3.one;
        foreach (Vector3 v in arr)
            res = Vector3.Scale(res, v);
        return res;
    }
}