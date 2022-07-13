using UnityEngine;

public class V4 {

	///<summary>Vector4.zero</summary>
	public static readonly Vector4 O = Vector4.zero;

	///<summary>Vector4.one</summary>
	public static readonly Vector4 I = Vector4.one;

	///<summary>Vector4.negativeInfinity</summary>
	public static readonly Vector4 negInf = Vector4.negativeInfinity;

	///<summary>Vector4.positiveInfinity</summary>
	public static readonly Vector4 posInf = Vector4.positiveInfinity;

	///<summary>Vector4(-1, -1, -1, -1)</summary>
	public static readonly Vector4 nnnn = new Vector4(-1, -1, -1, -1);

	///<summary>Vector4(-1, -1, -1, 0)</summary>
	public static readonly Vector4 nnnz = new Vector4(-1, -1, -1, 0);

	///<summary>Vector4(-1, -1, -1, 1)</summary>
	public static readonly Vector4 nnnp = new Vector4(-1, -1, -1, 1);

	///<summary>Vector4(-1, -1, 0, -1)</summary>
	public static readonly Vector4 nnzn = new Vector4(-1, -1, 0, -1);

	///<summary>Vector4(-1, -1, 0, 0)</summary>
	public static readonly Vector4 nnzz = new Vector4(-1, -1, 0, 0);

	///<summary>Vector4(-1, -1, 0, 1)</summary>
	public static readonly Vector4 nnzp = new Vector4(-1, -1, 0, 1);

	///<summary>Vector4(-1, -1, 1, -1)</summary>
	public static readonly Vector4 nnpn = new Vector4(-1, -1, 1, -1);

	///<summary>Vector4(-1, -1, 1, 0)</summary>
	public static readonly Vector4 nnpz = new Vector4(-1, -1, 1, 0);

	///<summary>Vector4(-1, -1, 1, 1)</summary>
	public static readonly Vector4 nnpp = new Vector4(-1, -1, 1, 1);

	///<summary>Vector4(-1, 0, -1, -1)</summary>
	public static readonly Vector4 nznn = new Vector4(-1, 0, -1, -1);

	///<summary>Vector4(-1, 0, -1, 0)</summary>
	public static readonly Vector4 nznz = new Vector4(-1, 0, -1, 0);

	///<summary>Vector4(-1, 0, -1, 1)</summary>
	public static readonly Vector4 nznp = new Vector4(-1, 0, -1, 1);

	///<summary>Vector4(-1, 0, 0, -1)</summary>
	public static readonly Vector4 nzzn = new Vector4(-1, 0, 0, -1);

	///<summary>Vector4(-1, 0, 0, 0)</summary>
	public static readonly Vector4 nzzz = new Vector4(-1, 0, 0, 0);

	///<summary>Vector4(-1, 0, 0, 1)</summary>
	public static readonly Vector4 nzzp = new Vector4(-1, 0, 0, 1);

	///<summary>Vector4(-1, 0, 1, -1)</summary>
	public static readonly Vector4 nzpn = new Vector4(-1, 0, 1, -1);

	///<summary>Vector4(-1, 0, 1, 0)</summary>
	public static readonly Vector4 nzpz = new Vector4(-1, 0, 1, 0);

	///<summary>Vector4(-1, 0, 1, 1)</summary>
	public static readonly Vector4 nzpp = new Vector4(-1, 0, 1, 1);

	///<summary>Vector4(-1, 1, -1, -1)</summary>
	public static readonly Vector4 npnn = new Vector4(-1, 1, -1, -1);

	///<summary>Vector4(-1, 1, -1, 0)</summary>
	public static readonly Vector4 npnz = new Vector4(-1, 1, -1, 0);

	///<summary>Vector4(-1, 1, -1, 1)</summary>
	public static readonly Vector4 npnp = new Vector4(-1, 1, -1, 1);

	///<summary>Vector4(-1, 1, 0, -1)</summary>
	public static readonly Vector4 npzn = new Vector4(-1, 1, 0, -1);

	///<summary>Vector4(-1, 1, 0, 0)</summary>
	public static readonly Vector4 npzz = new Vector4(-1, 1, 0, 0);

	///<summary>Vector4(-1, 1, 0, 1)</summary>
	public static readonly Vector4 npzp = new Vector4(-1, 1, 0, 1);

	///<summary>Vector4(-1, 1, 1, -1)</summary>
	public static readonly Vector4 nppn = new Vector4(-1, 1, 1, -1);

	///<summary>Vector4(-1, 1, 1, 0)</summary>
	public static readonly Vector4 nppz = new Vector4(-1, 1, 1, 0);

	///<summary>Vector4(-1, 1, 1, 1)</summary>
	public static readonly Vector4 nppp = new Vector4(-1, 1, 1, 1);

	///<summary>Vector4(0, -1, -1, -1)</summary>
	public static readonly Vector4 znnn = new Vector4(0, -1, -1, -1);

	///<summary>Vector4(0, -1, -1, 0)</summary>
	public static readonly Vector4 znnz = new Vector4(0, -1, -1, 0);

	///<summary>Vector4(0, -1, -1, 1)</summary>
	public static readonly Vector4 znnp = new Vector4(0, -1, -1, 1);

	///<summary>Vector4(0, -1, 0, -1)</summary>
	public static readonly Vector4 znzn = new Vector4(0, -1, 0, -1);

	///<summary>Vector4(0, -1, 0, 0)</summary>
	public static readonly Vector4 znzz = new Vector4(0, -1, 0, 0);

	///<summary>Vector4(0, -1, 0, 1)</summary>
	public static readonly Vector4 znzp = new Vector4(0, -1, 0, 1);

	///<summary>Vector4(0, -1, 1, -1)</summary>
	public static readonly Vector4 znpn = new Vector4(0, -1, 1, -1);

	///<summary>Vector4(0, -1, 1, 0)</summary>
	public static readonly Vector4 znpz = new Vector4(0, -1, 1, 0);

	///<summary>Vector4(0, -1, 1, 1)</summary>
	public static readonly Vector4 znpp = new Vector4(0, -1, 1, 1);

	///<summary>Vector4(0, 0, -1, -1)</summary>
	public static readonly Vector4 zznn = new Vector4(0, 0, -1, -1);

	///<summary>Vector4(0, 0, -1, 0)</summary>
	public static readonly Vector4 zznz = new Vector4(0, 0, -1, 0);

	///<summary>Vector4(0, 0, -1, 1)</summary>
	public static readonly Vector4 zznp = new Vector4(0, 0, -1, 1);

	///<summary>Vector4(0, 0, 0, -1)</summary>
	public static readonly Vector4 zzzn = new Vector4(0, 0, 0, -1);

	///<summary>Vector4(0, 0, 0, 0)</summary>
	public static readonly Vector4 zzzz = new Vector4(0, 0, 0, 0);

	///<summary>Vector4(0, 0, 0, 1)</summary>
	public static readonly Vector4 zzzp = new Vector4(0, 0, 0, 1);

	///<summary>Vector4(0, 0, 1, -1)</summary>
	public static readonly Vector4 zzpn = new Vector4(0, 0, 1, -1);

	///<summary>Vector4(0, 0, 1, 0)</summary>
	public static readonly Vector4 zzpz = new Vector4(0, 0, 1, 0);

	///<summary>Vector4(0, 0, 1, 1)</summary>
	public static readonly Vector4 zzpp = new Vector4(0, 0, 1, 1);

	///<summary>Vector4(0, 1, -1, -1)</summary>
	public static readonly Vector4 zpnn = new Vector4(0, 1, -1, -1);

	///<summary>Vector4(0, 1, -1, 0)</summary>
	public static readonly Vector4 zpnz = new Vector4(0, 1, -1, 0);

	///<summary>Vector4(0, 1, -1, 1)</summary>
	public static readonly Vector4 zpnp = new Vector4(0, 1, -1, 1);

	///<summary>Vector4(0, 1, 0, -1)</summary>
	public static readonly Vector4 zpzn = new Vector4(0, 1, 0, -1);

	///<summary>Vector4(0, 1, 0, 0)</summary>
	public static readonly Vector4 zpzz = new Vector4(0, 1, 0, 0);

	///<summary>Vector4(0, 1, 0, 1)</summary>
	public static readonly Vector4 zpzp = new Vector4(0, 1, 0, 1);

	///<summary>Vector4(0, 1, 1, -1)</summary>
	public static readonly Vector4 zppn = new Vector4(0, 1, 1, -1);

	///<summary>Vector4(0, 1, 1, 0)</summary>
	public static readonly Vector4 zppz = new Vector4(0, 1, 1, 0);

	///<summary>Vector4(0, 1, 1, 1)</summary>
	public static readonly Vector4 zppp = new Vector4(0, 1, 1, 1);

	///<summary>Vector4(1, -1, -1, -1)</summary>
	public static readonly Vector4 pnnn = new Vector4(1, -1, -1, -1);

	///<summary>Vector4(1, -1, -1, 0)</summary>
	public static readonly Vector4 pnnz = new Vector4(1, -1, -1, 0);

	///<summary>Vector4(1, -1, -1, 1)</summary>
	public static readonly Vector4 pnnp = new Vector4(1, -1, -1, 1);

	///<summary>Vector4(1, -1, 0, -1)</summary>
	public static readonly Vector4 pnzn = new Vector4(1, -1, 0, -1);

	///<summary>Vector4(1, -1, 0, 0)</summary>
	public static readonly Vector4 pnzz = new Vector4(1, -1, 0, 0);

	///<summary>Vector4(1, -1, 0, 1)</summary>
	public static readonly Vector4 pnzp = new Vector4(1, -1, 0, 1);

	///<summary>Vector4(1, -1, 1, -1)</summary>
	public static readonly Vector4 pnpn = new Vector4(1, -1, 1, -1);

	///<summary>Vector4(1, -1, 1, 0)</summary>
	public static readonly Vector4 pnpz = new Vector4(1, -1, 1, 0);

	///<summary>Vector4(1, -1, 1, 1)</summary>
	public static readonly Vector4 pnpp = new Vector4(1, -1, 1, 1);

	///<summary>Vector4(1, 0, -1, -1)</summary>
	public static readonly Vector4 pznn = new Vector4(1, 0, -1, -1);

	///<summary>Vector4(1, 0, -1, 0)</summary>
	public static readonly Vector4 pznz = new Vector4(1, 0, -1, 0);

	///<summary>Vector4(1, 0, -1, 1)</summary>
	public static readonly Vector4 pznp = new Vector4(1, 0, -1, 1);

	///<summary>Vector4(1, 0, 0, -1)</summary>
	public static readonly Vector4 pzzn = new Vector4(1, 0, 0, -1);

	///<summary>Vector4(1, 0, 0, 0)</summary>
	public static readonly Vector4 pzzz = new Vector4(1, 0, 0, 0);

	///<summary>Vector4(1, 0, 0, 1)</summary>
	public static readonly Vector4 pzzp = new Vector4(1, 0, 0, 1);

	///<summary>Vector4(1, 0, 1, -1)</summary>
	public static readonly Vector4 pzpn = new Vector4(1, 0, 1, -1);

	///<summary>Vector4(1, 0, 1, 0)</summary>
	public static readonly Vector4 pzpz = new Vector4(1, 0, 1, 0);

	///<summary>Vector4(1, 0, 1, 1)</summary>
	public static readonly Vector4 pzpp = new Vector4(1, 0, 1, 1);

	///<summary>Vector4(1, 1, -1, -1)</summary>
	public static readonly Vector4 ppnn = new Vector4(1, 1, -1, -1);

	///<summary>Vector4(1, 1, -1, 0)</summary>
	public static readonly Vector4 ppnz = new Vector4(1, 1, -1, 0);

	///<summary>Vector4(1, 1, -1, 1)</summary>
	public static readonly Vector4 ppnp = new Vector4(1, 1, -1, 1);

	///<summary>Vector4(1, 1, 0, -1)</summary>
	public static readonly Vector4 ppzn = new Vector4(1, 1, 0, -1);

	///<summary>Vector4(1, 1, 0, 0)</summary>
	public static readonly Vector4 ppzz = new Vector4(1, 1, 0, 0);

	///<summary>Vector4(1, 1, 0, 1)</summary>
	public static readonly Vector4 ppzp = new Vector4(1, 1, 0, 1);

	///<summary>Vector4(1, 1, 1, -1)</summary>
	public static readonly Vector4 pppn = new Vector4(1, 1, 1, -1);

	///<summary>Vector4(1, 1, 1, 0)</summary>
	public static readonly Vector4 pppz = new Vector4(1, 1, 1, 0);

	///<summary>Vector4(1, 1, 1, 1)</summary>
	public static readonly Vector4 pppp = new Vector4(1, 1, 1, 1);

	///<summary>Vector4 x</summary>
	public static Vector4 X(Vector4 v, float x) {
		return new Vector4(x, v.y, v.z, v.w);
	}

	///<summary>Vector4 y</summary>
	public static Vector4 Y(Vector4 v, float y) {
		return new Vector4(v.x, y, v.z, v.w);
	}

	///<summary>Vector4 z</summary>
	public static Vector4 Z(Vector4 v, float z) {
		return new Vector4(v.x, v.y, z, v.w);
	}

	///<summary>Vector4 w</summary>
	public static Vector4 W(Vector4 v, float w) {
		return new Vector4(v.x, v.y, v.z, w);
	}

	///<summary>Vector4 x y</summary>
	public static Vector4 Xy(Vector4 v, float x, float y) {
		return new Vector4(x, y, v.z, v.w);
	}

	///<summary>Vector4 x z</summary>
	public static Vector4 Xz(Vector4 v, float x, float z) {
		return new Vector4(x, v.y, z, v.w);
	}

	///<summary>Vector4 x w</summary>
	public static Vector4 Xw(Vector4 v, float x, float w) {
		return new Vector4(x, v.y, v.z, w);
	}

	///<summary>Vector4 y z</summary>
	public static Vector4 Yz(Vector4 v, float y, float z) {
		return new Vector4(v.x, y, z, v.w);
	}

	///<summary>Vector4 y w</summary>
	public static Vector4 Yw(Vector4 v, float y, float w) {
		return new Vector4(v.x, y, v.z, w);
	}

	///<summary>Vector4 z w</summary>
	public static Vector4 Zw(Vector4 v, float z, float w) {
		return new Vector4(v.x, v.y, z, w);
	}

	///<summary>Vector4 x y z</summary>
	public static Vector4 Xyz(Vector4 v, float x, float y, float z) {
		return new Vector4(x, y, z, v.w);
	}

	///<summary>Vector4 x y w</summary>
	public static Vector4 Xyw(Vector4 v, float x, float y, float w) {
		return new Vector4(x, y, v.z, w);
	}

	///<summary>Vector4 x z w</summary>
	public static Vector4 Xzw(Vector4 v, float x, float z, float w) {
		return new Vector4(x, v.y, z, w);
	}

	///<summary>Vector4 y z w</summary>
	public static Vector4 Yzw(Vector4 v, float y, float z, float w) {
		return new Vector4(v.x, y, z, w);
	}

	///<summary>Vector4-г Vector4-д үржинэ</summary>
	public static Vector4 Mul(Vector4 a, Vector4 b) {
		return Vector4.Scale(a, b);
	}

	///<summary>Vector4-г Vector4-д хуваана</summary>
	public static Vector4 Div(Vector4 a, Vector4 b) {
		return new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
	}

}