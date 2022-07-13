using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerHoleIoController : MB {
    public float speed = 10, radius = 100;
    public bool isPlaying = false;
    float dis;
    void Start () {
        rb.NoG();
        rb.Constraints(false, true, false, true, true, true);
    }
    void Update () {
        if (IsPlaying || isPlaying) {
            if (IsDown)
                mp = MP;
            if (IsClick) {
                dis = V3.Dis (MP, mp);
                if (dis > radius)
                    mp = V3.Move (MP, mp, radius);
                transform.rotation = Q.Euler (0, Ang.LookForward (mp, MP), 0);
                rb.velocity = transform.forward * M.Clamp01 (dis / radius) * speed;
            }
            if (IsUp)
                rb.V0();
        } else
            rb.V0();
    }
}