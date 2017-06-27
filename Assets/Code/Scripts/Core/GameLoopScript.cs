using System;
using UnityEngine;

public class GameLoopScript : MonoBehaviour
{
	private const double LAG_CAP = 0.15f;
	private const int TICKS_PER_SECOND = 60;
	private const float TIME_SLICE = 1.0f / (float)TICKS_PER_SECOND;

	private double lastTime;
	private double currentTime;
	private double deltaTime;
	private double accumulatedTime;
	private double alpha;


	private bool isRunning;

	void Start()
	{
		lastTime = (float)DateTime.Now.Ticks;
	}

	void FixedUpdate()
	{
		currentTime = (float)DateTime.Now.Ticks;
		deltaTime = (currentTime - lastTime) / 10000000.0f;
		lastTime = currentTime;
		accumulatedTime += deltaTime;

		if (accumulatedTime >= LAG_CAP)
		{
			accumulatedTime = LAG_CAP;
		}

		while (accumulatedTime > TIME_SLICE)
		{
			accumulatedTime -= TIME_SLICE;
		}

		alpha = (accumulatedTime / deltaTime);
	}

	public double getAlpha()
	{
		return alpha;
	}
}
