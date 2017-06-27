using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SplashSceneScript : MonoBehaviour 
{	
	public float pauseTime = 3.0f;
	public float startingScale;
	public float endingScale;
	public float timeToTransition;
	public Canvas canvas;
	public GameObject blackFadePrefab;
	public Image bountiveLogoPrefab;

	private GameObject blackFadeTransitionObj;
	private FadeTransitionScript blackFadeScript;

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


		blackFadeTransitionObj = Instantiate(blackFadePrefab);
		blackFadeTransitionObj.AddComponent<FadeTransitionScript>();
		blackFadeScript = blackFadeTransitionObj.GetComponent<FadeTransitionScript>();
		Util.resizeObjectToScreen(blackFadeTransitionObj);

		blackFadeScript.startingAlpha = 1.0f;
		blackFadeScript.endingAlpha = 0.0f;
		blackFadeScript.timeToTransition = 1.5f;
		blackFadeScript.imageColor = new Vector4(0.0f, 0.0f, 0.0f, blackFadeScript.startingAlpha);
		blackFadeScript.startTransition();

		startFinished = true;
	}
	
	void Update () 
	{
		if (!startFinished)
		{
			return;
		}

		if (blackFadeScript.isTransitionOver() && !bountiveFadeScript.isTransitionOver())
		{
			elapsedPauseTime += Time.deltaTime;

			if (elapsedPauseTime >= pauseTime)
			{
				bountiveFadeScript.startTransition();
				elapsedPauseTime = 0;
			}
		}
		else if (bountiveFadeScript.isTransitionOver())
		{
			setHomeScreen();
		}


		if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
		{
			setHomeScreen();
		}
	}

	private void setHomeScreen()
	{
		elapsedPauseTime = 0;
		SceneManager.LoadScene("Scenes/home_scene");
	}
}
