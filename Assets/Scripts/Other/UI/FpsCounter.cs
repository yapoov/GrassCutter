using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MB {
    
    public FormatTxt fps;
    
    int n = 0;
    
    float dt = 0f;

    void Update() {
        dt += DT;
        n++;
        if (dt >= 0.999f) {
            fps.Data(n);
            dt = 0f;
            n = 0;
        }
    }
}