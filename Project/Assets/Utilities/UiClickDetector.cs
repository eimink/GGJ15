using UnityEngine;
using System.Collections;

public class UiClickDetector : MonoBehaviour {

	public GameObject targetObject;
	public string targetMethod;

	void Awake()
	{
		if (targetObject == null)
			targetObject = this.gameObject;
	}

	void OnMouseUpAsButton()
	{
		if (targetMethod == null)
			Debug.LogError ("Target Method cannot be null!");
		else
			targetObject.SendMessage (targetMethod);
	}
}
