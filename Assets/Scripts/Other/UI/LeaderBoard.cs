using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MB {

    public bool isHud;

    public string nameChild = "", nameFormat = "(name)",
        scoreChild = "", scoreFormat = "(score)",
        score2Child = "", score2Format = "(score2)";

    List<LeaderBoardUIData> places = new List<LeaderBoardUIData>();

    private void Awake() {
        transform.Childs().ForEach(x => places.Add(new LeaderBoardUIData(x.Gc<Image>(), x.Child<Text>(nameChild), x.Child<Text>(scoreChild), x.Child<Text>(score2Child))));
    }

    public void Data(List<LeaderBoardData> datas) {
        List<LeaderBoardData> list = new List<LeaderBoardData>(datas);
        LeaderBoardData.Sort(list);
        if (isHud) {
            int playerIdx = LeaderBoardData.PlayerIdx(list);
            for (int i = 0; i < places.Count; i++) {
                bool isLast = i == places.Count - 1, isGreater = playerIdx >= i, isList = i < list.Count;
                LeaderBoardUIDataActive(i,
                    isList && list[i].isLive && (isLast ? isGreater : true),
                    isLast ? (isList && isGreater ? playerIdx + 1 : 0) : (isList ? i + 1 : 0),
                    isList ? list[isLast && isGreater ? playerIdx : i] : null
                );
            }
        } else {
            RectTransform rt = (RectTransform)transform;
            rt.sizeDelta = V2.Y(rt.sizeDelta, rt.sizeDelta.y / places.Count * Mathf.Clamp(datas.Count, 0, places.Count));
            for (int i = 0; i < places.Count; i++)
                if (i < list.Count && list[i].isLive)
                    LeaderBoardUIDataActive(i, true, 0, list[i]);
                else
                    LeaderBoardUIDataActive(i, false, 0, null);
        }
    }

    public void LeaderBoardUIDataActive(int idx, bool active, int place, LeaderBoardData data) {
        if (active) {
            places[idx].bgImg.Show();
            Color bgCol = isHud ? (A.GC.isLbhBgColConst ? (data.isPlayer ? A.GC.LbhPlayerCol : A.GC.LbhBotCol) : data.col) :
                (data.isPlayer ? A.GC.LbgPlayerCol : A.GC.LbgBotCol);
            Color nameCol = isHud ? (!A.GC.isLbhBgColConst ? (data.isPlayer ? A.GC.LbhPlayerCol : A.GC.LbhBotCol) : data.col) :
                (A.GC.isLbgNameUseCol ? data.col : Color.clear);
            if (places[idx].bgImg)
                places[idx].bgImg.color = bgCol;
            if (places[idx].nameTxt) {
                if (nameCol != Color.clear)
                    places[idx].nameTxt.color = nameCol;
                places[idx].nameTxt.text = data.Format(nameFormat, place);
            }
            if (places[idx].scoreTxt)
                places[idx].scoreTxt.text = data.Format(scoreFormat, place);
            if (places[idx].score2Txt)
                places[idx].score2Txt.text = data.Format(score2Format, place);
        } else
            places[idx].bgImg.Hide();
    }
}