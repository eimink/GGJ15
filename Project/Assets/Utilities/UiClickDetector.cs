using UnityEngine;
using System.Collections;

public class UiClickDetector : MonoBehaviour {

	GameObject targetObject;
	string targetMethod;

	void OnMouseUpAsButton()
	{
		targetObject.SendMessage (targetMethod);
	}
}
