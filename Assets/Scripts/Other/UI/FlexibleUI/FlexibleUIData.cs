using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flexible UI Data")]
public class FlexibleUIData : ScriptableObject
{
    public List<Color> colors;
    public List<Font> fonts;
    public bool isUpdate;
}
