using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MB {
    // public int showSkinCount = 3;
    // public float leftRightSpacing = 50;
    // public float selectedScale = 1.5f;
    // public int idx;
    // public Color lockedCol = Color.gray;
    // public GameObject selectBtnGo;
    // float size, dis, leftLimX, rightLimX;
    // bool isClick = false;
    // int count;
    // RectTransform rt;
    // List<bool> actives = new List<bool> ();
    // private void Start () {
    //     Init (0, new bool[] { true, true, true, false, false });
    // }
    // public override void CharacterSkin (int playerSkinIdx, params bool[] types) {
    //     Init (playerSkinIdx, types);
    // }
    // public void Init (int playerSkinIdx, params bool[] types) {
    //     rt = transform.Child<RectTransform> (0, 0);
    //     count = rt.childCount;
    //     idx = playerSkinIdx < 0 ? 0 : playerSkinIdx;
    //     actives = FillList<bool> (types.ToList (), count, false);
    //     size = rt.Child<RectTransform> (0).rect.width;
    //     float width = transform.GC<RectTransform> ().rect.width;
    //     float spacing = (width - showSkinCount * size - leftRightSpacing * 2) / (showSkinCount - 1);
    //     dis = spacing + size;
    //     rt.sizeDelta = A.Vec2X (rt.sizeDelta, dis * count);
    //     leftLimX = -(rt.sizeDelta.x - spacing - size) / 2;
    //     rightLimX = -leftLimX;
    //     SetIdx (idx);
    //     Select (idx);
    // }
    // void Update () {
    //     if (IsDown) {
    //         mp = MP;
    //         isClick = true;
    //     }
    //     if (IsClick) {
    //         rt.localPosition = A.Vec3X (
    //             rt.localPosition,
    //             A.Clamp (rt.localPosition.x + (MP.x - mp.x), leftLimX, rightLimX)
    //         );
    //         UpdateScale ();
    //         idx = A.RoundInt (CurIdx ());
    //         SelectButton(idx);
    //         mp = MP;
    //     }
    //     if (IsUp) {
    //         isClick = false;
    //     }
    //     if (!isClick) {
    //         UpdateScale ();
    //         rt.localPosition = A.VecLerp (rt.localPosition, IdxPos (idx), DT * 10);
    //     }
    // }
    // List<T> FillList<T> (List<T> lis, int count, T def) {
    //     List<T> res = new List<T> ();
    //     if (lis.Null ()) {
    //         for (int i = 0; i < count; i++)
    //             res.Add (def);
    //     } else if (lis.Count > count) {
    //         for (int i = 0; i < count; i++)
    //             res.Add (lis[i]);
    //     } else {
    //         for (int i = 0; i < lis.Count; i++)
    //             res.Add (lis[i]);
    //         for (int i = lis.Count; i < count; i++)
    //             res.Add (def);
    //     }
    //     return res;
    // }
    // float CurIdx () { return (rightLimX - rt.localPosition.x) / dis; }
    // void UpdateScale () {
    //     float tmpIdx = CurIdx ();
    //     int floorIdx = A.FloorInt (tmpIdx), ceilIdx = A.CeilInt (tmpIdx);
    //     for (int i = 0; i < count; i++) {
    //         float scale = i == floorIdx ? (selectedScale - (selectedScale - 1) * (tmpIdx - floorIdx)) :
    //             i == ceilIdx ? (selectedScale - (selectedScale - 1) * (ceilIdx - tmpIdx)) : 1;
    //         rt.Child (i).localScale = Vector3.one * scale;
    //     }
    // }
    // void Select (int idx) {
    //     for (int i = 0; i < count; i++) {
    //         rt.ChildActive (i == idx, i, 1);
    //         if (!actives[i])
    //             rt.Child<Image> (i, 0).color = lockedCol;
    //     }
    // }
    // public void SetIdx (int idx) {
    //     this.idx = idx;
    //     rt.localPosition = IdxPos (idx);
    // }
    // Vector3 IdxPos (int idx) { return A.Vec3X (rt.localPosition, rightLimX - dis * idx); }
    // void SelectButton (int idx) {
    //     selectBtnGo.Active (actives[idx] && idx != GameController.PlayerSkinIdx);
    // }
    // public void Close () {
    //     gameObject.Hide ();
    // }
    // public void Select () {
    //     if (actives[idx]) {
    //         GameController.PlayerSkinIdx = idx;
    //         A.SetData (Data.PlayerSkinIdx, idx);
    //         gameObject.Hide ();
    //     }
    // }
}