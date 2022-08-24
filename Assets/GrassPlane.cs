using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlane : MonoBehaviour
{
    public int id;
    public float hardness;
    bool cutDown;
    public Camera orthoCamera;
    public bool finished = false;
    public int coinSpawnNum = 10;
    RenderTexture renderTexture;
    float lastTime = 0;
    int sqrSize = 256;


    Camera renderCamera;
    // Start is called before the first frame update
    void Start()
    {
        finished = GameController.Level - 1 > id;
        if (finished)
        {
            GetComponent<Renderer>().material.SetTexture("_GrassMap", Texture2D.blackTexture);
            return;
        }
        renderTexture = new RenderTexture(sqrSize, sqrSize, 16);
        // print(id);
        // string path = Application.persistentDataPath + "/" + id + ".png";
        // if (System.IO.File.Exists(path))
        // {
        //     var bites = System.IO.File.ReadAllBytes(path);
        //     var savedTex = new Texture2D(sqrSize, sqrSize);
        //     if (bites != null)
        //         if (savedTex.LoadImage(bites))
        //         {
        //             Graphics.Blit(savedTex, renderTexture);
        //         }
        // }
        renderCamera = orthoCamera;
        renderCamera.targetTexture = renderTexture;
        transform.localPosition = new Vector3(-transform.parent.position.x / 2f, transform.localPosition.y, transform.localPosition.z);

        GetComponent<Renderer>().material.SetTexture("_GrassMap", renderTexture);
        orthoCamera.orthographicSize = Mathf.Max(GetComponent<MeshRenderer>().bounds.size.x, GetComponent<MeshRenderer>().bounds.size.y) / 2;
        var coin = Resources.Load<GameObject>("Coin");
        for (int i = 0; i < coinSpawnNum; i++)
        {

            Instantiate(coin, transform.parent.TransformPoint(new Vector3(Rnd.Rng(-5f, 5f), Rnd.Rng(-5f, 5f), -0.1f)), Q.O);
        }


    }

    private void FixedUpdate()
    {
        if (GameController.Level - 1 != id) return;
        if (Time.time > lastTime)
        {
            // print("saved texture");
            lastTime = Time.time + 1;
            // SaveTexture(renderTexture);
            int blackCount = 0;
            Texture2D texToCheck = toTexture2D(renderTexture);
            for (int i = 0; i < texToCheck.height; i++)
            {
                for (int j = 0; j < texToCheck.width; j++)
                {
                    if (texToCheck.GetPixel(i, j).grayscale < 0.2f)
                        blackCount++;
                }
            }

            if ((float)blackCount / (texToCheck.width * texToCheck.height) > 0.98)
            {
                A.LevelCompleted();
            }
        }
    }
    public void SaveTexture(RenderTexture rt)
    {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + id + ".png", bytes);
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;
        return tex;
    }


    public void SetData(GrassPlaneData planeData)
    {
        GetComponent<Renderer>().material.SetColor("_TipColor", planeData.color);
        this.hardness = planeData.hardness;
    }


}


public struct GrassPlaneData
{
    public Color color;
    public float hardness;

}