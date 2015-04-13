using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {


	public Transform blockTransform;
	public bool begun;

	// Use this for initialization
	void Start () {
		blockTransform = this.transform;

		Vector3 screenPos = GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(blockTransform.position);
		screenPos.y = 0;

		begun = false;


	}
	
	// Update is called once per frame
	void Update () {
		if (!begun) {
			blockTransform.position = new Vector3 (blockTransform.position.x, GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y, blockTransform.position.z);
			begun = true;
		}

		if (blockTransform.position.y > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().topBorder.y) {
			blockTransform.position = new Vector3 (blockTransform.position.x, GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y, blockTransform.position.z);
		} else {
			blockTransform.position = new Vector3 (blockTransform.position.x, (blockTransform.position.y + 0.03f), blockTransform.position.z);
		}
	}
}
