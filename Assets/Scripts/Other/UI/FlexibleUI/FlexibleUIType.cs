using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleUIType : FlexibleUI {
    public enum UIType {
        Image,
        Text,
        Shadow,
        TextColor,
        TextFont,
    }
    public UIType type;
    public int colorIdx;
    public int fontIdx;
    public bool isAplha = false;
    protected override void OnSkinUI () {
        base.OnSkinUI ();
        if (skinData.isUpdate) {
            Color color = skinData.colors[colorIdx >= skinData.colors.Count ? 0 : colorIdx];
            Font font = skinData.fonts[fontIdx >= skinData.fonts.Count ? 0 : fontIdx];
            Text text = null;
            switch (type) {
                case UIType.Text:
                    text = go.Gc<Text> ();
                    if (text) {
                        text.color = Col.A (color, isAplha ? text.color.a : color.a);
                        text.font = font;
                    }
                    break;
                case UIType.TextColor:
                    text = go.Gc<Text> ();
                    if (text) {
                        text.color = Col.A (color, isAplha ? text.color.a : color.a);
                    }
                    break;
                case UIType.TextFont:
                    text = go.Gc<Text> ();
                    if (text) {
                        text.font = font;
                    }
                    break;
                case UIType.Shadow:
                    Shadow shadow = go.Gc<Shadow> ();
                    if (shadow) {
                        shadow.effectColor = color;
                    }
                    break;
                case UIType.Image:
                    Image image = go.Gc<Image> ();
                    if (image) {
                        image.color = color;
                    }
                    break;
            }
        }
    }
}