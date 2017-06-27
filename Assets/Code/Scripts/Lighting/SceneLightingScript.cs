using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLightingScript : MonoBehaviour 
{
	public float completeLightnessDepth;
	public float completeDarknessDepth;

	private Light sceneLight;
	private float depth;
	private float lerpPercent;

	void Start()
	{
		sceneLight = this.gameObject.GetComponent<Light>();
	}

	void Update () 
	{
		depth = GameManagerScript.getGameManagerScript().getHeightManager().getDepth();


		lerpPercent = (depth - completeLightnessDepth) / (completeDarknessDepth - completeLightnessDepth);

		sceneLight.intensity = Mathf.Lerp(1.0f, 0.0f, lerpPercent);
	}
}
