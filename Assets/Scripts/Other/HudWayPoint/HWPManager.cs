using System.Collections.Generic;
using UnityEngine;

public class HWPManager : MB
{
    [Tooltip("Hud list manager, you can add a new hud directly here.")]
    public List<HWPInfo> Huds = new List<HWPInfo>();
    [Tooltip("You can use MainCamera or the root of your player")]
    public Transform LocalPlayer = null;
    public float offScreenArrowDis = 0, offScreenNameDis = 100;
    public float clampBorder = 12;
    public bool useGizmos = true;
    [Header("Global Settings")]
    [Range(1, 50)] public float IconSize = 50;
    [Range(1, 50)] public float OffScreenIconSize = 25;
    [Header("GUI Scaler")]
    [Tooltip("The resolution the UI layout is designed for. If the screen resolution is larger, the GUI will be scaled up, and if it's smaller, the GUI will be scaled down. This is done in accordance with the Screen Match Mode.")]
    public Vector2 m_ReferenceResolution = new Vector2(800f, 600f);
    [Range(0f, 1f), Tooltip("Determines if the scaling is using the width or height as reference, or a mix in between."), SerializeField]
    public float m_MatchWidthOrHeight;
    [Tooltip("Select Reference Resolution automatically in run time.")]
    public bool AutoScale = true;
    [Header("Style")]
    public GUIStyle TextStyle;
    private static HWPManager _instance;
    public static HWPManager instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType<HWPManager>();
            }
            return _instance;
        }
    }
    void OnDestroy()
    {
        _instance = null;
    }
    void Update() { if (AutoScale) { m_ReferenceResolution.x = Screen.width; m_ReferenceResolution.y = Screen.height; } }
    void OnGUI()
    {
        if (!HWPUtility.mCamera || !LocalPlayer || A.FollowType == FollowType.None)
            return;
        //pass test :)
        for (int i = 0; i < Huds.Count; i++)
        {
            if (!Huds[i].Hide)
            {
                if (Huds[i].HideOnCloseDistance > 0 && GetHudDistance(i) < Huds[i].HideOnCloseDistance) { continue; }
                if (Huds[i].HideOnLargeDistance > 0 && GetHudDistance(i) > Huds[i].HideOnLargeDistance) { continue; }
                OnScreen(i);
                OffScreen(i);
            }
        }
    }
    void OnScreen(int i)
    {
        //if transform destroy, then remove from list
        if (!Huds[i].m_Target)
        {
            Huds.Remove(Huds[i]);
            return;
        }
        //Check target if OnScreen
        if (HWPUtility.isOnScreen(HWPUtility.ScreenPosition(Huds[i].m_Target), Huds[i].m_Target) &&
            IsPlaying && // Тоглох
            !Huds[i].character ? true : Huds[i].character.data.isLive && // амьд
            (A.FollowType == FollowType.Hud || A.FollowType == FollowType.HudPointer || A.FollowType == FollowType.HudPointerOff)) // HUD
        {
            //Calculate Position of target
            Vector3 RelativePosition = Huds[i].m_Target.position + Huds[i].Offset;
            if ((Vector3.Dot(this.LocalPlayer.forward, RelativePosition - this.LocalPlayer.position) > 0f))
            {
                //Calculate the 2D position of the position where the icon should be drawn
                Vector3 point = HWPUtility.mCamera.WorldToViewportPoint(RelativePosition);

                //The viewportPoint coordinates are between 0 and 1, so we have to convert them into screen space here
                Vector2 drawPosition = new Vector2(point.x * Screen.width, Screen.height * (1 - point.y));

                if (!Huds[i].arrow.ShowArrow)
                {
                    //Clamp the position to the edge of the screen in case the icon would be drawn outside the screen
                    drawPosition.x = Mathf.Clamp(drawPosition.x, clampBorder, Screen.width - clampBorder);
                    drawPosition.y = Mathf.Clamp(drawPosition.y, clampBorder, Screen.height - clampBorder);
                }
                //Calculate distance from player to way point
                float Distance = Vector3.Distance(this.LocalPlayer.position, RelativePosition);
                //Cache distance
                float CompleteDistance = Distance;

                //Max Hud Increment 
                if (Distance > Huds[i].m_MaxSize) // if more than "50" no increase more
                {
                    Distance = 50;
                }
                float n = IconSize;
                //Calculate depend of type 
                if (Huds[i].m_TypeHud == HWPType.Decreasing)
                {
                    n = (((50 + Distance) / (25)) * 0.9f) + 0.1f;
                }
                else if (Huds[i].m_TypeHud == HWPType.Increasing)
                {
                    n = (((50 - Distance) / (25)) * 0.9f) + 0.1f;
                }
                //Calculate Size of Hud
                float sizeX = Huds[i].m_Icon.width * n;
                if (sizeX >= Huds[i].m_MaxSize)
                {
                    sizeX = Huds[i].m_MaxSize;
                }
                float sizeY = Huds[i].m_Icon.height * n;
                if (sizeY >= Huds[i].m_MaxSize)
                {
                    sizeY = Huds[i].m_MaxSize;
                }
                float TextUperIcon = sizeY / 2 + 5;

                //palpating effect
                if (Huds[i].isPalpitin)
                {
                    Palpating(Huds[i]);
                }
                //Draw Huds
                GUI.color = Huds[i].color;
                GUI.DrawTexture(new Rect(drawPosition.x - (sizeX / 2), drawPosition.y - (sizeY / 2), sizeX, sizeY), Huds[i].m_Icon);
                if (!Huds[i].ShowDistance)
                {
                    if (!string.IsNullOrEmpty(Huds[i].text))
                    {
                        Vector2 size = TextStyle.CalcSize(new GUIContent(Huds[i].text));
                        GUI.Label(new Rect(drawPosition.x - (size.x / 2) + 10, (drawPosition.y - (size.y / 2)) - TextUperIcon, size.x, size.y), Huds[i].text, TextStyle);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Huds[i].text))
                    {
                        string text = Huds[i].text + "\n<color=whitte>[" + string.Format("{0:N0}m", CompleteDistance) + "]</color>";
                        Vector2 size = TextStyle.CalcSize(new GUIContent(text));
                        GUI.Label(new Rect(drawPosition.x - (size.x / 2) + 10, (drawPosition.y - (size.y / 2)) - TextUperIcon, size.x, size.y), text, TextStyle);
                    }
                    else
                    {
                        string text = "<color=whitte>[" + string.Format("{0:N0}m", CompleteDistance) + "]</color>";
                        Vector2 size = TextStyle.CalcSize(new GUIContent(text));
                        GUI.Label(new Rect(drawPosition.x - (size.x / 2) + 10, ((drawPosition.y - (size.y / 2)) - TextUperIcon), size.x, size.y), text, TextStyle);
                    }
                }
            }
        }
    }
    void OffScreen(int i)
    {
        //if transform destroy, then remove from list
        if (!Huds[i].m_Target)
        {
            Huds.Remove(Huds[i]);
            return;
        }
        if (Huds[i].arrow.ArrowIcon && Huds[i].arrow.ShowArrow &&
            IsPlaying && // Тоглох
            !Huds[i].character ? true : Huds[i].character.data.isLive && // амьд
            GameController.Kills + A.GC.showFollowLive >= A.Characters.Count && // showFollowLive хүнтэй
            (A.FollowType != FollowType.Follow && A.FollowType != FollowType.Hud)) // заагчтай
        {
            //Check target if OnScreen
            if (!HWPUtility.isOnScreen(HWPUtility.ScreenPosition(Huds[i].m_Target), Huds[i].m_Target))
            {
                //Get the relative position of arrow
                Vector3 ArrowPosition = Huds[i].m_Target.position + Huds[i].arrow.ArrowOffset;
                Vector3 pointArrow = HWPUtility.mCamera.WorldToScreenPoint(ArrowPosition);

                pointArrow.x = pointArrow.x / HWPUtility.mCamera.pixelWidth;
                pointArrow.y = pointArrow.y / HWPUtility.mCamera.pixelHeight;

                Vector3 mForward = Huds[i].m_Target.position - HWPUtility.mCamera.transform.position;
                Vector3 mDir = HWPUtility.mCamera.transform.InverseTransformDirection(mForward);
                mDir = mDir.normalized / 5;
                pointArrow.x = 0.5f + mDir.x * 20f / HWPUtility.mCamera.aspect;
                pointArrow.y = 0.5f + mDir.y * 20f;

                if (pointArrow.z < 0)
                {
                    pointArrow *= -1f;
                    pointArrow *= -1f;
                }
                //Arrow
                GUI.color = Huds[i].color;

                float Xpos = HWPUtility.mCamera.pixelWidth * pointArrow.x;
                float Ypos = HWPUtility.mCamera.pixelHeight * (1f - pointArrow.y);

                //palpating effect
                if (Huds[i].isPalpitin)
                {
                    Palpating(Huds[i]);
                }

                //Calculate area to rotate guis
                float mRot = HWPUtility.GetRotation(HWPUtility.mCamera.pixelWidth / (2), HWPUtility.mCamera.pixelHeight / (2), Xpos, Ypos);
                //Get pivot from area
                Vector2 pivot = HWPUtility.GetPivot(Xpos, Ypos, Huds[i].arrow.size);
                //Arrow
                Vector2 rotVec = new Vector2(M.Cos(mRot), M.Sin(mRot));
                Vector2 pos1 = pivot - rotVec * offScreenArrowDis;
                Matrix4x4 matrix = GUI.matrix;
                GUIUtility.RotateAroundPivot(mRot - 90, pos1);
                GUI.DrawTexture(new Rect(pos1.x - HWPUtility.HalfSize(Huds[i].arrow.size), pos1.y - HWPUtility.HalfSize(Huds[i].arrow.size), Huds[i].arrow.size, Huds[i].arrow.size), Huds[i].arrow.ArrowIcon);
                GUI.matrix = matrix;

                float ClampedX = Mathf.Clamp(pivot.x, 20, (Screen.width - OffScreenIconSize) - 20);
                float ClampedY = Mathf.Clamp(pivot.y, 20, (Screen.height - OffScreenIconSize) - 20);
                GUI.DrawTexture(HWPUtility.ScalerRect(new Rect(ClampedX, ClampedY, OffScreenIconSize, OffScreenIconSize)), Huds[i].m_Icon);

                Vector2 pos = pivot;
                //Icons and Text
                if (A.FollowType != FollowType.FollowPointerOff && A.FollowType != FollowType.HudPointerOff)
                    if (!Huds[i].ShowDistance)
                    {
                        if (!string.IsNullOrEmpty(Huds[i].text))
                        {
                            Vector2 size = TextStyle.CalcSize(new GUIContent(Huds[i].text));
                            // pos.x = Mathf.Clamp (pos.x, (size.x + OffScreenIconSize) + 30, ((Screen.width - OffScreenIconSize) - 10) - size.x);
                            // pos.y = Mathf.Clamp (pos.y, (size.y + OffScreenIconSize) + 35, ((Screen.height - size.y) - OffScreenIconSize) - 20);
                            pos = pivot - rotVec * offScreenNameDis;
                            GUIUtility.RotateAroundPivot(mRot - 90, pos);
                            GUI.Label(HWPUtility.ScalerRect(new Rect(
                                pos.x - (size.x / 2),
                                pos.y - (size.y / 2),
                                size.x, size.y)), Huds[i].text, TextStyle);
                            GUI.matrix = matrix;
                        }
                    }
                    else
                    {
                        float Distance = Vector3.Distance(LocalPlayer.position, Huds[i].m_Target.position);
                        if (!string.IsNullOrEmpty(Huds[i].text))
                        {
                            string text = Huds[i].text + "\n <color=whitte>[" + string.Format("{0:N0}m", Distance) + "]</color>";
                            Vector2 size = TextStyle.CalcSize(new GUIContent(text));
                            pos.x = Mathf.Clamp(pos.x, (size.x + OffScreenIconSize) + 30, ((Screen.width - OffScreenIconSize) - 10) - size.x);
                            pos.y = Mathf.Clamp(pos.y, (size.y + OffScreenIconSize) + 35, ((Screen.height - size.y) - OffScreenIconSize) - 20);
                            GUI.Label(HWPUtility.ScalerRect(new Rect(pos.x - (size.x / 2), (pos.y - (size.y / 2)), size.x, size.y)), text, TextStyle);
                        }
                        else
                        {
                            string text = "<color=whitte>[" + string.Format("{0:N0}m", Distance) + "]</color>";
                            Vector2 size = TextStyle.CalcSize(new GUIContent(text));
                            pos.x = Mathf.Clamp(pos.x, (size.x + OffScreenIconSize) + 30, ((Screen.width - OffScreenIconSize) - 10) - size.x);
                            pos.y = Mathf.Clamp(pos.y, (size.y + OffScreenIconSize) + 35, ((Screen.height - size.y) - OffScreenIconSize) - 20);
                            GUI.Label(HWPUtility.ScalerRect(new Rect(pos.x - (size.x / 2), (pos.y - (size.y / 2)), size.x, size.y)), text, TextStyle);
                        }
                    }
                // GUI.DrawTexture(bl_HudUtility.ScalerRect(new Rect(mPivot.x + marge.x,(mPivot.y + ((!Huds[i].ShowDistance) ? 10 : 20)) + marge.y, 25, 25)), Huds[i].m_Icon);
            }
            GUI.color = Color.white;
        }
    }
    public void CreateHud(HWPInfo info)
    {
        Huds.Add(info);
    }
    public void RemoveHud(int i)
    {
        Huds.RemoveAt(i);
    }
    public void RemoveHud(HWPInfo hud)
    {
        if (Huds.Contains(hud))
        {
            Huds.Remove(hud);
        }
        else
        {
            Debug.Log("Huds list don't contain this hud!");
        }
    }
    public void HideStateHud(int i, bool hide = false)
    {
        if (Huds[i].NotNull())
        {
            Huds[i].Hide = hide;
        }
    }
    public void HideStateHud(HWPInfo hud, bool hide = false)
    {
        if (Huds.Contains(hud))
        {
            for (int i = 0; i < Huds.Count; i++)
            {
                if (Huds[i] == hud)
                {
                    Huds[i].Hide = hide;
                }
            }
        }
    }
    private float GetHudDistance(int i)
    {
        //if transform destroy, then remove from list
        if (Huds[i].Null() || !Huds[i].m_Target)
        {
            Huds.Remove(Huds[i]);
            return 0;
        }
        //Calculate Position of target
        Vector3 RelativePosition = Huds[i].m_Target.position + Huds[i].Offset;
        float Distance = Vector3.Distance(this.LocalPlayer.position, RelativePosition);
        return Distance;
    }
    private void Palpating(HWPInfo hud)
    {
        if (hud.color.a <= 0)
        {
            hud.tip = false;
        }
        else if (hud.color.a >= 1)
        {
            hud.tip = true;
        }
        //Create a loop
        if (hud.tip == false)
        {
            hud.color.a += DT * 0.5f;
        }
        else
        {
            hud.color.a -= DT * 0.5f;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (!useGizmos)
            return;
        for (int i = 0; i < Huds.Count; i++)
        {
            if (Huds[i].m_Target)
            {
                Gizmos.color = new Color(0, 0.35f, 0.9f, 0.9f);
                Gizmos.DrawWireSphere(Huds[i].m_Target.position, 3);
                Gizmos.color = new Color(0, 0.35f, 0.9f, 0.3f);
                Gizmos.DrawSphere(Huds[i].m_Target.position, 3);
                if (i < Huds.Count - 1)
                {
                    Gizmos.DrawLine(Huds[i].m_Target.position, Huds[i + 1].m_Target.position);
                }
                else
                {
                    Gizmos.DrawLine(Huds[i].m_Target.position, Huds[0].m_Target.position);
                }
            }
        }
    }
}