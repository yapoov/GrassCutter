using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MB {

    public FormatTxt score;

    public FormatTxt best;

    public LeaderBoard leaderBoard;

    public void Data(float score, float best, int level, List<LeaderBoardData> datas) {
        if (this.score)
            this.score.Data(score);
        if (this.best)
            this.best.Data(best);
        if (leaderBoard)
            leaderBoard.Data(datas);
    }
}