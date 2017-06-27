using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLightSpawnerScript : MonoBehaviour 
{
	public GameObject sceneLightPrefab;
	private GameObject sceneLight;

	void Start () 
	{
		sceneLight = Instantiate(sceneLightPrefab);
		sceneLight.transform.parent = this.gameObject.transform;
	}
}
