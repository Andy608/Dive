using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour 
{
	private static GameManagerScript gameManagerScript;
	public const float UI_FADE_TIME = 0.5f;

	private HeightManagerScript heightManagerScript;

	public GameObject[] walls;

	public bool inGame;

	void Awake () 
	{
		initGameManager();
	}

	void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus)
		{
			//Debug.Log("STARTING");
		}
		else
		{
			//Debug.Log("STOPPING");
		}
	}

	void OnApplicationPause(bool hasFocus)
	{
		//Debug.Log("STOPPING");
		//gameLoop.stopGameLoop();
	}

	void Start ()
	{
		walls = GameObject.FindGameObjectsWithTag("Wall");
	}
	
	void Update () 
	{
		//Debug.Log("ACCELERATION: " + GameManagerScript.getGameManagerScript().getHeightManager().gameMovementData.getAcceleration());
		//Debug.Log("VELOCITY: " + GameManagerScript.getGameManagerScript().getHeightManager().gameMovementData.getVelocity());
	}

	public void startGame()
	{
		inGame = true;
		heightManagerScript.setupForGame();
	}

	public bool isInGame()
	{
		return inGame;
	}

	public static GameManagerScript getGameManagerScript()
	{
		return gameManagerScript;
	}

	private void initGameManager()
	{
		inGame = false;
		gameManagerScript = this.GetComponent<GameManagerScript>();
		heightManagerScript = this.GetComponent<HeightManagerScript>();
		DontDestroyOnLoad(this.transform.gameObject);
	}

	public HeightManagerScript getHeightManager()
	{
		return heightManagerScript;
	}
}
