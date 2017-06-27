using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScaleScript : MonoBehaviour 
{
	public static Vector2 nativeRes = new Vector2 (270, 480);

	private const float PIXELS_PER_UNIT = 1.0f;
	private static float pixelsToUnits;

	private Camera cameraObj;
	private static float ratio;

	void Start() 
	{
		cameraObj = this.gameObject.GetComponent<Camera>();

		updateRatio ();
		pixelsToUnits = ratio * PIXELS_PER_UNIT;
		cameraObj.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
	}

	public static float getRatio () 
	{
		updateRatio ();
		return ratio;
	}

	public static float getPixelsToUnits () 
	{
		return pixelsToUnits;
	}

	public static void updateRatio () 
	{
		ratio = Screen.width / nativeRes.x;
	}
}
