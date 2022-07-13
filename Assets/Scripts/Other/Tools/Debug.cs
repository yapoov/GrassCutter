using System.Collections.Generic;
using UnityEngine;

public class Dbg {
    ///<summary>шулуун зурна</summary>
    public static void Line(Vector3 a, Vector3 b, Color col = default(Color), float dur = 0) {
        Col.DefBlack(ref col);
        Debug.DrawLine(a, b, col, dur);
    }

    ///<summary>цацраг зурна</summary>
    public static void Ray(Vector3 a, Vector3 dir, Color col = default(Color), float dur = 0) {
        Col.DefBlack(ref col);
        Debug.DrawRay(a, dir, col, dur);
    }

    ///<summary>муруй зурна</summary>
    public static void Curve(List<Vector3> pnts, Color col = default(Color), float dur = 0, bool isShowPnt = false, float r = 0.1f, Color col2 = default(Color)) {
        if (isShowPnt && pnts.Count > 0)
            Sphere(pnts[0], r, col2, dur);
        for (int i = 1; i < pnts.Count; i++) {
            Line(pnts[i - 1], pnts[i], col, dur);
            if (isShowPnt)
                Sphere(pnts[i], r, col2, dur);
        }
    }

    ///<summary>тойрог зурна</summary>
    public static void Sphere(Vector3 pos, float r, Color col = default(Color), float dur = 0) {
        for (int ang = 0, dAng = 36; ang < 360; ang += dAng) {
            float sin1 = M.Sin(ang) * r, cos1 = M.Cos(ang) * r, sin2 = M.Sin(ang + dAng) * r, cos2 = M.Cos(ang + dAng) * r;
            Line(pos + new Vector3(0, sin1, cos1), pos + new Vector3(0, sin2, cos2), col, dur); // y z
            Line(pos + new Vector3(cos1, sin1, 0), pos + new Vector3(cos2, sin2, 0), col, dur); // x y
            Line(pos + new Vector3(sin1, 0, cos1), pos + new Vector3(sin2, 0, cos2), col, dur); // x z
        }
    }

    ///<summary>цлиндр зурна</summary>
    public static void Cylinder(Vector3 pos, float r, float h, Color col = default(Color), float dur = 0) {
        for (int ang = 0, dAng = 36; ang < 360; ang += dAng) {
            float sin1 = M.Sin(ang) * r, cos1 = M.Cos(ang) * r, sin2 = M.Sin(ang + dAng) * r, cos2 = M.Cos(ang + dAng) * r;
            Vector3 a = new Vector3(sin1, 0, cos1), b = new Vector3(sin2, 0, cos2), c = V3.u * h / 2;
            Line(pos + a + c, pos + b + c, col, dur); // up
            Line(pos + a - c, pos + b - c, col, dur); // down
            Line(pos + a + c, pos + a - c, col, dur); // line
        }
    }

    ///<summary>куб зурна</summary>
    public static void Cube(Vector3 pos, Vector3 size, Color col = default(Color), float dur = 0) {
        Vector3 half = size / 2;
        // up
        Line(pos + new Vector3(-half.x, half.y, -half.z), pos + new Vector3(-half.x, half.y, half.z), col, dur);
        Line(pos + new Vector3(-half.x, half.y, half.z), pos + new Vector3(half.x, half.y, half.z), col, dur);
        Line(pos + new Vector3(half.x, half.y, half.z), pos + new Vector3(half.x, half.y, -half.z), col, dur);
        Line(pos + new Vector3(half.x, half.y, -half.z), pos + new Vector3(-half.x, half.y, -half.z), col, dur);
        // middle
        Line(pos + new Vector3(-half.x, half.y, -half.z), pos + new Vector3(-half.x, -half.y, -half.z), col, dur);
        Line(pos + new Vector3(-half.x, half.y, half.z), pos + new Vector3(-half.x, -half.y, half.z), col, dur);
        Line(pos + new Vector3(half.x, half.y, half.z), pos + new Vector3(half.x, -half.y, half.z), col, dur);
        Line(pos + new Vector3(half.x, half.y, -half.z), pos + new Vector3(half.x, -half.y, -half.z), col, dur);
        // down
        Line(pos + new Vector3(-half.x, -half.y, -half.z), pos + new Vector3(-half.x, -half.y, half.z), col, dur);
        Line(pos + new Vector3(-half.x, -half.y, half.z), pos + new Vector3(half.x, -half.y, half.z), col, dur);
        Line(pos + new Vector3(half.x, -half.y, half.z), pos + new Vector3(half.x, -half.y, -half.z), col, dur);
        Line(pos + new Vector3(half.x, -half.y, -half.z), pos + new Vector3(-half.x, -half.y, -half.z), col, dur);
    }
}