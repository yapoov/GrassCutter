using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RotModel : MB
{
    public bool isFill = true, isDisUv = true;
    public int n = 8;
    public List<Vector2> points = new List<Vector2>() {
        new Vector2 (-0.5f, -0.5f),
        new Vector2 (-0.5f, 0.5f),
    };
    public Tf t = new Tf(Vector3.zero, Q.O, Vector3.one);
    Mesh mesh;
    public void UpdateMesh()
    {
        Msh.Init(ref mesh, go);
        Msh.RotModel(ref mesh, isFill, isDisUv, n, points, t);
    }
}