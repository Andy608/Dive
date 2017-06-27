using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneScript : MonoBehaviour {

	public GameObject gameManagerPrefab;
	public Vector3 diveVelocity;

	private ParallaxManagerScript parallaxManagerScript;

	void Start () 
	{
		if (GameManagerScript.getGameManagerScript() == null)
		{
			Instantiate(gameManagerPrefab, new Vector3(), Quaternion.identity);
			GameManagerScript.getGameManagerScript().startGame();
		}
		
		parallaxManagerScript = GameManagerScript.getGameManagerScript().GetComponent<ParallaxManagerScript>();
	}
	
	void Update () 
	{
		if (GameManagerScript.getGameManagerScript().isInGame())
		{
			GameManagerScript.getGameManagerScript().getHeightManager().getMovementScript().velocity += diveVelocity;
			parallaxManagerScript.lerpBackgrounds(GameManagerScript.getGameManagerScript().getHeightManager().getDepth());
			//Debug.Log(GameManagerScript.getGameManagerScript().getHeightManager().getDepth());
		}
	}
}
