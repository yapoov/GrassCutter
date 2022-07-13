using UnityEngine;

public class Ang {

    ///<summary>b-г cw үнэн бол [a, a+180] үгүй бол [a, a-180] хооронд байна уу шалгана</summary>
    public static bool IsNear(float a, float b, bool cw = true) {
        return M.Dis(a, Rep(b, a, cw)) < 180;
    }

    ///<summary>a, b-н хооронд f өнцөг байна уу шалгана</summary>
    public static bool IsBet(float f, float a, float b) {
        return Dis(f, a) < Dis(a, b) && Dis(f, b) < Dis(a, b);
    }

    ///<summary>cw үнэн бол цагийн зүүний дагуу үгүй бол эсрэг a, b-н хооронд f өнцөг байна уу шалгана</summary>
    public static bool IsBet(float f, float a, float b, bool cw) {
        return IsNear(a, b, cw) == M.IsBet(Rep(f, a, cw), a, Rep(b, a, cw));
    }

    ///<summary>f∈[a, b] өнцөг</summary>
    public static float Clamp(float f, float a, float b) {
        return IsNear(a, b) ? M.Clamp(Rep(f, a), a, Rep(b, a)) : M.Clamp(Rep(f, b), b, Rep(a, b));
    }

    ///<summary>f-г cw үнэн бол [a, a+360] үгүй бол [a, a-360] хооронд давтана</summary>
    public static float Rep(float f, float a = 0, bool cw = true) {
        return M.Rep(f, a, a + cw.Sign() * 360);
    }

    ///<summary>a, b-н зөрүү өнцөг</summary>
    public static float Dis(float a, float b) {
        return Mathf.DeltaAngle(a, b);
    }

    ///<summary>a өнцгийг b өнцөгрүү t хувиар ойртуулна</summary>
    public static float Lerp(float a, float b, float t) {
        return Mathf.LerpAngle(a, b, t);
    }

    ///<summary>a өнцгийг b өнцөгрүү t хувиар ойртуулна [cw үнэн бол цагийн зүүний дагуу]</summary>
    public static float Lerp(float a, float b, float t, bool cw) {
        return M.Lerp(a, Rep(b, a, cw), t);
    }

    ///<summary>a өнцгийг b өнцөгрүү d-р ойртуулна</summary>
    public static float Move(float a, float b, float d) {
        return Mathf.MoveTowardsAngle(a, b, d);
    }

    ///<summary>a өнцгийг b өнцөгрүү d-р ойртуулна [cw үнэн бол цагийн зүүний дагуу]</summary>
    public static float Move(float a, float b, float d, bool cw) {
        return M.Move(a, Rep(b, a, cw), d);
    }

    ///<summary>дээрээс хархад a-с b-рүү харах өнцөг zLx [isUnity үнэн бол unity үгүй бол math дээр ашиглах өнцөг]</summary>
    public static float LookDown(Vector3 a, Vector3 b, bool isUnity = true) {
        return UnityOrReal(M.Atan2(b.z - a.z, b.x - a.x), isUnity);
    }

    ///<summary>урдаас хархад a-с b-рүү харах өнцөг yLx [isUnity үнэн бол unity үгүй бол math дээр ашиглах өнцөг]</summary>
    public static float LookForward(Vector3 a, Vector3 b, bool isUnity = true) {
        return UnityOrReal(M.Atan2(b.y - a.y, b.x - a.x), isUnity);
    }

    ///<summary>Atan2-р бодоод гарч ирсэн өнцгийг хөрвүүлнэ</summary>
    public static float UnityOrReal(float ang, bool isUnity) {
        return Rep(isUnity ? (540 - Rep(ang + 90)) : ang);
    }

    ///<summary>Өнцгийг Vector3 болгоно</summary>
    public static Vector3 V3(float r, float ang) {
        return new Vector3(M.Cos(ang), 0, M.Sin(ang)) * r;
    }
}