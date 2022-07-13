using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerBlocksBusterController : MB {
    public float speed = 10, posScl = 0.02f;
    public bool isPlaying = false;
    float dis;
    Vector3 pos;
    void Start () {
        rb.NoG();
        rb.Constraints(false, true, false, true, true, true);
    }
    void Update () {
        if (IsPlaying || isPlaying) {
            if (IsDown)
                mp = MP;
            if (IsClick) {
                pos = transform.position + new Vector3 (MP.x - mp.x, 0, MP.y - mp.y) * posScl;
                rb.MovePosition (pos);
                mp = MP;
            }
            if (IsUp)
                rb.V0();
        } else
            rb.V0();
    }
    private void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere (pos, 0.5f);
    }
}