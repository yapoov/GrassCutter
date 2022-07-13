using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotRandomMoveController : MB
{
    public float velocity = 10, rotSpeed = 5, minTime = 1.5f, maxTime = 3;
    float curAngle = 0, angle = 0, t, dt = 0;
    Vector3 vel;
    void Start()
    {
        rb.NoG();
        rb.Constraints(false, true, false, true, true, true);
    }
    void Update()
    {
        if (IsPlaying)
        {
            dt += DT;
            if (dt > t)
            {
                dt = 0;
                t = Rnd.Rng(minTime, maxTime);
                angle = Rnd.Ang;
            }
            curAngle = M.Lerp(curAngle, angle, DT * rotSpeed);
            transform.rotation = Q.Euler(0, curAngle, 0);
            rb.velocity = transform.forward * velocity;
        }
        else
            rb.V0();
    }
}
