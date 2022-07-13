using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MB {
    public Color Color {
        get { return color; }
        set { Setup(value); }
    }
    Color color = Color.red;
    Action update;
    static bool GetLocalMouse(GameObject go, out Vector2 result) {
        var rt = (RectTransform)go.transform;
        var mp = rt.TfInvPnt(MP);
        result.x = Mathf.Clamp(mp.x, rt.rect.min.x, rt.rect.max.x);
        result.y = Mathf.Clamp(mp.y, rt.rect.min.y, rt.rect.max.y);
        return rt.rect.Contains(mp);
    }
    static Vector2 GetWidgetSize(GameObject go) {
        var rt = (RectTransform)go.transform;
        return rt.rect.size;
    }
    static void RGBToHSV(Color color, out float h, out float s, out float v) {
        var cmin = Mathf.Min(color.r, color.g, color.b);
        var cmax = Mathf.Max(color.r, color.g, color.b);
        var d = cmax - cmin;
        if (d == 0) {
            h = 0;
        } else if (cmax == color.r) {
            h = M.Rep((color.g - color.b) / d, 6);
        } else if (cmax == color.g) {
            h = (color.b - color.r) / d + 2;
        } else {
            h = (color.r - color.g) / d + 4;
        }
        s = cmax == 0 ? 0 : d / cmax;
        v = cmax;
    }
    GameObject Go(string name) {
        return transform.Find(name).gameObject;
    }
    void Setup(Color inputColor) {
        var satvalGo = Go("SaturationValue");
        var satvalKnob = Go("SaturationValue/Knob");
        var hueGo = Go("Hue");
        var hueKnob = Go("Hue/Knob");
        var alphaGo = Go("Alpha");
        var alphaKnob = Go("Alpha/Knob");
        var result = Go("Result/Result");
        // hue texture apply
        var hueColors = new Color[] {
            Color.red,
            Color.yellow,
            Color.green,
            Color.cyan,
            Color.blue,
            Color.magenta,
        };
        var hueTex = new Texture2D(1, 7);
        for (int i = 0; i < 7; i++) {
            hueTex.SetPixel(0, i, hueColors[i % 6]);
        }
        hueTex.Apply();
        hueGo.Gc<Image>().sprite = Sprite.Create(hueTex, new Rect(0, 0.5f, 1, 6), new Vector2(0.5f, 0.5f));
        // alpha texture apply
        var alphaColors = new Color[] {
            new Color (1, 1, 1, 0),
            Color.white,
        };
        var alphaTex = new Texture2D(2, 1);
        for (int i = 0; i < 2; i++) {
            alphaTex.SetPixel(i, 0, alphaColors[i]);
        }
        alphaTex.Apply();
        alphaGo.Gc<Image>().sprite = Sprite.Create(alphaTex, new Rect(0.5f, 0, 1, 1), new Vector2(0.5f, 0.5f));
        // saturation value texture apply
        var satvalColors = new Color[] {
            new Color (0, 0, 0),
            new Color (0, 0, 0),
            new Color (1, 1, 1),
            hueColors[0],
        };
        var satvalTex = new Texture2D(2, 2);
        satvalGo.Gc<Image>().sprite = Sprite.Create(satvalTex, new Rect(0.5f, 0.5f, 1, 1), new Vector2(0.5f, 0.5f));
        Action resetSatValTexture = () => {
            for (int j = 0; j < 2; j++) {
                for (int i = 0; i < 2; i++) {
                    satvalTex.SetPixel(i, j, satvalColors[i + j * 2]);
                }
            }
            satvalTex.Apply();
        };
        // load size
        var hueSz = GetWidgetSize(hueGo);
        var alphaSz = GetWidgetSize(alphaGo);
        var satvalSz = GetWidgetSize(satvalGo);
        float hue, saturation, value, alpha = inputColor.a;
        RGBToHSV(inputColor, out hue, out saturation, out value);
        Action applyHue = () => {
            var i0 = Mathf.Clamp((int)hue, 0, 5);
            var i1 = (i0 + 1) % 6;
            var resultColor = Color.Lerp(hueColors[i0], hueColors[i1], hue - i0);
            satvalColors[3] = resultColor;
            resetSatValTexture();
        };
        Action applySaturationValue = () => {
            var sv = new Vector2(saturation, value);
            var isv = new Vector2(1 - sv.x, 1 - sv.y);
            var c0 = isv.x * isv.y * satvalColors[0];
            var c1 = sv.x * isv.y * satvalColors[1];
            var c2 = isv.x * sv.y * satvalColors[2];
            var c3 = sv.x * sv.y * satvalColors[3];
            var resultColor = c0 + c1 + c2 + c3;
            var resImg = result.Gc<Image>();
            resultColor = new Color(resultColor.r, resultColor.g, resultColor.b, alpha);
            resImg.color = resultColor;
            color = resultColor;
        };
        applyHue();
        applySaturationValue();
        satvalKnob.transform.localPosition = new Vector2(saturation * satvalSz.x, value * satvalSz.y);
        hueKnob.transform.localPosition = new Vector2(hueKnob.transform.localPosition.x, hue / 6 * satvalSz.y);
        alphaKnob.transform.localPosition = new Vector2(alpha * alphaSz.x, alphaKnob.transform.localPosition.y);
        Action dragH = null;
        Action dragSV = null;
        Action dragA = null;
        Action idle = () => {
            if (IsDown) {
                Vector2 mp;
                if (GetLocalMouse(hueGo, out mp)) {
                    update = dragH;
                } else if (GetLocalMouse(satvalGo, out mp)) {
                    update = dragSV;
                } else if (GetLocalMouse(alphaGo, out mp)) {
                    update = dragA;
                }
            }
        };
        dragA = () => {
            Vector2 mp;
            GetLocalMouse(alphaGo, out mp);
            alpha = mp.x / alphaSz.x;
            var resImg = result.Gc<Image>();
            var resultColor = new Color(resImg.color.r, resImg.color.g, resImg.color.b, alpha);
            resImg.color = resultColor;
            color = resultColor;
            alphaKnob.transform.localPosition = new Vector2(mp.x, alphaKnob.transform.localPosition.y);
            if (IsUp) {
                update = idle;
            }
        };
        dragH = () => {
            Vector2 mp;
            GetLocalMouse(hueGo, out mp);
            hue = mp.y / hueSz.y * 6;
            applyHue();
            applySaturationValue();
            hueKnob.transform.localPosition = new Vector2(hueKnob.transform.localPosition.x, mp.y);
            if (IsUp) {
                update = idle;
            }
        };
        dragSV = () => {
            Vector2 mp;
            GetLocalMouse(satvalGo, out mp);
            saturation = mp.x / satvalSz.x;
            value = mp.y / satvalSz.y;
            applySaturationValue();
            satvalKnob.transform.localPosition = mp;
            if (IsUp) {
                update = idle;
            }
        };
        update = idle;
    }
    void Awake() {
        Color = Color.red;
    }
    void Update() {
        update();
    }
}