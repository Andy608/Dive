using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeSceneScript : MonoBehaviour {

	public GameObject tapToPlayTextObj;
	public GameObject titleTextObj;

	public GameObject whiteFadePrefab;
	public float whiteFadeTime;

	private FadeTransitionScript titleTransitionScript;
	private FadeTransitionScript tapToPlayTransitionScript;

	private OpeningParallaxScript parallaxScript;
	private ParallaxManagerScript parallaxManagerScript;

	void Start () 
	{
		tapToPlayTextObj.SetActive(false);
		parallaxManagerScript = GameManagerScript.getGameManagerScript().GetComponent<ParallaxManagerScript>();
		parallaxScript = GetComponent<OpeningParallaxScript>();
		parallaxScript.startAnimation(parallaxManagerScript);

		titleTransitionScript = titleTextObj.GetComponent<FadeTransitionScript>();
		titleTransitionScript.startingAlpha = 1.0f;
		titleTransitionScript.endingAlpha = 0.0f;
		titleTransitionScript.timeToTransition = GameManagerScript.UI_FADE_TIME;
		titleTransitionScript.imageColor = titleTransitionScript.GetComponent<Text>().color;
		titleTransitionScript.isText = true;

		tapToPlayTransitionScript = tapToPlayTextObj.GetComponent<FadeTransitionScript>();
		tapToPlayTransitionScript.endingAlpha = 0.0f;
		tapToPlayTransitionScript.timeToTransition = GameManagerScript.UI_FADE_TIME;
		tapToPlayTransitionScript.imageColor =  tapToPlayTextObj.GetComponent<Text>().color;
		tapToPlayTransitionScript.isText = true;
	}

	void Update()
	{
		if (tapToPlayTextObj.activeSelf && !titleTransitionScript.isTransitioning() && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
		{
			titleTransitionScript.startTransition();
			tapToPlayTransitionScript.startingAlpha = tapToPlayTextObj.GetComponent<Text>().color.a;
			tapToPlayTransitionScript.startTransition();
		}

		if (titleTransitionScript.isTransitionOver())
		{
			GameManagerScript.getGameManagerScript().startGame();
			SceneManager.LoadScene("Scenes/play_scene");
		}

		if (parallaxScript.getIsFinishingAnimation())
		{
			if (!tapToPlayTextObj.activeSelf)
			{
				tapToPlayTextObj.SetActive(true);
			}
		}
	}
}
