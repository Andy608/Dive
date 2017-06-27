using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerSpawnScript : MonoBehaviour {

	public GameObject wallTriggerPrefab;

	public float topSpawnerMultipler;
	public float bottomSpawnerMultipler;
	public float yScale;

	private ScaleWidthScript scaledScreenScript;

	void Start () 
	{
		scaledScreenScript = Camera.main.GetComponent<ScaleWidthScript>();

		Vector3 wallTriggerPosition = new Vector3(0, 0, -1);
		wallTriggerPosition.y = topSpawnerMultipler * scaledScreenScript.calculatedHeight;
		createWallTrigger(false, wallTriggerPosition);

		wallTriggerPosition.y = -(bottomSpawnerMultipler * scaledScreenScript.calculatedHeight);
		createWallTrigger(true, wallTriggerPosition);
	}

	private void createWallTrigger(bool isBottomTrigger, Vector3 position)
	{
		GameObject wallTrigger = Instantiate(wallTriggerPrefab,
			position,
			Quaternion.identity);

		Vector3 scale = wallTrigger.transform.localScale;
		scale.x = scaledScreenScript.targetWidth;
		scale.y = yScale;
		wallTrigger.transform.localScale = scale;

		if (isBottomTrigger)
		{
			wallTrigger.GetComponent<WallTriggerScript>().isBottomTrigger = true;
		}
	}
}
