using System.Collections.Generic;
using UnityEngine;

public static partial class A {

    ///<summary>Эхлэж байгааг шалгана</summary>
    public static bool IsStarting => GameController.State == GameState.Starting;

    ///<summary>Тоглож байгааг шалгана</summary>
    public static bool IsPlaying => GameController.State == GameState.Playing;

    ///<summary>Зогсоосон байгааг шалгана</summary>
    public static bool IsPause => GameController.State == GameState.Pause;

    ///<summary>Хожсон эсэхийг шалгана</summary>
    public static bool IsLevelCompleted => GameController.State == GameState.LevelCompleted;

    ///<summary>Хожигдсон эсэхийг шалгана</summary>
    public static bool IsGameOver => GameController.State == GameState.GameOver;

    ///<summary>Тохиргоо хийж байгааг шалгана</summary>
    public static bool IsSettings => GameController.State == GameState.Settings;

    ///<summary>Шилжиж байгааг шалгана</summary>
    public static bool IsShifting => GameController.State == GameState.Shifting;

    // INPUT

    ///<summary>Input.GetMouseButton(0)</summary>
    public static bool IsClick => Input.GetMouseButton(0);

    ///<summary>Input.GetMouseButtonDown(0)</summary>
    public static bool IsDown => Input.GetMouseButtonDown(0);

    ///<summary>Input.GetMouseButtonUp(0)</summary>
    public static bool IsUp => Input.GetMouseButtonUp(0);

    ///<summary>Input.mousePosition</summary>
    public static Vector3 MP => Input.mousePosition;

    // PHYSICS

    ///<summary>Physics.gravity</summary>
    public static Vector3 G {
        get => Physics.gravity;
        set => Physics.gravity = value;
    }

    // TIME

    ///<summary>Time.deltaTime</summary>
    public static float DT => Time.deltaTime;

    ///<summary>0.1 секунд хүлээнэ</summary>
    public static WaitForSeconds Wfs01 = new WaitForSeconds(0.1f);

    ///<summary>0.2 секунд хүлээнэ</summary>
    public static WaitForSeconds Wfs02 = new WaitForSeconds(0.2f);

    ///<summary>0.25 секунд хүлээнэ</summary>
    public static WaitForSeconds Wfs05 = new WaitForSeconds(0.25f);

    ///<summary>0.5 секунд хүлээнэ</summary>
    public static WaitForSeconds Wfs025 = new WaitForSeconds(0.5f);

    ///<summary>1 секунд хүлээнэ</summary>
    public static WaitForSeconds Wfs1 = new WaitForSeconds(1);

    // INSTANCE

    ///<summary>GameController</summary>
    public static GameController GC => GameController.Instance;

    ///<summary>CanvasController</summary>
    public static CanvasController CC => CanvasController.Instance;

    ///<summary>CameraController</summary>
    public static CameraController CM => CameraController.Instance;

    ///<summary>GameSettings</summary>
    public static GameSettings GS => GameSettings.Instance;

    ///<summary>LevelSpawner</summary>
    public static LevelSpawner LS => LevelSpawner.Instance;

    ///<summary>BotSpawner</summary>
    public static BotSpawner BS => BotSpawner.Instance;

    ///<summary>EnvSpawner</summary>
    public static EnvSpawner ES => EnvSpawner.Instance;

    ///<summary>Player</summary>
    public static Player Player {
        get {
            if (_Player.Null())
                _Player = GameObject.FindObjectOfType<Player>();
            return _Player;
        }
    }
    static Player _Player;

    ///<summary>Camera.main</summary>
    public static Camera Cam => Camera.main;

    ///<summary>FollowType</summary>
    public static FollowType FollowType => GC.followType;

    ///<summary>Characters</summary>
    public static List<Character> Characters => BS.characters;

    ///<summary>Дүрийн 200-н нэр</summary>
    public static readonly List<string> Names = new List<string>() {
        "Guy", "Hill", "Brittany", "Townsend", "Santos", "Roberson", "Jeffrey", "Jackson", "Lindsey", "Wheeler",
        "Madeline", "Cobb", "Paula", "Gibbs", "Angel", "Underwood", "Judy", "Adkins", "Johnathan", "Quinn",
        "Isabel", "Ray", "Kerry", "Schneider", "Milton", "Martin", "Robyn", "Farmer", "Clifford", "Dennis",
        "Leslie", "Marshall", "Marc", "Wise", "Alfonso", "Holmes", "Tyrone", "Gilbert", "Catherine", "Simon",
        "Nina", "Bowers", "Darryl", "Potter", "Jennie", "Sherman", "Danny", "Caldwell", "David", "James",
        "Adam", "Oliver", "Doyle", "Stephens", "Cody", "Mcguire", "Gerardo", "Hanson", "Jo", "Sanders",
        "Owen", "Andrews", "Archie", "Garcia", "Eric", "Turner", "Ella", "Cook", "Rudolph", "Franklin",
        "Perry", "Lindsey", "Dianne", "Medina", "Jane", "Rhodes", "Woodrow", "Gonzales", "Lila", "Ballard",
        "Christian", "Walsh", "Jon", "Hall", "Kate", "Love", "Elizabeth", "Griffin", "Elsie", "Keller",
        "Rosalie", "Fitzgerald", "Deanna", "Harris", "Cristina", "Gregory", "Jean", "Griffith", "Lori", "Olson",
        "Laura", "Bass", "Rex", "Lee", "Tara", "Morrison", "Dan", "Haynes", "Frances", "Shelton",
        "Lucas", "Walters", "Juana", "Singleton", "Wallace", "Shaw", "Craig", "Rivera", "Juanita", "Norris",
        "Tommy", "Gomez", "Roman", "Castro", "Carroll", "Todd", "Jaime", "Poole", "Scott", "Craig",
        "Laurie", "Frank", "Emily", "Hampton", "Guillermo", "Lynch", "Andre", "Flowers", "Betty", "Gutierrez",
        "Josh", "Willis", "Karen", "Williamson", "Peggy", "Peters", "Timmy", "Gross", "Joan", "Gill",
        "Cora", "Gonzalez", "Jacquelyn", "Curtis", "Traci", "Bates", "Homer", "Larson", "Tabitha", "Butler",
        "Molly", "Holt", "Arthur", "Meyer", "Jessie", "Torres", "Dora", "Foster", "Marty", "Stone",
        "Teri", "Berry", "Spencer", "Norton", "Hazel", "Reid", "Stuart", "Goodwin", "Oscar", "Freeman",
        "Ross", "Weber", "Michele", "Diaz", "Bernadette", "Chapman", "Erick", "Fleming", "Shannon", "Burke",
        "Vicky", "Maldonado", "Nancy", "Lewis", "Nathaniel", "Mcgee", "Alex", "Ferguson", "Johanna", "Estrada"
    };

    ///<summary>Хожигдох</summary>
    public static void GameOver(bool isComplete = true) {
        GC.GameOver(isComplete);
    }

    ///<summary>Хожигдох</summary>
    public static void GameOver(bool isComplete, List<LeaderBoardData> datas) {
        GC.GameOver(isComplete, datas);
    }

    ///<summary>Хожих</summary>
    public static void LevelCompleted() {
        GC.LevelCompleted();
    }

    ///<summary>Хожих</summary>
    public static void LevelCompleted(List<LeaderBoardData> datas) {
        GC.LevelCompleted(datas);
    }

    ///<summary>Дахиж тоглох</summary>
    public static void Replay(float time = 0) {
        CC.Replay(time);
    }
}