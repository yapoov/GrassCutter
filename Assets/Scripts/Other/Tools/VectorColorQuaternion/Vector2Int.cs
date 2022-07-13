using UnityEngine;

public class V2I {

	///<summary>Vector2Int.left</summary>
	public static readonly Vector2Int l = Vector2Int.left;

	///<summary>Vector2Int.right</summary>
	public static readonly Vector2Int r = Vector2Int.right;

	///<summary>Vector2Int.down</summary>
	public static readonly Vector2Int d = Vector2Int.down;

	///<summary>Vector2Int.up</summary>
	public static readonly Vector2Int u = Vector2Int.up;

	///<summary>Vector2Int.zero</summary>
	public static readonly Vector2Int O = Vector2Int.zero;

	///<summary>Vector2Int.one</summary>
	public static readonly Vector2Int I = Vector2Int.one;

	///<summary>Vector2Int(-1, -1)</summary>
	public static readonly Vector2Int nn = new Vector2Int(-1, -1);

	///<summary>Vector2Int(-1, 0)</summary>
	public static readonly Vector2Int nz = new Vector2Int(-1, 0);

	///<summary>Vector2Int(-1, 1)</summary>
	public static readonly Vector2Int np = new Vector2Int(-1, 1);

	///<summary>Vector2Int(0, -1)</summary>
	public static readonly Vector2Int zn = new Vector2Int(0, -1);

	///<summary>Vector2Int(0, 0)</summary>
	public static readonly Vector2Int zz = new Vector2Int(0, 0);

	///<summary>Vector2Int(0, 1)</summary>
	public static readonly Vector2Int zp = new Vector2Int(0, 1);

	///<summary>Vector2Int(1, -1)</summary>
	public static readonly Vector2Int pn = new Vector2Int(1, -1);

	///<summary>Vector2Int(1, 0)</summary>
	public static readonly Vector2Int pz = new Vector2Int(1, 0);

	///<summary>Vector2Int(1, 1)</summary>
	public static readonly Vector2Int pp = new Vector2Int(1, 1);

	///<summary>Vector2Int x</summary>
	public static Vector2Int X(Vector2Int v, int  x) {
		return new Vector2Int(x, v.y);
	}

	///<summary>Vector2Int y</summary>
	public static Vector2Int Y(Vector2Int v, int  y) {
		return new Vector2Int(v.x, y);
	}

	///<summary>Vector2Int-г Vector2Int-д үржинэ</summary>
	public static Vector2Int Mul(Vector2Int a, Vector2Int b) {
		return Vector2Int.Scale(a, b);
	}

	///<summary>Vector2Int-г Vector2Int-д хуваана</summary>
	public static Vector2Int Div(Vector2Int a, Vector2Int b) {
		return new Vector2Int(a.x / b.x, a.y / b.y);
	}

}