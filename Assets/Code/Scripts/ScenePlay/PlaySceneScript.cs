using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneScript : MonoBehaviour {

	public GameObject gameManagerPrefab;
	public GameObject depthTextObj;

	public Vector3 diveVelocity;

	private FadeCoroutine depthTextObjFadeScript;

	//private ParallaxManagerScript parallaxManagerScript;

	void Start () 
	{
		depthTextObj.AddComponent<FadeCoroutine>();
		depthTextObjFadeScript = depthTextObj.GetComponent<FadeCoroutine>();
		depthTextObjFadeScript.startingAlpha = 0.0f;
		depthTextObjFadeScript.endingAlpha = 1.0f;
		depthTextObjFadeScript.timeToTransition = GameManagerScript.UI_FADE_TIME;
		depthTextObjFadeScript.imageColor = depthTextObjFadeScript.GetComponent<Text>().color;
		depthTextObjFadeScript.isText = true;
		StartCoroutine(depthTextObjFadeScript.fade());

		if (GameManagerScript.getGameManagerScript() == null)
		{
			Instantiate(gameManagerPrefab, new Vector3(), Quaternion.identity);
			GameManagerScript.getGameManagerScript().startGame();
		}
		
		//parallaxManagerScript = GameManagerScript.getGameManagerScript().GetComponent<ParallaxManagerScript>();

		GameManagerScript.getGameManagerScript().getHeightManager().getMovementScript().velocity = diveVelocity;
		//StartCoroutine(updatePlayScene());
	}
	
	IEnumerator updatePlayScene () 
	{
		while (GameManagerScript.getGameManagerScript().isInGame())
		{
			//parallaxManagerScript.lerpBackgrounds(GameManagerScript.getGameManagerScript().getHeightManager().getDepth());
			yield return null;
		}
	}
}
