using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthScript : MonoBehaviour 
{
	public GameObject depthTextObj;

	private Text depthText;
	private HeightManagerScript heightManagerScript;
	private string depth;

	void Start () 
	{
		depthText = depthTextObj.GetComponent<Text>();
		depthText.text = "0" + getUnit();
		heightManagerScript = GameManagerScript.getGameManagerScript().getHeightManager();
	}
	
	void Update () 
	{
		depth = Mathf.Floor(heightManagerScript.getDepth()).ToString("n0");
		depthText.text = depth + getUnit();
	}

	private string getUnit()
	{
		return "m";
	}
}
