using UnityEngine;

public class V3I {

	///<summary>Vector3Int.left</summary>
	public static readonly Vector3Int l = Vector3Int.left;

	///<summary>Vector3Int.right</summary>
	public static readonly Vector3Int r = Vector3Int.right;

	///<summary>Vector3Int.down</summary>
	public static readonly Vector3Int d = Vector3Int.down;

	///<summary>Vector3Int.up</summary>
	public static readonly Vector3Int u = Vector3Int.up;

	///<summary>Vector3Int.back</summary>
	public static readonly Vector3Int b = new Vector3Int(0, 0, -1);

	///<summary>Vector3Int.forward</summary>
	public static readonly Vector3Int f = new Vector3Int(0, 0, 1);

	///<summary>Vector3Int.zero</summary>
	public static readonly Vector3Int O = Vector3Int.zero;

	///<summary>Vector3Int.one</summary>
	public static readonly Vector3Int I = Vector3Int.one;

	///<summary>Vector3Int(-1, -1, -1)</summary>
	public static readonly Vector3Int nnn = new Vector3Int(-1, -1, -1);

	///<summary>Vector3Int(-1, -1, 0)</summary>
	public static readonly Vector3Int nnz = new Vector3Int(-1, -1, 0);

	///<summary>Vector3Int(-1, -1, 1)</summary>
	public static readonly Vector3Int nnp = new Vector3Int(-1, -1, 1);

	///<summary>Vector3Int(-1, 0, -1)</summary>
	public static readonly Vector3Int nzn = new Vector3Int(-1, 0, -1);

	///<summary>Vector3Int(-1, 0, 0)</summary>
	public static readonly Vector3Int nzz = new Vector3Int(-1, 0, 0);

	///<summary>Vector3Int(-1, 0, 1)</summary>
	public static readonly Vector3Int nzp = new Vector3Int(-1, 0, 1);

	///<summary>Vector3Int(-1, 1, -1)</summary>
	public static readonly Vector3Int npn = new Vector3Int(-1, 1, -1);

	///<summary>Vector3Int(-1, 1, 0)</summary>
	public static readonly Vector3Int npz = new Vector3Int(-1, 1, 0);

	///<summary>Vector3Int(-1, 1, 1)</summary>
	public static readonly Vector3Int npp = new Vector3Int(-1, 1, 1);

	///<summary>Vector3Int(0, -1, -1)</summary>
	public static readonly Vector3Int znn = new Vector3Int(0, -1, -1);

	///<summary>Vector3Int(0, -1, 0)</summary>
	public static readonly Vector3Int znz = new Vector3Int(0, -1, 0);

	///<summary>Vector3Int(0, -1, 1)</summary>
	public static readonly Vector3Int znp = new Vector3Int(0, -1, 1);

	///<summary>Vector3Int(0, 0, -1)</summary>
	public static readonly Vector3Int zzn = new Vector3Int(0, 0, -1);

	///<summary>Vector3Int(0, 0, 0)</summary>
	public static readonly Vector3Int zzz = new Vector3Int(0, 0, 0);

	///<summary>Vector3Int(0, 0, 1)</summary>
	public static readonly Vector3Int zzp = new Vector3Int(0, 0, 1);

	///<summary>Vector3Int(0, 1, -1)</summary>
	public static readonly Vector3Int zpn = new Vector3Int(0, 1, -1);

	///<summary>Vector3Int(0, 1, 0)</summary>
	public static readonly Vector3Int zpz = new Vector3Int(0, 1, 0);

	///<summary>Vector3Int(0, 1, 1)</summary>
	public static readonly Vector3Int zpp = new Vector3Int(0, 1, 1);

	///<summary>Vector3Int(1, -1, -1)</summary>
	public static readonly Vector3Int pnn = new Vector3Int(1, -1, -1);

	///<summary>Vector3Int(1, -1, 0)</summary>
	public static readonly Vector3Int pnz = new Vector3Int(1, -1, 0);

	///<summary>Vector3Int(1, -1, 1)</summary>
	public static readonly Vector3Int pnp = new Vector3Int(1, -1, 1);

	///<summary>Vector3Int(1, 0, -1)</summary>
	public static readonly Vector3Int pzn = new Vector3Int(1, 0, -1);

	///<summary>Vector3Int(1, 0, 0)</summary>
	public static readonly Vector3Int pzz = new Vector3Int(1, 0, 0);

	///<summary>Vector3Int(1, 0, 1)</summary>
	public static readonly Vector3Int pzp = new Vector3Int(1, 0, 1);

	///<summary>Vector3Int(1, 1, -1)</summary>
	public static readonly Vector3Int ppn = new Vector3Int(1, 1, -1);

	///<summary>Vector3Int(1, 1, 0)</summary>
	public static readonly Vector3Int ppz = new Vector3Int(1, 1, 0);

	///<summary>Vector3Int(1, 1, 1)</summary>
	public static readonly Vector3Int ppp = new Vector3Int(1, 1, 1);

	///<summary>Vector3Int x</summary>
	public static Vector3Int X(Vector3Int v, int  x) {
		return new Vector3Int(x, v.y, v.z);
	}

	///<summary>Vector3Int y</summary>
	public static Vector3Int Y(Vector3Int v, int  y) {
		return new Vector3Int(v.x, y, v.z);
	}

	///<summary>Vector3Int z</summary>
	public static Vector3Int Z(Vector3Int v, int  z) {
		return new Vector3Int(v.x, v.y, z);
	}

	///<summary>Vector3Int x y</summary>
	public static Vector3Int Xy(Vector3Int v, int  x, int  y) {
		return new Vector3Int(x, y, v.z);
	}

	///<summary>Vector3Int x z</summary>
	public static Vector3Int Xz(Vector3Int v, int  x, int  z) {
		return new Vector3Int(x, v.y, z);
	}

	///<summary>Vector3Int y z</summary>
	public static Vector3Int Yz(Vector3Int v, int  y, int  z) {
		return new Vector3Int(v.x, y, z);
	}

	///<summary>Vector3Int-г Vector3Int-д үржинэ</summary>
	public static Vector3Int Mul(Vector3Int a, Vector3Int b) {
		return Vector3Int.Scale(a, b);
	}

	///<summary>Vector3Int-г Vector3Int-д хуваана</summary>
	public static Vector3Int Div(Vector3Int a, Vector3Int b) {
		return new Vector3Int(a.x / b.x, a.y / b.y, a.z / b.z);
	}

}