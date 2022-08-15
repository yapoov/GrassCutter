using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ANALYTICS_SDKS
using GameAnalyticsSDK;
#endif

public enum GameState { Starting, Playing, Pause, LevelCompleted, GameOver, Settings, Shifting }

public enum Data { IsWin, Score, Best, Level, Diamond, Coin, PlayerName, IsVibration, PlayerSkinIdx, LevelIdx, ShopPrice }

public enum FollowType { None, Hud, HudPointer, HudPointerOff, Follow, FollowPointer, FollowPointerOff }

public class GameController : Singleton<GameController>
{

    public static GameState State;

    public static float Score, GameTime;

    public static float Best { get { return Data.Best.F(); } }

    public static bool IsWin { get { return Data.IsWin.B(); } }

    public static int Level, Diamond, Coin, Kills, Life, PlayerSkinIdx, ShopPrice;

    public static string PlayerName;

    public static bool IsVibration;

    // Data-д хадгалж болох төрөл: bool, int, float, string, Vector2, Vector2Int, Vector3, Vector3Int, Vector4, Color
    public static Dictionary<Data, object> Datas = new Dictionary<Data, object>() {
        { Data.IsWin, true },
        { Data.Score, 0f },
        { Data.Best, 0f },
        { Data.Level, 1 },
        { Data.Diamond, 0 },
        { Data.Coin, 0 },
        { Data.PlayerName, "Player" },
        { Data.IsVibration, true },
        { Data.PlayerSkinIdx, 0 },
        { Data.LevelIdx, -1 },
        { Data.ShopPrice,0}
    };

    [Header("UI")]

    public bool isStartButton = false;

    public bool isNewBest = true;

    public bool isPauseButton = false;

    [Header("Game")]

    public float gameTime = 120;

    public float gameOverWaitTime = 0;

    public float levelCompletedWaitTime = 0;

    [Header("LeaderBoard")]

    public bool isLbhBgColConst = true;

    public Color LbhPlayerCol = new Color32(255, 255, 255, 100);

    public Color LbhBotCol = new Color32(0, 0, 0, 100);

    public bool isLbgNameUseCol = true;

    public Color LbgPlayerCol = new Color32(255, 255, 255, 100);

    public Color LbgBotCol = Color.clear;

    [Header("Character")]

    public int showFollowLive = 3;

    public FollowType followType;

    [DrawIf("followType", typeof(int), (int)FollowType.None, ComparisonType.NotEqual)]

    public bool isNameUppercase = false;

    public Color playerCol = new Color32(244, 67, 54, 255);

    public List<Color> botCols = new List<Color>() {
        new Color32 (233, 30, 99, 255),
        new Color32 (156, 39, 176, 255),
        new Color32 (103, 58, 183, 255),
        new Color32 (63, 81, 181, 255),
        new Color32 (33, 150, 243, 255),
        new Color32 (3, 169, 244, 255),
        new Color32 (0, 188, 212, 255),
        new Color32 (0, 150, 136, 255),
        new Color32 (76, 175, 80, 255),
        new Color32 (139, 195, 74, 255),
        new Color32 (205, 220, 57, 255),
        new Color32 (255, 235, 59, 255),
        new Color32 (255, 193, 7, 255),
        new Color32 (255, 152, 0, 255),
        new Color32 (255, 87, 34, 255),
        new Color32 (121, 85, 72, 255),
        new Color32 (158, 158, 158, 255),
        new Color32 (96, 125, 139, 255),
    };

    [Header("Player Settings Change")]

    public string companyName = "Fat Monster Games";

    public string companyWebSite = "boldchb.github.io";

    public string productName = "Game Name";

    public string version = "1.0";

    public Texture2D icon;

    public Texture2D iPhoneLaunchScreen;

    public Texture2D iPadLaunchScreen;

    [Header("Screenshot")]

    public string screenshotName;

    public event System.Action OnStarted;
    void Awake()
    {
        Application.targetFrameRate = 60;

        if (Application.isEditor)
        {
            // game view-н scale-г өөрчилнө
            A.SetGameViewScale();

            // Build folder үүсгэх
            IO.CheckCrtDir("Build");

            // .gitignore үүсгэх
            if (!IO.IsFileExists(".gitignore"))
                IO.CrtFile(".gitignore", IO.ReadFile(IO.GetDataPath() + "gitignore"));

            // ProjectSettings / Editor / Version Control / Mode-г Visible Meta Files болгох
            if (!IO.ReadFile(IO.GetPsPath() + "EditorSettings.asset").Contains("Visible Meta Files"))
                IO.SetMetaLine("ProjectSettings/EditorSettings.asset", "m_ExternalVersionControlSupport", "m_ExternalVersionControlSupport: Visible Meta Files");

            IO.ExtensionGameObjectRb();
            // IO.ExtensionGameObjectTf();
            IO.ExtensionGameObject();
            IO.ExtensionEnum();

            // IO.EditorMenuItem();
            // IO.Vector();
        }
    }

    void Start()
    {
        State = GameState.Starting;

        // update data
        GameTime = gameTime;
        Score = Data.Score.F();
        Coin = Data.Coin.I();
        Diamond = Data.Diamond.I();
        Level = Data.Level.I();
        IsVibration = Data.IsVibration.B();
        PlayerSkinIdx = Data.PlayerSkinIdx.I();
        Kills = 0;
        Life = 1;

        // show ui
        A.CC.HudScore(Score);
        A.CC.HudBest(Best);
        A.CC.HudCoin(Coin);
        A.CC.HudDiamond(Diamond);
        A.CC.HudKills(Kills);
        A.CC.HudLife(Life);
        A.CC.HudLevelBar(Level);
        A.LS.Init();
        OnGameStarted();
        OnStarted?.Invoke();

    }

    void Update()
    {
        if (IsStarting && !isStartButton && IsDown)
            Play();
        if (IsPause && !isPauseButton && IsDown)
            A.CC.Resume();
    }

    public void Play()
    {
        State = GameState.Playing;
        // A.Player.MouseButtonDown();
        A.CC.ShowHud();
        OnPlayStarted();
    }

    public void GameOver(bool isComplete = true)
    {
        GameOver(isComplete, LeaderBoardData.GetDatas());
    }

    public void GameOver(bool isComplete, List<LeaderBoardData> datas)
    {
        if (IsPlaying)
        {
            OnGameFinished(false);
            LeaderBoardData.RemoveNames();
            State = GameState.GameOver;
            Data.IsWin.Set(false);
            Data.Score.Set(0f);
            if (Best < Score)
            {
                Data.Best.Set(Score);
                if (isNewBest) A.CC.NewBest(gameOverWaitTime, Score, Level, datas);
                else A.CC.GameOver(gameOverWaitTime, Score, Best, Level, datas, isComplete);
            }
            else A.CC.GameOver(gameOverWaitTime, Score, Best, Level, datas, isComplete);
        }
    }

    public void LevelCompleted()
    {
        LevelCompleted(LeaderBoardData.GetDatas());
    }

    public void LevelCompleted(List<LeaderBoardData> datas)
    {
        if (IsPlaying)
        {
            OnGameFinished();
            State = GameState.LevelCompleted;
            Data.IsWin.Set(true);
            Data.Score.Set(Score);
            Data.Level.Set(Level + 1);
            A.CC.LevelCompleted(levelCompletedWaitTime, Level, datas);
        }
    }

    void OnApplicationQuit()
    {
        Time.timeScale = 1;
        Data.Score.Set(0f);
    }

    public void VarTimeSet<T, V>(T obj, string name, V value, float time)
    {
        StartCoroutine(VarTimeSetCor(obj, name, value, time));
    }

    IEnumerator VarTimeSetCor<T, V>(T obj, string name, V value, float time)
    {
        System.Reflection.FieldInfo f = A.Field<T>(obj, name);
        f.SetValue(obj, new VarTime<V>(((VarTime<V>)f.GetValue(obj)).value, Time.time));
        yield return new WaitForSeconds(time + 0.001f);
        if (((VarTime<V>)f.GetValue(obj)).time + time <= Time.time)
            f.SetValue(obj, new VarTime<V>(value, Time.time));
    }

    void OnGameStarted()
    {
#if ANALYTICS_SDKS
        if (PlayerPrefs.GetInt("LevelZero", 0) == 0)
        {
            PlayerPrefs.SetInt("LevelZero", 1);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level_000");
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level_000");
        }
#endif
    }

    void OnPlayStarted()
    {
#if ANALYTICS_SDKS
    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level_" + Level.ToString("000"));
#endif
    }

    void OnGameFinished(bool isLevelComplete = true)
    {
#if ANALYTICS_SDKS
        if (isLevelComplete)
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level_" + Level.ToString("000"), (int)Score);
        else
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "level_" + Level.ToString("000"), (int)Score);
#endif
    }
}