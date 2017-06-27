using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledWallScript : MonoBehaviour 
{
	private Vector3 scale;

	ScaleWidthScript screenScaleScript;

	void Start () 
	{
		screenScaleScript = Camera.main.GetComponent<ScaleWidthScript>();
		scale = this.transform.localScale;
	}

	void Update () 
	{
		scale.Set(screenScaleScript.targetWidth, screenScaleScript.calculatedHeight, scale.z);

		if (this.transform.localScale.x < 0)
		{
			scale.x = -scale.x;
		}

		this.transform.localScale = scale;

		scale.Set(1, (float)screenScaleScript.calculatedHeight / (float)screenScaleScript.targetWidth, scale.z);
		this.GetComponent<Renderer>().material.mainTextureScale = scale;
	}
}
