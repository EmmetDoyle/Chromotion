using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	private Rigidbody2D ballRigidbody;
	private SpriteRenderer render;

	private float speed;
	public float r, g, b;
	

	// Use this for initialization
	void Start () {

		ballRigidbody = this.rigidbody2D;
		render = gameObject.GetComponent<SpriteRenderer> ();
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

		ballRigidbody.velocity = new Vector2 (move * speed, ballRigidbody.velocity.y);
	}
}
