using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerCharacterController : MonoBehaviour {
	public GameObject action1Prefab;
	public GameObject action2Prefab;
	public GameObject action3Prefab;
	public GameObject action4Prefab;

	public float actionDelay = 2.0f;

	bool canDoAction = true;

	private PlayerInput input;

	void ActivateAction()
	{
		canDoAction = true;
	}

	// Use this for initialization
	void Start ()
	{
		input = GetComponent<PlayerInput> ();
		if (input == null)
		{
			Debug.LogError("PlayerInput not set to this game object!");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (canDoAction) 
		{
			if (input.GetPlayerInputAxis("Fire1"))
			{
				Instantiate (action1Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", actionDelay); 

			}

			if (input.GetPlayerInputAxis("Fire2") )
			{
				Instantiate (action2Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", actionDelay); 
				
			}
			if (input.GetPlayerInputAxis("Fire3"))
			{
				Instantiate (action3Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", actionDelay); 
				
			}
			if (input.GetPlayerInputAxis("Fire4") )
			{
				Instantiate (action4Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", actionDelay); 
				
			}
		}
	}
}
