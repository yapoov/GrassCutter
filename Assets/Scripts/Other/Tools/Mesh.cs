using System.Collections.Generic;
using UnityEngine;

public class Msh {

    public static int[] UvUArr = new int[] { 0, 0, 1, 1, 0, 1 };

    public static int[] UvVArr = new int[] { 0, 1, 0, 0, 1, 1 };

    ///<summary>mesh null байх үед шинийг үүсгэж материалд нь стандарт материал өгнө</summary>
    public static void Init(ref Mesh mesh, GameObject go) {
        if (!mesh) {
            mesh = new Mesh();
            go.Gc<MeshFilter>().sharedMesh = mesh;
            if (!go.Gc<MeshRenderer>().material)
                go.Gc<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        }
    }

    ///<summary>mesh цэг, гурвалжин</summary>
    public static void VsTs(ref Mesh mesh, Vector3[] vs, int[] ts) {
        mesh.Clear();
        mesh.vertices = vs;
        mesh.triangles = ts;
    }

    ///<summary>mesh цэг, гурвалжин</summary>
    public static void VsTsRn(ref Mesh mesh, Vector3[] vs, int[] ts) {
        VsTs(ref mesh, vs, ts);
        mesh.RecalculateNormals();
    }

    ///<summary>mesh цэг, гурвалжин</summary>
    public static void VsTsRn2(ref Mesh mesh, Vector3[] vs, int[] ts) {
        Vector3[] vs2 = new Vector3[ts.Length];
        int[] ts2 = new int[ts.Length];
        for (int i = 0; i < ts.Length; i++) {
            vs2[i] = vs[ts[i]];
            ts2[i] = i;
        }
        VsTsRn(ref mesh, vs2, ts2);
    }

    ///<summary>mesh цэг, гурвалжин, uv</summary>
    public static void VsTsUv(ref Mesh mesh, Vector3[] vs, int[] ts, Vector2[] uv) {
        VsTs(ref mesh, vs, ts);
        mesh.uv = uv;
    }

    ///<summary>mesh цэг, гурвалжин, uv</summary>
    public static void VsTsUvRn(ref Mesh mesh, Vector3[] vs, int[] ts, Vector2[] uv) {
        VsTsUv(ref mesh, vs, ts, uv);
        mesh.RecalculateNormals();
    }

    ///<summary>mesh цэг, гурвалжин, uv</summary>
    public static void VsTsUvRn2(ref Mesh mesh, Vector3[] vs, int[] ts, Vector2[] uv) {
        Vector3[] vs2 = new Vector3[ts.Length];
        int[] ts2 = new int[ts.Length];
        Vector2[] uv2 = new Vector2[ts.Length];
        for (int i = 0; i < ts.Length; i++) {
            vs2[i] = vs[ts[i]];
            ts2[i] = i;
            uv2[i] = uv[ts[i]];
        }
        VsTsUvRn(ref mesh, vs2, ts2, uv2);
    }

    ///<summary>mesh цэг, гурвалжин, нормал</summary>
    public static void VsTsNs(ref Mesh mesh, Vector3[] vs, int[] ts, Vector3[] ns) {
        VsTs(ref mesh, vs, ts);
        mesh.normals = ns;
    }

    ///<summary>mesh цэг, гурвалжин, нормал, uv</summary>
    public static void VsTsNsUv(ref Mesh mesh, Vector3[] vs, int[] ts, Vector3[] ns, Vector2[] uv) {
        VsTsUv(ref mesh, vs, ts, uv);
        mesh.normals = ns;
    }

    // mesh-г tf-р хувиргана
    public static void UpdTf(ref Mesh mesh, Tf tf) {
        Vector3[] vs = mesh.vertices.Cln();
        Vector3[] ns = mesh.normals.Cln();
        for (int i = 0; i < vs.Length; i++) {
            vs[i] = Tf.Rot(tf.r, V3.Mul(vs[i], tf.s)) + tf.t;
            ns[i] = Tf.Rot(tf.r, ns[i]).normalized;
        }
        mesh.vertices = vs;
        mesh.normals = ns;
    }

    ///<summary>mesh-р сектор үүсгэнэ</summary>
    public static void SectorSegment(ref Mesh mesh, float r, float h, float dy, float staAng, float ang, int n, bool isSegment) {
        int m = n + (isSegment ? 1 : 2);
        Vector3[] vs = new Vector3[m * 2];
        for (int i = 0; i <= n; i++) {
            float a = staAng - ang / 2 + i * ang / n, x = M.Cos(a) * r, z = M.Sin(a) * r;
            vs[i * 2] = new Vector3(x, -h / 2 + dy, z);
            vs[i * 2 + 1] = new Vector3(x, h / 2 + dy, z);
        }
        if (!isSegment) {
            vs[(n + 1) * 2] = new Vector3(0, -h / 2 + dy, 0);
            vs[(n + 1) * 2 + 1] = new Vector3(0, h / 2 + dy, 0);
        }
        int[] ts = new int[(m + n) * 6];
        for (int i = 0, i1; i < m; i++) {
            i1 = (i + 1) % m;
            ts[i * 6] = i * 2;
            ts[i * 6 + 1] = i * 2 + 1;
            ts[i * 6 + 2] = i1 * 2;
            ts[i * 6 + 3] = i1 * 2;
            ts[i * 6 + 4] = i * 2 + 1;
            ts[i * 6 + 5] = i1 * 2 + 1;
        }
        int tri = isSegment ? 0 : (n + 1) * 2;
        for (int i = 0, j; i < n; i++) {
            j = (m + i) * 6;
            ts[j] = tri;
            ts[j + 1] = i * 2;
            ts[j + 2] = (i + 1) * 2;
            ts[j + 3] = ts[j] + 1;
            ts[j + 4] = ts[j + 2] + 1;
            ts[j + 5] = ts[j + 1] + 1;
        }
        VsTsRn2(ref mesh, vs, ts);
    }

    ///<summary>mesh-р эргэлтийн бие үүсгэнэ</summary>
    public static void RotModel(ref Mesh mesh, bool isFill, bool isDisUv, int n, List<Vector2> points, Tf tf) {
        List<Vector2> lis = new List<Vector2>(points);
        if (isFill) {
            lis.Insert(0, V2.X(points[0], 0));
            lis.Add(V2.X(points[points.Count - 1], 0));
        }
        // vertices
        Vector3[] vs = new Vector3[n * lis.Count];
        float dAng = 360f / n;
        for (int i = 0; i < lis.Count; i++)
            for (int j = 0; j < n; j++)
                vs[i * n + j] = Tf.Rot(tf.r, V3.Mul(new Vector3(lis[i].x * M.Cos(j * dAng), lis[i].y, lis[i].x * M.Sin(j * dAng)), tf.s)) + tf.t;
        // triangles
        int[] ts = new int[n * 6 * (lis.Count - 1)];
        for (int i = 0; i < lis.Count - 1; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < 6; k++)
                    ts[n * 6 * i + j * 6 + k] = n * i + (j + UvUArr[k]) % n + UvVArr[k] * n;
        // uv
        Vector3[] v = new Vector3[ts.Length];
        int[] t = new int[ts.Length];
        Vector2[] uv = new Vector2[ts.Length];
        float du = 1f / n, dv = 1f / (lis.Count - 1);
        if (isDisUv) {
            float dis = 0, tmpDis, curDis = 0;
            List<float> disLis = new List<float>();
            for (int i = 1; i < lis.Count; i++) {
                tmpDis = Vector3.Distance(lis[i - 1], lis[i]);
                disLis.Add(tmpDis);
                dis += tmpDis;
            }
            for (int i = 0; i < ts.Length; i++) {
                v[i] = vs[ts[i]];
                t[i] = i;
                uv[i] = new Vector2(
                    (i / 6 % n + UvUArr[i % 6]) * du,
                    (curDis + UvVArr[i % 6] * disLis[i / 6 / n]) / dis
                );
                if ((i + 1) % (6 * n) == 0)
                    curDis += disLis[i / 6 / n];
            }
        } else {
            for (int i = 0; i < ts.Length; i++) {
                v[i] = vs[ts[i]];
                t[i] = i;
                uv[i] = new Vector2(
                    (i / 6 % n + UvUArr[i % 6]) * du,
                    (i / 6 / n + UvVArr[i % 6]) * dv
                );
            }
        }
        // mesh
        VsTsUvRn(ref mesh, vs, ts, uv);
    }

    ///<summary>mesh-р зам үүсгэнэ</summary>
    public static void Road(ref Mesh mesh, bool isLoop, List<Vector3> points, Vector3 dPos, Vector2 size) {
        if (points.Count >= 2 && mesh) {
            int n = 4;
            List<Vector3> lis = new List<Vector3>(points);
            if (isLoop)
                lis.Add(lis[0]);
            // vertices
            Vector3[] vs = new Vector3[lis.Count * n];
            Vector3 d = Vector3.zero, dir;
            for (int i = 0; i < lis.Count; i++) {
                if (isLoop && (i == 0 || i == lis.Count - 1)) {
                    dir = Vector3.Lerp(lis[1] - lis[0], lis[lis.Count - 1] - lis[lis.Count - 2], 0.5f);
                    d = new Vector3(dir.z, 0, -dir.x);
                } else if (i < lis.Count - 1) {
                    dir = lis[i + 1] - lis[i];
                    d += new Vector3(dir.z, 0, -dir.x);
                } else {
                    dir = lis[i - 1] - lis[i];
                    d += new Vector3(-dir.z, 0, dir.x);
                }
                d.Normalize();
                vs[i * n + 0] = lis[i] - d * size.x / 2 - V3.u * size.y / 2;
                vs[i * n + 1] = lis[i] - d * size.x / 2 + V3.u * size.y / 2;
                vs[i * n + 2] = lis[i] + d * size.x / 2 + V3.u * size.y / 2;
                vs[i * n + 3] = lis[i] + d * size.x / 2 - V3.u * size.y / 2;
            }
            // triangles
            int[] ts = new int[n * 6 * (lis.Count - 1) + 12];
            for (int i = 0; i < lis.Count - 1; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < 6; k++)
                        ts[n * 6 * i + j * 6 + k] = n * i + (j + UvUArr[k]) % n + UvVArr[k] * n;
            int[] fbArr = new int[] { 0, 1, 3, 3, 1, 2 };
            for (int i = 0; i < 12; i++)
                ts[n * 6 * (lis.Count - 1) + i] = i < 6 ? fbArr[i] : (vs.Length - 1 - fbArr[i - 6]);
            // uv
            Vector3[] v = new Vector3[ts.Length];
            int[] t = new int[ts.Length];
            Vector2[] uv = new Vector2[ts.Length];
            float du = 1f / n, dv = 1f / (lis.Count - 1);
            for (int i = 0; i < ts.Length; i++) {
                v[i] = vs[ts[i]];
                t[i] = i;
                uv[i] = new Vector2(
                    (i % 24 / 6 + UvUArr[i % 24 % 6]) * du,
                    (i / 24 + UvVArr[i % 24 % 6]) * dv
                );
            }
            // mesh
            VsTsUvRn(ref mesh, vs, ts, uv);
        }
    }


    public static void Box(ref Mesh mesh, Vector3 size) {
        float px = size.x / 2, nx = -px, py = size.y / 2, ny = -py, pz = size.z / 2, nz = -pz;
        Vector3[] vs = new Vector3[24] {
            new Vector3(nx, ny, pz), new Vector3(nx, py, pz), new Vector3(nx, py, nz), new Vector3(nx, ny, nz),
            new Vector3(px, ny, nz), new Vector3(px, py, nz), new Vector3(px, py, pz), new Vector3(px, ny, pz),
            new Vector3(nx, ny, pz), new Vector3(nx, ny, nz), new Vector3(px, ny, nz), new Vector3(px, ny, pz),
            new Vector3(nx, py, nz), new Vector3(nx, py, pz), new Vector3(px, py, pz), new Vector3(px, py, nz),
            new Vector3(nx, ny, nz), new Vector3(nx, py, nz), new Vector3(px, py, nz), new Vector3(px, ny, nz),
            new Vector3(px, ny, pz), new Vector3(px, py, pz), new Vector3(nx, py, pz), new Vector3(nx, ny, pz),
        };
        int[] ts = new int[36] {
            0,  1,  3,  3,  1,  2,   4,  5,  7,  7,  5,  6,
            8,  9,  11, 11, 9,  10,  12, 13, 15, 15, 13, 14,
            16, 17, 19, 19, 17, 18,  20, 21, 23, 23, 21, 22,
        };
        Vector3[] ns = new Vector3[24] {
            V3.l, V3.l, V3.l, V3.l,  V3.r, V3.r, V3.r, V3.r,
            V3.d, V3.d, V3.d, V3.d,  V3.u, V3.u, V3.u, V3.u,
            V3.b, V3.b, V3.b, V3.b,  V3.f, V3.f, V3.f, V3.f,
        };
        float u0 = 0, u1 = 0.25f, u2 = 0.5f, u3 = 0.75f, u4 = 1, v0 = 0, v1 = 1f / 3f, v2 = 2f / 3f, v3 = 1;
        Vector2[] uv = new Vector2[] {
            new Vector2(u0, v1), new Vector2(u0, v2), new Vector2(u1, v2), new Vector2(u1, v1),
            new Vector2(u2, v1), new Vector2(u2, v2), new Vector2(u3, v2), new Vector2(u3, v1),
            new Vector2(u1, v0), new Vector2(u1, v1), new Vector2(u2, v1), new Vector2(u2, v0),
            new Vector2(u1, v2), new Vector2(u1, v3), new Vector2(u2, v3), new Vector2(u2, v2),
            new Vector2(u1, v1), new Vector2(u1, v2), new Vector2(u2, v2), new Vector2(u2, v1),
            new Vector2(u3, v1), new Vector2(u3, v2), new Vector2(u4, v2), new Vector2(u4, v1),
        };
        VsTsNsUv(ref mesh, vs, ts, ns, uv);
    }

    public static void Cone(ref Mesh mesh, int vertices, float radius1, float radius2, float depth, bool isVertexNormal) {
        Vector3[] vs = new Vector3[vertices * 4 + 2];
        Vector2[] uv = new Vector2[vs.Length];
        float dAng = 360f / vertices, h2 = depth / 2;
        Vector2 uvT = new Vector2(0.25f, 0.75f), uvB = new Vector2(0.75f, 0.75f);
        for (int i = 0; i < vertices; i++) {
            float a = i * dAng, x = M.Cos(a), z = M.Sin(a);
            vs[i * 4 + 2] = vs[i * 4] = new Vector3(x * radius1, -h2, z * radius1);
            vs[i * 4 + 3] = vs[i * 4 + 1] = new Vector3(x * radius2, h2, z * radius2);
            uv[i * 4] = new Vector2(i.F() / vertices, 0);
            uv[i * 4 + 1] = new Vector2(i.F() / vertices, 0.5f);
            uv[i * 4 + 2] = uvB + new Vector2(x, -z) / 4;
            uv[i * 4 + 3] = uvT + new Vector2(x, z) / 4;
            if (i == 0) {
                vs[vertices * 4] = vs[i * 4];
                vs[vertices * 4 + 1] = vs[i * 4 + 1];
                uv[vertices * 4] = new Vector2(1, 0);
                uv[vertices * 4 + 1] = new Vector2(1, 0.5f);
            }
        }
        int[] ts = new int[vertices * 12 - 6];
        for (int i = 0; i < vertices; i++)
            for (int j = 0; j < 6; j++)
                ts[i * 6 + j] = (i + UvUArr[j]) * 4 + UvVArr[j];
        for (int i = 0, j; i < vertices - 2; i++) {
            j = (vertices + i) * 6;
            ts[j + 3] = (ts[j] = 2) + 1;
            ts[j + 5] = (ts[j + 1] = (i + 1) * 4 + 2) + 1;
            ts[j + 4] = (ts[j + 2] = (i + 2) * 4 + 2) + 1;
        }
        if (isVertexNormal)
            VsTsUvRn(ref mesh, vs, ts, uv);
        else
            VsTsUvRn2(ref mesh, vs, ts, uv);
    }

    public static void UvSphere(ref Mesh mesh, int segments, int rings, float radius, bool isVertexNormal) {
        int n = (segments + 1) * (rings - 1);
        Vector3[] vs = new Vector3[n + segments * 2];
        Vector2[] uv = new Vector2[vs.Length];
        float drAng = 180f / rings, dsAng = 360f / segments, dr = 1f / rings, ds = 1f / segments;
        for (int i = 0, k; i < rings - 1; i++)
            for (int j = 0; j < segments + 1; j++) {
                k = (segments + 1) * i + j;
                vs[k] = new Vector3(
                    M.Cos(-90 - (i + 1) * drAng) * M.Cos(j * dsAng) * radius,
                    M.Sin(-90 - (i + 1) * drAng) * radius,
                    M.Cos(-90 - (i + 1) * drAng) * M.Sin(j * dsAng) * radius
                );
                uv[k] = new Vector2(j * ds, (i + 1) * dr);
            }
        for (int i = 0, k; i < segments; i++) {
            k = n + i * 2;
            vs[k] = V3.d * radius;
            vs[k + 1] = V3.u * radius;
            uv[k] = new Vector2((i + 0.5f) * ds, 0);
            uv[k + 1] = new Vector2((i + 0.5f) * ds, 1);
        }
        int m = segments * (rings - 2) * 6;
        int[] ts = new int[m + segments * 6];
        for (int i = 0; i < rings - 2; i++)
            for (int j = 0; j < segments; j++)
                for (int k = 0; k < 6; k++)
                    ts[(segments * i + j) * 6 + k] = (segments + 1) * (i + UvVArr[k]) + j + UvUArr[k];
        for (int i = 0; i < segments; i++) {
            ts[m + i * 6] = n + i * 2;
            ts[m + i * 6 + 1] = i;
            ts[m + i * 6 + 2] = i + 1;
            ts[m + i * 6 + 3] = n + i * 2 + 1;
            ts[m + i * 6 + 4] = (segments + 1) * (rings - 2) + i + 1;
            ts[m + i * 6 + 5] = (segments + 1) * (rings - 2) + i;
        }
        if (isVertexNormal) {
            List<Vector3> ns = new List<Vector3>();
            vs.Lis().ForEach(x => ns.Add(x.normalized));
            VsTsNsUv(ref mesh, vs, ts, ns.Arr(), uv);
        } else
            VsTsUvRn2(ref mesh, vs, ts, uv);
    }

    public static void IcoSphere(ref Mesh mesh, int subdivisions, float radius) {
        List<Vector3> vs = new List<Vector3>();

        vs.Add(new Vector3(-1, M.GoldenRatio, 0).normalized * radius);
        vs.Add(new Vector3(1, M.GoldenRatio, 0).normalized * radius);
        vs.Add(new Vector3(-1, -M.GoldenRatio, 0).normalized * radius);
        vs.Add(new Vector3(1, -M.GoldenRatio, 0).normalized * radius);

        vs.Add(new Vector3(0, -1, M.GoldenRatio).normalized * radius);
        vs.Add(new Vector3(0, 1, M.GoldenRatio).normalized * radius);
        vs.Add(new Vector3(0, -1, -M.GoldenRatio).normalized * radius);
        vs.Add(new Vector3(0, 1, -M.GoldenRatio).normalized * radius);

        vs.Add(new Vector3(M.GoldenRatio, 0, -1).normalized * radius);
        vs.Add(new Vector3(M.GoldenRatio, 0, 1).normalized * radius);
        vs.Add(new Vector3(-M.GoldenRatio, 0, -1).normalized * radius);
        vs.Add(new Vector3(-M.GoldenRatio, 0, 1).normalized * radius);

        // create 20 triangles of the icosahedron
        List<Vector3Int> faces = new List<Vector3Int>();

        // 5 faces around point 0
        faces.Add(new Vector3Int(0, 11, 5));
        faces.Add(new Vector3Int(0, 5, 1));
        faces.Add(new Vector3Int(0, 1, 7));
        faces.Add(new Vector3Int(0, 7, 10));
        faces.Add(new Vector3Int(0, 10, 11));

        // 5 adjacent faces 
        faces.Add(new Vector3Int(1, 5, 9));
        faces.Add(new Vector3Int(5, 11, 4));
        faces.Add(new Vector3Int(11, 10, 2));
        faces.Add(new Vector3Int(10, 7, 6));
        faces.Add(new Vector3Int(7, 1, 8));

        // 5 faces around point 3
        faces.Add(new Vector3Int(3, 9, 4));
        faces.Add(new Vector3Int(3, 4, 2));
        faces.Add(new Vector3Int(3, 2, 6));
        faces.Add(new Vector3Int(3, 6, 8));
        faces.Add(new Vector3Int(3, 8, 9));

        // 5 adjacent faces 
        faces.Add(new Vector3Int(4, 9, 5));
        faces.Add(new Vector3Int(2, 4, 11));
        faces.Add(new Vector3Int(6, 2, 10));
        faces.Add(new Vector3Int(8, 6, 7));
        faces.Add(new Vector3Int(9, 8, 1));
        Dictionary<long, int> midPntIdxDic = new Dictionary<long, int>();
        for (int i = 0; i < subdivisions - 1; i++) {
            List<Vector3Int> faces2 = new List<Vector3Int>();
            foreach (var t in faces) {
                int a = GetMidPntIdx(t.x, t.y, ref vs, ref midPntIdxDic, radius);
                int b = GetMidPntIdx(t.y, t.z, ref vs, ref midPntIdxDic, radius);
                int c = GetMidPntIdx(t.z, t.x, ref vs, ref midPntIdxDic, radius);

                faces2.Add(new Vector3Int(t.x, a, c));
                faces2.Add(new Vector3Int(t.y, b, a));
                faces2.Add(new Vector3Int(t.z, c, b));
                faces2.Add(new Vector3Int(a, b, c));
            }
            faces = faces2;
        }
        List<int> ts = new List<int>();
        for (int i = 0; i < faces.Count; i++) {
            ts.Add(faces[i].x);
            ts.Add(faces[i].y);
            ts.Add(faces[i].z);
        }
        Vector3[] ns = new Vector3[vs.Count];
        for (int i = 0; i < ns.Length; i++)
            ns[i] = vs[i].normalized;
        VsTsNs(ref mesh, vs.Arr(), ts.Arr(), ns);
    }

    private static int GetMidPntIdx(int p1, int p2, ref List<Vector3> vs, ref Dictionary<long, int> dic, float r) {
        long key = ((long)(p1 < p2 ? p1 : p2) << 32) + (p1 < p2 ? p2 : p1);
        int ret;
        if (dic.TryGetValue(key, out ret))
            return ret;
        vs.Add(((vs[p1] + vs[p2]) / 2).normalized * r);
        dic.Add(key, vs.Count - 1);
        return vs.Count - 1;
    }

    public static void Torus(ref Mesh mesh, int majorSegments, int minorSegments, float majorRadius, float minorRadius, bool isVertexNormal) {
        int m1 = minorSegments + 1;
        Vector3[] vs = new Vector3[(majorSegments + 1) * m1];
        Vector3[] ns = new Vector3[vs.Length];
        Vector2[] uv = new Vector2[vs.Length];
        float dnAng = 360f / majorSegments, dmAng = 360f / minorSegments;
        for (int i = 0, k; i <= majorSegments; i++) {
            Vector3 p = new Vector3(M.Cos(i * dnAng) * majorRadius, 0, M.Sin(i * dnAng) * majorRadius);
            for (int j = 0; j <= minorSegments; j++) {
                k = m1 * i + j;
                vs[k] = p + Q.AngAxis(-i * dnAng, Vector3.up) * new Vector3(M.Cos(j * dmAng) * minorRadius, M.Sin(j * dmAng) * minorRadius);
                ns[k] = vs[k] - p;
                uv[k] = new Vector2(i.F() / majorSegments, j.F() / minorSegments);
            }
        }
        int[] ts = new int[majorSegments * minorSegments * 6];
        for (int i = 0, i1 = 1, k; i < majorSegments; i++, i1++) {
            for (int j = 0, j1 = 1; j < minorSegments; j++, j1++) {
                k = (minorSegments * i + j) * 6;
                ts[k] = m1 * i + j;
                ts[k + 1] = m1 * i + j1;
                ts[k + 2] = m1 * i1 + j;
                ts[k + 3] = m1 * i1 + j;
                ts[k + 4] = m1 * i + j1;
                ts[k + 5] = m1 * i1 + j1;
            }
        }
        if (isVertexNormal)
            VsTsNsUv(ref mesh, vs, ts, ns, uv);
        else
            VsTsUvRn2(ref mesh, vs, ts, uv);
    }
}