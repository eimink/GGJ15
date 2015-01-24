using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerCharacterController : MonoBehaviour {
	//public GameObject action1Prefab;
	public GameObject actionBPrefab;
	public GameObject actionXPrefab;
	public GameObject actionYPrefab;

	public float cooldownTime = 1.0f;

	bool canDoAction = true;

	private PlayerInput input;

	GameObject [] friendlyObjects;

	void ActivateAction()
	{
		canDoAction = true;
	}

	void DoTriggerAction(Collider other)
	{
		if (other.gameObject != gameObject && other.gameObject.tag == gameObject.tag)
		{
			SphereCollider thisSc = GetComponent<SphereCollider> ();
			if (other.GetType().ToString() == "UnityEngine.SphereCollider" )
			{
				SphereCollider otherSc = (SphereCollider)other;
				Vector3 delta = other.gameObject.GetComponent<Transform> ().position - gameObject.GetComponent<Transform> ().position;

				float dLimit = thisSc.radius + otherSc.radius;
				float f = 0.07f * (delta.magnitude - dLimit);
			//	Debug.Log("f: " + f.ToString());
				CharacterController controller = GetComponent<CharacterController> ();
				controller.Move (f * delta.normalized);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		DoTriggerAction (other);
	}

	void OnTriggerStay(Collider other) 
	{
		DoTriggerAction (other);
	}

	// Use this for initialization
	void Start ()
	{
		input = GetComponent<PlayerInput> ();
		if (input == null)
		{
			Debug.LogError("PlayerInput not set to this game object!");
		}

		friendlyObjects = GameObject.FindGameObjectsWithTag (gameObject.tag);
	//	Debug.Log ("Found " + friendlyObjects.Length + " " + gameObject.tag + "s" );
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (canDoAction) 
		{
			if (input.GetPlayerInputAxis("Fire1"))
			{
				// hyppy
				GetComponent<ThirdPersonController>().Jump();
			}

			if (input.GetPlayerInputAxis("Fire2") )
			{
				Instantiate (actionBPrefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", cooldownTime); 
			}
			if (input.GetPlayerInputAxis("Fire3"))
			{
				// pommi = x
				Instantiate (actionXPrefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", cooldownTime);
			}
			if (input.GetPlayerInputAxis("Fire4") )
			{
				// turretti = y
				Instantiate (actionYPrefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", cooldownTime); 
			}
		}
	}
}
