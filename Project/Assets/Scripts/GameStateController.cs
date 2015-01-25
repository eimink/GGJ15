using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	int frameCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (frameCount > 10) {
						if (GameObject.FindGameObjectsWithTag ("Player1").Length == 0) {
								Debug.Log ("Player2 wins!");
								Application.LoadLevel (1);
						}

						if (GameObject.FindGameObjectsWithTag ("Player2").Length == 0) {
								Debug.Log ("Player1 wins!");
								Application.LoadLevel (1);
						}
				}

		++frameCount;
	}
}
