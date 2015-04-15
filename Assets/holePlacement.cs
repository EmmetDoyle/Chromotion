using UnityEngine;
using System.Collections;

public class holePlacement : MonoBehaviour {

	public Transform holeTransform;
	public SpriteRenderer holeRenderer;

	// Use this for initialization
	void Start () {
		holeTransform = this.transform;
		holeRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (holeTransform.position.y > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().topBorder.y) {
			holeTransform.position = new Vector3 (holeTransform.position.x, GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().bottomBorder.y, holeTransform.position.z);
		} else {
			holeTransform.position = new Vector3 (holeTransform.position.x, (holeTransform.position.y + 0.03f), holeTransform.position.z);
		}

	}
}
