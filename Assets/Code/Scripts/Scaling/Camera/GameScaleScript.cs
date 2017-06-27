using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScaleScript : MonoBehaviour 
{
	private const float RATIO = 0.5625f;
	private static float orthographicSize = GUIScaleScript.nativeRes.x;

	private Camera cameraObj;
	private static float ratio;

	void Start() 
	{
		cameraObj = this.gameObject.GetComponent<Camera>();

		cameraObj.projectionMatrix = Matrix4x4.Ortho(
			-orthographicSize / 2.0f, orthographicSize / 2.0f,
				-orthographicSize, orthographicSize, 
				cameraObj.nearClipPlane, cameraObj.farClipPlane);
	}

	public static float getRatio () 
	{
		return RATIO;
	}
}
