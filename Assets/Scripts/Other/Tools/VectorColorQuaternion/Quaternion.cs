using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class Q {

    ///<summary>Quaternion.identity</summary>
    public static readonly Quaternion O = Quaternion.identity;

    ///<summary></summary>
    public static float Ang(Quaternion a, Quaternion b) {
        return Quaternion.Angle(a, b);
    }

    ///<summary></summary>
    public static Quaternion AngAxis(float angle, Vector3 axis) {
        return Quaternion.AngleAxis(angle, axis);
    }

    ///<summary></summary>
    public static float Dot(Quaternion a, Quaternion b) {
        return Quaternion.Dot(a, b);
    }

    ///<summary></summary>
    public static Quaternion Euler(Vector3 euler) {
        return Quaternion.Euler(euler);
    }

    ///<summary></summary>
    public static Quaternion Euler(float x, float y, float z) {
        return Quaternion.Euler(x, y, z);
    }

    ///<summary></summary>
    public static Quaternion FromToRot(Vector3 fromDir, Vector3 toDir) {
        return Quaternion.FromToRotation(fromDir, toDir);
    }

    ///<summary></summary>
    public static Quaternion Inv(Quaternion rot) {
        return Quaternion.Inverse(rot);
    }

    ///<summary></summary>
    public static Quaternion Lerp(Quaternion a, Quaternion b, float t) {
        return Quaternion.Lerp(a, b, t);
    }

    ///<summary></summary>
    public static Quaternion UnLerp(Quaternion a, Quaternion b, float t) {
        return Quaternion.LerpUnclamped(a, b, t);
    }

    ///<summary></summary>
    public static Quaternion LookRot(Vector3 fwd) {
        return Quaternion.LookRotation(fwd);
    }

    ///<summary></summary>
    public static Quaternion LookRot(Vector3 fwd, [DefaultValue("Vector3.up")] Vector3 up) {
        return Quaternion.LookRotation(fwd, up);
    }

    ///<summary></summary>
    public static Quaternion Nor(Quaternion q) {
        return Quaternion.Normalize(q);
    }

    ///<summary></summary>
    public static Quaternion Rot(Quaternion a, Quaternion b, float d) {
        return Quaternion.RotateTowards(a, b, d);
    }

    ///<summary></summary>
    public static Quaternion Slerp(Quaternion a, Quaternion b, float t) {
        return Quaternion.Slerp(a, b, t);
    }

    ///<summary></summary>
    public static Quaternion UnSlerp(Quaternion a, Quaternion b, float t) {
        return Quaternion.SlerpUnclamped(a, b, t);
    }
}