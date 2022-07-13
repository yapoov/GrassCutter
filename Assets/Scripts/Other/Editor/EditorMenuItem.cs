using UnityEditor;

public partial class EditorMenuItem : Editor {

	[MenuItem ("GameObject/UI/CanvasController/IO")]
	public static void CanvasControllerIO () {
		CreatePrefab ("UI/CanvasController/CanvasControllerIO", "CanvasController");
	}

	[MenuItem ("GameObject/UI/CanvasController/Simple")]
	public static void CanvasControllerSimple () {
		CreatePrefab ("UI/CanvasController/CanvasControllerSimple", "CanvasController");
	}

	[MenuItem ("GameObject/UI/UI/RegularButton")]
	public static void RegularButton () {
		CreatePrefab ("UI/Buttons/RegularButton", "RegularButton");
	}

	[MenuItem ("GameObject/UI/Confetti/LeftRight")]
	public static void ConfettiLeftRight () {
		CreatePrefab ("UI/Confetti/ConfettiLeftRight", "Confetti");
	}

	[MenuItem ("GameObject/UI/Confetti/Simple")]
	public static void ConfettiSimple () {
		CreatePrefab ("UI/Confetti/ConfettiSimple", "Confetti");
	}

	[MenuItem ("GameObject/UI/Confetti/UpDown")]
	public static void ConfettiUpDown () {
		CreatePrefab ("UI/Confetti/ConfettiUpDown", "Confetti");
	}

	[MenuItem ("GameObject/UI/GameOver/Button")]
	public static void GameOverButton () {
		CreatePrefab ("UI/GameOver/GameOverButton", "GameOver");
	}

	[MenuItem ("GameObject/UI/GameOver/LeaderBoardButton")]
	public static void GameOverLeaderBoardButton () {
		CreatePrefab ("UI/GameOver/GameOverLeaderBoardButton", "GameOver");
	}

	[MenuItem ("GameObject/UI/GameOver/ScoreBestButton")]
	public static void GameOverScoreBestButton () {
		CreatePrefab ("UI/GameOver/GameOverScoreBestButton", "GameOver");
	}

	[MenuItem ("GameObject/UI/GameSettings/GameSettings")]
	public static void GameSettings () {
		Create ("UI/GameSettings/GameSettings", "GameSettings");
	}

	[MenuItem ("GameObject/UI/GameSettings/ColorPicker")]
	public static void GameSettingsColorPicker () {
		CreatePrefab ("UI/GameSettings/GameSettingsColorPicker", "ColorPicker");
	}

	[MenuItem ("GameObject/UI/GameSettings/Dropdown")]
	public static void GameSettingsDropdown () {
		CreatePrefab ("UI/GameSettings/GameSettingsDropdown", "Dropdown");
	}

	[MenuItem ("GameObject/UI/GameSettings/InputField")]
	public static void GameSettingsInputField () {
		CreatePrefab ("UI/GameSettings/GameSettingsInputField", "InputField");
	}

	[MenuItem ("GameObject/UI/GameSettings/Slider")]
	public static void GameSettingsSlider () {
		CreatePrefab ("UI/GameSettings/GameSettingsSlider", "Slider");
	}

	[MenuItem ("GameObject/UI/GameSettings/Toggle")]
	public static void GameSettingsToggle () {
		CreatePrefab ("UI/GameSettings/GameSettingsToggle", "Toggle");
	}

	[MenuItem ("GameObject/UI/GameSettings/Vector2")]
	public static void GameSettingsVector2 () {
		CreatePrefab ("UI/GameSettings/GameSettingsVector2", "Vector2");
	}

	[MenuItem ("GameObject/UI/GameSettings/Vector3")]
	public static void GameSettingsVector3 () {
		CreatePrefab ("UI/GameSettings/GameSettingsVector3", "Vector3");
	}

	[MenuItem ("GameObject/UI/GameSettings/Vector4")]
	public static void GameSettingsVector4 () {
		CreatePrefab ("UI/GameSettings/GameSettingsVector4", "Vector4");
	}

	[MenuItem ("GameObject/UI/Hud/Hud")]
	public static void Hud () {
		Create ("UI/Hud/Hud", "Hud");
	}

	[MenuItem ("GameObject/UI/Hud/Best")]
	public static void HudBest () {
		CreatePrefab ("UI/Hud/HudBest", "Best");
	}

	[MenuItem ("GameObject/UI/Hud/Coin")]
	public static void HudCoin () {
		CreatePrefab ("UI/Hud/HudCoin", "Coin");
	}

	[MenuItem ("GameObject/UI/Hud/Diamond")]
	public static void HudDiamond () {
		CreatePrefab ("UI/Hud/HudDiamond", "Diamond");
	}

	[MenuItem ("GameObject/UI/Hud/Kills")]
	public static void HudKills () {
		CreatePrefab ("UI/Hud/HudKills", "Kills");
	}

	[MenuItem ("GameObject/UI/Hud/Score")]
	public static void HudScore () {
		CreatePrefab ("UI/Hud/HudScore", "Score");
	}

	[MenuItem ("GameObject/UI/Hud/Time")]
	public static void HudTime () {
		CreatePrefab ("UI/Hud/HudTime", "Time");
	}

	[MenuItem ("GameObject/UI/LeaderBoard/GameOver")]
	public static void LeaderBoardGameOver () {
		CreatePrefab ("UI/LeaderBoard/LeaderBoardGameOver", "LeaderBoard");
	}

	[MenuItem ("GameObject/UI/LeaderBoard/Hud")]
	public static void LeaderBoardHud () {
		CreatePrefab ("UI/LeaderBoard/LeaderBoardHud", "LeaderBoard");
	}

	[MenuItem ("GameObject/UI/LevelBar/Flag")]
	public static void LevelBarFlag () {
		CreatePrefab ("UI/LevelBar/LevelBarFlag", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelBar/FlagPointer")]
	public static void LevelBarFlagPointer () {
		CreatePrefab ("UI/LevelBar/LevelBarFlagPointer", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelBar/Image")]
	public static void LevelBarImage () {
		CreatePrefab ("UI/LevelBar/LevelBarImage", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelBar/ImagePointer")]
	public static void LevelBarImagePointer () {
		CreatePrefab ("UI/LevelBar/LevelBarImagePointer", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelBar/Simple")]
	public static void LevelBarSimple () {
		CreatePrefab ("UI/LevelBar/LevelBarSimple", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelBar/Stage")]
	public static void LevelBarStage () {
		CreatePrefab ("UI/LevelBar/LevelBarStage", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelBar/StageText")]
	public static void LevelBarStageText () {
		CreatePrefab ("UI/LevelBar/LevelBarStageText", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelBar/Text")]
	public static void LevelBarText () {
		CreatePrefab ("UI/LevelBar/LevelBarText", "LevelBar");
	}

	[MenuItem ("GameObject/UI/LevelCompleted/Button")]
	public static void LevelCompletedButton () {
		CreatePrefab ("UI/LevelCompleted/LevelCompletedButton", "LevelCompleted");
	}

	[MenuItem ("GameObject/UI/LevelCompleted/LeaderBoardButton")]
	public static void LevelCompletedLeaderBoardButton () {
		CreatePrefab ("UI/LevelCompleted/LevelCompletedLeaderBoardButton", "LevelCompleted");
	}

	[MenuItem ("GameObject/UI/LevelCompleted/Simple")]
	public static void LevelCompletedSimple () {
		CreatePrefab ("UI/LevelCompleted/LevelCompletedSimple", "LevelCompleted");
	}

	[MenuItem ("GameObject/UI/NewBest/ScoreButton")]
	public static void NewBestScoreButton () {
		CreatePrefab ("UI/NewBest/NewBestScoreButton", "NewBest");
	}

	[MenuItem ("GameObject/UI/Pause/Button")]
	public static void PauseButton () {
		CreatePrefab ("UI/Pause/PauseButton", "Pause");
	}

	[MenuItem ("GameObject/UI/Pause/TapToPlay")]
	public static void PauseTapToPlay () {
		CreatePrefab ("UI/Pause/PauseTapToPlay", "Pause");
	}

	[MenuItem ("GameObject/UI/Tutorial/Infinity")]
	public static void TutorialInfinity () {
		CreatePrefab ("UI/Tutorial/TutorialInfinity", "Tutorial");
	}

	[MenuItem ("GameObject/UI/Tutorial/InputName")]
	public static void TutorialInputName () {
		CreatePrefab ("UI/Tutorial/TutorialInputName", "Tutorial");
	}

	[MenuItem ("GameObject/UI/Tutorial/Line")]
	public static void TutorialLine () {
		CreatePrefab ("UI/Tutorial/TutorialLine", "Tutorial");
	}

	[MenuItem ("GameObject/UI/Tutorial/TapToPlay")]
	public static void TutorialTapToPlay () {
		CreatePrefab ("UI/Tutorial/TutorialTapToPlay", "Tutorial");
	}

	[MenuItem ("GameObject/UI/UI/ButtonNext")]
	public static void ButtonNext () {
		CreatePrefab ("UI/UI/ButtonNext", "ButtonNext");
	}

	[MenuItem ("GameObject/UI/UI/ButtonPlay")]
	public static void ButtonPlay () {
		CreatePrefab ("UI/UI/ButtonPlay", "ButtonPlay");
	}

	[MenuItem ("GameObject/UI/UI/ButtonReplay")]
	public static void ButtonReplay () {
		CreatePrefab ("UI/UI/ButtonReplay", "ButtonReplay");
	}

	[MenuItem ("GameObject/UI/UI/FpsCounter")]
	public static void FpsCounter () {
		CreatePrefab ("UI/UI/FpsCounter", "FpsCounter");
	}

	[MenuItem ("GameObject/UI/UI/LevelCompleted")]
	public static void LevelCompleted () {
		CreatePrefab ("UI/UI/LevelCompleted", "LevelCompleted");
	}

	[MenuItem ("GameObject/UI/UI/Menu")]
	public static void Menu () {
		Create ("UI/UI/Menu", "Menu");
	}

	[MenuItem ("GameObject/UI/UI/Score")]
	public static void Score () {
		CreatePrefab ("UI/UI/Score", "Score");
	}

	[MenuItem ("GameObject/UI/UI/Title")]
	public static void Title () {
		CreatePrefab ("UI/UI/Title", "Title");
	}

}