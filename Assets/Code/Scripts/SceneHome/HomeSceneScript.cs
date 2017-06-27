using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneScript : MonoBehaviour {

	public GameObject whiteFadePrefab;
	public float whiteFadeTime;

	//private GameObject whiteFadeObj;
	//private FadeTransitionScript fadeTransitionScript;

	private OpeningParallaxScript parallaxScript;
	private ParallaxManagerScript parallaxManagerScript;

	void Start () 
	{
		parallaxManagerScript = GameManagerScript.getGameManagerScript().GetComponent<ParallaxManagerScript>();
		parallaxScript = GetComponent<OpeningParallaxScript>();

		//whiteFadeObj = Instantiate(whiteFadePrefab);
		//whiteFadeObj.AddComponent<FadeTransitionScript>();
		//fadeTransitionScript = whiteFadeObj.GetComponent<FadeTransitionScript>();
		//Util.resizeObjectToScreen(whiteFadeObj);

		//fadeTransitionScript.startingAlpha = 1.0f;
		//fadeTransitionScript.endingAlpha = 0.0f;
		//fadeTransitionScript.timeToTransition = whiteFadeTime;
		//fadeTransitionScript.imageColor = new Vector4(0.0f, 0.0f, 0.0f, fadeTransitionScript.startingAlpha);
		//fadeTransitionScript.startTransition();

		parallaxScript.startAnimation(parallaxManagerScript);
	}

	void Update()
	{
		if (parallaxScript.getIsFinishingAnimation() && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
		{
			GameManagerScript.getGameManagerScript().startGame();
			SceneManager.LoadScene("Scenes/play_scene");
		}
	}
}
