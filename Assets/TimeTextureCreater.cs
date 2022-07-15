using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTextureCreater : MonoBehaviour
{
    Camera _camera;
    public Material grassMat;
    private void OnEnable()
    {
        _camera = this.Gc<Camera>();
    }



    void CreateTexture()
    {


    }
}
