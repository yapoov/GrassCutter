using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHand : MB {
    public Transform handTf;
    public List<Vector3> points;
    public int smooth = 10;
    public float spacing = 10;
    public float speed = 1;

    List<Vector3> lis = new List<Vector3>();
    float dis = 0;

    void Start() {
        lis = Crv.CatmullRomSpline(points, smooth, spacing);
    }

    void Update() {
        handTf.position = transform.TfPnt(GetPoint(dis));
        dis += DT * speed;
    }

    Vector3 GetPoint(float dis) {
        int i = Mathf.FloorToInt(dis / spacing) % lis.Count, i2 = (i + 1) % lis.Count;
        return Vector3.Lerp(lis[i], lis[i2], dis % spacing / spacing);
    }
}