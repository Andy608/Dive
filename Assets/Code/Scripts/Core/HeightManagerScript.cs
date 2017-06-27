using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightManagerScript : MonoBehaviour
{
	private MovementScript gameMovementScript;

	void Start () 
	{
		gameMovementScript = this.gameObject.GetComponent<MovementScript>();
	}

	public float getDepth()
	{
		return gameMovementScript.getPosition().y;
	}

	public void setDepth(float depth)
	{
		gameMovementScript.setPosition(0.0f, depth);
	}

	public void setupForGame()
	{
		//GameObject[] walls = GameManagerScript.getGameManagerScript().walls;
		
		//for (int i = 0; i < walls.Length; ++i)
		//{
			//walls[i].GetComponent<WallScript>().wallMovement.setVelocity(0, 0);
		//}

		//gameMovementData.resetToZero();
	}

	public MovementScript getMovementScript()
	{
		return gameMovementScript;
	}
}
