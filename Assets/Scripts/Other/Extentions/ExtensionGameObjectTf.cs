using UnityEngine;

public static partial class ExtensionGameObject {

	// ############### TRANSFORM.POSITION ###############

	///<summary>transform.position-г авна</summary>
	public static Vector3 Tp(this GameObject a) {
		return a.transform.position;
	}

	///<summary>transform.position-г өөрчилнө</summary>
	public static void Tp(this GameObject a, Vector3 v) {
		a.transform.position = v;
	}

	///<summary>transform.position-г өөрчилнө</summary>
	public static void Tp(this GameObject a, float x, float y, float z) {
		a.transform.position = new Vector3(x, y, z);
	}

	///<summary>transform.position-н x-г өөрчилнө</summary>
	public static void TpX(this GameObject a, float x) {
		a.transform.position = V3.X(a.transform.position, x);
	}

	///<summary>transform.position-н y-г өөрчилнө</summary>
	public static void TpY(this GameObject a, float y) {
		a.transform.position = V3.Y(a.transform.position, y);
	}

	///<summary>transform.position-н z-г өөрчилнө</summary>
	public static void TpZ(this GameObject a, float z) {
		a.transform.position = V3.Z(a.transform.position, z);
	}

	///<summary>transform.position-н x, y-г өөрчилнө</summary>
	public static void TpXy(this GameObject a, float x, float y) {
		a.transform.position = V3.Xy(a.transform.position, x, y);
	}

	///<summary>transform.position-н x, z-г өөрчилнө</summary>
	public static void TpXz(this GameObject a, float x, float z) {
		a.transform.position = V3.Xz(a.transform.position, x, z);
	}

	///<summary>transform.position-н y, z-г өөрчилнө</summary>
	public static void TpYz(this GameObject a, float y, float z) {
		a.transform.position = V3.Yz(a.transform.position, y, z);
	}

	///<summary>transform.position-д v-г нэмнэ</summary>
	public static void TpD(this GameObject a, Vector3 v) {
		a.transform.position += v;
	}

	///<summary>transform.position-д x, y, z-г нэмнэ</summary>
	public static void TpD(this GameObject a, float x, float y, float z) {
		a.transform.position += new Vector3(x, y, z);
	}

	///<summary>transform.position-д x-г нэмнэ</summary>
	public static void TpDx(this GameObject a, float x) {
		a.transform.position += new Vector3(x, 0, 0);
	}

	///<summary>transform.position-д y-г нэмнэ</summary>
	public static void TpDy(this GameObject a, float y) {
		a.transform.position += new Vector3(0, y, 0);
	}

	///<summary>transform.position-д z-г нэмнэ</summary>
	public static void TpDz(this GameObject a, float z) {
		a.transform.position += new Vector3(0, 0, z);
	}

	///<summary>transform.position-д x, y-г нэмнэ</summary>
	public static void TpDxy(this GameObject a, float x, float y) {
		a.transform.position += new Vector3(x, y, 0);
	}

	///<summary>transform.position-д x, z-г нэмнэ</summary>
	public static void TpDxz(this GameObject a, float x, float z) {
		a.transform.position += new Vector3(x, 0, z);
	}

	///<summary>transform.position-д y, z-г нэмнэ</summary>
	public static void TpDyz(this GameObject a, float y, float z) {
		a.transform.position += new Vector3(0, y, z);
	}

	// ############### TRANSFORM.LOCALPOSITION ###############

	///<summary>transform.localPosition-г авна</summary>
	public static Vector3 Tlp(this GameObject a) {
		return a.transform.localPosition;
	}

	///<summary>transform.localPosition-г өөрчилнө</summary>
	public static void Tlp(this GameObject a, Vector3 v) {
		a.transform.localPosition = v;
	}

	///<summary>transform.localPosition-г өөрчилнө</summary>
	public static void Tlp(this GameObject a, float x, float y, float z) {
		a.transform.localPosition = new Vector3(x, y, z);
	}

	///<summary>transform.localPosition-н x-г өөрчилнө</summary>
	public static void TlpX(this GameObject a, float x) {
		a.transform.localPosition = V3.X(a.transform.localPosition, x);
	}

	///<summary>transform.localPosition-н y-г өөрчилнө</summary>
	public static void TlpY(this GameObject a, float y) {
		a.transform.localPosition = V3.Y(a.transform.localPosition, y);
	}

	///<summary>transform.localPosition-н z-г өөрчилнө</summary>
	public static void TlpZ(this GameObject a, float z) {
		a.transform.localPosition = V3.Z(a.transform.localPosition, z);
	}

	///<summary>transform.localPosition-н x, y-г өөрчилнө</summary>
	public static void TlpXy(this GameObject a, float x, float y) {
		a.transform.localPosition = V3.Xy(a.transform.localPosition, x, y);
	}

	///<summary>transform.localPosition-н x, z-г өөрчилнө</summary>
	public static void TlpXz(this GameObject a, float x, float z) {
		a.transform.localPosition = V3.Xz(a.transform.localPosition, x, z);
	}

	///<summary>transform.localPosition-н y, z-г өөрчилнө</summary>
	public static void TlpYz(this GameObject a, float y, float z) {
		a.transform.localPosition = V3.Yz(a.transform.localPosition, y, z);
	}

	///<summary>transform.localPosition-д v-г нэмнэ</summary>
	public static void TlpD(this GameObject a, Vector3 v) {
		a.transform.localPosition += v;
	}

	///<summary>transform.localPosition-д x, y, z-г нэмнэ</summary>
	public static void TlpD(this GameObject a, float x, float y, float z) {
		a.transform.localPosition += new Vector3(x, y, z);
	}

	///<summary>transform.localPosition-д x-г нэмнэ</summary>
	public static void TlpDx(this GameObject a, float x) {
		a.transform.localPosition += new Vector3(x, 0, 0);
	}

	///<summary>transform.localPosition-д y-г нэмнэ</summary>
	public static void TlpDy(this GameObject a, float y) {
		a.transform.localPosition += new Vector3(0, y, 0);
	}

	///<summary>transform.localPosition-д z-г нэмнэ</summary>
	public static void TlpDz(this GameObject a, float z) {
		a.transform.localPosition += new Vector3(0, 0, z);
	}

	///<summary>transform.localPosition-д x, y-г нэмнэ</summary>
	public static void TlpDxy(this GameObject a, float x, float y) {
		a.transform.localPosition += new Vector3(x, y, 0);
	}

	///<summary>transform.localPosition-д x, z-г нэмнэ</summary>
	public static void TlpDxz(this GameObject a, float x, float z) {
		a.transform.localPosition += new Vector3(x, 0, z);
	}

	///<summary>transform.localPosition-д y, z-г нэмнэ</summary>
	public static void TlpDyz(this GameObject a, float y, float z) {
		a.transform.localPosition += new Vector3(0, y, z);
	}

	// ############### TRANSFORM.ROTATION ###############

	///<summary>transform.rotation-г авна</summary>
	public static Quaternion Tr(this GameObject a) {
		return a.transform.rotation;
	}

	///<summary>transform.rotation-г өөрчилнө</summary>
	public static void Tr(this GameObject a, Quaternion v) {
		a.transform.rotation = v;
	}

	// ############### TRANSFORM.LOCALROTATION ###############

	///<summary>transform.localRotation-г авна</summary>
	public static Quaternion Tlr(this GameObject a) {
		return a.transform.localRotation;
	}

	///<summary>transform.localRotation-г өөрчилнө</summary>
	public static void Tlr(this GameObject a, Quaternion v) {
		a.transform.localRotation = v;
	}

	// ############### TRANSFORM.LOSSYSCALE ###############

	///<summary>transform.lossyScale-г авна</summary>
	public static Vector3 Ts(this GameObject a) {
		return a.transform.lossyScale;
	}

	// ############### TRANSFORM.LOCALSCALE ###############

	///<summary>transform.localScale-г авна</summary>
	public static Vector3 Tls(this GameObject a) {
		return a.transform.localScale;
	}

	///<summary>transform.localScale-г өөрчилнө</summary>
	public static void Tls(this GameObject a, Vector3 v) {
		a.transform.localScale = v;
	}

	///<summary>transform.localScale-г өөрчилнө</summary>
	public static void Tls(this GameObject a, float x, float y, float z) {
		a.transform.localScale = new Vector3(x, y, z);
	}

	///<summary>transform.localScale-н x-г өөрчилнө</summary>
	public static void TlsX(this GameObject a, float x) {
		a.transform.localScale = V3.X(a.transform.localScale, x);
	}

	///<summary>transform.localScale-н y-г өөрчилнө</summary>
	public static void TlsY(this GameObject a, float y) {
		a.transform.localScale = V3.Y(a.transform.localScale, y);
	}

	///<summary>transform.localScale-н z-г өөрчилнө</summary>
	public static void TlsZ(this GameObject a, float z) {
		a.transform.localScale = V3.Z(a.transform.localScale, z);
	}

	///<summary>transform.localScale-н x, y-г өөрчилнө</summary>
	public static void TlsXy(this GameObject a, float x, float y) {
		a.transform.localScale = V3.Xy(a.transform.localScale, x, y);
	}

	///<summary>transform.localScale-н x, z-г өөрчилнө</summary>
	public static void TlsXz(this GameObject a, float x, float z) {
		a.transform.localScale = V3.Xz(a.transform.localScale, x, z);
	}

	///<summary>transform.localScale-н y, z-г өөрчилнө</summary>
	public static void TlsYz(this GameObject a, float y, float z) {
		a.transform.localScale = V3.Yz(a.transform.localScale, y, z);
	}

	///<summary>transform.localScale-д v-г нэмнэ</summary>
	public static void TlsD(this GameObject a, Vector3 v) {
		a.transform.localScale += v;
	}

	///<summary>transform.localScale-д x, y, z-г нэмнэ</summary>
	public static void TlsD(this GameObject a, float x, float y, float z) {
		a.transform.localScale += new Vector3(x, y, z);
	}

	///<summary>transform.localScale-д x-г нэмнэ</summary>
	public static void TlsDx(this GameObject a, float x) {
		a.transform.localScale += new Vector3(x, 0, 0);
	}

	///<summary>transform.localScale-д y-г нэмнэ</summary>
	public static void TlsDy(this GameObject a, float y) {
		a.transform.localScale += new Vector3(0, y, 0);
	}

	///<summary>transform.localScale-д z-г нэмнэ</summary>
	public static void TlsDz(this GameObject a, float z) {
		a.transform.localScale += new Vector3(0, 0, z);
	}

	///<summary>transform.localScale-д x, y-г нэмнэ</summary>
	public static void TlsDxy(this GameObject a, float x, float y) {
		a.transform.localScale += new Vector3(x, y, 0);
	}

	///<summary>transform.localScale-д x, z-г нэмнэ</summary>
	public static void TlsDxz(this GameObject a, float x, float z) {
		a.transform.localScale += new Vector3(x, 0, z);
	}

	///<summary>transform.localScale-д y, z-г нэмнэ</summary>
	public static void TlsDyz(this GameObject a, float y, float z) {
		a.transform.localScale += new Vector3(0, y, z);
	}

	// ############### TRANSFORM.EULERANGLES ###############

	///<summary>transform.eulerAngles-г авна</summary>
	public static Vector3 Te(this GameObject a) {
		return a.transform.eulerAngles;
	}

	///<summary>transform.eulerAngles-г өөрчилнө</summary>
	public static void Te(this GameObject a, Vector3 v) {
		a.transform.eulerAngles = v;
	}

	///<summary>transform.eulerAngles-г өөрчилнө</summary>
	public static void Te(this GameObject a, float x, float y, float z) {
		a.transform.eulerAngles = new Vector3(x, y, z);
	}

	///<summary>transform.eulerAngles-н x-г өөрчилнө</summary>
	public static void TeX(this GameObject a, float x) {
		a.transform.eulerAngles = V3.X(a.transform.eulerAngles, x);
	}

	///<summary>transform.eulerAngles-н y-г өөрчилнө</summary>
	public static void TeY(this GameObject a, float y) {
		a.transform.eulerAngles = V3.Y(a.transform.eulerAngles, y);
	}

	///<summary>transform.eulerAngles-н z-г өөрчилнө</summary>
	public static void TeZ(this GameObject a, float z) {
		a.transform.eulerAngles = V3.Z(a.transform.eulerAngles, z);
	}

	///<summary>transform.eulerAngles-н x, y-г өөрчилнө</summary>
	public static void TeXy(this GameObject a, float x, float y) {
		a.transform.eulerAngles = V3.Xy(a.transform.eulerAngles, x, y);
	}

	///<summary>transform.eulerAngles-н x, z-г өөрчилнө</summary>
	public static void TeXz(this GameObject a, float x, float z) {
		a.transform.eulerAngles = V3.Xz(a.transform.eulerAngles, x, z);
	}

	///<summary>transform.eulerAngles-н y, z-г өөрчилнө</summary>
	public static void TeYz(this GameObject a, float y, float z) {
		a.transform.eulerAngles = V3.Yz(a.transform.eulerAngles, y, z);
	}

	///<summary>transform.eulerAngles-д v-г нэмнэ</summary>
	public static void TeD(this GameObject a, Vector3 v) {
		a.transform.eulerAngles += v;
	}

	///<summary>transform.eulerAngles-д x, y, z-г нэмнэ</summary>
	public static void TeD(this GameObject a, float x, float y, float z) {
		a.transform.eulerAngles += new Vector3(x, y, z);
	}

	///<summary>transform.eulerAngles-д x-г нэмнэ</summary>
	public static void TeDx(this GameObject a, float x) {
		a.transform.eulerAngles += new Vector3(x, 0, 0);
	}

	///<summary>transform.eulerAngles-д y-г нэмнэ</summary>
	public static void TeDy(this GameObject a, float y) {
		a.transform.eulerAngles += new Vector3(0, y, 0);
	}

	///<summary>transform.eulerAngles-д z-г нэмнэ</summary>
	public static void TeDz(this GameObject a, float z) {
		a.transform.eulerAngles += new Vector3(0, 0, z);
	}

	///<summary>transform.eulerAngles-д x, y-г нэмнэ</summary>
	public static void TeDxy(this GameObject a, float x, float y) {
		a.transform.eulerAngles += new Vector3(x, y, 0);
	}

	///<summary>transform.eulerAngles-д x, z-г нэмнэ</summary>
	public static void TeDxz(this GameObject a, float x, float z) {
		a.transform.eulerAngles += new Vector3(x, 0, z);
	}

	///<summary>transform.eulerAngles-д y, z-г нэмнэ</summary>
	public static void TeDyz(this GameObject a, float y, float z) {
		a.transform.eulerAngles += new Vector3(0, y, z);
	}

	// ############### TRANSFORM.LOCALEULERANGLES ###############

	///<summary>transform.localEulerAngles-г авна</summary>
	public static Vector3 Tle(this GameObject a) {
		return a.transform.localEulerAngles;
	}

	///<summary>transform.localEulerAngles-г өөрчилнө</summary>
	public static void Tle(this GameObject a, Vector3 v) {
		a.transform.localEulerAngles = v;
	}

	///<summary>transform.localEulerAngles-г өөрчилнө</summary>
	public static void Tle(this GameObject a, float x, float y, float z) {
		a.transform.localEulerAngles = new Vector3(x, y, z);
	}

	///<summary>transform.localEulerAngles-н x-г өөрчилнө</summary>
	public static void TleX(this GameObject a, float x) {
		a.transform.localEulerAngles = V3.X(a.transform.localEulerAngles, x);
	}

	///<summary>transform.localEulerAngles-н y-г өөрчилнө</summary>
	public static void TleY(this GameObject a, float y) {
		a.transform.localEulerAngles = V3.Y(a.transform.localEulerAngles, y);
	}

	///<summary>transform.localEulerAngles-н z-г өөрчилнө</summary>
	public static void TleZ(this GameObject a, float z) {
		a.transform.localEulerAngles = V3.Z(a.transform.localEulerAngles, z);
	}

	///<summary>transform.localEulerAngles-н x, y-г өөрчилнө</summary>
	public static void TleXy(this GameObject a, float x, float y) {
		a.transform.localEulerAngles = V3.Xy(a.transform.localEulerAngles, x, y);
	}

	///<summary>transform.localEulerAngles-н x, z-г өөрчилнө</summary>
	public static void TleXz(this GameObject a, float x, float z) {
		a.transform.localEulerAngles = V3.Xz(a.transform.localEulerAngles, x, z);
	}

	///<summary>transform.localEulerAngles-н y, z-г өөрчилнө</summary>
	public static void TleYz(this GameObject a, float y, float z) {
		a.transform.localEulerAngles = V3.Yz(a.transform.localEulerAngles, y, z);
	}

	///<summary>transform.localEulerAngles-д v-г нэмнэ</summary>
	public static void TleD(this GameObject a, Vector3 v) {
		a.transform.localEulerAngles += v;
	}

	///<summary>transform.localEulerAngles-д x, y, z-г нэмнэ</summary>
	public static void TleD(this GameObject a, float x, float y, float z) {
		a.transform.localEulerAngles += new Vector3(x, y, z);
	}

	///<summary>transform.localEulerAngles-д x-г нэмнэ</summary>
	public static void TleDx(this GameObject a, float x) {
		a.transform.localEulerAngles += new Vector3(x, 0, 0);
	}

	///<summary>transform.localEulerAngles-д y-г нэмнэ</summary>
	public static void TleDy(this GameObject a, float y) {
		a.transform.localEulerAngles += new Vector3(0, y, 0);
	}

	///<summary>transform.localEulerAngles-д z-г нэмнэ</summary>
	public static void TleDz(this GameObject a, float z) {
		a.transform.localEulerAngles += new Vector3(0, 0, z);
	}

	///<summary>transform.localEulerAngles-д x, y-г нэмнэ</summary>
	public static void TleDxy(this GameObject a, float x, float y) {
		a.transform.localEulerAngles += new Vector3(x, y, 0);
	}

	///<summary>transform.localEulerAngles-д x, z-г нэмнэ</summary>
	public static void TleDxz(this GameObject a, float x, float z) {
		a.transform.localEulerAngles += new Vector3(x, 0, z);
	}

	///<summary>transform.localEulerAngles-д y, z-г нэмнэ</summary>
	public static void TleDyz(this GameObject a, float y, float z) {
		a.transform.localEulerAngles += new Vector3(0, y, z);
	}

}