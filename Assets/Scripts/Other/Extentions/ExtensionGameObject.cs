using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.UI;

public static partial class ExtensionGameObject {

    // ############### ############### COMPONENT ############### ###############

    ///<summary>GetComponent</summary>
    public static T Gc<T>(this GameObject a) {
        return a.GetComponent<T>();
    }

    ///<summary>GetComponentInChildren</summary>
    public static T Gcic<T>(this GameObject a) {
        return a.GetComponentInChildren<T>();
    }

    ///<summary>GetComponentInParent</summary>
    public static T Gcip<T>(this GameObject a) {
        return a.GetComponentInParent<T>();
    }

    ///<summary>GetComponents</summary>
    public static T[] Gcs<T>(this GameObject a) {
        return a.GetComponents<T>();
    }

    ///<summary>GetComponentsInChildren</summary>
    public static T[] Gcsic<T>(this GameObject a) {
        return a.GetComponentsInChildren<T>();
    }

    ///<summary>GetComponentsInParent</summary>
    public static T[] Gcsip<T>(this GameObject a) {
        return a.GetComponentsInParent<T>();
    }

    ///<summary>GetComponentsAll</summary>
    public static List<T> Gca<T>(this GameObject a) {
        return a.Contains<T>() ? a.Gcs<T>().Lis().Add<T>(a.Gcsic<T>()) : a.Gcsic<T>().Lis();
    }

    // ############### SIBLING ###############

    ///<summary>sibling-р sibling-н Transform авна</summary>
    public static Transform Sibling(this GameObject a, int sibling = 0) {
        return a.ParentChild(0, sibling);
    }

    ///<summary>sibling-р sibling-н GameObject авна</summary>
    public static GameObject SiblingGo(this GameObject a, int sibling = 0) {
        return a.ParentChildGo(0, sibling);
    }

    ///<summary>sibling-р sibling-н T авна</summary>
    public static T Sibling<T>(this GameObject a, int sibling = 0) {
        return a.ParentChild<T>(0, sibling);
    }

    // ############### PARENT ###############

    ///<summary>parent-р эцэгийн Transform авна</summary>
    public static Transform Parent(this GameObject a, int parent = 0) {
        Transform tf = a.transform.parent;
        for (int i = 0; i < parent; i++)
            tf = tf.parent;
        return tf;
    }

    ///<summary>parent-р эцэгийн GameObject авна</summary>
    public static GameObject ParentGo(this GameObject a, int parent = 0) {
        return a.Parent(parent).gameObject;
    }

    ///<summary>parent-р эцэгийн T авна</summary>
    public static T Parent<T>(this GameObject a, int parent = 0) {
        return a.ParentGo(parent).Gc<T>();
    }

    // ############### CHILD ###############

    ///<summary>childs-р хүүхдийн Transform авна</summary>
    public static Transform Child(this GameObject a, params int[] childs) {
        Transform tf = a.transform;
        for (int i = 0; i < childs.Length; i++)
            tf = tf.GetChild(childs[i]);
        return tf;
    }

    ///<summary>childs-р хүүхдийн Transform авна</summary>
    public static Transform Child(this GameObject a, string childs = "") {
        return a.Child(childs.RgxSplit("\\D+").Parse(x => int.Parse(x)));
    }

    ///<summary>childs-р хүүхдийн GameObject авна</summary>
    public static GameObject ChildGo(this GameObject a, params int[] childs) {
        return a.Child(childs).gameObject;
    }

    ///<summary>childs-р хүүхдийн GameObject авна</summary>
    public static GameObject ChildGo(this GameObject a, string childs = "") {
        return a.Child(childs).gameObject;
    }

    ///<summary>childs-р хүүхдийн T авна</summary>
    public static T Child<T>(this GameObject a, params int[] childs) {
        return a.ChildGo(childs).Gc<T>();
    }

    ///<summary>childs-р хүүхдийн T авна</summary>
    public static T Child<T>(this GameObject a, string childs = "") {
        return a.ChildGo(childs).Gc<T>();
    }

    // ############### PARENT CHILD ###############

    ///<summary>parent-р эцэгийн childs-р хүүхдийн Transform авна</summary>
    public static Transform ParentChild(this GameObject a, int parent = 0, params int[] childs) {
        return a.ParentGo(parent).Child(childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийн Transform авна</summary>
    public static Transform ParentChild(this GameObject a, int parent = 0, string childs = "") {
        return a.ParentGo(parent).Child(childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийн GameObject авна</summary>
    public static GameObject ParentChildGo(this GameObject a, int parent = 0, params int[] childs) {
        return a.ParentGo(parent).ChildGo(childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийн GameObject авна</summary>
    public static GameObject ParentChildGo(this GameObject a, int parent = 0, string childs = "") {
        return a.ParentGo(parent).ChildGo(childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийн T авна</summary>
    public static T ParentChild<T>(this GameObject a, int parent = 0, params int[] childs) {
        return a.ParentGo(parent).Child<T>(childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийн T авна</summary>
    public static T ParentChild<T>(this GameObject a, int parent = 0, string childs = "") {
        return a.ParentGo(parent).Child<T>(childs);
    }

    // ############### CHILDS ###############

    ///<summary>Transform төрөлтэй хүүхдүүдийг авна</summary>
    public static List<Transform> Childs(this GameObject a) {
        return a.Childs<Transform>();
    }

    ///<summary>GameObject төрөлтэй хүүхдүүдийг авна</summary>
    public static List<GameObject> ChildGos(this GameObject a) {
        return a.Childs<GameObject>();
    }

    ///<summary>T төрөлтэй хүүхдүүдийг авна</summary>
    public static List<T> Childs<T>(this GameObject a) {
        List<T> lis = new List<T>();
        for (int i = 0; i < a.transform.childCount; i++)
            if (a.Child(i).Contains<T>())
                lis.Add(a.Child<T>(i));
        return lis;
    }

    // ############### ############### ACTIVE ############### ###############

    ///<summary>active-г өөрчилнө</summary>
    public static void Active(this GameObject a, bool active) {
        a.SetActive(active);
    }

    ///<summary>sibling-р sibling-н Transform авна</summary>
    public static void SiblingActive(this GameObject a, bool active, int sibling = 0) {
        a.SiblingGo(sibling).Active(active);
    }

    ///<summary>parent-р эцэгийн active-г өөрчилнө</summary>
    public static void ParentActive(this GameObject a, bool active, int parent = 0) {
        a.ParentGo(parent).Active(active);
    }

    ///<summary>childs-р хүүхдийн active-г өөрчилнө</summary>
    public static void ChildActive(this GameObject a, bool active, params int[] childs) {
        a.ChildGo(childs).Active(active);
    }

    ///<summary>childs-р хүүхдийн active-г өөрчилнө</summary>
    public static void ChildActive(this GameObject a, bool active, string childs = "") {
        a.ChildGo(childs).Active(active);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийн active-г өөрчилнө</summary>
    public static void ParentChildActive(this GameObject a, bool active, int parent = 0, params int[] childs) {
        a.ParentChildGo(parent, childs).Active(active);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийн active-г өөрчилнө</summary>
    public static void ParentChildActive(this GameObject a, bool active, int parent = 0, string childs = "") {
        a.ParentChildGo(parent, childs).Active(active);
    }

    // ############### HIDE ###############

    ///<summary>нууна</summary>
    public static void Hide(this GameObject a) {
        a.Active(false);
    }

    ///<summary>sibling-р sibling-г нууна</summary>
    public static void SiblingHide(this GameObject a, int sibling = 0) {
        a.SiblingActive(false);
    }

    ///<summary>parent-р эцэгийг нууна</summary>
    public static void ParentHide(this GameObject a, int parent = 0) {
        a.ParentActive(false, parent);
    }

    ///<summary>childs-р хүүхдийг нууна</summary>
    public static void ChildHide(this GameObject a, params int[] childs) {
        a.ChildActive(false, childs);
    }

    ///<summary>childs-р хүүхдийг нууна</summary>
    public static void ChildHide(this GameObject a, string childs = "") {
        a.ChildActive(false, childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийг нууна</summary>
    public static void ParentChildHide(this GameObject a, int parent = 0, params int[] childs) {
        a.ParentChildActive(false, parent, childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийг нууна</summary>
    public static void ParentChildHide(this GameObject a, int parent = 0, string childs = "") {
        a.ParentChildActive(false, parent, childs);
    }

    // ############### SHOW ###############

    ///<summary>харуулна</summary>
    public static void Show(this GameObject a) {
        a.Active(true);
    }

    ///<summary>sibling-р sibling-г харуулна</summary>
    public static void SiblingShow(this GameObject a, int sibling = 0) {
        a.SiblingActive(true);
    }

    ///<summary>parent-р эцэгийг харуулна</summary>
    public static void ParentShow(this GameObject a, int parent = 0) {
        a.ParentActive(true, parent);
    }

    ///<summary>childs-р хүүхдийг харуулна</summary>
    public static void ChildShow(this GameObject a, params int[] childs) {
        a.ChildActive(true, childs);
    }

    ///<summary>childs-р хүүхдийг харуулна</summary>
    public static void ChildShow(this GameObject a, string childs = "") {
        a.ChildActive(true, childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийг харуулна</summary>
    public static void ParentChildShow(this GameObject a, int parent = 0, params int[] childs) {
        a.ParentChildActive(true, parent, childs);
    }

    ///<summary>parent-р эцэгийн childs-р хүүхдийг харуулна</summary>
    public static void ParentChildShow(this GameObject a, int parent = 0, string childs = "") {
        a.ParentChildActive(true, parent, childs);
    }

    // ############### ############### TRANSFORM ############### ###############

    // ############### TRANSFORM DIR PNT VEC ###############

    ///<summary>transform.TransformDirection</summary>
    public static Vector3 TfDir(this GameObject a, float x, float y, float z) {
        return a.transform.TransformDirection(x, y, z);
    }

    ///<summary>transform.TransformDirection</summary>
    public static Vector3 TfDir(this GameObject a, Vector3 dir) {
        return a.transform.TransformDirection(dir);
    }

    ///<summary>transform.InverseTransformDirection</summary>
    public static Vector3 TfInvDir(this GameObject a, float x, float y, float z) {
        return a.transform.InverseTransformDirection(x, y, z);
    }

    ///<summary>transform.InverseTransformDirection</summary>
    public static Vector3 TfInvDir(this GameObject a, Vector3 dir) {
        return a.transform.InverseTransformDirection(dir);
    }

    ///<summary>transform.TransformPoint</summary>
    public static Vector3 TfPnt(this GameObject a, float x, float y, float z) {
        return a.transform.TransformPoint(x, y, z);
    }

    ///<summary>transform.TransformPoint</summary>
    public static Vector3 TfPnt(this GameObject a, Vector3 pnt) {
        return a.transform.TransformPoint(pnt);
    }

    ///<summary>transform.InverseTransformPoint</summary>
    public static Vector3 TfInvPnt(this GameObject a, float x, float y, float z) {
        return a.transform.InverseTransformPoint(x, y, z);
    }

    ///<summary>transform.InverseTransformPoint</summary>
    public static Vector3 TfInvPnt(this GameObject a, Vector3 pnt) {
        return a.transform.InverseTransformPoint(pnt);
    }

    ///<summary>transform.TransformVector</summary>
    public static Vector3 TfVec(this GameObject a, float x, float y, float z) {
        return a.transform.TransformVector(x, y, z);
    }

    ///<summary>transform.TransformVector</summary>
    public static Vector3 TfVec(this GameObject a, Vector3 vec) {
        return a.transform.TransformVector(vec);
    }

    ///<summary>transform.InverseTransformVector</summary>
    public static Vector3 TfInvVec(this GameObject a, float x, float y, float z) {
        return a.transform.InverseTransformVector(x, y, z);
    }

    ///<summary>transform.InverseTransformVector</summary>
    public static Vector3 TfInvVec(this GameObject a, Vector3 vec) {
        return a.transform.InverseTransformVector(vec);
    }

    // ############### TRANSFORM LOOK AT ###############

    ///<summary>transform.LookAt</summary>
    public static void TfLookAt(this GameObject a, Transform tf) {
        a.transform.LookAt(tf);
    }

    ///<summary>transform.LookAt</summary>
    public static void TfLookAt(this GameObject a, Transform tf, [DefaultValue("Vector3.up")] Vector3 up) {
        a.transform.LookAt(tf, up);
    }

    ///<summary>transform.LookAt</summary>
    public static void TfLookAt(this GameObject a, Vector3 pos) {
        a.transform.LookAt(pos);
    }

    ///<summary>transform.LookAt</summary>
    public static void TfLookAt(this GameObject a, Vector3 pos, [DefaultValue("Vector3.up")] Vector3 up) {
        a.transform.LookAt(pos, up);
    }

    // ############### TRANSFORM ROTATE ###############

    ///<summary>transform.Rotate</summary>
    public static void TfRot(this GameObject a, float x, float y, float z) {
        a.transform.Rotate(x, y, z);
    }

    ///<summary>transform.Rotate</summary>
    public static void TfRot(this GameObject a, float x, float y, float z, [DefaultValue("Space.Self")] Space spc) {
        a.transform.Rotate(x, y, z, spc);
    }

    ///<summary>transform.Rotate</summary>
    public static void TfRot(this GameObject a, Vector3 rot) {
        a.transform.Rotate(rot);
    }

    ///<summary>transform.Rotate</summary>
    public static void TfRot(this GameObject a, Vector3 rot, [DefaultValue("Space.Self")] Space spc) {
        a.transform.Rotate(rot, spc);
    }

    ///<summary>transform.Rotate</summary>
    public static void TfRot(this GameObject a, Vector3 axis, float ang) {
        a.transform.Rotate(axis, ang);
    }

    ///<summary>transform.Rotate</summary>
    public static void TfRot(this GameObject a, Vector3 axis, float ang, [DefaultValue("Space.Self")] Space spc) {
        a.transform.Rotate(axis, ang, spc);
    }

    ///<summary>transform.RotateAround</summary>
    public static void TfRotAround(this GameObject a, Vector3 pnt, Vector3 axis, float ang) {
        a.transform.RotateAround(pnt, axis, ang);
    }

    // ############### TRANSFORM TRANSLATE ###############

    ///<summary>transform.Translate</summary>
    public static void TfTra(this GameObject a, float x, float y, float z) {
        a.transform.Translate(x, y, z);
    }

    ///<summary>transform.Translate</summary>
    public static void TfTra(this GameObject a, float x, float y, float z, [DefaultValue("Space.Self")] Space spc) {
        a.transform.Translate(x, y, z, spc);
    }

    ///<summary>transform.Translate</summary>
    public static void TfTra(this GameObject a, float x, float y, float z, Transform tf) {
        a.transform.Translate(x, y, z, tf);
    }

    ///<summary>transform.Translate</summary>
    public static void TfTra(this GameObject a, Vector3 tra) {
        a.transform.Translate(tra);
    }

    ///<summary>transform.Translate</summary>
    public static void TfTra(this GameObject a, Vector3 tra, [DefaultValue("Space.Self")] Space spc) {
        a.transform.Translate(tra, spc);
    }

    ///<summary>transform.Translate</summary>
    public static void TfTra(this GameObject a, Vector3 tra, Transform tf) {
        a.transform.Translate(tra, tf);
    }
    
    // ############### FIND ###############

    ///<summary>name нэртэй Transform-г олж буцаана</summary>
    public static Transform Find(this GameObject a, string name) {
        return a.transform.Find(name);
    }

    ///<summary>name нэртэй GameObject-г олж буцаана</summary>
    public static GameObject FindGo(this GameObject a, string name) {
        return a.transform.Find(name).gameObject;
    }

    ///<summary>name нэртэй T-г олж буцаана</summary>
    public static T Find<T>(this GameObject a, string name) {
        return a.transform.Find(name).Gc<T>();
    }

    // ############### TRANSFORM ###############

    ///<summary>байрыг нь солино</summary>
    public static void SibIdx(this GameObject a, int i) {
        a.transform.SetSiblingIndex(i);
    }

    ///<summary>байрлалын дугаарыг нь авна</summary>
    public static int SibIdx(this GameObject a) {
        return a.transform.GetSiblingIndex();
    }

    ///<summary>эхэнд байрлуулна</summary>
    public static void SibFirst(this GameObject a) {
        a.transform.SetAsFirstSibling();
    }

    ///<summary>сүүлд байрлуулна</summary>
    public static void SibLast(this GameObject a) {
        a.transform.SetAsLastSibling();
    }

    ///<summary>эцэгийг parTf-р солино</summary>
    public static void Parent(this GameObject a, Transform parTf) {
        a.transform.SetParent(parTf);
    }

    // ############### ############### OTHER ############### ###############

    // ############### DESTROY ###############

    ///<summary>хүүхдүүдийг устгана</summary>
    public static void DestroyChilds<T>(this GameObject a, int sta = 0, int end = -1) {
        List<T> lis = a.Childs<T>();
        for (int i = sta, n = end < 0 ? lis.Count : end; i < n; i++)
            ((MonoBehaviour)(object)lis[i]).gameObject.Destroy();
    }

    ///<summary>хүүхдүүдийг устгана</summary>
    public static void DestroyChilds(this GameObject a, int sta = 0, int end = -1) {
        a.DestroyChilds<GameObject>(sta, end);
    }

    ///<summary>устгана</summary>
    public static void Destroy(this GameObject a, float t = 0) {
        MonoBehaviour.Destroy(a, t);
    }

    // ############### MATERIAL COLOR ###############

    ///<summary>renderer-н material-г авна</summary>
    public static Material RenMat(this GameObject a) {
        return a.Gc<Renderer>().material;
    }

    ///<summary>renderer-н material-уудыг авна</summary>
    public static List<Material> RenMats(this GameObject a) {
        return a.Gc<Renderer>().materials.Lis();
    }

    ///<summary>өнгө-г өөрчилнө</summary>
    public static void RenMatCol(this GameObject a, Color col) {
        a.RenMat().color = col;
    }

    ///<summary>өнгө-г өөрчилнө</summary>
    public static void RenMatCol(this GameObject a, string name, Color col) {
        a.RenMat().SetColor(name, col);
    }

    ///<summary>өнгө-г авна</summary>
    public static Color RenMatCol(this GameObject a) {
        return a.RenMat().color;
    }

    ///<summary>өнгө-г авна</summary>
    public static Color RenMatCol(this GameObject a, string name) {
        return a.RenMat().GetColor(name);
    }

    // ############### OTHER ###############

    ///<summary>Contains Component</summary>
    public static bool Contains<T>(this GameObject a) {
        return a.Gc<T>() != null;
    }

    // color
    public static Color UiCol(this GameObject a, Color col = default(Color)) {
        if (a.Gc<Image>()) return a.Gc<Image>().color;
        else if (a.Gc<Text>()) return a.Gc<Text>().color;
        else if (a.Gc<TextMesh>()) return a.Gc<TextMesh>().color;
        else if (a.Gc<TextMeshPro>()) return a.Gc<TextMeshPro>().color;
        else return col;
    }

    // active
    public static bool Enabled(this GameObject a) {
        return a && a.activeSelf;
    }

    ///<summary>material-уудыг авна</summary>
    public static List<Material> MatLis(this GameObject a) {
        List<Renderer> renLis = a.Gca<Renderer>();
        List<Material> matLis = new List<Material>();
        for (int i = 0; i < renLis.Count; i++)
            for (int j = 0; j < renLis[i].materials.Length; j++)
                matLis.Add(renLis[i].materials[j]);
        return matLis;
    }

    ///<summary>material-уудыг transparent болгож авна</summary>
    public static List<Material> MatLisTransparent(this GameObject a) {
        List<Material> matLis = a.MatLis();
        matLis.ForEach(x => Mat.RenMode(x, RenderingMode.Transparent));
        return matLis;
    }

    ///<summary>tag ижил байна уу шалгана</summary>
    public static bool Tag(this GameObject a, string tag) {
        return a.CompareTag(tag);
    }

};