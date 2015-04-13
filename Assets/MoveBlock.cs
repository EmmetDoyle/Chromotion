using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {


	public Transform blockTransform;
	public SpriteRenderer blockRender;
	public bool begun;
	public float r, g, b;

	// Use this for initialization
	void Start () {
		blockTransform = this.transform;
		blockRender = gameObject.GetComponent<SpriteRenderer> ();

		Vector3 screenPos = GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(blockTransform.position);
		screenPos.y = 0;

		begun = false;
		r = 0f;
		g = 0.5f;
		b = 1f;

		blockRender.color = new Color (r, g, b, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (!begun) {
			blockTransform.position = new Vector3 (blockTransform.position.x, GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y, blockTransform.position.z);
			begun = true;
		}

		if (blockTransform.position.y > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().topBorder.y) {
			blockRender.color = new Color (r, g, b, 1);
			blockTransform.position = new Vector3 (blockTransform.position.x, GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y, blockTransform.position.z);
		} else {
			blockTransform.position = new Vector3 (blockTransform.position.x, (blockTransform.position.y + 0.03f), blockTransform.position.z);
		}
	}

	void ColorPicker ()
	{
		Color result;
		int choice;

		choice = Random.Range ((int)0, (int)5);

		switch (choice) {
		case 0:
				r = (Random.Range (0, 1000)) / 1000; 
				g = 1; 
				b = 0;
			break;

		case 1:
			     r = (Random.Range (0, 1000)) / 1000; 
			     g = 0; 
			     b = 1;
			break;

		case 2:
			     r = 1; 
			     g = (Random.Range (0, 1000)) / 1000; 
			     b = 0;
			break;

		case 3: 
				 r = 0;
			     g = (Random.Range (0, 1000)) / 1000;
			     b = 1;
			break;

		case 4:
			     r = 1;
			     g = 0;
			     b = (Random.Range (0, 1000)) / 1000;
			break;

		case 5:
			     r = 0;
			     g = 1;
			     b = (Random.Range (0, 1000)) / 1000;
			break;

		}

	}

}
