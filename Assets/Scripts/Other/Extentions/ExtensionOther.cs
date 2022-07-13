using UnityEngine;

public static class ExtensionOther {

    ///<summary>null байна уу шалгана</summary>
    public static bool Null(this object a) {
        return a == null;
    }

    ///<summary>null биш байна уу шалгана</summary>
    public static bool NotNull(this object a) {
        return a != null;
    }

    ///<summary>default утгатайгаа ижил байна уу шалгана</summary>
    public static bool IsDefault<T>(this T a) {
        return a.Equals(default(T));
    }
}