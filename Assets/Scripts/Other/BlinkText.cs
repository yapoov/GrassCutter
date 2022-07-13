using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MB {
    public float duration = 1;
    Text text;
    bool isAlphaDown = true;
    float t;
    void Start () {
        t = duration;
        text = go.Gc<Text> ();
    }
    void Update () {
        t += isAlphaDown ? -DT : DT;
        isAlphaDown = t < 0 || t > duration ? !isAlphaDown : isAlphaDown;
        text.color = Col.A (text.color, t / duration);
    }
}