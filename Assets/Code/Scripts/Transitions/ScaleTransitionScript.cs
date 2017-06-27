using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransitionScript : MonoBehaviour
{
	public float timeToTransition;
	public float startingScale;
	public float endingScale;

	private Vector3 objectScale;
	private bool isTransitioning;
	private float mElapsedTime;

	void Start () 
	{
		objectScale = new Vector3(startingScale, startingScale, startingScale);
		startTransition();
	}

	void Update () 
	{
		if (isTransitioning)
		{
			transition();
		}
	}

	private void startTransition()
	{
		isTransitioning = true;
	}

	private void transition()
	{
		mElapsedTime += Time.deltaTime;

		if (mElapsedTime > timeToTransition)
		{
			stopTransition();
		}
		else
		{
			float delta = (mElapsedTime / timeToTransition);
			float scale = ((1.0f - delta) * startingScale) + delta * endingScale;

			objectScale.Set(scale, scale, scale);
			this.transform.localScale = objectScale;
		}
	}

	private void stopTransition()
	{
		isTransitioning = false;
	}
}
