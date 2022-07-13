using UnityEngine;

public partial class Tf {
    ///<summary>pos байрлалыг local space-с world space болгон байрлалыг буцаана</summary>
    public static Vector3 Pnt(Tf tf, Vector3 pos) {
        return Matrix4x4.TRS(tf.t, tf.q, tf.s).MultiplyPoint3x4(pos);
    }

    ///<summary>pos байралыг world space-с local space болгон байрлалыг буцаана</summary>
    public static Vector3 InvPnt(Tf tf, Vector3 pos) {
        return Matrix4x4.TRS(tf.t, tf.q, tf.s).inverse.MultiplyPoint3x4(pos);
    }

    ///<summary>dir чиглэлийг local space-с world space болгон чиглэлийг буцаана</summary>
    public static Vector3 Dir(Quaternion rot, Vector3 dir) {
        return rot * dir;
    }

    ///<summary>dir чиглэлийг local space-с world space болгон чиглэлийг буцаана</summary>
    public static Vector3 Dir(Vector3 rot, Vector3 dir) {
        return Dir(Q.Euler(rot), dir);
    }

    ///<summary>pos-г rot-р эргүүлхэд гарах байрлалыг буцаана</summary>
    public static Vector3 Rot(Quaternion rot, Vector3 pos) {
        return Matrix4x4.Rotate(rot).MultiplyPoint3x4(pos);
    }

    ///<summary>pos-г rot-р эргүүлхэд гарах байрлалыг буцаана</summary>
    public static Vector3 Rot(Vector3 rot, Vector3 pos) {
        return Rot(Q.Euler(rot), pos);
    }

    ///<summary>tf-г pnt цэг дээр төвтэй axis тэнхлэгийн дагуу ang өнцгөөр эргүүлхэд гарах байрлалыг буцаана</summary>
    public static Vector3 RotAround(Tf tf, Vector3 pnt, Vector3 axis, float ang) {
        return pnt + Q.AngAxis(ang, axis) * (tf.t - pnt);
    }

    ///<summary>pos-с tar-рүү харах эргэлтийг буцаана</summary>
    public static Quaternion LookAt(Vector3 pos, Vector3 tar) {
        return Q.LookRot(tar - pos);
    }
}