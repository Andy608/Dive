using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallScript : MonoBehaviour 
{
	public float wallSpeedMultipler;

	[HideInInspector]
	public MovementScript wallMovement;

	[HideInInspector]
	public Vector2 wallOffset;

	private Material wallMaterial;

	private Vector2 velocity;

	void Awake () 
	{
		wallMaterial = this.GetComponent<Renderer>().material;
		wallOffset = wallMaterial.GetTextureOffset("_MainTex");

		wallMovement = this.gameObject.GetComponent<MovementScript>();
		velocity = new Vector2();
	}
	
	void Update () 
	{
		if (GameManagerScript.getGameManagerScript().isInGame())
		{
			wallMovement.setVelocity(GameManagerScript.getGameManagerScript().getHeightManager().getMovementScript().getVelocity());
		}

		velocity.Set(wallMovement.velocity.x, wallMovement.velocity.y / 20.0f);

		//Debug.Log(velocity);

		this.wallOffset += velocity * Time.deltaTime * wallSpeedMultipler;
		wallMaterial.SetTextureOffset("_MainTex", wallOffset);
	}
}
