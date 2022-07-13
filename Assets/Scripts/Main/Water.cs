using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float SpeedX = 0.015f;
    float SpeedY = 0.01f;
    private float CurrX;
    private float CurrY;
    Renderer _renderer;

    void Start()
    {
        CurrX = GetComponent<Renderer>().material.mainTextureOffset.x;
        CurrY= GetComponent<Renderer>().material.mainTextureOffset.y;
        _renderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        CurrX += Time.deltaTime *  SpeedX;
        CurrY -= Time.deltaTime * SpeedY;
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(CurrX, CurrY));
    }
}
