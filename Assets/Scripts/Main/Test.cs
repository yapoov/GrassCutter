using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MB {
    private void Start() {
    }
    public void Button() { }
}
// [ExecuteInEditMode]
// [RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(BoxCollider), typeof(SphereCollider))]
// public class Test : MB
// {
//     [HideInInspector]
//     public bool hideInInspector;
//     [Range(0, 100)]
//     public float range0_100;
//     [Multiline(4)]
//     public string multiline4;
//     [TextArea]
//     public string textArea;
//     [ColorUsage(false, false)]
//     public Color colorUsageFalseFalse;
//     [ColorUsage(false, true)]
//     public Color colorUsageFalseTrue;
//     [ColorUsage(true, false)]
//     public Color colorUsageTrueFalse;
//     [ColorUsage(true, true)]
//     public Color colorUsageTrueTrue;
//     public int spaceStart10;
//     [Space(10)]
//     public int spaceEnd10;
//     [Header("Header")]
//     public int header;
//     [Tooltip("Tooltip")]
//     public int toolTip;
//     [SerializeField]
//     private int serializeField;
//     public SystemSerializable systemSerializable;
//     [System.Serializable]
//     public class SystemSerializable { public int id = 0; }
//     [ContextMenu("ContextMenu")]
//     public void ContextMenu()
//     {
//         transform.localPosition = Vector3.zero;
//         transform.localRotation = Q.id;
//         transform.localScale = Vector3.one;
//     }
//     public void Button()
//     {
//         // print(A.RepIdx(idx, n));
//         // transform.Translate()
//         // transform.LookAt(Vector3.zero)
//         //     string[] arr = new string[] { "", "l", "r", "b7.5", "b7.5l", "b7.5r" };
//         //     string prvPath = "Main\\Resources\\Rect\\";
//         //     for (int i = 5; i <= 100; i += i == 5 ? 5 : 10) {
//         //         for (int j = 0; j < arr.Length; j++) {
//         //             if ((i == 5 && j == 0) || (i == 10 && j <= 2) || i > 10) {
//         //                 Vector4 border = Vector4.zero;
//         //                 switch (j) {
//         //                     case 0:
//         //                         border = A.SprBorder (i, i, i, i);
//         //                         break;
//         //                     case 1:
//         //                         border = A.SprBorder (i, 0, i, i);
//         //                         break;
//         //                     case 2:
//         //                         border = A.SprBorder (0, i, i, i);
//         //                         break;
//         //                     case 3:
//         //                         border = A.SprBorder (i, i, i, i);
//         //                         break;
//         //                     case 4:
//         //                         border = A.SprBorder (i, 0, i, i);
//         //                         break;
//         //                     case 5:
//         //                         border = A.SprBorder (0, i, i, i);
//         //                         break;
//         //                 }
//         //                 A.SetSprBorder (prvPath + "r" + i + arr[j] + ".png.meta", border);
//         //             }
//         //         }
//         //     }
//     }
// }