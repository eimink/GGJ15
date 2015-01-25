using UnityEngine;
using System.Collections;

public class CameraTearEdges : MonoBehaviour {

	float desiredAspectRatio = 16.0f/9.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		float curAspect = GetComponent<Camera>().aspect;
		
		Rect rc;
		
		if( curAspect < desiredAspectRatio )
		{
			float desiredHeight = ((float)Screen.width)/desiredAspectRatio;
			float d = 1.0f - ((float)desiredHeight/(float)Screen.height);
			float margin = 0.5f * d;
			rc = new Rect( 0.0f, margin*(float)Screen.height, 1.0f*(float)Screen.width, (1.0f - (2.0f*margin))*(float)Screen.height );
		}
		else if( curAspect > desiredAspectRatio )
		{
			float desiredWidth = ((float)Screen.height)*desiredAspectRatio;
			float d = 1.0f - ((float)desiredWidth/(float)Screen.width);
			float margin = 0.5f * d;
			rc = new Rect( margin*(float)Screen.width, 0.0f, (1.0f - (2.0f*margin))*(float)Screen.width, (float)Screen.height );
		}
		else
		{
			return;
			//		rc = new Rect( 0.0f, 0.0f, (float)Screen.width, (float)Screen.height );
		}
		
		GetComponent<Camera> ().rect = rc;

	}
}
