using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MB {
    public Image bgImg, bstImg, scrImg, scrPtrImg, bstPtrImg, nxtLvlImg;
    public Text curLvlTxt, nxtLvlTxt, lvlTxt, dataTxt;
    public string format = "LEVEL (data)";
    public bool isStage = false;
    public Stage stgLvlPf, stgPf;
    public bool isCurNxtLvl = true;
    public float dSpc = 95, spc = 80;
    public void Data(int level, float progressScore, float progressBest, string progressText, int stage) {
        if (!isStage) {
            if (curLvlTxt.Enabled())
                curLvlTxt.text = level.ToString();
            if (nxtLvlTxt.Enabled())
                nxtLvlTxt.text = (level + 1).ToString();
            if (lvlTxt.Enabled())
                lvlTxt.text = A.Format(format, "(data)", level.ToString());
            if (dataTxt.Enabled())
                dataTxt.text = progressText;
            if (bstImg.Enabled())
                bstImg.fillAmount = progressBest;
            if (scrImg.Enabled())
                scrImg.fillAmount = progressScore;
            if (scrPtrImg.Enabled() && bgImg.Enabled())
                scrPtrImg.rectTransform.anchoredPosition = new Vector2(bgImg.rectTransform.sizeDelta.x * (progressScore - 0.5f), scrPtrImg.rectTransform.anchoredPosition.y);
            if (bstPtrImg.Enabled() && bgImg.Enabled())
                bstPtrImg.rectTransform.anchoredPosition = new Vector2(bgImg.rectTransform.sizeDelta.x * (progressBest - 0.5f), bstPtrImg.rectTransform.anchoredPosition.y);
            if (progressScore >= 0.999f && nxtLvlImg.Enabled() && scrImg.Enabled())
                nxtLvlImg.color = scrImg.color;
        } else {
            Stage curLvlStg = null, nxtLvlStg = null;
            List<Stage> stages = new List<Stage>();
            transform.DestroyChilds<Stage>();
            float dx = (1 - stage) * 0.5f * spc;
            if (isCurNxtLvl) {
                if (stgLvlPf) {
                    curLvlStg = Instantiate(stgLvlPf, transform.position, Q.O, transform);
                    curLvlStg.transform.localPosition = V3.r * (dx - dSpc);
                    curLvlStg.SetState(StageState.Done);
                    nxtLvlStg = Instantiate(stgLvlPf, transform.position, Q.O, transform);
                    nxtLvlStg.transform.localPosition = V3.r * (dx + (stage - 1) * spc + dSpc);
                }
            } else if (lvlTxt.Enabled())
                lvlTxt.text = A.Format(format, "(data)", level.ToString());
            stages.Clear();
            for (int i = 0; i < stage; i++) {
                Stage stg = Instantiate(stgPf, transform.position, Q.O, transform);
                stg.transform.localPosition = V3.r * (dx + i * spc);
                stages.Add(stg);
            }
            // level
            if (curLvlStg && curLvlStg.levelTxt)
                curLvlStg.levelTxt.text = level.ToString();
            if (nxtLvlStg && nxtLvlStg.levelTxt)
                nxtLvlStg.levelTxt.text = (level + 1).ToString();
            // fill
            int idx = (int)(stage * progressScore);
            if (curLvlStg)
                curLvlStg.SetState(StageState.Done);
            for (int i = 0; i < stage; i++)
                stages[i].SetState(i < idx ? StageState.Done : i == idx ? StageState.Selected : StageState.None);
            if (nxtLvlStg)
                nxtLvlStg.SetState(idx >= stage ? StageState.Done : StageState.None);
        }
    }
}