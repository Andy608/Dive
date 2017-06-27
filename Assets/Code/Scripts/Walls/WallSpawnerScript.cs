using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnerScript : MonoBehaviour 
{	
	public const int WALL_SHIFT = 4;
	//public const int WALL_HEIGHT = 1024 - 1;
	//public const int WALL_WIDTH = 144;

	public GameObject wallPrefab;

	void Start () 
	{
		Vector3 wallPosition = new Vector3();

		int wallHeight = (int)(wallPrefab.GetComponent<SpriteRenderer>().sprite.rect.height);
		int wallWidth = (int)(wallPrefab.GetComponent<SpriteRenderer>().sprite.rect.width);

		for (int i = 0; i < WALL_SHIFT; ++i)
		{
			wallPosition.x = (-Camera.main.GetComponent<ScaleWidthScript>().targetWidth / 2.0f) + (wallWidth / 2.0f);
			wallPosition.y = Camera.main.GetComponent<ScaleWidthScript>().calculatedHeight - (wallHeight * i);
			wallPosition.z = wallPrefab.transform.position.z;

			createWall(false, wallPosition);

			wallPosition.x = (Camera.main.GetComponent<ScaleWidthScript>().targetWidth / 2.0f) - (wallWidth / 2.0f);
			wallPosition.y = Camera.main.GetComponent<ScaleWidthScript>().calculatedHeight + ((wallHeight) / 2.0f) - (wallHeight * i);
			wallPosition.z = wallPrefab.transform.position.z;
			createWall(true, wallPosition);
		}
	}

	private void createWall(bool flipTexture, Vector3 position)
	{
		GameObject coralWall = Instantiate(wallPrefab, 
			position,
			Quaternion.identity);

		if (flipTexture)
		{
			Vector3 scale = coralWall.transform.localScale;
			scale.x *= -1;
			coralWall.transform.localScale = scale;
		}

		DontDestroyOnLoad(coralWall);
	}
}
