using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public float playerHealth = 100.0f;
	public float multipliers = 1.0f;
	public string TitleScreenString = "TitleScreen";
	public string FailScreen = "LevelFailed";
	public string Level2 = "Level2";
	public string Level1 = "Level1";
	public string GameFinish = "GameFinish";

	public float score = 0.0f;
	private float highScore = 1.0f;
	private bool gameOver = false;
	private bool hasSaved = false;
	private bool levelClear = false;
	private bool gameFinish = false;

	// Use this for initialization
	void Start ()
	{
		Instance = this;
		if(GameObject.FindGameObjectWithTag ("level2") )
		{
			loadLevel1();
		}
		loadHighScore();
		CreateLevelString ();
	}
	
	// Update is called once per frame
	void Update () {

		if(GameObject.FindGameObjectWithTag ("Player") == null) 
		{
			gameOver = true;
		}
		if(GameObject.FindGameObjectWithTag ("Enemy") == null)
		{
			levelClear = true;
		}
		if(GameObject.FindGameObjectWithTag ("Enemy") == null && Application.loadedLevelName == "Level2")
		{
			gameFinish = true;
		}

		if (levelClear) 
		{
			if(!hasSaved)
			{
				SaveHighScore ();
				hasSaved = true;
			}
			SaveLevel1();
			Application.LoadLevel (Level2);

		}
		if(gameFinish && Application.loadedLevelName == "Level2")
		{
			SaveHighScore ();
			SaveLastScore ();
			Application.LoadLevel (GameFinish);

		}

		if(gameOver)
		{
			if(!hasSaved)
			{
				SaveHighScore();

				hasSaved = true;
			}
			if (!GameObject.FindGameObjectWithTag ("level2"))
			{
				SaveLevel1();
			}
			SaveLastLevel ();
			SaveLastScore ();

			Application.LoadLevel(FailScreen);
		}
		if (!gameOver)
		{
			score += multipliers * Time.deltaTime;
			if (score > highScore)
			{
				highScore = score;
			}

		}
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();
		}
	}

	void SaveLevel1()
	{
		int currentScore = (int)score;
		PlayerPrefs.SetInt ("Level1Score", currentScore);
		PlayerPrefs.Save ();
		int currentMultiplier = (int)multipliers;
		PlayerPrefs.SetInt ("Level1Multipliers", currentMultiplier);
		PlayerPrefs.Save();
		string currentLevel = Application.loadedLevelName;
		PlayerPrefs.SetString ("LastLevel", currentLevel);
		PlayerPrefs.Save();
	}

	void CreateLevelString()
	{
		PlayerPrefs.SetString ("Level1", Level1);
		PlayerPrefs.SetString ("Level2", Level2);
		PlayerPrefs.Save ();
	}

	void SaveLastLevel()
	{
		string currentLevel = Application.loadedLevelName;
		PlayerPrefs.SetString ("LastLevel", currentLevel);
		PlayerPrefs.Save();
	}

	void loadLevel1()
	{
		score = PlayerPrefs.GetInt("Level1Score");
		multipliers = PlayerPrefs.GetInt ("Level1Multipliers");
	}
		
	void SaveLastScore()
	{
		int currentScore = (int)score;
		PlayerPrefs.SetInt ("LastScore", currentScore);
		PlayerPrefs.Save();
	}

	void SaveHighScore()
	{
		int currentHighScore = (int)highScore;
		PlayerPrefs.SetInt ("HighScore", currentHighScore);
		PlayerPrefs.Save();
	}
		
	void loadHighScore()
	{
		highScore = PlayerPrefs.GetInt("HighScore");
	}
		
	void OnGUI()
	{
		GUILayout.Label("Health : " + playerHealth.ToString());
		GUILayout.Label("Score : " + score.ToString());
		GUILayout.Label("Multipliers : " + multipliers.ToString());
		GUILayout.Label("HighScore : " + highScore.ToString());
	}
}
