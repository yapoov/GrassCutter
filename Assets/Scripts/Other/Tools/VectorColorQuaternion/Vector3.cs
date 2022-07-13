using UnityEngine;

public partial class V3 {

	///<summary>Vector3.left</summary>
	public static readonly Vector3 l = Vector3.left;

	///<summary>Vector3.right</summary>
	public static readonly Vector3 r = Vector3.right;

	///<summary>Vector3.down</summary>
	public static readonly Vector3 d = Vector3.down;

	///<summary>Vector3.up</summary>
	public static readonly Vector3 u = Vector3.up;

	///<summary>Vector3.back</summary>
	public static readonly Vector3 b = Vector3.back;

	///<summary>Vector3.forward</summary>
	public static readonly Vector3 f = Vector3.forward;

	///<summary>Vector3.zero</summary>
	public static readonly Vector3 O = Vector3.zero;

	///<summary>Vector3.one</summary>
	public static readonly Vector3 I = Vector3.one;

	///<summary>Vector3.negativeInfinity</summary>
	public static readonly Vector3 negInf = Vector3.negativeInfinity;

	///<summary>Vector3.positiveInfinity</summary>
	public static readonly Vector3 posInf = Vector3.positiveInfinity;

	///<summary>Vector3(-1, -1, -1)</summary>
	public static readonly Vector3 nnn = new Vector3(-1, -1, -1);

	///<summary>Vector3(-1, -1, 0)</summary>
	public static readonly Vector3 nnz = new Vector3(-1, -1, 0);

	///<summary>Vector3(-1, -1, 1)</summary>
	public static readonly Vector3 nnp = new Vector3(-1, -1, 1);

	///<summary>Vector3(-1, 0, -1)</summary>
	public static readonly Vector3 nzn = new Vector3(-1, 0, -1);

	///<summary>Vector3(-1, 0, 0)</summary>
	public static readonly Vector3 nzz = new Vector3(-1, 0, 0);

	///<summary>Vector3(-1, 0, 1)</summary>
	public static readonly Vector3 nzp = new Vector3(-1, 0, 1);

	///<summary>Vector3(-1, 1, -1)</summary>
	public static readonly Vector3 npn = new Vector3(-1, 1, -1);

	///<summary>Vector3(-1, 1, 0)</summary>
	public static readonly Vector3 npz = new Vector3(-1, 1, 0);

	///<summary>Vector3(-1, 1, 1)</summary>
	public static readonly Vector3 npp = new Vector3(-1, 1, 1);

	///<summary>Vector3(0, -1, -1)</summary>
	public static readonly Vector3 znn = new Vector3(0, -1, -1);

	///<summary>Vector3(0, -1, 0)</summary>
	public static readonly Vector3 znz = new Vector3(0, -1, 0);

	///<summary>Vector3(0, -1, 1)</summary>
	public static readonly Vector3 znp = new Vector3(0, -1, 1);

	///<summary>Vector3(0, 0, -1)</summary>
	public static readonly Vector3 zzn = new Vector3(0, 0, -1);

	///<summary>Vector3(0, 0, 0)</summary>
	public static readonly Vector3 zzz = new Vector3(0, 0, 0);

	///<summary>Vector3(0, 0, 1)</summary>
	public static readonly Vector3 zzp = new Vector3(0, 0, 1);

	///<summary>Vector3(0, 1, -1)</summary>
	public static readonly Vector3 zpn = new Vector3(0, 1, -1);

	///<summary>Vector3(0, 1, 0)</summary>
	public static readonly Vector3 zpz = new Vector3(0, 1, 0);

	///<summary>Vector3(0, 1, 1)</summary>
	public static readonly Vector3 zpp = new Vector3(0, 1, 1);

	///<summary>Vector3(1, -1, -1)</summary>
	public static readonly Vector3 pnn = new Vector3(1, -1, -1);

	///<summary>Vector3(1, -1, 0)</summary>
	public static readonly Vector3 pnz = new Vector3(1, -1, 0);

	///<summary>Vector3(1, -1, 1)</summary>
	public static readonly Vector3 pnp = new Vector3(1, -1, 1);

	///<summary>Vector3(1, 0, -1)</summary>
	public static readonly Vector3 pzn = new Vector3(1, 0, -1);

	///<summary>Vector3(1, 0, 0)</summary>
	public static readonly Vector3 pzz = new Vector3(1, 0, 0);

	///<summary>Vector3(1, 0, 1)</summary>
	public static readonly Vector3 pzp = new Vector3(1, 0, 1);

	///<summary>Vector3(1, 1, -1)</summary>
	public static readonly Vector3 ppn = new Vector3(1, 1, -1);

	///<summary>Vector3(1, 1, 0)</summary>
	public static readonly Vector3 ppz = new Vector3(1, 1, 0);

	///<summary>Vector3(1, 1, 1)</summary>
	public static readonly Vector3 ppp = new Vector3(1, 1, 1);

	///<summary>Vector3 x</summary>
	public static Vector3 X(Vector3 v, float x) {
		return new Vector3(x, v.y, v.z);
	}

	///<summary>Vector3 y</summary>
	public static Vector3 Y(Vector3 v, float y) {
		return new Vector3(v.x, y, v.z);
	}

	///<summary>Vector3 z</summary>
	public static Vector3 Z(Vector3 v, float z) {
		return new Vector3(v.x, v.y, z);
	}

	///<summary>Vector3 x y</summary>
	public static Vector3 Xy(Vector3 v, float x, float y) {
		return new Vector3(x, y, v.z);
	}

	///<summary>Vector3 x z</summary>
	public static Vector3 Xz(Vector3 v, float x, float z) {
		return new Vector3(x, v.y, z);
	}

	///<summary>Vector3 y z</summary>
	public static Vector3 Yz(Vector3 v, float y, float z) {
		return new Vector3(v.x, y, z);
	}

	///<summary>Vector3-г Vector3-д үржинэ</summary>
	public static Vector3 Mul(Vector3 a, Vector3 b) {
		return Vector3.Scale(a, b);
	}

	///<summary>Vector3-г Vector3-д хуваана</summary>
	public static Vector3 Div(Vector3 a, Vector3 b) {
		return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
	}

}