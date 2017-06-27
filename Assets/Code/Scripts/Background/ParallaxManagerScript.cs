using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManagerScript : MonoBehaviour 
{
	public GameObject[] backgroundObjectPrefabs;

	private List<GameObject> activeBackgrounds;
	private GameObject[] backgroundObjects;

	void Start () 
	{
		activeBackgrounds = new List<GameObject>(backgroundObjectPrefabs.Length);
		backgroundObjects = new GameObject[backgroundObjectPrefabs.Length];

		for (int i = 0; i < backgroundObjects.Length; ++i)
		{
			backgroundObjects[i] = Instantiate(backgroundObjectPrefabs[i]);
			DontDestroyOnLoad(backgroundObjects[i]);
			backgroundObjects[i].SetActive(false);
		}
	}

	void Update ()
	{
		float depth = GameManagerScript.getGameManagerScript().getHeightManager().getDepth();
		//Debug.Log(depth);

		for (int i = 0; i < backgroundObjects.Length; ++i)
		{
			if (!activeBackgrounds.Contains(backgroundObjects[i]) && 
				(depth > backgroundObjects[i].GetComponent<BackgroundScript>().startLerpY && 

				(i + 1 == backgroundObjects.Length || (i + 1 < backgroundObjects.Length && 
				depth < backgroundObjects[i + 1].GetComponent<BackgroundScript>().endLerpY))))
			{
				//Debug.Log("ACTIVATING BACKGROUND: " + i);
				activeBackgrounds.Add(backgroundObjects[i]);
				backgroundObjects[i].SetActive(true);
			}
			else if (activeBackgrounds.Contains(backgroundObjects[i]) && 
				((depth < backgroundObjects[i].GetComponent<BackgroundScript>().startLerpY && i - 1 >= 0) ||
					(i + 1 < backgroundObjects.Length && depth > backgroundObjects[i + 1].GetComponent<BackgroundScript>().endLerpY)))
			{
				//Debug.Log("DEACTIVATING BACKGROUND: " + i);
				activeBackgrounds.Remove(backgroundObjects[i]);
				backgroundObjects[i].SetActive(false);
			}
		}
	}

	public void lerpBackgrounds(float lerpDepth)
	{
		//for (int i = 0; i < activeBackgrounds.Count; ++i)
		//{
		//	activeBackgrounds[i].GetComponent<BackgroundScript>().lerpBackground(lerpDepth);
		//}
	}
}
