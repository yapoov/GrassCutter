using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBest : MB {
    
    public FormatTxt score;
    
    public void Data(float score, int level, List<LeaderBoardData> datas) {
        if (this.score)
            this.score.Data(score);
    }
}