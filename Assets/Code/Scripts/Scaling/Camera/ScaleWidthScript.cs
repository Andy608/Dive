using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWidthScript : MonoBehaviour 
{
	public int targetWidth;
	public float pixelsToUnits;

	public int calculatedHeight;
	private Camera cameraObj;

	void Awake()
	{
		calculatedHeight = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
		cameraObj = this.GetComponent<Camera>();
	}

	void Start ()
	{
		StartCoroutine(updateCamera());
	}

	IEnumerator updateCamera()
	{
		while (true)
		{
			calculatedHeight = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
			//Debug.Log(calculatedHeight);

			cameraObj.orthographicSize = calculatedHeight / pixelsToUnits / 2;

			yield return null;
		}
	}
}
