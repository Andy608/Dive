using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SplashSceneScript : MonoBehaviour 
{	
	public float pauseTime = 1.0f;
	public float startingScale;
	public float endingScale;
	public float timeToTransition;
	public Canvas canvas;
	public GameObject blackFadePrefab;
	public Image bountiveLogoPrefab;

	private GameObject introBlackFadeTransitionObj;
	private GameObject outroBlackFadeTransitionObj;
	private FadeCoroutine introBlackFadeScript;
	private FadeCoroutine outroBlackFadeScript;

	private Image bountiveLogo;
	private ScaleTransitionScript scaleScript;
	private FadeCoroutine bountiveFadeScript;

	private float elapsedPauseTime;

	private bool startFinished;

	void Start () 
	{
		Camera.main.GetComponent<Camera>().backgroundColor = Color.white;
		bountiveLogo = Instantiate(bountiveLogoPrefab);
		bountiveLogo.gameObject.AddComponent<ScaleTransitionScript>();
		bountiveLogo.gameObject.AddComponent<FadeCoroutine>();
		bountiveLogo.transform.SetParent(canvas.transform);
		bountiveLogo.transform.localPosition = new Vector3(0.0f, 0.0f, canvas.transform.localPosition.z);

		scaleScript = bountiveLogo.GetComponent<ScaleTransitionScript>();
		scaleScript.startingScale = startingScale;
		scaleScript.endingScale = endingScale;
		scaleScript.timeToTransition = timeToTransition;

		bountiveFadeScript = bountiveLogo.GetComponent<FadeCoroutine>();
		bountiveFadeScript.startingAlpha = 1.0f;
		bountiveFadeScript.endingAlpha = 0.0f;
		bountiveFadeScript.timeToTransition = 1.0f;
		bountiveFadeScript.imageColor = new Vector4(1.0f, 1.0f, 1.0f, bountiveFadeScript.startingAlpha);
		bountiveFadeScript.isUIImage = true;
		bountiveFadeScript.destoryAfterTransition = true;


		introBlackFadeTransitionObj = Instantiate(blackFadePrefab);
		introBlackFadeTransitionObj.AddComponent<FadeCoroutine>();
		introBlackFadeScript = introBlackFadeTransitionObj.GetComponent<FadeCoroutine>();
		Util.resizeObjectToScreen(introBlackFadeTransitionObj);

		introBlackFadeScript.startingAlpha = 1.0f;
		introBlackFadeScript.endingAlpha = 0.0f;
		introBlackFadeScript.timeToTransition = 1.5f;
		introBlackFadeScript.imageColor = new Vector4(0.0f, 0.0f, 0.0f, introBlackFadeScript.startingAlpha);
		introBlackFadeScript.isSprite = true;
		introBlackFadeScript.destoryAfterTransition = true;


		outroBlackFadeTransitionObj = Instantiate(blackFadePrefab);
		outroBlackFadeTransitionObj.GetComponent<SpriteRenderer>().color = new Vector4(
			outroBlackFadeTransitionObj.GetComponent<SpriteRenderer>().color.r,
			outroBlackFadeTransitionObj.GetComponent<SpriteRenderer>().color.g,
			outroBlackFadeTransitionObj.GetComponent<SpriteRenderer>().color.b,
			0.0f
		);
		outroBlackFadeTransitionObj.AddComponent<FadeCoroutine>();
		outroBlackFadeScript = outroBlackFadeTransitionObj.GetComponent<FadeCoroutine>();
		Util.resizeObjectToScreen(outroBlackFadeTransitionObj);

		outroBlackFadeScript.startingAlpha = 0.0f;
		outroBlackFadeScript.endingAlpha = 1.0f;
		outroBlackFadeScript.timeToTransition = 0.5f;
		outroBlackFadeScript.imageColor = new Vector4(0.0f, 0.0f, 0.0f, outroBlackFadeScript.startingAlpha);
		outroBlackFadeScript.isSprite = true;
		outroBlackFadeScript.destoryAfterTransition = false;

		startFinished = true;
		StartCoroutine(introBlackFadeScript.fade());
		StartCoroutine(updateSplashScene());
	}
	
	IEnumerator updateSplashScene () 
	{
		while (startFinished)
		{
			if ((Input.touches.Length > 0 || Input.GetMouseButtonDown(0)) && !bountiveFadeScript.isTransitioning() && !bountiveFadeScript.isTransitionOver())
			{
				StartCoroutine(bountiveFadeScript.fade());
			}
			else if (introBlackFadeScript.isTransitionOver() && !bountiveFadeScript.isTransitionOver())
			{
				elapsedPauseTime += Time.deltaTime;

				if (elapsedPauseTime >= pauseTime && !bountiveFadeScript.isTransitioning())
				{
					StartCoroutine(bountiveFadeScript.fade());
					elapsedPauseTime = 0;
				}
			}

			if (bountiveFadeScript.isTransitionOver() && !outroBlackFadeScript.isTransitionOver() && !outroBlackFadeScript.isTransitioning())
			{
				StartCoroutine(outroBlackFadeScript.fade());
			}

			if (outroBlackFadeScript.isTransitionOver())
			{
				setHomeScreen();
			}

			yield return null;
		}
	}

	private void setHomeScreen()
	{
		elapsedPauseTime = 0;
		SceneManager.LoadScene("Scenes/home_scene");
	}
}
