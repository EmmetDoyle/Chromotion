﻿using UnityEngine;
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
		r = 0.0f;
		g = 0.0f;
		b = 0.0f;
		render.color = new Color (r, g, b, 1);

		speed = 5.0f;

		//print(GameObject.Find("MainCamera").renderer.bounds.size.x);
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Horizontal");

		ballRigidbody.velocity = new Vector3 (move * speed, ballRigidbody.velocity.y, 0);

		if (ballTransform.position.y > GameObject.Find ("Block").GetComponent<MoveBlock> ().blockTransform.position.y) {
			ballTransform.position = new Vector3 (ballTransform.position.x, ballTransform.position.y - 0.5f, ballTransform.position.z);
		} else {
			ballTransform.position = new Vector3 (ballTransform.position.x, GameObject.Find ("Block").GetComponent<MoveBlock> ().blockTransform.position.y, ballTransform.position.z);
		}

		Vector3 screenPos = GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(ballTransform.position);
		if (screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1) {
			r = 1f;
			g = screenPos.x * (1f / GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1);
			print (g);
			b = 0f;
		} else if (screenPos.x > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1 && screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section2) {
			r = (((GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1) - screenPos.x) * (1f / (GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1))) + 1;
			g = 1f;
			b = 0f;
		} else if (screenPos.x > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section2 && screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section3){
			r = 0f;
			g = 1f;
			b = (screenPos.x - GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section2) * (1f / GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1);
		}
		else if (screenPos.x > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section3 && screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section4){
			r = 0f;
			g = (((GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section3) - screenPos.x) * (1f / (GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1))) + 1;
			b = 1f;
		}
		else if (screenPos.x > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section4 && screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section5){
			r = (screenPos.x - GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section4) * (1f / GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1);
			g = 0f;
			b = 1f;
		}
		else if (screenPos.x > GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section5 && screenPos.x < GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section6){
			r = 1f;
			g = 0f;
			b = (((GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section5) - screenPos.x) * (1f / (GameObject.Find ("MainCamera").GetComponent<ScreenSize> ().section1))) + 1;
		}

		render.color = new Color (r, g, b, 1);
	}
}
