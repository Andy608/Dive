using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransitionScript : MonoBehaviour
{
	public float timeToTransition = 2.0f;

	public Vector4 imageColor;
	public float startingAlpha;
	public float endingAlpha;

	private bool transitioning;
	private bool transitionEnded;
	private float elapsedTime;

	void Start () 
	{
		transitionEnded = false;
	}
	
	void Update () 
	{
		if (isTransitioning())
		{
			transition();
		}
	}

	public void startTransition()
	{
		transitioning = true;
		imageColor.w = startingAlpha;

		if (this.GetComponent<SpriteRenderer>() == null)
		{
			this.GetComponent<Image>().color = imageColor;
		}
		else
		{
			this.GetComponent<SpriteRenderer>().color = imageColor;
		}
	}

	private void transition()
	{
		elapsedTime += Time.deltaTime;

		imageColor.w = startingAlpha - (elapsedTime / timeToTransition);
		if (this.GetComponent<SpriteRenderer>() == null)
		{
			this.GetComponent<Image>().color = imageColor;
		}
		else
		{
			this.GetComponent<SpriteRenderer>().color = imageColor;
		}

		if (elapsedTime >= timeToTransition)
		{
			stopTransition();
		}
	}

	private void stopTransition()
	{
		transitioning = false;
		transitionEnded = true;
		Destroy(this.gameObject);
	}

	public bool isTransitioning()
	{
		return transitioning;
	}

	public bool isTransitionOver()
	{
		return transitionEnded;
	}
}
