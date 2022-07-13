using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MB
{
    public LeaderBoardData data;
    HWP hwp = null;
    TextMeshPro followTmp;
    public void Init()
    {
        transform.SetParent(A.BS.transform);
    }
    public void UpdatePlace(int place) { }
    public void UpdateColor(Color col) { }
    // default functions
    public void CreateName(LeaderBoardData lbd)
    {
        UpdateColor(lbd.col);
        data = lbd;
        if (A.FollowType != FollowType.None)
        {
            hwp = go.Gc<HWP>();
            if (hwp)
            {
                hwp.info.arrow.size = Screen.width * 0.06f;
                HWPManager.instance.TextStyle.fontSize = M.RoundInt(Screen.width * 0.06f);
                HWPManager.instance.TextStyle.contentOffset = Vector2.up * -(Screen.width * 0.06f * 1.6f);
                hwp.info.text = A.GC.isNameUppercase ? data.name.ToUpper() : data.name;
                hwp.info.color = data.col;
                hwp.info.character = this;
            }
            if (A.FollowType == FollowType.Follow || A.FollowType == FollowType.FollowPointer)
            {
                Follow follow = Crt.Go<Follow>(Resources.Load<GameObject>("Main/FollowName"),
                    new Tf(transform.position), "", A.GC.transform);
                follow.followTf = transform;
                followTmp = follow.Child<TextMeshPro>(0);
                if (followTmp)
                {
                    followTmp.text = A.GC.isNameUppercase ? data.name.ToUpper() : data.name;
                    followTmp.color = data.col;
                }
            }
        }
    }
    public void RemoveName()
    {
        if (A.FollowType != FollowType.None)
        {
            hwp.info.text = "";
            hwp.info.arrow.size = 0;
            if ((A.FollowType == FollowType.Follow || A.FollowType == FollowType.FollowPointer) && followTmp)
                followTmp.text = "";
        }
    }
    public void AddScore(Vector3 pos = default(Vector3), int dScore = 1, float time = 1)
    {
        Crt.DstGoChild<TextMeshPro>(Resources.Load<GameObject>("Main/AddScore"),
            new Tf(pos.IsDefault() ? transform.position : pos),
            time, "0", "", A.GC.transform).text = "+" + dScore;
    }
}