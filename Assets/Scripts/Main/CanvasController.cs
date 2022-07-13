using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum TutorialType { Line, Infinity, TapToPlay, InputName }

public class CanvasController : Singleton<CanvasController> {

    [Header("Panels")]

    public GameObject menu;

    public GameObject hud;

    public GameOver gameOverComplete;

    public GameOver gameOverUnCompleted;

    public NewBest newBest;

    public LevelCompleted levelCompleted;

    public GameObject pause;

    [Header("Hud items")]

    public HudTime hudTime;

    public FormatTxt hudKills;

    public FormatTxt hudScore;

    public FormatTxt hudBest;

    public FormatTxt hudDiamond;

    public FormatTxt hudCoin;

    public FormatTxt hudLife;

    public LevelBar hudLevelBar;

    public LeaderBoard hudLeaderBoard;

    GameState tmpGs;

    InputField playerNameInp;

    float time = 0;

    private void Start() {
        Show(menu);
        Hide(hud);
        Hide(gameOverComplete);
        Hide(gameOverUnCompleted);
        Hide(newBest);
        Hide(levelCompleted);
        Hide(pause);
        ReadPlayerName();
    }

    private void Update() {
        if (IsPlaying) {
            if (hudLeaderBoard)
                HudLeaderBoard(LeaderBoardData.GetDatas());
            if (hudTime) {
                time += DT;
                if (GameController.GameTime - time > 0) {
                    HudTime(GameController.GameTime - time);
                } else {
                    HudTime(0);
                    A.GC.GameOver();
                }
            }
        }
    }

    void ReadPlayerName() {
        GameObject playerNameGo = GameObject.Find("PlayerName");
        if (playerNameGo) {
            playerNameInp = playerNameGo.Gc<InputField>();
            if (playerNameInp)
                playerNameInp.text = GameController.PlayerName = Data.PlayerName.Str();
        }
    }

    public void HudScore(float score) {
        FtData(hudScore, score);
    }

    public void HudBest(float best) {
        FtData(hudBest, best);
    }

    public void HudCoin(int coin) {
        FtData(hudCoin, coin);
    }

    public void HudDiamond(int diamond) {
        FtData(hudDiamond, diamond);
    }

    public void HudKills(int kills) {
        FtData(hudKills, kills);
    }

    public void HudLife(int life) {
        FtData(hudLife, life);
    }

    public void HudTime(float time) {
        if (hudTime)
            hudTime.Data(time);
    }

    public void HudLevelBar(int level = 1, float progressScore = 0, float progressBest = 0, string progressText = "", int stage = 1) {
        if (hudLevelBar)
            hudLevelBar.Data(level, progressScore, progressBest, progressText, stage);
    }

    public void HudLeaderBoard(List<LeaderBoardData> datas = null) {
        if (hudLeaderBoard)
            hudLeaderBoard.Data(datas);
    }

    public void ShowHud() {
        Hide(menu);
        Show(hud);
    }

    public void GameOver(float time = 0, float score = 0, float best = 0, int level = 1, List<LeaderBoardData> datas = null, bool isComplete = true) {
        StartCoroutine(GameOverCor(time, score, best, level, datas, isComplete));
    }

    IEnumerator GameOverCor(float time, float score, float best, int level, List<LeaderBoardData> datas, bool isComplete) {
        yield return new WaitForSeconds(time);
        if (isComplete) {
            if (gameOverComplete) {
                Hide(hud);
                Show(gameOverComplete);
                gameOverComplete.Data(score, best, level, datas);
            }
        } else {
            if (gameOverUnCompleted) {
                Hide(hud);
                Show(gameOverUnCompleted);
                gameOverUnCompleted.Data(score, best, level, datas);
            }
        }
    }

    public void NewBest(float time = 0, float score = 0, int level = 1, List<LeaderBoardData> datas = null) {
        StartCoroutine(NewBestCor(time, score, level, datas));
    }
    public IEnumerator NewBestCor(float time, float score, int level, List<LeaderBoardData> datas) {
        yield return new WaitForSeconds(time);
        if (newBest) {
            Hide(hud);
            Show(newBest);
            newBest.Data(score, level, datas);
        }
    }

    public void LevelCompleted(float time = 0, int level = 1, List<LeaderBoardData> datas = null) {
        StartCoroutine(LevelCompletedCor(time, level, datas));
    }

    IEnumerator LevelCompletedCor(float time, int level, List<LeaderBoardData> datas) {
        yield return new WaitForSeconds(time);
        if (levelCompleted) {
            Hide(hud);
            Show(levelCompleted);
            levelCompleted.Data(level, datas);
        }
    }

    public void Pause(float time = 0) {
        StartCoroutine(PauseCor(time));
    }

    IEnumerator PauseCor(float time) {
        yield return new WaitForSeconds(time);
        if (pause) {
            Show(pause);
            Time.timeScale = 0;
            tmpGs = GameController.State;
            GameController.State = GameState.Pause;
        }
    }

    public void Resume(float time = 0) {
        StartCoroutine(ResumeCor(time));
    }

    IEnumerator ResumeCor(float time) {
        yield return new WaitForSeconds(time);
        if (pause) {
            Hide(pause);
            Time.timeScale = 1;
            GameController.State = tmpGs;
        }
    }

    public void Replay(float time = 0) {
        StartCoroutine(ReplayCor(time));
    }

    IEnumerator ReplayCor(float time) {
        yield return new WaitForSeconds(time);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void Play() {
        if (playerNameInp)
            GameController.PlayerName = playerNameInp.text;
        Data.PlayerName.Set(GameController.PlayerName);
        LeaderBoardData.SetPlayerData(GameController.PlayerName);
        A.GC.Play();
    }

    void FtData(FormatTxt txt, float data) {
        if (txt)
            txt.Data(data);
    }

    void Hide(GameObject a) {
        if (a)
            a.Hide();
    }

    void Show(GameObject a) {
        if (a)
            a.Show();
    }

    void Hide(Component a) {
        if (a)
            a.Hide();
    }

    void Show(Component a) {
        if (a)
            a.Show();
    }
}