using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIChange : MB
{
    [Range(0f, 1f)]
    public float alpha = 1;
    public Color color, color2;
    public Font font;
    public TMP_FontAsset tmpFont;
    List<TextMeshPro> tmpLis = new List<TextMeshPro>();
    List<TextMesh> tmLis = new List<TextMesh>();
    List<Text> txtLis = new List<Text>();
    List<Image> imgLis = new List<Image>();
    List<float> tmpALis = new List<float>();
    List<float> tmALis = new List<float>();
    List<float> txtALis = new List<float>();
    List<float> imgALis = new List<float>();
    private void Update()
    {
        alpha = M.Clamp01(alpha);
        for (int i = 0; i < tmpLis.Count; i++)
            tmpLis[i].color = Col.A(tmpLis[i].color, tmpALis[i] * alpha);
        for (int i = 0; i < tmLis.Count; i++)
            tmLis[i].color = Col.A(tmLis[i].color, tmALis[i] * alpha);
        for (int i = 0; i < txtLis.Count; i++)
            txtLis[i].color = Col.A(txtLis[i].color, txtALis[i] * alpha);
        for (int i = 0; i < imgLis.Count; i++)
            imgLis[i].color = Col.A(imgLis[i].color, imgALis[i] * alpha);
    }
    public void Alpha()
    {
        tmpLis = go.Gca<TextMeshPro>();
        tmpLis.ForEach(x => tmpALis.Add(x.color.a));
        tmLis = go.Gca<TextMesh>();
        tmLis.ForEach(x => tmALis.Add(x.color.a));
        txtLis = go.Gca<Text>();
        txtLis.ForEach(x => txtALis.Add(x.color.a));
        imgLis = go.Gca<Image>();
        imgLis.ForEach(x => imgALis.Add(x.color.a));
    }
    public void Color()
    {
        A.FOsOT<TextMeshPro>().ForEach(x => x.color = x.color == color ? color2 : x.color);
        A.FOsOT<TextMesh>().ForEach(x => x.color = x.color == color ? color2 : x.color);
        A.FOsOT<Text>().ForEach(x => x.color = x.color == color ? color2 : x.color);
        A.FOsOT<Image>().ForEach(x => x.color = x.color == color ? color2 : x.color);
        A.SaveOpenScenes();
    }
    public void Font()
    {
        A.FOsOT<TextMeshPro>().ForEach(x => x.font = tmpFont);
        A.FOsOT<TextMesh>().ForEach(x => x.font = font);
        A.FOsOT<Text>().ForEach(x => x.font = font);
        A.SaveOpenScenes();
    }
}