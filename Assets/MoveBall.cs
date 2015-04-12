using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	private Rigidbody2D ballRigidbody;
	private SpriteRenderer render;
	public Transform ballTransform;

	private float speed;
	public float r, g, b;
	

	// Use this for initialization
	void Start () {

		ballRigidbody = this.rigidbody2D;
		render = gameObject.GetComponent<SpriteRenderer> ();
		ballTransform = this.transform;
		r = 0f;
		g = 0f;
		b = 0f;
		render.color = new Color (r, g, b, 1);

		speed = 5.0f;

		//print(GameObject.Find("MainCamera").renderer.bounds.size.x);
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Horizontal");

		ballRigidbody.velocity = new Vector3 (move * speed, ballRigidbody.velocity.y, 0);

		Vector3 screenPos = GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(ballTransform.position);
		if (screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1) {
			r = 1f;
			g = 0f;
			b = 0f;
		} else if (screenPos.x > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1 && screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section2) {
			r = 1f;
			g = 1f;
			b = 0f;
		} else {
			r = 0f;
			g = 0f;
			b = 0f;
		}
		render.color = new Color (r, g, b, 1);
	}
}
