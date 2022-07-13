using System.Collections.Generic;
using UnityEngine;

public class Crv {
    ///<summary>pnts-н цэгүүдийн хоорондох зайг ижил dis болгох</summary>
    public static List<Vector3> PntsSameDisBetPnts(List<Vector3> pnts, float dis) {
        List<Vector3> res = new List<Vector3>();
        if (pnts.Count > 0) {
            Vector3 p = pnts[0];
            res.Add(p);
            for (int i = 1; i < pnts.Count; i++) {
                while (Vector3.Distance(p, pnts[i]) > dis) {
                    p = Vector3.MoveTowards(p, pnts[i], dis);
                    res.Add(p);
                }
            }
            res.Add(pnts[pnts.Count - 1]);
        }
        return res;
    }

    ///<summary>pnts-н цэгүүдийн зай</summary>
    public static float PntsDis(List<Vector3> pnts) {
        float res = 0;
        for (int i = 1; i < pnts.Count; i++)
            res += V3.Dis(pnts[i - 1], pnts[i]);
        return res;
    }

    ///<summary>3-н цэгийн bezier-н муруй</summary>
    public static Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t) {
        return V3.Lerp(V3.Lerp(a, b, t), V3.Lerp(b, c, t), t);
    }

    ///<summary>4-н цэгийн bezier-н муруй</summary>
    public static Vector3 CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t) {
        return V3.Lerp(QuadraticCurve(a, b, c, t), QuadraticCurve(b, c, d, t), t);
    }

    // Catmull Rom Spline

    ///<summary>муруй үүсгэнэ</summary>
    public static List<Vector3> CatmullRomSpline(List<Vector3> pnts, int smt = 5, float spc = -1, bool isLoop = true) {
        List<Vector3> res = new List<Vector3>();
        if (isLoop) {
            for (int i = -1; i < pnts.Count - 1; i++)
                res = A.Add2List<Vector3>(
                    res,
                    CatmullRomSpline(pnts.RepIdx(i), pnts.RepIdx(i + 1), pnts.RepIdx(i + 2), pnts.RepIdx(i + 3), smt, false, true)
                );
        } else {
            for (int i = 0; i <= pnts.Count - 4; i++)
                res = A.Add2List<Vector3>(res, CatmullRomSpline(pnts[i], pnts[i + 1], pnts[i + 2], pnts[i + 3], smt, i == 0, true));
        }
        if (spc > 0.01f)
            res = PntsSameDisBetPnts(res, spc);
        return res;
    }

    ///<summary>CatmullRom муруй p1-с p2-н хоорондох цэгүүдийг үүсгэнэ</summary>
    public static List<Vector3> CatmullRomSpline(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, int smt, bool isStaIn = true, bool isEndIn = true) {
        List<Vector3> res = new List<Vector3>();
        if (isStaIn)
            res.Add(p1);
        for (int i = 1; i < smt; i++)
            res.Add(GetCatmullRomPosition(p0, p1, p2, p3, (float)i / smt));
        if (isEndIn)
            res.Add(p2);
        return res;
    }

    ///<summary>CatmullRom муруйн цэг үүсгэх томъёо</summary>
    public static Vector3 GetCatmullRomPosition(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
        return 0.5f * ((2f * p1) + (p2 - p0) * t +
            (2f * p0 - 5f * p1 + 4f * p2 - p3) * t * t +
            (-p0 + 3f * p1 - 3f * p2 + p3) * t * t * t);
    }
}