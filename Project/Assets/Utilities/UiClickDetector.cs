using UnityEngine;
using System.Collections;

public class UiClickDetector : MonoBehaviour {

	public GameObject targetObject;
	public string targetMethod;

	void Start()
	{
		if (targetObject == null)
			targetObject = this.gameObject;
	}

	void OnMouseDown()
	{
		Debug.Log ("OnClicked event: " + this.gameObject.name);
		if (targetMethod == null)
			Debug.LogError ("Target Method cannot be null!");
		else
			targetObject.SendMessage (targetMethod);
	}
}
