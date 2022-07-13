using UnityEngine;

public static partial class ExtensionGameObject {

	///<summary>rigidbody-г авна</summary>
	public static Rigidbody Rb(this GameObject a) {
		return a.Gc<Rigidbody>();
	}

	///<summary>constraints-г өөрчилнө</summary>
	public static void RbConstraints(this GameObject a, bool isFrzPosX = false, bool isFrzPosY = false, bool isFrzPosZ = false, bool isFrzRotX = false, bool isFrzRotY = false, bool isFrzRotZ = false) {
		a.Rb().Constraints(isFrzPosX, isFrzPosY, isFrzPosZ, isFrzRotX, isFrzRotY, isFrzRotZ);
	}

	///<summary>constraints-г хөлдөөнө</summary>
	public static void RbFreezeAll(this GameObject a) {
		a.Rb().FreezeAll();
	}

	///<summary>constraints-г байрлалыг хөлдөөнө</summary>
	public static void RbFreezePos(this GameObject a) {
		a.Rb().FreezePos();
	}

	///<summary>constraints-г эргэлтийг хөлдөөнө</summary>
	public static void RbFreezeRot(this GameObject a) {
		a.Rb().FreezeRot();
	}

	///<summary>constraints-г хөлдөөхгүй болгоно</summary>
	public static void RbNone(this GameObject a) {
		a.Rb().None();
	}

	///<summary>хурдыг 0 болгоно</summary>
	public static void RbV0(this GameObject a) {
		a.Rb().V0();
	}

	///<summary>татах хүч ашиглана</summary>
	public static void RbUseG(this GameObject a, bool useGravity = true) {
		a.Rb().UseG(useGravity);
	}

	///<summary>татах хүч ашиглахгүй</summary>
	public static void RbNoG(this GameObject a) {
		a.Rb().NoG();
	}

}