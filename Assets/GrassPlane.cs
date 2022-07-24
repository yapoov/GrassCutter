using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlane : MonoBehaviour
{
    private float hardness;
    bool cutDown;
    public Camera orthoCamera;
    RenderTexture texture;
    // Start is called before the first frame update
    void Start()
    {

        texture = new RenderTexture(256, 256, 1);
        GetComponentInChildren<Camera>().targetTexture = texture;
        GetComponent<Renderer>().material.SetTexture("_GrassMap", texture);

        //Set Camera pos and size;
        orthoCamera.orthographicSize = Mathf.Max(GetComponent<MeshRenderer>().bounds.size.x, GetComponent<MeshRenderer>().bounds.size.y) / 2;
    }


    public void SetData(GrassPlaneData planeData)
    {
        GetComponent<Renderer>().material.SetColor("_TipColor", planeData.color);
        this.hardness = planeData.hardness;
    }

    void CheckIfBlack(RenderTexture texture)
    {

        CustomRenderTexture customTexture = new CustomRenderTexture(256, 256, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                // texture.co


            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}


public struct GrassPlaneData
{
    public Color color;
    public float hardness;

}