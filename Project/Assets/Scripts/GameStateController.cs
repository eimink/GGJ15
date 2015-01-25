﻿using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	int frameCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Escape))
					Application.LoadLevel (0);

		if (frameCount > 10) {
						if (GameObject.FindGameObjectsWithTag ("Player1").Length == 0) {
								Debug.Log ("Player2 wins!");
								Application.LoadLevel (0);
						}

						if (GameObject.FindGameObjectsWithTag ("Player2").Length == 0) {
								Debug.Log ("Player1 wins!");
						Application.LoadLevel (0);
						}
				}

		++frameCount;
	}
}
