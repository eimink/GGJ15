using UnityEngine;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour {
	public GameObject bombPrefab;

	int playerId;

	public void SetPlayerId(int id)
	{
		playerId = id;
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("P1_Fire1")) 
		{
			Instantiate(bombPrefab, GetComponent<Transform>().position, Quaternion.identity);
		//	Debug.Log("P1_Fire1");
		}
		/*
		if (Input.GetButton ("P1_Fire2")) 
		{
			Debug.Log("P1_Fire2");
		}
		if (Input.GetButton ("P1_Fire3")) 
		{
			Debug.Log("P1_Fire3");
		}
		if (Input.GetButton ("P1_Fire4")) 
		{
			Debug.Log("P1_Fire4");
		}*/

		//playerNum
	}
}
