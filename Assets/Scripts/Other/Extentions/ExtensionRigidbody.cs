using UnityEngine;

public static class ExtensionRigidbody {

    ///<summary>constraints-г өөрчилнө</summary>
    public static void Constraints(this Rigidbody a, bool isFrzPosX = false, bool isFrzPosY = false, bool isFrzPosZ = false, bool isFrzRotX = false, bool isFrzRotY = false, bool isFrzRotZ = false) {
        a.constraints = (isFrzPosX ? RigidbodyConstraints.FreezePositionX : 0) |
            (isFrzPosY ? RigidbodyConstraints.FreezePositionY : 0) |
            (isFrzPosZ ? RigidbodyConstraints.FreezePositionZ : 0) |
            (isFrzRotX ? RigidbodyConstraints.FreezeRotationX : 0) |
            (isFrzRotY ? RigidbodyConstraints.FreezeRotationY : 0) |
            (isFrzRotZ ? RigidbodyConstraints.FreezeRotationZ : 0);
    }

    ///<summary>constraints-г хөлдөөнө</summary>
    public static void FreezeAll(this Rigidbody a) {
        a.constraints = RigidbodyConstraints.FreezeAll;
    }

    ///<summary>constraints-г байрлалыг хөлдөөнө</summary>
    public static void FreezePos(this Rigidbody a) {
        a.constraints = RigidbodyConstraints.FreezePosition;
    }

    ///<summary>constraints-г эргэлтийг хөлдөөнө</summary>
    public static void FreezeRot(this Rigidbody a) {
        a.constraints = RigidbodyConstraints.FreezeRotation;
    }

    ///<summary>constraints-г хөлдөөхгүй болгоно</summary>
    public static void None(this Rigidbody a) {
        a.constraints = RigidbodyConstraints.None;
    }

    ///<summary>хурдыг 0 болгоно</summary>
    public static void V0(this Rigidbody a) {
        a.velocity = V3.O;
    }

    ///<summary>татах хүч ашиглана</summary>
    public static void UseG(this Rigidbody a, bool useGravity = true) {
        a.useGravity = useGravity;
    }

    ///<summary>татах хүч ашиглахгүй</summary>
    public static void NoG(this Rigidbody a) {
        a.useGravity = false;
    }
}