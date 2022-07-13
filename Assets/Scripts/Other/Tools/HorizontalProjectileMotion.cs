using System.Collections.Generic;
using UnityEngine;

public class Hpm {
    ///<summary>a-с v0 анхны хурдтай хөдөлхөд time хугацаанд туулах n-ш цэгүүд</summary>
    public static List<Vector3> Pnts(Vector3 a, Vector3 v0, float time, int n) {
        List<Vector3> res = new List<Vector3>() { a };
        for (int i = 1; i <= n; i++)
            res.Add(Pnt(a, v0, time * i / n));
        return res;
    }

    ///<summary>a-с v0 анхны хурдтай хөдөлхөд time хугацаанд туулах цэг</summary>
    public static Vector3 Pnt(Vector3 a, Vector3 v0, float time) {
        return a + v0 * time + V3.u * Physics.gravity.y * time * time / 2f;
    }

    ///<summary>a-с b-рүү h өндөртэй явах үеийн анхны хурд</summary>
    public static Vector3 H(Vector3 a, Vector3 b, float h) {
        float time = 0, ang = 0;
        return H(a, b, h, ref time, ref ang);
    }

    ///<summary>a-с b-рүү h өндөртэй явах үеийн анхны хурд, хугацаа, өнцөг</summary>
    public static Vector3 H(Vector3 a, Vector3 b, float h, ref float time, ref float ang) {
        float g = Physics.gravity.y;
        float disY = b.y - a.y;
        Vector3 disXZ = new Vector3(b.x - a.x, 0, b.z - a.z);
        time = Mathf.Sqrt(-2 * h / g) + Mathf.Sqrt(2 * (disY - h) / g);
        Vector3 vY = V3.u * Mathf.Sqrt(-2 * g * h);
        Vector3 vXZ = disXZ / time;
        Vector3 v0 = vXZ + vY * -g.Sign();
        ang = Vector3.Angle(v0, new Vector3(v0.x, 0, v0.z));
        return v0;
    }

    ///<summary>a-с b-рүү ang өнцөгтэй явах үеийн анхны хурд</summary>
    public static Vector3 Ang(Vector3 a, Vector3 b, float ang) {
        float time = 0, h = 0;
        return Ang(a, b, ang, ref time, ref h);
    }

    ///<summary>a-с b-рүү ang өнцөгтэй явах үеийн анхны хурд, хугацаа, өндөр</summary>
    public static Vector3 Ang(Vector3 a, Vector3 b, float ang, ref float time, ref float h) {
        float g = Physics.gravity.y;
        Vector3 aXz = V3.Y(a, 0), bXz = V3.Y(b, 0);
        float disXz = V3.Dis(aXz, bXz);
        float tanAlpha = Mathf.Tan(ang * Mathf.Deg2Rad);
        float disY = b.y - a.y;
        float vZ = Mathf.Sqrt(g * disXz * disXz / (2f * (disY - disXz * tanAlpha)));
        float vY = tanAlpha * vZ;
        Vector3 v0 = Q.LookRot(bXz - a) * new Vector3(0f, vY, vZ);
        h = -v0.y * v0.y / (2 * g);
        time = time = Mathf.Sqrt(-2 * h / g) + Mathf.Sqrt(2 * (disY - h) / g);
        return v0;
    }

    ///<summary>v0 анхны хурдтай явах үеийн дээд өндөр</summary>
    public static float V0H(Vector3 v0) {
        return -v0.y * v0.y / (2 * Physics.gravity.y);
    }

    ///<summary>v0 анхны хурдтай явах үеийн өнцөг</summary>
    public static float V0Ang(Vector3 v0) {
        return v0.y.Sign() * Vector3.Angle(v0, new Vector3(v0.x, 0, v0.z));
    }
}