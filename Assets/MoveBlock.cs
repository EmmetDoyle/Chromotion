using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {


	public Transform blockTransform;
	public bool printed;

	// Use this for initialization
	void Start () {
		blockTransform = this.transform;

		Vector3 screenPos = GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(blockTransform.position);
		screenPos.y = 0;

		printed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!printed) {
			print (GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y);
		}
		blockTransform.position = new Vector3 (blockTransform.position.x, GameObject.Find("MainCamera").GetComponent<ScreenSize>().bottomBorder.y, blockTransform.position.z);
	}
}
