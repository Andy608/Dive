using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningParallaxScript : MonoBehaviour 
{
	public float startingDepth;
	public float endingDepth;
	public float startingVelocity;
	public float timeToGetThere;

	private Vector3 targetPosition;
	private Vector3 currentPosition;
	private Vector3 velocity;

	private bool isAnimating;
	private bool isFinishingAnimation;

	private ParallaxManagerScript parallaxManagerScript;

	private GameObject[] walls;

	void Start () 
	{
		currentPosition = new Vector3(transform.position.x, startingDepth, transform.position.z);
		targetPosition = new Vector3(transform.position.x, endingDepth, transform.position.z);
		velocity = new Vector3(0, startingVelocity, 0);
		walls = GameManagerScript.getGameManagerScript().walls;
	}

	void Update()
	{
		if (this.isAnimating && !GameManagerScript.getGameManagerScript().isInGame())
		{
			updateParallax();
		}
	}

	private void updateParallax () 
	{
		currentPosition = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, timeToGetThere);

		for (int i = 0; i < walls.Length; ++i)
		{
			walls[i].GetComponent<MovementScript>().setVelocity(0.0f, -currentPosition.y / walls[i].GetComponent<WallScript>().wallSpeedMultipler * 8.0f);
		}

		if (currentPosition.y < 0.01f)
		{
			isAnimating = false;
		}
		else if (currentPosition.y <= 20.0f)
		{
			isFinishingAnimation = true;
		}

		GameManagerScript.getGameManagerScript().getHeightManager().getMovementScript().setPosition(currentPosition.x, currentPosition.y);
	}

	public void startAnimation(ParallaxManagerScript parallaxManagerScript)
	{
		isAnimating = true;
		this.parallaxManagerScript = parallaxManagerScript;
	}

	public bool getIsAnimating()
	{
		return isAnimating;
	}

	public bool getIsFinishingAnimation()
	{
		return isFinishingAnimation;
	}
}
