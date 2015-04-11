using UnityEngine;
using System.Collections;

public class ScreenSize : MonoBehaviour {

	public int screenWidth;
	public int section1, section2, section3, section4, section5, section6;


	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		section1 = screenWidth / 6;
		section2 = (int)(screenWidth / 6) * 2;
		section3 = (int)(screenWidth / 6) * 3;
		section4 = (int)(screenWidth / 6) * 4;
		section5 = (int)(screenWidth / 6) * 5;
		section6 = (int)screenWidth;

		print ("screen width is " + screenWidth);
		print ("section1 is " + section1);
		print ("section2 is " + section2);
		print ("section3 is " + section3);
		print ("section4 is " + section4);
		print ("section5 is " + section5);
		print ("section6 is " + section6);
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
