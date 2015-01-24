using UnityEngine;
using System.Collections;

public class AlignToCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = Camera.mainCamera.transform.position - transform.position;
		
		v.x = v.z = 0.0f;
		
		transform.LookAt( Camera.mainCamera.transform.position - v );
		
		transform.rotation =(Camera.mainCamera.transform.rotation); // Take care about camera rotation
	}
}
