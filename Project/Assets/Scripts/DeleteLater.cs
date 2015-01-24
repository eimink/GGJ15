using UnityEngine;
using System.Collections;

public class DeleteLater : MonoBehaviour {
	public float deleteTime = 5.0f;

	// Use this for initialization
	void Start () {
		Invoke ("DeleteMe", deleteTime);
	}
	
	// Update is called once per frame
	void DeleteMe () {
		Destroy (gameObject);
	}
}
