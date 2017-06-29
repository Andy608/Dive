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
	private FadeTransitionScript introBlackFadeScript;
	private FadeTransitionScript outroBlackFadeScript;

	private Image bountiveLogo;
	private ScaleTransitionScript scaleScript;
	private FadeTransitionScript bountiveFadeScript;

	private float elapsedPauseTime;

	private bool startFinished;

	void Start () 
	{
		Camera.main.GetComponent<Camera>().backgroundColor = Color.white;
		bountiveLogo = Instantiate(bountiveLogoPrefab);
		bountiveLogo.gameObject.AddComponent<ScaleTransitionScript>();
		bountiveLogo.gameObject.AddComponent<FadeTransitionScript>();
		bountiveLogo.transform.SetParent(canvas.transform);
		bountiveLogo.transform.localPosition = new Vector3(0.0f, 0.0f, canvas.transform.localPosition.z);

		scaleScript = bountiveLogo.GetComponent<ScaleTransitionScript>();
		scaleScript.startingScale = startingScale;
		scaleScript.endingScale = endingScale;
		scaleScript.timeToTransition = timeToTransition;

		bountiveFadeScript = bountiveLogo.GetComponent<FadeTransitionScript>();
		bountiveFadeScript.startingAlpha = 1.0f;
		bountiveFadeScript.endingAlpha = 0.0f;
		bountiveFadeScript.timeToTransition = 1.0f;
		bountiveFadeScript.imageColor = new Vector4(1.0f, 1.0f, 1.0f, bountiveFadeScript.startingAlpha);
		bountiveFadeScript.isUIImage = true;
		bountiveFadeScript.destoryAfterTransition = true;


		introBlackFadeTransitionObj = Instantiate(blackFadePrefab);
		introBlackFadeTransitionObj.AddComponent<FadeTransitionScript>();
		introBlackFadeScript = introBlackFadeTransitionObj.GetComponent<FadeTransitionScript>();
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
		outroBlackFadeTransitionObj.AddComponent<FadeTransitionScript>();
		outroBlackFadeScript = outroBlackFadeTransitionObj.GetComponent<FadeTransitionScript>();
		Util.resizeObjectToScreen(outroBlackFadeTransitionObj);

		outroBlackFadeScript.startingAlpha = 0.0f;
		outroBlackFadeScript.endingAlpha = 1.0f;
		outroBlackFadeScript.timeToTransition = 0.5f;
		outroBlackFadeScript.imageColor = new Vector4(0.0f, 0.0f, 0.0f, outroBlackFadeScript.startingAlpha);
		outroBlackFadeScript.isSprite = true;
		outroBlackFadeScript.destoryAfterTransition = true;
		Debug.Log(outroBlackFadeScript.imageColor);

		startFinished = true;
		introBlackFadeScript.startTransition();
	}
	
	void Update () 
	{
		if (!startFinished)
		{
			return;
		}

		if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0) && !bountiveFadeScript.isTransitioning())
		{
			bountiveFadeScript.startTransition();
		}
		else if (introBlackFadeScript.isTransitionOver() && !bountiveFadeScript.isTransitionOver())
		{
			elapsedPauseTime += Time.deltaTime;

			if (elapsedPauseTime >= pauseTime)
			{
				bountiveFadeScript.startTransition();
				elapsedPauseTime = 0;
			}
		}

		if (bountiveFadeScript.isTransitionOver() && !outroBlackFadeScript.isTransitioning())
		{
			outroBlackFadeScript.startTransition();
		}

		if (outroBlackFadeScript.isTransitionOver())
		{
			Camera.main.GetComponent<Camera>().backgroundColor = Color.black;
			setHomeScreen();
		}
	}

	private void setHomeScreen()
	{
		elapsedPauseTime = 0;
		SceneManager.LoadScene("Scenes/home_scene");
	}
}
