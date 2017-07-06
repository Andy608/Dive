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

	private FadeCoroutine titleTransitionScript;
	private FadeCoroutine tapToPlayTransitionScript;

	private OpeningParallaxScript parallaxScript;

	void Start () 
	{
		tapToPlayTextObj.SetActive(false);
		parallaxScript = GetComponent<OpeningParallaxScript>();
		parallaxScript.startAnimation();

		titleTextObj.AddComponent<FadeCoroutine>();
		titleTransitionScript = titleTextObj.GetComponent<FadeCoroutine>();
		titleTransitionScript.startingAlpha = 1.0f;
		titleTransitionScript.endingAlpha = 0.0f;
		titleTransitionScript.timeToTransition = GameManagerScript.UI_FADE_TIME;
		titleTransitionScript.imageColor = titleTransitionScript.GetComponent<Text>().color;
		titleTransitionScript.isText = true;

		tapToPlayTextObj.AddComponent<FadeCoroutine>();
		tapToPlayTransitionScript = tapToPlayTextObj.GetComponent<FadeCoroutine>();
		tapToPlayTransitionScript.endingAlpha = 0.0f;
		tapToPlayTransitionScript.timeToTransition = GameManagerScript.UI_FADE_TIME;
		tapToPlayTransitionScript.imageColor =  tapToPlayTextObj.GetComponent<Text>().color;
		tapToPlayTransitionScript.isText = true;
		tapToPlayTransitionScript.destoryAfterTransition = true;

		StartCoroutine(updateHomeScene());
	}

	IEnumerator updateHomeScene()
	{
		while (true)
		{
			if (tapToPlayTextObj.activeSelf && !titleTransitionScript.isTransitioning() && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
			{
				StartCoroutine(titleTransitionScript.fade());
				tapToPlayTransitionScript.startingAlpha = tapToPlayTextObj.GetComponent<Text>().color.a;
				StartCoroutine(tapToPlayTransitionScript.fade());
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

			yield return null;
		}
	}
}
