using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerCharacterController : MonoBehaviour {
	public GameObject action1Prefab;
	public GameObject action2Prefab;
	public GameObject action3Prefab;
	public GameObject action4Prefab;

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
				Instantiate (action1Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", cooldownTime); 

			}

			if (input.GetPlayerInputAxis("Fire2") )
			{
				Instantiate (action2Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", cooldownTime); 
				
			}
			if (input.GetPlayerInputAxis("Fire3"))
			{
				Instantiate (action3Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", cooldownTime); 
				
			}
			if (input.GetPlayerInputAxis("Fire4") )
			{
				Instantiate (action4Prefab, GetComponent<Transform> ().position, Quaternion.identity);
				canDoAction = false;
				Invoke ("ActivateAction", cooldownTime); 
				
			}
		}
	}
}
