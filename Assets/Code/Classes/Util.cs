using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
	public static void resizeObjectToScreen(GameObject obj)
	{
		ScaleWidthScript screenScaleScript = Camera.main.GetComponent<ScaleWidthScript>();

		Sprite sprite = obj.GetComponent<SpriteRenderer>().sprite;
		Vector3 scale = new Vector3(screenScaleScript.targetWidth, screenScaleScript.calculatedHeight, 1.0f);
		obj.transform.localScale = scale;
	}

	public static void fitObjectToWidth(GameObject obj)
	{
		ScaleWidthScript screenScaleScript = Camera.main.GetComponent<ScaleWidthScript>();

		Sprite sprite = obj.GetComponent<SpriteRenderer>().sprite;
		Vector3 scale = new Vector3(screenScaleScript.targetWidth / (float)sprite.rect.width, screenScaleScript.targetWidth / (float)sprite.rect.width, 1.0f);
		obj.transform.localScale = scale;
	}
}
