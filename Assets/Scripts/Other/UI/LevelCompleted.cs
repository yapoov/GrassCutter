using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleted : MB {
    
    public FormatTxt level;
    
    public LeaderBoard leaderBoard;
    
    public float time = 1;
    
    public void Data(int level, List<LeaderBoardData> datas) {
        if (this.level)
            this.level.Data(level);
        if (leaderBoard)
            leaderBoard.Data(datas);
        if (time > 0)
            A.Replay(time);
    }
}