﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour 
{
	public float wallSpeedMultipler;

	[HideInInspector]
	public MovementScript wallMovement;

	private Vector3 shiftOffset = new Vector3();
	private float height;

	private bool isUpdating;

	void Start () 
	{
		isUpdating = false;
		height = this.GetComponent<SpriteRenderer>().sprite.rect.height;
		shiftOffset.y = height * WallSpawnerScript.WALL_SHIFT;
		wallMovement = this.gameObject.GetComponent<MovementScript>();
		DontDestroyOnLoad(this.transform.gameObject);
		StartCoroutine(updateWall());
	}

	IEnumerator updateWall ()
	{
		isUpdating = true;

		while (true)
		{
			if (this.transform.position.y + (height / 2.0f) < -(Camera.main.GetComponent<ScaleWidthScript>().calculatedHeight))
			{
				this.transform.position += shiftOffset;
			}
			else if (this.transform.position.y - (height / 2.0f) > (Camera.main.GetComponent<ScaleWidthScript>().calculatedHeight))
			{
				this.transform.position -= shiftOffset;
			}

			if (GameManagerScript.getGameManagerScript().isInGame())
			{
				wallMovement.setVelocity(GameManagerScript.getGameManagerScript().getHeightManager().getMovementScript().getVelocity());
			}

			this.transform.position += wallMovement.getVelocity() * Time.deltaTime * wallSpeedMultipler;

			//Debug.Log("Velocity " + GameManagerScript.getGameManagerScript().getHeightManager().getMovementScript().getVelocity() * Time.deltaTime);

			yield return null;
		}
	}

	void startCoroutine()
	{
		if (isUpdating)
		{
			StopCoroutine("updateWall");
		}

		StartCoroutine("updateWall");
	}
}
