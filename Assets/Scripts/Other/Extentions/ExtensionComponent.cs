using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public static class ExtensionComponent {

	// ############### ############### COMPONENT ############### ###############

	///<summary>GetComponent</summary>
	public static T Gc<T>(this Component a) {
		return a.gameObject.Gc<T>();
	}

	///<summary>GetComponentInChildren</summary>
	public static T Gcic<T>(this Component a) {
		return a.gameObject.Gcic<T>();
	}

	///<summary>GetComponentInParent</summary>
	public static T Gcip<T>(this Component a) {
		return a.gameObject.Gcip<T>();
	}

	///<summary>GetComponents</summary>
	public static T[] Gcs<T>(this Component a) {
		return a.gameObject.Gcs<T>();
	}

	///<summary>GetComponentsInChildren</summary>
	public static T[] Gcsic<T>(this Component a) {
		return a.gameObject.Gcsic<T>();
	}

	///<summary>GetComponentsInParent</summary>
	public static T[] Gcsip<T>(this Component a) {
		return a.gameObject.Gcsip<T>();
	}

	///<summary>GetComponentsAll</summary>
	public static List<T> Gca<T>(this Component a) {
		return a.gameObject.Gca<T>();
	}

	// ############### SIBLING ###############

	///<summary>sibling-р sibling-н Transform авна</summary>
	public static Transform Sibling(this Component a, int sibling = 0) {
		return a.gameObject.Sibling(sibling);
	}

	///<summary>sibling-р sibling-н GameObject авна</summary>
	public static GameObject SiblingGo(this Component a, int sibling = 0) {
		return a.gameObject.SiblingGo(sibling);
	}

	///<summary>sibling-р sibling-н T авна</summary>
	public static T Sibling<T>(this Component a, int sibling = 0) {
		return a.gameObject.Sibling<T>(sibling);
	}

	// ############### PARENT ###############

	///<summary>parent-р эцэгийн Transform авна</summary>
	public static Transform Parent(this Component a, int parent = 0) {
		return a.gameObject.Parent(parent);
	}

	///<summary>parent-р эцэгийн GameObject авна</summary>
	public static GameObject ParentGo(this Component a, int parent = 0) {
		return a.gameObject.ParentGo(parent);
	}

	///<summary>parent-р эцэгийн T авна</summary>
	public static T Parent<T>(this Component a, int parent = 0) {
		return a.gameObject.Parent<T>(parent);
	}

	// ############### CHILD ###############

	///<summary>childs-р хүүхдийн Transform авна</summary>
	public static Transform Child(this Component a, params int[] childs) {
		return a.gameObject.Child(childs);
	}

	///<summary>childs-р хүүхдийн Transform авна</summary>
	public static Transform Child(this Component a, string childs = "") {
		return a.gameObject.Child(childs);
	}

	///<summary>childs-р хүүхдийн GameObject авна</summary>
	public static GameObject ChildGo(this Component a, params int[] childs) {
		return a.gameObject.ChildGo(childs);
	}

	///<summary>childs-р хүүхдийн GameObject авна</summary>
	public static GameObject ChildGo(this Component a, string childs = "") {
		return a.gameObject.ChildGo(childs);
	}

	///<summary>childs-р хүүхдийн T авна</summary>
	public static T Child<T>(this Component a, params int[] childs) {
		return a.gameObject.Child<T>(childs);
	}

	///<summary>childs-р хүүхдийн T авна</summary>
	public static T Child<T>(this Component a, string childs = "") {
		return a.gameObject.Child<T>(childs);
	}

	// ############### PARENT CHILD ###############

	///<summary>parent-р эцэгийн childs-р хүүхдийн Transform авна</summary>
	public static Transform ParentChild(this Component a, int parent = 0, params int[] childs) {
		return a.gameObject.ParentChild(parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийн Transform авна</summary>
	public static Transform ParentChild(this Component a, int parent = 0, string childs = "") {
		return a.gameObject.ParentChild(parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийн GameObject авна</summary>
	public static GameObject ParentChildGo(this Component a, int parent = 0, params int[] childs) {
		return a.gameObject.ParentChildGo(parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийн GameObject авна</summary>
	public static GameObject ParentChildGo(this Component a, int parent = 0, string childs = "") {
		return a.gameObject.ParentChildGo(parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийн T авна</summary>
	public static T ParentChild<T>(this Component a, int parent = 0, params int[] childs) {
		return a.gameObject.ParentChild<T>(parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийн T авна</summary>
	public static T ParentChild<T>(this Component a, int parent = 0, string childs = "") {
		return a.gameObject.ParentChild<T>(parent, childs);
	}

	// ############### CHILDS ###############

	///<summary>Transform төрөлтэй хүүхдүүдийг авна</summary>
	public static List<Transform> Childs(this Component a) {
		return a.gameObject.Childs();
	}

	///<summary>GameObject төрөлтэй хүүхдүүдийг авна</summary>
	public static List<GameObject> ChildGos(this Component a) {
		return a.gameObject.ChildGos();
	}

	///<summary>T төрөлтэй хүүхдүүдийг авна</summary>
	public static List<T> Childs<T>(this Component a) {
		return a.gameObject.Childs<T>();
	}

	// ############### ############### ACTIVE ############### ###############

	///<summary>active-г өөрчилнө</summary>
	public static void Active(this Component a, bool active) {
		a.gameObject.Active(active);
	}

	///<summary>sibling-р sibling-н Transform авна</summary>
	public static void SiblingActive(this Component a, bool active, int sibling = 0) {
		a.gameObject.SiblingActive(active, sibling);
	}

	///<summary>parent-р эцэгийн active-г өөрчилнө</summary>
	public static void ParentActive(this Component a, bool active, int parent = 0) {
		a.gameObject.ParentActive(active, parent);
	}

	///<summary>childs-р хүүхдийн active-г өөрчилнө</summary>
	public static void ChildActive(this Component a, bool active, params int[] childs) {
		a.gameObject.ChildActive(active, childs);
	}

	///<summary>childs-р хүүхдийн active-г өөрчилнө</summary>
	public static void ChildActive(this Component a, bool active, string childs = "") {
		a.gameObject.ChildActive(active, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийн active-г өөрчилнө</summary>
	public static void ParentChildActive(this Component a, bool active, int parent = 0, params int[] childs) {
		a.gameObject.ParentChildActive(active, parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийн active-г өөрчилнө</summary>
	public static void ParentChildActive(this Component a, bool active, int parent = 0, string childs = "") {
		a.gameObject.ParentChildActive(active, parent, childs);
	}

	// ############### HIDE ###############

	///<summary>нууна</summary>
	public static void Hide(this Component a) {
		a.gameObject.Hide();
	}

	///<summary>sibling-р sibling-г нууна</summary>
	public static void SiblingHide(this Component a, int sibling = 0) {
		a.gameObject.SiblingHide(sibling);
	}

	///<summary>parent-р эцэгийг нууна</summary>
	public static void ParentHide(this Component a, int parent = 0) {
		a.gameObject.ParentHide(parent);
	}

	///<summary>childs-р хүүхдийг нууна</summary>
	public static void ChildHide(this Component a, params int[] childs) {
		a.gameObject.ChildHide(childs);
	}

	///<summary>childs-р хүүхдийг нууна</summary>
	public static void ChildHide(this Component a, string childs = "") {
		a.gameObject.ChildHide(childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийг нууна</summary>
	public static void ParentChildHide(this Component a, int parent = 0, params int[] childs) {
		a.gameObject.ParentChildHide(parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийг нууна</summary>
	public static void ParentChildHide(this Component a, int parent = 0, string childs = "") {
		a.gameObject.ParentChildHide(parent, childs);
	}

	// ############### SHOW ###############

	///<summary>харуулна</summary>
	public static void Show(this Component a) {
		a.gameObject.Show();
	}

	///<summary>sibling-р sibling-г харуулна</summary>
	public static void SiblingShow(this Component a, int sibling = 0) {
		a.gameObject.SiblingShow(sibling);
	}

	///<summary>parent-р эцэгийг харуулна</summary>
	public static void ParentShow(this Component a, int parent = 0) {
		a.gameObject.ParentShow(parent);
	}

	///<summary>childs-р хүүхдийг харуулна</summary>
	public static void ChildShow(this Component a, params int[] childs) {
		a.gameObject.ChildShow(childs);
	}

	///<summary>childs-р хүүхдийг харуулна</summary>
	public static void ChildShow(this Component a, string childs = "") {
		a.gameObject.ChildShow(childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийг харуулна</summary>
	public static void ParentChildShow(this Component a, int parent = 0, params int[] childs) {
		a.gameObject.ParentChildShow(parent, childs);
	}

	///<summary>parent-р эцэгийн childs-р хүүхдийг харуулна</summary>
	public static void ParentChildShow(this Component a, int parent = 0, string childs = "") {
		a.gameObject.ParentChildShow(parent, childs);
	}

	// ############### ############### TRANSFORM ############### ###############

	// ############### TRANSFORM DIR PNT VEC ###############

	///<summary>transform.TransformDirection</summary>
	public static Vector3 TfDir(this Component a, float x, float y, float z) {
		return a.gameObject.TfDir(x, y, z);
	}

	///<summary>transform.TransformDirection</summary>
	public static Vector3 TfDir(this Component a, Vector3 dir) {
		return a.gameObject.TfDir(dir);
	}

	///<summary>transform.InverseTransformDirection</summary>
	public static Vector3 TfInvDir(this Component a, float x, float y, float z) {
		return a.gameObject.TfInvDir(x, y, z);
	}

	///<summary>transform.InverseTransformDirection</summary>
	public static Vector3 TfInvDir(this Component a, Vector3 dir) {
		return a.gameObject.TfInvDir(dir);
	}

	///<summary>transform.TransformPoint</summary>
	public static Vector3 TfPnt(this Component a, float x, float y, float z) {
		return a.gameObject.TfPnt(x, y, z);
	}

	///<summary>transform.TransformPoint</summary>
	public static Vector3 TfPnt(this Component a, Vector3 pnt) {
		return a.gameObject.TfPnt(pnt);
	}

	///<summary>transform.InverseTransformPoint</summary>
	public static Vector3 TfInvPnt(this Component a, float x, float y, float z) {
		return a.gameObject.TfInvPnt(x, y, z);
	}

	///<summary>transform.InverseTransformPoint</summary>
	public static Vector3 TfInvPnt(this Component a, Vector3 pnt) {
		return a.gameObject.TfInvPnt(pnt);
	}

	///<summary>transform.TransformVector</summary>
	public static Vector3 TfVec(this Component a, float x, float y, float z) {
		return a.gameObject.TfVec(x, y, z);
	}

	///<summary>transform.TransformVector</summary>
	public static Vector3 TfVec(this Component a, Vector3 vec) {
		return a.gameObject.TfVec(vec);
	}

	///<summary>transform.InverseTransformVector</summary>
	public static Vector3 TfInvVec(this Component a, float x, float y, float z) {
		return a.gameObject.TfInvVec(x, y, z);
	}

	///<summary>transform.InverseTransformVector</summary>
	public static Vector3 TfInvVec(this Component a, Vector3 vec) {
		return a.gameObject.TfInvVec(vec);
	}

	// ############### TRANSFORM LOOK AT ###############

	///<summary>transform.LookAt</summary>
	public static void TfLookAt(this Component a, Transform tf) {
		a.gameObject.TfLookAt(tf);
	}

	///<summary>transform.LookAt</summary>
	public static void TfLookAt(this Component a, Transform tf, [DefaultValue("Vector3.up")] Vector3 up) {
		a.gameObject.TfLookAt(tf, up);
	}

	///<summary>transform.LookAt</summary>
	public static void TfLookAt(this Component a, Vector3 pos) {
		a.gameObject.TfLookAt(pos);
	}

	///<summary>transform.LookAt</summary>
	public static void TfLookAt(this Component a, Vector3 pos, [DefaultValue("Vector3.up")] Vector3 up) {
		a.gameObject.TfLookAt(pos, up);
	}

	// ############### TRANSFORM ROTATE ###############

	///<summary>transform.Rotate</summary>
	public static void TfRot(this Component a, float x, float y, float z) {
		a.gameObject.TfRot(x, y, z);
	}

	///<summary>transform.Rotate</summary>
	public static void TfRot(this Component a, float x, float y, float z, [DefaultValue("Space.Self")] Space spc) {
		a.gameObject.TfRot(x, y, z, spc);
	}

	///<summary>transform.Rotate</summary>
	public static void TfRot(this Component a, Vector3 rot) {
		a.gameObject.TfRot(rot);
	}

	///<summary>transform.Rotate</summary>
	public static void TfRot(this Component a, Vector3 rot, [DefaultValue("Space.Self")] Space spc) {
		a.gameObject.TfRot(rot, spc);
	}

	///<summary>transform.Rotate</summary>
	public static void TfRot(this Component a, Vector3 axis, float ang) {
		a.gameObject.TfRot(axis, ang);
	}

	///<summary>transform.Rotate</summary>
	public static void TfRot(this Component a, Vector3 axis, float ang, [DefaultValue("Space.Self")] Space spc) {
		a.gameObject.TfRot(axis, ang, spc);
	}

	///<summary>transform.RotateAround</summary>
	public static void TfRotAround(this Component a, Vector3 pnt, Vector3 axis, float ang) {
		a.gameObject.TfRotAround(pnt, axis, ang);
	}

	// ############### TRANSFORM TRANSLATE ###############

	///<summary>transform.Translate</summary>
	public static void TfTra(this Component a, float x, float y, float z) {
		a.gameObject.TfTra(x, y, z);
	}

	///<summary>transform.Translate</summary>
	public static void TfTra(this Component a, float x, float y, float z, [DefaultValue("Space.Self")] Space spc) {
		a.gameObject.TfTra(x, y, z, spc);
	}

	///<summary>transform.Translate</summary>
	public static void TfTra(this Component a, float x, float y, float z, Transform tf) {
		a.gameObject.TfTra(x, y, z, tf);
	}

	///<summary>transform.Translate</summary>
	public static void TfTra(this Component a, Vector3 tra) {
		a.gameObject.TfTra(tra);
	}

	///<summary>transform.Translate</summary>
	public static void TfTra(this Component a, Vector3 tra, [DefaultValue("Space.Self")] Space spc) {
		a.gameObject.TfTra(tra, spc);
	}

	///<summary>transform.Translate</summary>
	public static void TfTra(this Component a, Vector3 tra, Transform tf) {
		a.gameObject.TfTra(tra, tf);
	}

	// ############### FIND ###############

	///<summary>name нэртэй Transform-г олж буцаана</summary>
	public static Transform Find(this Component a, string name) {
		return a.gameObject.Find(name);
	}

	///<summary>name нэртэй GameObject-г олж буцаана</summary>
	public static GameObject FindGo(this Component a, string name) {
		return a.gameObject.FindGo(name);
	}

	///<summary>name нэртэй T-г олж буцаана</summary>
	public static T Find<T>(this Component a, string name) {
		return a.gameObject.Find<T>(name);
	}

	// ############### TRANSFORM ###############

	///<summary>байрыг нь солино</summary>
	public static void SibIdx(this Component a, int i) {
		a.gameObject.SibIdx(i);
	}

	///<summary>байрлалын дугаарыг нь авна</summary>
	public static int SibIdx(this Component a) {
		return a.gameObject.SibIdx();
	}

	///<summary>эхэнд байрлуулна</summary>
	public static void SibFirst(this Component a) {
		a.gameObject.SibFirst();
	}

	///<summary>сүүлд байрлуулна</summary>
	public static void SibLast(this Component a) {
		a.gameObject.SibLast();
	}

	///<summary>эцэгийг parTf-р солино</summary>
	public static void Parent(this Component a, Transform parTf) {
		a.gameObject.Parent(parTf);
	}

	// ############### ############### OTHER ############### ###############

	// ############### DESTROY ###############

	///<summary>хүүхдүүдийг устгана</summary>
	public static void DestroyChilds<T>(this Component a, int sta = 0, int end = -1) {
		a.gameObject.DestroyChilds<T>(sta, end);
	}

	///<summary>хүүхдүүдийг устгана</summary>
	public static void DestroyChilds(this Component a, int sta = 0, int end = -1) {
		a.gameObject.DestroyChilds(sta, end);
	}

	///<summary>устгана</summary>
	public static void Destroy(this Component a, float t = 0) {
		a.gameObject.Destroy(t);
	}

	// ############### MATERIAL COLOR ###############

	///<summary>renderer-н material-г авна</summary>
	public static Material RenMat(this Component a) {
		return a.gameObject.RenMat();
	}

	///<summary>renderer-н material-уудыг авна</summary>
	public static List<Material> RenMats(this Component a) {
		return a.gameObject.RenMats();
	}

	///<summary>өнгө-г өөрчилнө</summary>
	public static void RenMatCol(this Component a, Color col) {
		a.gameObject.RenMatCol(col);
	}

	///<summary>өнгө-г өөрчилнө</summary>
	public static void RenMatCol(this Component a, string name, Color col) {
		a.gameObject.RenMatCol(name, col);
	}

	///<summary>өнгө-г авна</summary>
	public static Color RenMatCol(this Component a) {
		return a.gameObject.RenMatCol();
	}

	///<summary>өнгө-г авна</summary>
	public static Color RenMatCol(this Component a, string name) {
		return a.gameObject.RenMatCol(name);
	}

	// ############### OTHER ###############

	///<summary>Contains Component</summary>
	public static bool Contains<T>(this Component a) {
		return a.gameObject.Contains<T>();
	}

	// color

	public static Color UiCol(this Component a, Color col = default(Color)) {
		return a.gameObject.UiCol(col);
	}

	// active

	public static bool Enabled(this Component a) {
		return a.gameObject.Enabled();
	}

	///<summary>material-уудыг авна</summary>
	public static List<Material> MatLis(this Component a) {
		return a.gameObject.MatLis();
	}

	///<summary>material-уудыг transparent болгож авна</summary>
	public static List<Material> MatLisTransparent(this Component a) {
		return a.gameObject.MatLisTransparent();
	}

	///<summary>tag ижил байна уу шалгана</summary>
	public static bool Tag(this Component a, string tag) {
		return a.gameObject.Tag(tag);
	}

	///<summary>rigidbody-г авна</summary>
	public static Rigidbody Rb(this Component a) {
		return a.gameObject.Rb();
	}

	///<summary>constraints-г өөрчилнө</summary>
	public static void RbConstraints(this Component a, bool isFrzPosX = false, bool isFrzPosY = false, bool isFrzPosZ = false, bool isFrzRotX = false, bool isFrzRotY = false, bool isFrzRotZ = false) {
		a.gameObject.RbConstraints(isFrzPosX, isFrzPosY, isFrzPosZ, isFrzRotX, isFrzRotY, isFrzRotZ);
	}

	///<summary>constraints-г хөлдөөнө</summary>
	public static void RbFreezeAll(this Component a) {
		a.gameObject.RbFreezeAll();
	}

	///<summary>constraints-г байрлалыг хөлдөөнө</summary>
	public static void RbFreezePos(this Component a) {
		a.gameObject.RbFreezePos();
	}

	///<summary>constraints-г эргэлтийг хөлдөөнө</summary>
	public static void RbFreezeRot(this Component a) {
		a.gameObject.RbFreezeRot();
	}

	///<summary>constraints-г хөлдөөхгүй болгоно</summary>
	public static void RbNone(this Component a) {
		a.gameObject.RbNone();
	}

	///<summary>хурдыг 0 болгоно</summary>
	public static void RbV0(this Component a) {
		a.gameObject.RbV0();
	}

	///<summary>татах хүч ашиглана</summary>
	public static void RbUseG(this Component a, bool useGravity = true) {
		a.gameObject.RbUseG(useGravity);
	}

	///<summary>татах хүч ашиглахгүй</summary>
	public static void RbNoG(this Component a) {
		a.gameObject.RbNoG();
	}

	// ############### TRANSFORM.POSITION ###############

	///<summary>transform.position-г авна</summary>
	public static Vector3 Tp(this Component a) {
		return a.gameObject.Tp();
	}

	///<summary>transform.position-г өөрчилнө</summary>
	public static void Tp(this Component a, Vector3 v) {
		a.gameObject.Tp(v);
	}

	///<summary>transform.position-г өөрчилнө</summary>
	public static void Tp(this Component a, float x, float y, float z) {
		a.gameObject.Tp(x, y, z);
	}

	///<summary>transform.position-н x-г өөрчилнө</summary>
	public static void TpX(this Component a, float x) {
		a.gameObject.TpX(x);
	}

	///<summary>transform.position-н y-г өөрчилнө</summary>
	public static void TpY(this Component a, float y) {
		a.gameObject.TpY(y);
	}

	///<summary>transform.position-н z-г өөрчилнө</summary>
	public static void TpZ(this Component a, float z) {
		a.gameObject.TpZ(z);
	}

	///<summary>transform.position-н x, y-г өөрчилнө</summary>
	public static void TpXy(this Component a, float x, float y) {
		a.gameObject.TpXy(x, y);
	}

	///<summary>transform.position-н x, z-г өөрчилнө</summary>
	public static void TpXz(this Component a, float x, float z) {
		a.gameObject.TpXz(x, z);
	}

	///<summary>transform.position-н y, z-г өөрчилнө</summary>
	public static void TpYz(this Component a, float y, float z) {
		a.gameObject.TpYz(y, z);
	}

	///<summary>transform.position-д v-г нэмнэ</summary>
	public static void TpD(this Component a, Vector3 v) {
		a.gameObject.TpD(v);
	}

	///<summary>transform.position-д x, y, z-г нэмнэ</summary>
	public static void TpD(this Component a, float x, float y, float z) {
		a.gameObject.TpD(x, y, z);
	}

	///<summary>transform.position-д x-г нэмнэ</summary>
	public static void TpDx(this Component a, float x) {
		a.gameObject.TpDx(x);
	}

	///<summary>transform.position-д y-г нэмнэ</summary>
	public static void TpDy(this Component a, float y) {
		a.gameObject.TpDy(y);
	}

	///<summary>transform.position-д z-г нэмнэ</summary>
	public static void TpDz(this Component a, float z) {
		a.gameObject.TpDz(z);
	}

	///<summary>transform.position-д x, y-г нэмнэ</summary>
	public static void TpDxy(this Component a, float x, float y) {
		a.gameObject.TpDxy(x, y);
	}

	///<summary>transform.position-д x, z-г нэмнэ</summary>
	public static void TpDxz(this Component a, float x, float z) {
		a.gameObject.TpDxz(x, z);
	}

	///<summary>transform.position-д y, z-г нэмнэ</summary>
	public static void TpDyz(this Component a, float y, float z) {
		a.gameObject.TpDyz(y, z);
	}

	// ############### TRANSFORM.LOCALPOSITION ###############

	///<summary>transform.localPosition-г авна</summary>
	public static Vector3 Tlp(this Component a) {
		return a.gameObject.Tlp();
	}

	///<summary>transform.localPosition-г өөрчилнө</summary>
	public static void Tlp(this Component a, Vector3 v) {
		a.gameObject.Tlp(v);
	}

	///<summary>transform.localPosition-г өөрчилнө</summary>
	public static void Tlp(this Component a, float x, float y, float z) {
		a.gameObject.Tlp(x, y, z);
	}

	///<summary>transform.localPosition-н x-г өөрчилнө</summary>
	public static void TlpX(this Component a, float x) {
		a.gameObject.TlpX(x);
	}

	///<summary>transform.localPosition-н y-г өөрчилнө</summary>
	public static void TlpY(this Component a, float y) {
		a.gameObject.TlpY(y);
	}

	///<summary>transform.localPosition-н z-г өөрчилнө</summary>
	public static void TlpZ(this Component a, float z) {
		a.gameObject.TlpZ(z);
	}

	///<summary>transform.localPosition-н x, y-г өөрчилнө</summary>
	public static void TlpXy(this Component a, float x, float y) {
		a.gameObject.TlpXy(x, y);
	}

	///<summary>transform.localPosition-н x, z-г өөрчилнө</summary>
	public static void TlpXz(this Component a, float x, float z) {
		a.gameObject.TlpXz(x, z);
	}

	///<summary>transform.localPosition-н y, z-г өөрчилнө</summary>
	public static void TlpYz(this Component a, float y, float z) {
		a.gameObject.TlpYz(y, z);
	}

	///<summary>transform.localPosition-д v-г нэмнэ</summary>
	public static void TlpD(this Component a, Vector3 v) {
		a.gameObject.TlpD(v);
	}

	///<summary>transform.localPosition-д x, y, z-г нэмнэ</summary>
	public static void TlpD(this Component a, float x, float y, float z) {
		a.gameObject.TlpD(x, y, z);
	}

	///<summary>transform.localPosition-д x-г нэмнэ</summary>
	public static void TlpDx(this Component a, float x) {
		a.gameObject.TlpDx(x);
	}

	///<summary>transform.localPosition-д y-г нэмнэ</summary>
	public static void TlpDy(this Component a, float y) {
		a.gameObject.TlpDy(y);
	}

	///<summary>transform.localPosition-д z-г нэмнэ</summary>
	public static void TlpDz(this Component a, float z) {
		a.gameObject.TlpDz(z);
	}

	///<summary>transform.localPosition-д x, y-г нэмнэ</summary>
	public static void TlpDxy(this Component a, float x, float y) {
		a.gameObject.TlpDxy(x, y);
	}

	///<summary>transform.localPosition-д x, z-г нэмнэ</summary>
	public static void TlpDxz(this Component a, float x, float z) {
		a.gameObject.TlpDxz(x, z);
	}

	///<summary>transform.localPosition-д y, z-г нэмнэ</summary>
	public static void TlpDyz(this Component a, float y, float z) {
		a.gameObject.TlpDyz(y, z);
	}

	// ############### TRANSFORM.ROTATION ###############

	///<summary>transform.rotation-г авна</summary>
	public static Quaternion Tr(this Component a) {
		return a.gameObject.Tr();
	}

	///<summary>transform.rotation-г өөрчилнө</summary>
	public static void Tr(this Component a, Quaternion v) {
		a.gameObject.Tr(v);
	}

	// ############### TRANSFORM.LOCALROTATION ###############

	///<summary>transform.localRotation-г авна</summary>
	public static Quaternion Tlr(this Component a) {
		return a.gameObject.Tlr();
	}

	///<summary>transform.localRotation-г өөрчилнө</summary>
	public static void Tlr(this Component a, Quaternion v) {
		a.gameObject.Tlr(v);
	}

	// ############### TRANSFORM.LOSSYSCALE ###############

	///<summary>transform.lossyScale-г авна</summary>
	public static Vector3 Ts(this Component a) {
		return a.gameObject.Ts();
	}

	// ############### TRANSFORM.LOCALSCALE ###############

	///<summary>transform.localScale-г авна</summary>
	public static Vector3 Tls(this Component a) {
		return a.gameObject.Tls();
	}

	///<summary>transform.localScale-г өөрчилнө</summary>
	public static void Tls(this Component a, Vector3 v) {
		a.gameObject.Tls(v);
	}

	///<summary>transform.localScale-г өөрчилнө</summary>
	public static void Tls(this Component a, float x, float y, float z) {
		a.gameObject.Tls(x, y, z);
	}

	///<summary>transform.localScale-н x-г өөрчилнө</summary>
	public static void TlsX(this Component a, float x) {
		a.gameObject.TlsX(x);
	}

	///<summary>transform.localScale-н y-г өөрчилнө</summary>
	public static void TlsY(this Component a, float y) {
		a.gameObject.TlsY(y);
	}

	///<summary>transform.localScale-н z-г өөрчилнө</summary>
	public static void TlsZ(this Component a, float z) {
		a.gameObject.TlsZ(z);
	}

	///<summary>transform.localScale-н x, y-г өөрчилнө</summary>
	public static void TlsXy(this Component a, float x, float y) {
		a.gameObject.TlsXy(x, y);
	}

	///<summary>transform.localScale-н x, z-г өөрчилнө</summary>
	public static void TlsXz(this Component a, float x, float z) {
		a.gameObject.TlsXz(x, z);
	}

	///<summary>transform.localScale-н y, z-г өөрчилнө</summary>
	public static void TlsYz(this Component a, float y, float z) {
		a.gameObject.TlsYz(y, z);
	}

	///<summary>transform.localScale-д v-г нэмнэ</summary>
	public static void TlsD(this Component a, Vector3 v) {
		a.gameObject.TlsD(v);
	}

	///<summary>transform.localScale-д x, y, z-г нэмнэ</summary>
	public static void TlsD(this Component a, float x, float y, float z) {
		a.gameObject.TlsD(x, y, z);
	}

	///<summary>transform.localScale-д x-г нэмнэ</summary>
	public static void TlsDx(this Component a, float x) {
		a.gameObject.TlsDx(x);
	}

	///<summary>transform.localScale-д y-г нэмнэ</summary>
	public static void TlsDy(this Component a, float y) {
		a.gameObject.TlsDy(y);
	}

	///<summary>transform.localScale-д z-г нэмнэ</summary>
	public static void TlsDz(this Component a, float z) {
		a.gameObject.TlsDz(z);
	}

	///<summary>transform.localScale-д x, y-г нэмнэ</summary>
	public static void TlsDxy(this Component a, float x, float y) {
		a.gameObject.TlsDxy(x, y);
	}

	///<summary>transform.localScale-д x, z-г нэмнэ</summary>
	public static void TlsDxz(this Component a, float x, float z) {
		a.gameObject.TlsDxz(x, z);
	}

	///<summary>transform.localScale-д y, z-г нэмнэ</summary>
	public static void TlsDyz(this Component a, float y, float z) {
		a.gameObject.TlsDyz(y, z);
	}

	// ############### TRANSFORM.EULERANGLES ###############

	///<summary>transform.eulerAngles-г авна</summary>
	public static Vector3 Te(this Component a) {
		return a.gameObject.Te();
	}

	///<summary>transform.eulerAngles-г өөрчилнө</summary>
	public static void Te(this Component a, Vector3 v) {
		a.gameObject.Te(v);
	}

	///<summary>transform.eulerAngles-г өөрчилнө</summary>
	public static void Te(this Component a, float x, float y, float z) {
		a.gameObject.Te(x, y, z);
	}

	///<summary>transform.eulerAngles-н x-г өөрчилнө</summary>
	public static void TeX(this Component a, float x) {
		a.gameObject.TeX(x);
	}

	///<summary>transform.eulerAngles-н y-г өөрчилнө</summary>
	public static void TeY(this Component a, float y) {
		a.gameObject.TeY(y);
	}

	///<summary>transform.eulerAngles-н z-г өөрчилнө</summary>
	public static void TeZ(this Component a, float z) {
		a.gameObject.TeZ(z);
	}

	///<summary>transform.eulerAngles-н x, y-г өөрчилнө</summary>
	public static void TeXy(this Component a, float x, float y) {
		a.gameObject.TeXy(x, y);
	}

	///<summary>transform.eulerAngles-н x, z-г өөрчилнө</summary>
	public static void TeXz(this Component a, float x, float z) {
		a.gameObject.TeXz(x, z);
	}

	///<summary>transform.eulerAngles-н y, z-г өөрчилнө</summary>
	public static void TeYz(this Component a, float y, float z) {
		a.gameObject.TeYz(y, z);
	}

	///<summary>transform.eulerAngles-д v-г нэмнэ</summary>
	public static void TeD(this Component a, Vector3 v) {
		a.gameObject.TeD(v);
	}

	///<summary>transform.eulerAngles-д x, y, z-г нэмнэ</summary>
	public static void TeD(this Component a, float x, float y, float z) {
		a.gameObject.TeD(x, y, z);
	}

	///<summary>transform.eulerAngles-д x-г нэмнэ</summary>
	public static void TeDx(this Component a, float x) {
		a.gameObject.TeDx(x);
	}

	///<summary>transform.eulerAngles-д y-г нэмнэ</summary>
	public static void TeDy(this Component a, float y) {
		a.gameObject.TeDy(y);
	}

	///<summary>transform.eulerAngles-д z-г нэмнэ</summary>
	public static void TeDz(this Component a, float z) {
		a.gameObject.TeDz(z);
	}

	///<summary>transform.eulerAngles-д x, y-г нэмнэ</summary>
	public static void TeDxy(this Component a, float x, float y) {
		a.gameObject.TeDxy(x, y);
	}

	///<summary>transform.eulerAngles-д x, z-г нэмнэ</summary>
	public static void TeDxz(this Component a, float x, float z) {
		a.gameObject.TeDxz(x, z);
	}

	///<summary>transform.eulerAngles-д y, z-г нэмнэ</summary>
	public static void TeDyz(this Component a, float y, float z) {
		a.gameObject.TeDyz(y, z);
	}

	// ############### TRANSFORM.LOCALEULERANGLES ###############

	///<summary>transform.localEulerAngles-г авна</summary>
	public static Vector3 Tle(this Component a) {
		return a.gameObject.Tle();
	}

	///<summary>transform.localEulerAngles-г өөрчилнө</summary>
	public static void Tle(this Component a, Vector3 v) {
		a.gameObject.Tle(v);
	}

	///<summary>transform.localEulerAngles-г өөрчилнө</summary>
	public static void Tle(this Component a, float x, float y, float z) {
		a.gameObject.Tle(x, y, z);
	}

	///<summary>transform.localEulerAngles-н x-г өөрчилнө</summary>
	public static void TleX(this Component a, float x) {
		a.gameObject.TleX(x);
	}

	///<summary>transform.localEulerAngles-н y-г өөрчилнө</summary>
	public static void TleY(this Component a, float y) {
		a.gameObject.TleY(y);
	}

	///<summary>transform.localEulerAngles-н z-г өөрчилнө</summary>
	public static void TleZ(this Component a, float z) {
		a.gameObject.TleZ(z);
	}

	///<summary>transform.localEulerAngles-н x, y-г өөрчилнө</summary>
	public static void TleXy(this Component a, float x, float y) {
		a.gameObject.TleXy(x, y);
	}

	///<summary>transform.localEulerAngles-н x, z-г өөрчилнө</summary>
	public static void TleXz(this Component a, float x, float z) {
		a.gameObject.TleXz(x, z);
	}

	///<summary>transform.localEulerAngles-н y, z-г өөрчилнө</summary>
	public static void TleYz(this Component a, float y, float z) {
		a.gameObject.TleYz(y, z);
	}

	///<summary>transform.localEulerAngles-д v-г нэмнэ</summary>
	public static void TleD(this Component a, Vector3 v) {
		a.gameObject.TleD(v);
	}

	///<summary>transform.localEulerAngles-д x, y, z-г нэмнэ</summary>
	public static void TleD(this Component a, float x, float y, float z) {
		a.gameObject.TleD(x, y, z);
	}

	///<summary>transform.localEulerAngles-д x-г нэмнэ</summary>
	public static void TleDx(this Component a, float x) {
		a.gameObject.TleDx(x);
	}

	///<summary>transform.localEulerAngles-д y-г нэмнэ</summary>
	public static void TleDy(this Component a, float y) {
		a.gameObject.TleDy(y);
	}

	///<summary>transform.localEulerAngles-д z-г нэмнэ</summary>
	public static void TleDz(this Component a, float z) {
		a.gameObject.TleDz(z);
	}

	///<summary>transform.localEulerAngles-д x, y-г нэмнэ</summary>
	public static void TleDxy(this Component a, float x, float y) {
		a.gameObject.TleDxy(x, y);
	}

	///<summary>transform.localEulerAngles-д x, z-г нэмнэ</summary>
	public static void TleDxz(this Component a, float x, float z) {
		a.gameObject.TleDxz(x, z);
	}

	///<summary>transform.localEulerAngles-д y, z-г нэмнэ</summary>
	public static void TleDyz(this Component a, float y, float z) {
		a.gameObject.TleDyz(y, z);
	}

}