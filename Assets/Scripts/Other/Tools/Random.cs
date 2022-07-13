using System.Collections.Generic;
using UnityEngine;

public class Rnd {
    ///<summary>random rotation</summary>
    public static Quaternion Rot => Random.rotation;

    ///<summary>random rotation uniform</summary>
    public static Quaternion RotUniform => Random.rotationUniform;

    ///<summary>random нэгж бөмбөрцөг дээрх цэг</summary>
    public static Vector3 OnUnitSphere => Random.onUnitSphere;

    ///<summary>random нэгж бөмбөрцөг доторх цэг</summary>
    public static Vector3 InUnitSphere => Random.insideUnitSphere;

    ///<summary>random нэгж тойрог дээрх цэг</summary>
    public static Vector2 OnUnitCircle => Random.insideUnitCircle.normalized;

    ///<summary>random нэгж тойрог доторх цэг</summary>
    public static Vector2 InUnitCircle => Random.insideUnitCircle;

    ///<summary>random өнгө [alpha = 1]</summary>
    public static Color Col => new Color(Val, Val, Val, 1f);

    ///<summary>random өнгө</summary>
    public static Color ColA => Random.ColorHSV();

    ///<summary>random тоо [0, 1]</summary>
    public static float Val => Random.value;

    ///<summary>random тоо 0, 1</summary>
    public static int ValI => RngIn(0, 1);

    ///<summary>random тоо [-1, 1]</summary>
    public static float Val1 => Rng(-1f, 1f);

    ///<summary>random -1, 0, 1</summary>
    public static int Val1I => RngIn(-1, 1);

    ///<summary>random тэмдэг ±1</summary>
    public static int Sign => Bool ? -1 : 1;

    ///<summary>random өнцөг [0, 360]</summary>
    public static float Ang => Val * 360f;

    ///<summary>random bool</summary>
    public static bool Bool => Val < 0.5f;

    ///<summary>random тоо [0, n]</summary>
    public static float N(float n) {
        return Val * n;
    }

    ///<summary>random магадлал шалгана p[0, 1]</summary>
    public static bool P(float p) {
        return Val < p;
    }

    ///<summary>random тоо [a, b]</summary>
    public static float Rng(float a, float b) {
        return Random.Range(a, b);
    }

    ///<summary>random тоо [a, b[</summary>
    public static int Rng(int a, int b) {
        return Random.Range(a, b);
    }

    ///<summary>random тоо [a, b]</summary>
    public static int RngIn(int a, int b) {
        return Rng(a, b + 1);
    }

    ///<summary>random index [0, n[</summary>
    public static int Idx(int n) {
        return Rng(0, n);
    }

    ///<summary>random index i-с ялгаатай[0, n[</summary>
    public static int Idx(int n, int i) {
        int res = 0;
        if (i < 0)
            i = n - 1;
        if (n > 1)
            do {
                res = Idx(n);
            } while (res == i);
        return res;
    }

    ///<summary>random тоо a, b</summary>
    public static float Select(float a, float b) {
        return Select(0.5f, a, b);
    }

    ///<summary>random тоо p[0, 1] магадлал биелвэл a үгүй бол b</summary>
    public static float Select(float p, float a, float b) {
        return P(p) ? a : b;
    }

    ///<summary>random байрлал [a, b]</summary>
    public static Vector3 Pos(Vector3 a, Vector3 b) {
        Vector3 min = V3.Min(a, b), max = V3.Max(a, b);
        return new Vector3(Rng(min.x, max.x), Rng(min.y, max.y), Rng(min.z, max.z));
    }

    ///<summary>random enum</summary>
    public static T Enum<T>() {
        var values = System.Enum.GetValues(typeof(T));
        return (T)values.GetValue(Idx(values.Length));
    }

    ///<summary>random list 1 элемент</summary>
    public static T List<T>(List<T> lis) {
        return lis[Idx(lis.Count)];
    }

    ///<summary>random list n элемент</summary>
    public static List<T> List<T>(List<T> lis, int n) {
        List<T> res = new List<T>();
        if (1 <= n && n <= lis.Count)
            while (res.Count < n) {
                T t = lis[Idx(lis.Count)];
                if (!res.Contains(t))
                    res.Add(t);
            }
        else if (n > lis.Count)
            while (res.Count < n)
                res.Add(lis[Idx(lis.Count)]);
        return res;
    }

    ///<summary>random өнгө</summary>
    public static Color ColHSV(float hMin, float hMax, float sMin, float sMax, float vMin, float vMax, float aMin, float aMax) {
        return Random.ColorHSV(hMin, hMax, sMin, sMax, vMin, vMax, aMin, aMax);
    }

    ///<summary>random өнгө</summary>
    public static Color ColHSV(float hMin, float hMax, float sMin, float sMax, float vMin, float vMax) {
        return Random.ColorHSV(hMin, hMax, sMin, sMax, vMin, vMax);
    }

    ///<summary>random өнгө</summary>
    public static Color ColHSV(float hMin, float hMax, float sMin, float sMax) {
        return Random.ColorHSV(hMin, hMax, sMin, sMax);
    }

    ///<summary>random өнгө</summary>
    public static Color ColHSV(float hMin, float hMax) {
        return Random.ColorHSV(hMin, hMax);
    }
}