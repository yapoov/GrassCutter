using UnityEngine;
using UnityEngine.UI;

public class HudTime : MB {

    public Text txt;

    public void Data(float data) {
        if (txt)
            txt.text = A.TimeStr(data);
    }
}