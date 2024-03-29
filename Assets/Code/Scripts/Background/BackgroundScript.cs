﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour 
{
	public float startPositionY;
	public float endPositionY;

	public float startLerpY;
	public float endLerpY;

	private float lerpPercent;

	private Vector3 backgroundPosition;

	private HeightManagerScript heightManagerScript;

	void Start () 
	{
		lerpPercent = 0.0f;
		backgroundPosition = this.transform.position;

		float topScreen = Camera.main.GetComponent<ScaleWidthScript>().calculatedHeight / 2.0f;

		Util.fitObjectToWidth(this.gameObject);

		startPositionY = topScreen + startPositionY;
		endPositionY = topScreen + endPositionY;
		heightManagerScript = GameManagerScript.getGameManagerScript().getHeightManager();
		StartCoroutine("lerpBackground");
	}

	IEnumerator lerpBackground()
	{
		while (true)
		{
			lerpPercent = (heightManagerScript.getDepth() + heightManagerScript.getStartingDepth() - startLerpY) / (endLerpY - startLerpY);

			//Debug.Log(endPositionY + " " + lerpPercent);


			backgroundPosition.y = Camera.main.transform.position.y + Mathf.Lerp(startPositionY, endPositionY, lerpPercent);
			backgroundPosition.z = this.transform.position.z;

			this.transform.position = backgroundPosition;

			yield return null;
		}
	}
}
