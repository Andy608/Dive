using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class WatermarkSceneScript : MonoBehaviour {

	void Update()
	{
		if (SplashScreen.isFinished)
		{
			SceneManager.LoadScene("Scenes/splash_scene");
		}
	}
}
