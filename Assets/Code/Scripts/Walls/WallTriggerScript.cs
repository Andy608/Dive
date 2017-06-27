using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerScript : MonoBehaviour 
{
	public bool isBottomTrigger;
	private Vector3 offset = new Vector3();

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Wall")
		{
			offset.y = ((collision.gameObject.GetComponent<SpriteRenderer>().sprite.rect.height) * WallSpawnerScript.WALL_SHIFT);

			if (isBottomTrigger)
			{
				collision.gameObject.transform.position += offset;
			}
			else
			{
				collision.gameObject.transform.position -= offset;
			}
		}
	}
}
