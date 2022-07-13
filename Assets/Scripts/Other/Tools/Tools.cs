using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class VarTime<T> {
    public T value;
    public float time = 0;
    public VarTime(T value, float time) { Set(value, time); }
    public void Set(T value) { Set(value, Time.time); }
    public void Set(T value, float time) { this.value = value; this.time = time; }
    ///<summary>name хувьсагчийн нэр, V нь энэ хувьсагчийг агуулж байгаа класс харин obj обект, value өгөх утга, time хүлээх хугацаа</summary>
    public void Set<V>(V obj, string name, T value, float time) { A.GC.VarTimeSet(obj, name, value, time); }
}

[System.Serializable]
public partial class Tf {
    public Vector3 t;
    public Vector3 r;
    public Vector3 s;
    public Quaternion q { get { return Q.Euler(r); } }
    public Tf(Vector3 t, Quaternion r, Vector3 s) { Set(t, r.eulerAngles, s); }
    public Tf(Vector3 t, Vector3 r, Vector3 s) { Set(t, r, s); }
    public Tf(Vector3 t, Quaternion r) { Set(t, r.eulerAngles, Vector3.one); }
    public Tf(Vector3 t, Vector3 r) { Set(t, r, Vector3.one); }
    public Tf(Vector3 t) { Set(t, Vector3.zero, Vector3.one); }
    public Tf() { Set(Vector3.zero, Vector3.zero, Vector3.one); }
    public void Set(Vector3 t, Vector3 r, Vector3 s) { this.t = t; this.r = r; this.s = s; }
}

[System.Serializable]
public class LevelTile {
    public Vector2Int pos;
    public bool[] actives = new bool[5];
    public LevelTile(Vector2Int pos, bool isBody, bool isLF, bool isRF, bool isRB, bool isLB) {
        this.pos = pos;
        actives[0] = isBody;
        actives[1] = isLF;
        actives[2] = isRF;
        actives[3] = isRB;
        actives[4] = isLB;
    }
    public LevelTile(Vector2Int pos, bool[] actives) {
        this.pos = pos;
        this.actives = actives;
    }
}

public class RoadData {
    public RoadDir dir;
    public Vector3Int pos;
    public Quaternion rot;
    public RoadData(RoadDir dir, Vector3Int pos, Quaternion rot) { this.dir = dir; this.pos = pos; this.rot = rot; }
}
public enum RenderingMode { Opaque, Cutout, Fade, Transparent }
public enum RoadDir { LD, FD, RD, L, F, R, LU, FU, RU }
public enum Vib { Success, Warning, Error, Light, Medium, Heavy }
public enum RotType { Def, Rnd, Rot };

public static partial class A {
    ///<summary>enum-г string array болгоно</summary>
    public static string[] EnumStrArr<T>() {
        return System.Enum.GetValues(typeof(T)).OfType<object>().Select(o => o.ToString()).ToArray();
    }

    ///<summary>enum-г array болгоно</summary>
    public static T[] EnumArr<T>() {
        return System.Enum.GetValues(typeof(T)).OfType<object>().Select<object, T>(o => (T)o).ToArray();
    }

    ///<summary>0 дээр төвтэй n-ш цэгийн эхлэх цэг</summary>
    public static float Start(int n) {
        return (1 - n) / 2f;
    }

    ///<summary>sprite border болгоно</summary>
    public static Vector4 SprBorder(float l, float r, float t, float b) {
        return new Vector4(l, b, r, t);
    }

    ///<summary>sprite-н border-г өөрчилнэ</summary>
    public static void SetSprBorder(string path, Vector4 border) {
        IO.SetMetaLine(path, "spriteBorder", "spriteBorder: {x: " + border.x + ", y: " + border.y + ", z: " + border.z +
            ", w: " + border.w + "}");
    }

    ///<summary>Screenshot хийнэ</summary>
    public static void Screenshot(string path, string name) {
        IO.CheckCrtDir(path);
        string fileName = path + "/" + name + ".png";
#if UNITY_5
        Application.CaptureScreenshot (fileName, 1);
#else
        ScreenCapture.CaptureScreenshot(fileName, 1);
#endif
    }
    ///<summary>T төрөлтэй бүх обектуудыг авна</summary>
    public static List<T> FOsOTA<T>() { return Resources.FindObjectsOfTypeAll(typeof(T)).Lis().TypeCast<Object, T>(); }
    ///<summary>T төрөлтэй бүх идэвхитэй обектуудыг авна</summary>
    public static List<T> FOsOT<T>() { return Object.FindObjectsOfType(typeof(T)).Lis().TypeCast<Object, T>(); }

    ///<summary>format string-г key-г data-р орлуулж тавина</summary>
    public static string Format(string format, params string[] keyDatas) {
        if (keyDatas.Length == 2)
            return format.Contains(keyDatas[0]) ? format.Replace(keyDatas[0], keyDatas[1]) : format + keyDatas[1];
        else if (keyDatas.Length > 2)
            for (int i = 0, n = keyDatas.Length - (keyDatas.Length % 2 == 0 ? 0 : 1); i < n; i += 2)
                format = format.Contains(keyDatas[i]) ? format.Replace(keyDatas[i], keyDatas[i + 1]) : format;
        return format;
    }
    ///<summary>a обектийн name нэртэй хувьсагчийн мэдээллийг авна</summary>
    public static System.Reflection.FieldInfo Field<T>(T a, string name) {
        return a.GetType().GetField(name,
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.NonPublic
        );
    }
    ///<summary>Sprite-г Texture2D болгоно</summary>
    public static Texture2D SprTex(Sprite spr) { return spr.texture; }
    ///<summary>Texture2D-г Sprite болгоно</summary>
    public static Sprite TexSpr(Texture2D tex) { return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f); }
    static Dictionary<System.Type, System.Func<object, object, float>> dicDisFunc = new Dictionary<System.Type, System.Func<object, object, float>>() { //
        { typeof (int), (a, b) => Mathf.Abs ((int) a - (int) b) }, //
        { typeof (float), (a, b) => Mathf.Abs ((float) a - (float) b) }, //
        { typeof (Vector2), (a, b) => Vector2.Distance ((Vector2) a, (Vector2) b) }, //
        { typeof (Vector2Int), (a, b) => Vector2Int.Distance ((Vector2Int) a, (Vector2Int) b) }, //
        { typeof (Vector3), (a, b) => Vector3.Distance ((Vector3) a, (Vector3) b) }, //
        { typeof (Vector3Int), (a, b) => Vector3Int.Distance ((Vector3Int) a, (Vector3Int) b) }, //
        { typeof (Vector4), (a, b) => Vector4.Distance ((Vector4) a, (Vector4) b) }, //
        { typeof (Transform), (a, b) => Vector3.Distance (((Transform) a).position, ((Transform) b).position) }, //
        { typeof (GameObject), (a, b) => Vector3.Distance (((GameObject) a).transform.position, ((GameObject) b).transform.position) }, //
        { typeof (MonoBehaviour), (a, b) => Vector3.Distance (((MonoBehaviour) a).transform.position, ((MonoBehaviour) b).transform.position) }, //
    };
    static Dictionary<System.Type, System.Func<object, Vector3, float>> dicPosDisFunc = new Dictionary<System.Type, System.Func<object, Vector3, float>>() { //
        { typeof (Vector3), (a, b) => Vector3.Distance ((Vector3) a, b) }, //
        { typeof (Transform), (a, b) => Vector3.Distance (((Transform) a).position, b) }, //
        { typeof (GameObject), (a, b) => Vector3.Distance (((GameObject) a).transform.position, b) }, //
        { typeof (MonoBehaviour), (a, b) => Vector3.Distance (((MonoBehaviour) a).transform.position, b) }, //
    };
    ///<summary>t-тэй ойрхон lis-н элементийн idx-г авна</summary>
    public static int GetNearIdx<T>(List<T> lis, T t) {
        int idx = -1;
        if (lis.Count > 0 && (dicDisFunc.ContainsKey(lis[0].GetType()) || (lis[0] is MonoBehaviour))) {
            float minDis = float.MaxValue, dis;
            System.Func<object, object, float> f = dicDisFunc[(lis[0] is MonoBehaviour) ? typeof(MonoBehaviour) : lis[0].GetType()];
            for (int i = 0; i < lis.Count; i++) {
                dis = f(lis[i], t);
                if (dis < minDis) {
                    minDis = dis;
                    idx = i;
                }
            }
        }
        return idx;
    }
    ///<summary>pos байрлалтай ойрхон lis-н элементийн idx-г авна</summary>
    public static int GetPosNearIdx<T>(List<T> l, Vector3 pos) {
        int idx = -1;
        if (l.Count > 0 && (dicPosDisFunc.ContainsKey(l[0].GetType()) || (l[0] is MonoBehaviour))) {
            float minDis = float.MaxValue, dis;
            System.Func<object, Vector3, float> f = dicPosDisFunc[(l[0] is MonoBehaviour) ? typeof(MonoBehaviour) : l[0].GetType()];
            for (int i = 0; i < l.Count; i++) {
                dis = f(l[i], pos);
                if (dis < minDis) {
                    minDis = dis;
                    idx = i;
                }
            }
        }
        return idx;
    }
    ///<summary>t-тэй ойрхон lis-н элементийн idx-г авна</summary>
    public static List<T> DisSort<T>(List<T> l, T t) {
        List<T> lis = null;
        if (l.Count > 0 && (dicDisFunc.ContainsKey(l[0].GetType()) || (l[0] is MonoBehaviour))) {
            System.Func<object, object, float> f = dicDisFunc[(l[0] is MonoBehaviour) ? typeof(MonoBehaviour) : l[0].GetType()];
            List<Vector2> disLis = new List<Vector2>();
            for (int i = 0; i < l.Count; i++)
                disLis.Add(new Vector2(i, f(l[i], t)));
            disLis.Sort((a, b) => a.y.CompareTo(b.x));
            lis = new List<T>();
            for (int i = 0; i < disLis.Count; i++)
                lis.Add(l[(int)disLis[i].x]);
        }
        return lis;
    }
    ///<summary>time-г string болгоно</summary>
    public static string TimeStr(float time) { return System.TimeSpan.FromSeconds(Mathf.FloorToInt(time)).ToString().SubStr(3); }
    ///<summary>a, b-г солино</summary>
    public static void Swap<T>(ref T a, ref T b) { T t = a; a = b; b = t; }
    ///<summary>lis-г холино</summary>
    public static void Shuffle<T>(ref List<T> lis) {
        for (int i = 0; i < lis.Count; i++) {
            T tmp = lis[i];
            int randIdx = Rnd.Idx(lis.Count);
            lis[i] = lis[randIdx];
            lis[randIdx] = tmp;
        }
    }
    ///<summary>a, b list-г нэмнэ</summary>
    public static List<T> Add2List<T>(List<T> a, List<T> b) {
        List<T> res = a;
        foreach (T e in b) res.Add(e);
        return res;
    }

    // █▀▀▀▄ ▄▀▀▀▄ ▄▀▀▀▄ █▀▀▀▄ 
    // █▄▄▄▀ █   █ █▄▄▄█ █   █ 
    // █ ▀▄  █   █ █   █ █   █ 
    // ▀   ▀  ▀▀▀  ▀   ▀ ▀▀▀▀

    public static List<RoadData> RoadDirs2Datas(List<RoadDir> dirs) {
        List<RoadData> datas = new List<RoadData>();
        RoadDir prvDir, curDir;
        Vector3Int defPrvPrvPos = new Vector3Int(0, 0, -2), defPrvPos = new Vector3Int(0, 0, -1),
            prvPrvPos, prvPos, curPos;
        Quaternion curRot;
        for (int i = 0; i < dirs.Count; i++) {
            prvPrvPos = i == 0 ? defPrvPrvPos : i == 1 ? defPrvPos : datas[i - 2].pos;
            prvPos = i == 0 ? defPrvPos : datas[i - 1].pos;
            prvDir = i == 0 ? RoadDir.F : datas[i - 1].dir;
            curDir = dirs[i];
            curPos = RoadCurPos(prvDir, prvPrvPos, prvPos);
            curRot = RoadCurRot(prvPos, curPos);
            datas.Add(new RoadData(curDir, curPos, curRot));
        }
        return datas;
    }
    public static List<RoadData> RoadCreateDatas(int n, int staF, int endF) {
        bool isDone = false;
        List<RoadData> datas = new List<RoadData>();
        for (int i = 0; i < staF; i++) {
            Vector3Int curPos = RoadCurPos(RoadDir.F, RoadDatasPos(datas, i - 2), RoadDatasPos(datas, i - 1));
            datas.Add(new RoadData(RoadDir.F, curPos, RoadCurRot(RoadDatasPos(datas, i - 1), curPos)));
        }
        RoadCreateData(RoadDir.F, RoadDir.F, RoadDatasPos(datas, datas.Count - 2), RoadDatasPos(datas, datas.Count - 1),
            0, n - staF - endF, datas, ref isDone);
        for (int i = 0; i < endF; i++) {
            Vector3Int curPos = RoadCurPos(datas[datas.Count - 1].dir, datas[datas.Count - 2].pos, datas[datas.Count - 1].pos);
            datas.Add(new RoadData(RoadDir.F, curPos, RoadCurRot(datas[datas.Count - 1].pos, curPos)));
        }
        return datas;
    }
    static Vector3Int RoadDatasPos(List<RoadData> datas, int i) { return i < 0 ? new Vector3Int(0, 0, i) : datas[i].pos; }
    static void RoadCreateData(RoadDir prvDir, RoadDir curDir, Vector3Int prvPrvPos, Vector3Int prvPos, int iLen, int len,
        List<RoadData> datas, ref bool isDone) {
        if (isDone) return;
        if (iLen >= len) {
            isDone = true;
            return;
        }
        Vector3Int curPos = RoadCurPos(prvDir, prvPrvPos, prvPos);
        if (RoadIsOverlap(prvDir, prvPrvPos, prvPos, new List<RoadDir>() { curDir, RoadDir.F, RoadDir.F }, datas)) return;
        Quaternion curRot = RoadCurRot(prvPos, curPos);
        datas.Add(new RoadData(curDir, curPos, curRot));
        List<RoadDir> rndDirs = new List<RoadDir> { RoadDir.LD, RoadDir.FD, RoadDir.RD, RoadDir.L, RoadDir.F, RoadDir.R, RoadDir.LU, RoadDir.FU, RoadDir.RU };
        Shuffle<RoadDir>(ref rndDirs);
        for (int i = 0; i < rndDirs.Count; i++)
            RoadCreateData(curDir, rndDirs[i], prvPos, curPos, iLen + 1, len, datas, ref isDone);
        if (isDone) return;
        datas.RemoveAt(datas.Count - 1);
    }
    static Vector3Int RoadCurPos(RoadDir prvDir, Vector3Int prvPrvPos, Vector3Int prvPos) {
        Vector3 t = prvPos.V3();
        Quaternion r = Q.LookRot(t - new Vector3(prvPrvPos.x, prvPos.y, prvPrvPos.z));
        Vector3 s = Vector3.one;
        Vector3 pos = new List<Vector3Int>() {
            new Vector3Int (-1, -1, 0), new Vector3Int (0, -1, 1), new Vector3Int (1, -1, 0),
                new Vector3Int (-1, 0, 0), new Vector3Int (0, 0, 1), new Vector3Int (1, 0, 0),
                new Vector3Int (-1, 1, 0), new Vector3Int (0, 1, 1), new Vector3Int (1, 1, 0),
        }[(int)prvDir].V3();
        return Vector3Int.RoundToInt(Matrix4x4.TRS(t, r, s).MultiplyPoint3x4(pos));
    }
    static Quaternion RoadCurRot(Vector3Int prvPos, Vector3Int curPos) { return Q.LookRot(curPos.V3() - new Vector3(prvPos.x, curPos.y, prvPos.z)); }
    static bool RoadIsOverlap(RoadDir prvDir, Vector3Int prvPrvPos, Vector3Int prvPos, List<RoadDir> dirs, List<RoadData> datas) {
        List<Vector3Int> posLis = new List<Vector3Int>();
        for (int i = 0; i < dirs.Count; i++) {
            posLis.Add(RoadCurPos(
                i == 0 ? prvDir : dirs[i - 1],
                i == 0 ? prvPrvPos : i == 1 ? prvPos : posLis[i - 2],
                i == 0 ? prvPos : posLis[i - 1]
            ));
        }
        for (int i = 0; i < datas.Count; i++) {
            for (int j = 0; j < posLis.Count; j++) {
                // if (datas[i].pos == posLis[j] - Vector3Int.up * 2 ||
                //     datas[i].pos == posLis[j] - Vector3Int.up ||
                //     datas[i].pos == posLis[j] ||
                //     datas[i].pos == posLis[j] + Vector3Int.up ||
                //     datas[i].pos == posLis[j] + Vector3Int.up * 2) {
                //     return true;
                // }
                if (datas[i].pos == posLis[j] ||
                    (((int)dirs[j] / 3 == 2) && ( // ^
                        (datas[i].pos == posLis[j] + Vector3Int.up) || // ^*
                        (datas[i].pos == posLis[j] + Vector3Int.up * 2 && (int)datas[i].dir / 3 == 0) // ^^v
                    )) ||
                    (((int)dirs[j] / 3 == 1) && ( // -
                        (datas[i].pos == posLis[j] + Vector3Int.up && (int)datas[i].dir / 3 == 0) || // ^v
                        (datas[i].pos == posLis[j] + Vector3Int.down && (int)datas[i].dir / 3 == 2) // v^
                    )) ||
                    (((int)dirs[j] / 3 == 0) && ( // v
                        (datas[i].pos == posLis[j] + Vector3Int.down) || // v*
                        (datas[i].pos == posLis[j] + Vector3Int.down * 2 && (int)datas[i].dir / 3 == 2) // vv^
                    ))
                ) return true;
            }
        }
        return false;
    }
    static void RoadAddDatas(RoadDir prvDir, Vector3Int prvPrvPos, Vector3Int prvPos, List<RoadDir> dirs, List<RoadData> datas,
        ref RoadDir refCurDir, ref Vector3Int refPrvPos, ref Vector3Int refCurPos) {
        List<Vector3Int> idxs = new List<Vector3Int>();
        for (int i = 0; i < dirs.Count; i++) {
            refPrvPos = i == 0 ? prvPos : idxs[i - 1];
            refCurDir = dirs[i];
            refCurPos = RoadCurPos(
                i == 0 ? prvDir : dirs[i - 1],
                i == 0 ? prvPrvPos : i == 1 ? prvPos : idxs[i - 2],
                refPrvPos
            );
            idxs.Add(refCurPos);
            datas.Add(new RoadData(refCurDir, refCurPos, RoadCurRot(refPrvPos, refCurPos)));
        }
    }



    // █     █▀▀▀▀ █   █ █▀▀▀▀ █     
    // █     █▄▄▄  █   █ █▄▄▄  █     
    // █     █      █ █  █     █     
    // ▀▀▀▀▀ ▀▀▀▀▀   ▀   ▀▀▀▀▀ ▀▀▀▀▀

    ///<summary>үеийн өнгөнөөс tile-г авна</summary>
    public static List<LevelTile> TexGetTiles(List<Color> colors, Vector2Int size, Color emptyCol, bool isCorner) {
        List<LevelTile> res = new List<LevelTile>();
        List<Vector2Int> levelDirs = new List<Vector2Int>() {
            new Vector2Int (-1, 0), new Vector2Int (-1, 1), new Vector2Int (0, 1), new Vector2Int (1, 1),
            new Vector2Int (1, 0), new Vector2Int (1, -1), new Vector2Int (0, -1), new Vector2Int (-1, -1),
        };
        System.Func<int, int, int, int, List<Color>, Color, bool> isEmpty = (x, y, w, h, cols, empCol) =>
            (x < 0 || x >= w || y < 0 || y >= h || cols[TexGetIdx(x, y, w, h)] == empCol);
        for (int y = 0; y < size.y; y++) {
            for (int x = 0; x < size.x; x++) {
                List<bool> actives = new List<bool>() { !isEmpty(x, y, size.x, size.y, colors, emptyCol) };
                for (int i = 0; i < 4; i++) {
                    bool dir0 = !isEmpty(x + levelDirs[i * 2].x, y + levelDirs[i * 2].y, size.x, size.y, colors, emptyCol),
                        dir1 = !isEmpty(x + levelDirs[i * 2 + 1].x, y + levelDirs[i * 2 + 1].y, size.x, size.y, colors, emptyCol),
                        dir2 = !isEmpty(x + levelDirs[(i * 2 + 2) % 8].x, y + levelDirs[(i * 2 + 2) % 8].y, size.x, size.y, colors, emptyCol);
                    actives.Add(isCorner ? (actives[0] ? (dir0 || dir1 || dir2) : (dir0 && dir2)) :
                        (actives[0] ? ((dir0 && dir1) || (dir1 && dir2) || (dir2 && dir0) || (dir0 && !dir1) || (dir2 && !dir1)) : (dir0 && dir1 && dir2)));
                }
                if (actives.Contains(true))
                    res.Add(new LevelTile(new Vector2Int(x, y), actives.Arr()));
            }
        }
        return res;
    }
    ///<summary>зурагнаас үеийн өнгийг авна</summary>
    public static List<Color> TexGetLevelColors(Texture2D tex, Color borderCol, int level, out Vector2Int size) {
        int w = tex.width, h = tex.height;
        List<Color> colors = tex.GetPixels(0, 0, w, h).Lis();
        for (int y = 1, lvl = 0; y < h; y++) {
            for (int x = 0; x < w; x++) {
                if (colors[TexGetIdx(x, y, w, h)] == borderCol) {
                    bool isFirst = true;
                    for (int ix = x, iy = y; ix < w; ix++) {
                        if (colors[TexGetIdx(ix, iy, w, h)] == borderCol) {
                            Vector2Int tmpSize = TexGetRectSize(ix, iy, w, h, colors);
                            if (++lvl == level) {
                                size = tmpSize - Vector2Int.one * 2;
                                return tex.GetPixels(ix + 1, h - iy - size.y - 1, size.x, size.y).Lis();
                            }
                            if (isFirst) {
                                isFirst = false;
                                y += tmpSize.y;
                            }
                            ix += tmpSize.x;
                        }
                    }
                    break;
                }
            }
        }
        size = Vector2Int.zero;
        return null;
    }
    ///<summary>зурагнаас үеийн хүрээний хэмжэээг авна</summary>
    public static Vector2Int TexGetRectSize(int x, int y, int w, int h, List<Color> colors) {
        Color col = colors[TexGetIdx(x, y, w, h)];
        Vector2Int res = Vector2Int.zero;
        for (int ix = x; ix < w; ix++)
            if (colors[TexGetIdx(ix, y, w, h)] == col) res.x++;
            else break;
        for (int iy = y; iy < h; iy++)
            if (colors[TexGetIdx(x, iy, w, h)] == col) res.y++;
            else break;
        return res;
    }
    ///<summary>зурагны координатаар idx-г авах</summary>
    public static int TexGetIdx(int x, int y, int w, int h) { return (h - y - 1) * w + x; }



    // █   █  ▀█▀  █▀▀▀▄ █▀▀▀▄ ▄▀▀▀▄ ▀▀█▀▀  ▀█▀  ▄▀▀▀▄ █   █ 
    // █   █   █   █▄▄▄▀ █▄▄▄▀ █▄▄▄█   █     █   █   █ █▀▄ █ 
    //  █ █    █   █   █ █ ▀▄  █   █   █     █   █   █ █  ▀█ 
    //   ▀    ▀▀▀  ▀▀▀▀  ▀   ▀ ▀   ▀   ▀    ▀▀▀   ▀▀▀  ▀   ▀

    ///<summary>vibrate дугаргана</summary>
    public static void Vibrate(long ms) {
#if UNITY_ANDROID && !UNITY_EDITOR
        Vibration.Vibrate (ms);
#endif
    }
    ///<summary>vibrate дугаргана</summary>
    public static void Vibrate(Vib v) {
        if (GameController.IsVibration) {
#if UNITY_EDITOR
            Debug.Log("Vibrate: " + v);
#elif UNITY_ANDROID && !UNITY_EDITOR
            switch (v) {
                case Vib.Success:
                    Vibration.Vibrate (new long[] { 20, 20 }, -1);
                    break;
                case Vib.Warning:
                    Vibration.Vibrate (new long[] { 10, 10 }, -1);
                    break;
                case Vib.Error:
                    Vibration.Vibrate (new long[] { 20, 20, 20 }, -1);
                    break;
                case Vib.Light:
                    Vibration.Vibrate (10);
                    break;
                case Vib.Medium:
                    Vibration.Vibrate (15);
                    break;
                case Vib.Heavy:
                    Vibration.Vibrate (20);
                    break;
            }
#elif UNITY_IPHONE && !UNITY_EDITOR
            switch (v) {
                case Vib.Success:
                    TapticPlugin.TapticManager.Notification (TapticPlugin.Notification.Success);
                    break;
                case Vib.Warning:
                    TapticPlugin.TapticManager.Notification (TapticPlugin.Notification.Warning);
                    break;
                case Vib.Error:
                    TapticPlugin.TapticManager.Notification (TapticPlugin.Notification.Error);
                    break;
                case Vib.Light:
                    TapticPlugin.TapticManager.Impact (TapticPlugin.Impact.Light);
                    break;
                case Vib.Medium:
                    TapticPlugin.TapticManager.Impact (TapticPlugin.Impact.Medium);
                    break;
                case Vib.Heavy:
                    TapticPlugin.TapticManager.Impact (TapticPlugin.Impact.Heavy);
                    break;
            }
#endif
        }
    }
}