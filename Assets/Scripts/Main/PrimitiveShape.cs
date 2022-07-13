using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrimitiveShapeType { Box, Cone, Cylinder, UvSphere, IcoSphere, Torus }

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PrimitiveShape : MB {
    public PrimitiveShapeType type;
    public bool isVertexNormal = true;
    public Tf t;

    [Header("Box")]
    public Vector3 boxSize = V3.I;

    [Header("Cylinder")]
    [Range(3, 100)]
    public int cylinderVertices = 32;
    public float cylinderRadius = 0.5f;
    public float cylinderDepth = 1;

    [Header("Cone")]
    [Range(3, 100)]
    public int coneVertices = 32;
    public float coneRadius1 = 0.5f;
    public float coneRadius2 = 0;
    public float coneDepth = 1;

    [Header("UV Sphere")]
    [Range(3, 100)]
    public int uvSphereSegments = 32;
    [Range(2, 100)]
    public int uvSphereRings = 16;
    public float uvSphereRadius = 0.5f;

    [Header("Ico Sphere")]
    [Range(1, 5)]
    public int icoSphereSubdivisions = 2;
    public float icoSphereRadius = 0.5f;

    [Header("Torus")]
    [Range(3, 100)]
    public int torusMajorSegments = 48;
    [Range(3, 100)]
    public int torusMinorSegments = 12;
    public float torusMajorRadius = 0.5f;
    public float torusMinorRadius = 0.125f;

    [HideInInspector]
    public Mesh mesh;

    private void Start() {
    }

    private void Update() {
        Msh.Init(ref mesh, go);
        switch (type) {
            case PrimitiveShapeType.Box:
                Msh.Box(ref mesh, boxSize);
                break;
            case PrimitiveShapeType.Cone:
                Msh.Cone(ref mesh, coneVertices, coneRadius1, coneRadius2, coneDepth, isVertexNormal);
                break;
            case PrimitiveShapeType.Cylinder:
                Msh.Cone(ref mesh, cylinderVertices, cylinderRadius, cylinderRadius, cylinderDepth, isVertexNormal);
                break;
            case PrimitiveShapeType.UvSphere:
                Msh.UvSphere(ref mesh, uvSphereSegments, uvSphereRings, uvSphereRadius, isVertexNormal);
                break;
            case PrimitiveShapeType.IcoSphere:
                Msh.IcoSphere(ref mesh, icoSphereSubdivisions, icoSphereRadius);
                break;
            case PrimitiveShapeType.Torus:
                Msh.Torus(ref mesh, torusMajorSegments, torusMinorSegments, torusMajorRadius, torusMinorRadius, isVertexNormal);
                break;
        }
        Msh.UpdTf(ref mesh, t);
    }
}