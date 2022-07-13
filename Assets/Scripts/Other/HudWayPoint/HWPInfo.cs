using UnityEngine;

//When the player approaches the hud will start to
public enum HWPType
{
    None,
    Increasing,
    Decreasing,
}

[System.Serializable]
public class HWPInfo
{
    public Character character;
    public string text = null;
    [Tooltip("Transform to HUD follow, is empty this will be take this transform.")]
    public Transform m_Target = null;
    public Texture2D m_Icon = null;
    public Color color = new Color(1, 1, 1, 1);
    [Tooltip("Modify the target position.")]
    public Vector3 Offset;

    [Tooltip("When player is it approaches to the target, the icon It becomes smaller (Decreasing) or large(Increasing).")]
    public HWPType m_TypeHud = HWPType.Decreasing;
    [Tooltip("Max size to the hud can scale.")]
    public float m_MaxSize = 50f;
    [Range(0.1f, 10), Tooltip("Hide when target is more close that the distance, leave 0 for no hide")]
    public float HideOnCloseDistance = 0;
    [Range(15, 1000), Tooltip("Hide when target is more large that the distance, leave 0 for no hide")]
    public float HideOnLargeDistance = 0;
    public bool ShowDistance = true;
    [Tooltip("Is HUD hide for default?, you can change it in runtime.")]
    public bool ShowDynamically = false;
    [Tooltip("hud is fade.")]
    public bool isPalpitin = true;
    [System.Serializable]
    public class m_Arrow
    {
        public bool ShowArrow = true;
        public Texture ArrowIcon = null;
        public Vector3 ArrowOffset = Vector3.zero;
        public float size = 30;
    }

    [Space(5)]
    [Header("Arrow")]
    public m_Arrow arrow;
    [HideInInspector]
    public bool tip = false;
    [HideInInspector] public bool Hide = false;
}