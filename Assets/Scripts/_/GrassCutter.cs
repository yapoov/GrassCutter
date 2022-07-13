using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCutter : MonoBehaviour
{
    public Mesh mesh;

    public GrassPainter grassPainter;

    MeshFilter filter;

    [SerializeField]
    List<Vector3> positions = new List<Vector3>();
    [SerializeField]
    List<Color> colors = new List<Color>();
    [SerializeField]
    List<int> indicies = new List<int>();
    [SerializeField]
    List<Vector3> normals = new List<Vector3>();
    [SerializeField]
    List<Vector2> length = new List<Vector2>();

    ComputeShader instantiatedComputeShader;

    int[] indi;
    private void Start()
    {
        mesh = grassPainter.mesh;

        mesh.GetVertices(positions);
        mesh.GetIndices(indicies, 0);
        indi = indicies.ToArray();
        mesh.GetUVs(0, length);
        mesh.GetColors(colors);
        mesh.GetNormals(normals);

        filter = grassPainter.Gc<MeshFilter>();
        instantiatedComputeShader = grassPainter.Gc<GrassComputeScript>().m_InstantiatedComputeShader;
    }

    private void Update()
    {

        bool canRebuild = false;
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 pos = positions[i];
            pos += grassPainter.transform.position;
            if (Vector3.Distance(transform.position, pos) < 2f)
            {
                positions.RemoveAt(i);
                colors.RemoveAt(i);
                normals.RemoveAt(i);
                length.RemoveAt(i);
                indicies.RemoveAt(i);
                canRebuild = true;
            }
        }
        for (int ii = 0; ii < indicies.Count; ii++)
        {
            indicies[ii] = ii;
        }

        if (canRebuild)
        {
            RebuildMesh();

            // instantiatedComputeShader.SetFloat("", 0);
        }



    }

    void RebuildMesh()
    {
        if (mesh == null)
        {
            mesh = new Mesh();
        }
        mesh.Clear();
        mesh.SetVertices(positions);
        indi = indicies.ToArray();
        mesh.SetIndices(indi, MeshTopology.Points, 0);
        mesh.SetUVs(0, length);
        mesh.SetColors(colors);
        mesh.SetNormals(normals);
        mesh.RecalculateBounds();
        filter.sharedMesh = mesh;
    }
}
