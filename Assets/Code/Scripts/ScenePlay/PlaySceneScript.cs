using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneScript : MonoBehaviour {

	public GameObject gameManagerPrefab;
	public GameObject depthTextObj;

	public Vector3 diveVelocity;

	private FadeTransitionScript depthTextObjFadeScript;

	private ParallaxManagerScript parallaxManagerScript;

	void Start () 
	{
		depthTextObjFadeScript = depthTextObj.GetComponent<FadeTransitionScript>();
		depthTextObjFadeScript.startingAlpha = 0.0f;
		depthTextObjFadeScript.endingAlpha = 1.0f;
		depthTextObjFadeScript.timeToTransition = GameManagerScript.UI_FADE_TIME;
		depthTextObjFadeScript.imageColor = depthTextObjFadeScript.GetComponent<Text>().color;
		depthTextObjFadeScript.isText = true;
		depthTextObjFadeScript.startTransition();

		if (GameManagerScript.getGameManagerScript() == null)
		{
			Instantiate(gameManagerPrefab, new Vector3(), Quaternion.identity);
			GameManagerScript.getGameManagerScript().startGame();
		}
		
		parallaxManagerScript = GameManagerScript.getGameManagerScript().GetComponent<ParallaxManagerScript>();
	}
	
	void Update () 
	{
		if (GameManagerScript.getGameManagerScript().isInGame() && depthTextObjFadeScript.isTransitionOver())
		{
			GameManagerScript.getGameManagerScript().getHeightManager().getMovementScript().velocity += diveVelocity;
			parallaxManagerScript.lerpBackgrounds(GameManagerScript.getGameManagerScript().getHeightManager().getDepth());
		}
	}
}
