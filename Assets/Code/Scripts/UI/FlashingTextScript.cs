using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingTextScript : MonoBehaviour 
{
	private const float ALPHA_OPAQUE = 1.0f;
	private const float ALPHA_TRANSPARENT = 0.0f;

	public GameObject flashingText;

	//Time between flashes
	public float flashTime = 0.5f;

	//Time it takes to flash
	public float fadeTime = 1.0f;

	private float elapsedIntervalCounter;
	private float alphaTracker;

	private bool fadeOut;

	private Color color;
	private Text objText;

	void Start () 
	{
		objText = flashingText.GetComponent<Text>();
		reset();
	}
	
	void Update () 
	{
		elapsedIntervalCounter += Time.deltaTime;

		if (elapsedIntervalCounter >= flashTime)
		{

			if (fadeOut)
			{
				alphaTracker -= Time.deltaTime * fadeTime;

				if (alphaTracker <= ALPHA_TRANSPARENT)
				{
					alphaTracker = ALPHA_TRANSPARENT;
					fadeOut = false;
					elapsedIntervalCounter = 0.0f;
				}
			}
			else
			{
				alphaTracker += Time.deltaTime * fadeTime;

				if (alphaTracker >= ALPHA_OPAQUE)
				{
					alphaTracker = ALPHA_OPAQUE;
					fadeOut = true;
					elapsedIntervalCounter = 0.0f;
				}
			}

			color.a = alphaTracker;
			objText.color = color;
		}
	}

	private void reset()
	{
		elapsedIntervalCounter = 0.0f;
		alphaTracker = ALPHA_OPAQUE;
		fadeOut = true;
		color = objText.color;
	}
}
