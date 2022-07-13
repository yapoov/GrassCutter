using UnityEngine;

public partial class Lyr {
    ///<summary>Layer => LayerMask</summary>
    public static int LayerLm(int layer) {
        return 1 << layer;
    }

    ///<summary>Layer => Name</summary>
    public static string LayerName(int layer) {
        return LayerMask.LayerToName(layer);
    }

    ///<summary>LayerMask => Layer</summary>
    public static int LmLayer(int layerMask) {
        return 1 >> layerMask;
    }

    ///<summary>LayerMask => Name</summary>
    public static string LmName(int layerMask) {
        return LayerMask.LayerToName(1 >> layerMask);
    }

    ///<summary>Name => Layer</summary>
    public static int NameLayer(string name) {
        return LayerMask.NameToLayer(name);
    }

    ///<summary>Name => LayerMask</summary>
    public static int NameLm(string name) {
        return 1 << LayerMask.NameToLayer(name);
    }
}