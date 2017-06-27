using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillColorScript : MonoBehaviour 
{
	private readonly Color BACKGROUND_0_COLOR = new Color(0x41 / 255.0f, 0xF2 / 255.0f, 0xF2 / 255.0f);
	private readonly Color BACKGROUND_1_COLOR = new Color(0x40 / 255.0f, 0xA6 / 255.0f, 0xDD / 255.0f);
	private readonly Color BACKGROUND_2_COLOR = new Color(0x37 / 255.0f, 0x5B / 255.0f, 0xBF / 255.0f);
	private readonly Color BACKGROUND_3_COLOR = new Color(0x3D / 255.0f, 0x24 / 255.0f, 0x7F / 255.0f);
	private readonly Color BACKGROUND_4_COLOR = new Color(0x1C / 255.0f, 0x0B / 255.0f, 0x26 / 255.0f);

	public int backgroundColorID;

	void Start () 
	{
		switch (backgroundColorID)
		{
		case 0:
			this.gameObject.GetComponent<SpriteRenderer>().color = BACKGROUND_0_COLOR;
			break;
		case 1:
			this.gameObject.GetComponent<SpriteRenderer>().color = BACKGROUND_1_COLOR;
			break;
		case 2:
			this.gameObject.GetComponent<SpriteRenderer>().color = BACKGROUND_2_COLOR;
			break;
		case 3:
			this.gameObject.GetComponent<SpriteRenderer>().color = BACKGROUND_3_COLOR;
			break;
		case 4:
			this.gameObject.GetComponent<SpriteRenderer>().color = BACKGROUND_4_COLOR;
			break;
		}
	}
}
