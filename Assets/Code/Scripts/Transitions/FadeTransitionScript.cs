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

	public bool isUIImage;
	public bool isSprite;
	public bool isText;
	public bool destoryAfterTransition;

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

		setImageColor();
	}

	private void transition()
	{
		elapsedTime += Time.deltaTime;

		imageColor.w = Mathf.Lerp(startingAlpha, endingAlpha, (elapsedTime / timeToTransition));

		setImageColor();

		if (elapsedTime >= timeToTransition)
		{
			stopTransition();
		}
	}

	private void stopTransition()
	{
		transitioning = false;
		transitionEnded = true;

		if (destoryAfterTransition)
		{
			Destroy(this.gameObject);
		}
	}

	private void setImageColor()
	{
		if (isUIImage)
		{
			this.GetComponent<Image>().color = imageColor;
		}
		else if (isSprite)
		{
			this.GetComponent<SpriteRenderer>().color = imageColor;
		}
		else if (isText)
		{
			this.GetComponent<Text>().color = imageColor;
		}
	}

	public void reset()
	{
		transitioning = false;
		transitionEnded = false;
		elapsedTime = 0.0f;
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
