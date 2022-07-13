using UnityEngine;

public class V2 {

	///<summary>Vector2.left</summary>
	public static readonly Vector2 l = Vector2.left;

	///<summary>Vector2.right</summary>
	public static readonly Vector2 r = Vector2.right;

	///<summary>Vector2.down</summary>
	public static readonly Vector2 d = Vector2.down;

	///<summary>Vector2.up</summary>
	public static readonly Vector2 u = Vector2.up;

	///<summary>Vector2.zero</summary>
	public static readonly Vector2 O = Vector2.zero;

	///<summary>Vector2.one</summary>
	public static readonly Vector2 I = Vector2.one;

	///<summary>Vector2.negativeInfinity</summary>
	public static readonly Vector2 negInf = Vector2.negativeInfinity;

	///<summary>Vector2.positiveInfinity</summary>
	public static readonly Vector2 posInf = Vector2.positiveInfinity;

	///<summary>Vector2(-1, -1)</summary>
	public static readonly Vector2 nn = new Vector2(-1, -1);

	///<summary>Vector2(-1, 0)</summary>
	public static readonly Vector2 nz = new Vector2(-1, 0);

	///<summary>Vector2(-1, 1)</summary>
	public static readonly Vector2 np = new Vector2(-1, 1);

	///<summary>Vector2(0, -1)</summary>
	public static readonly Vector2 zn = new Vector2(0, -1);

	///<summary>Vector2(0, 0)</summary>
	public static readonly Vector2 zz = new Vector2(0, 0);

	///<summary>Vector2(0, 1)</summary>
	public static readonly Vector2 zp = new Vector2(0, 1);

	///<summary>Vector2(1, -1)</summary>
	public static readonly Vector2 pn = new Vector2(1, -1);

	///<summary>Vector2(1, 0)</summary>
	public static readonly Vector2 pz = new Vector2(1, 0);

	///<summary>Vector2(1, 1)</summary>
	public static readonly Vector2 pp = new Vector2(1, 1);

	///<summary>Vector2 x</summary>
	public static Vector2 X(Vector2 v, float x) {
		return new Vector2(x, v.y);
	}

	///<summary>Vector2 y</summary>
	public static Vector2 Y(Vector2 v, float y) {
		return new Vector2(v.x, y);
	}

	///<summary>Vector2-г Vector2-д үржинэ</summary>
	public static Vector2 Mul(Vector2 a, Vector2 b) {
		return Vector2.Scale(a, b);
	}

	///<summary>Vector2-г Vector2-д хуваана</summary>
	public static Vector2 Div(Vector2 a, Vector2 b) {
		return new Vector2(a.x / b.x, a.y / b.y);
	}

}