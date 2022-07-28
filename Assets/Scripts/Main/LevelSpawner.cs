using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : Singleton<LevelSpawner>
{
    public Transform playerTf;
    public List<Level> levels;
    public void Init()
    {
        LoadLevel();
        // LeaderBoardData.SetDatas();
    }
    public void LoadLevel()
    {


        //
    }
    int GetLevelIdx()
    {
        int res = GameController.Level - 1;
        if (GameController.Level > levels.Count)
        {
            res = Data.LevelIdx.I();
            if (res < 0 || GameController.IsWin)
            {
                res = Rnd.Idx(levels.Count, res);
                Data.LevelIdx.Set(res);
            }
        }
        return res;
    }
}