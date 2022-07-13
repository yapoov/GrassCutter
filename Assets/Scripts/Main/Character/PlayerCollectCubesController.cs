using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerCollectCubesController : MB {
    public float speed = 10, posScl = 0.02f, disTh = 10;
    public bool isPlaying = false;
    float dis;
    Vector3 staPos, pos;
    void Start () {
        rb.NoG();
        rb.Constraints(false, true, false, true, true, true);
    }
    void Update () {
        if (IsPlaying || isPlaying) {
            if (IsDown) {
                mp = MP;
                staPos = transform.position;
            }
            if (IsClick)
                pos = staPos + new Vector3 (MP.x - mp.x, 0, MP.y - mp.y) * posScl;
            dis = V3.Dis (transform.position, pos);
            if (dis < 0.1f) {
                transform.position = pos;
                rb.V0();
            } else {
                transform.LookAt (pos);
                rb.velocity = transform.forward * M.Clamp01 (dis / disTh) * speed;
            }
        } else
            rb.V0();
    }
    private void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere (pos, 0.5f);
    }
}