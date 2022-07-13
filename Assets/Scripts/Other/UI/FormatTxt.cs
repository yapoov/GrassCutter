using UnityEngine;
using UnityEngine.UI;

public class FormatTxt : MB {

    public Text txt;

    public string format = "(data)";

    public void Data(float data) {
        if (txt)
            txt.text = A.Format(format, "(data)", data.ToString());
    }
}