using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerCharacterController : MonoBehaviour {
	//public GameObject action1Prefab;
	public GameObject actionBPrefab;
	public GameObject actionXPrefab;
	public GameObject actionYPrefab;

	public float actionBCooldownTime = 1.0f;
	public float actionXCooldownTime = 1.0f;
	public float actionYCooldownTime = 1.0f;
	bool canDoActionB = true;
	bool canDoActionX = true;
	bool canDoActionY = true;

	public AudioClip healSound;
	public AudioClip jumpSound;

//	public float cooldownTime = 1.0f;

//	bool canDoAction = true;

	private PlayerInput input;

	GameObject [] friendlyObjects;

	void ActivateActionB()
	{
		canDoActionB = true;
	}

	void ActivateActionX()
	{
		canDoActionX = true;
	}

	void ActivateActionY()
	{
		canDoActionY = true;
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
		if (input.GetPlayerInputAxis("Fire1"))
		{
			// hyppy
			GetComponent<ThirdPersonController>().Jump();
			PlayerInput playerNumber = (PlayerInput)this.GetComponent("PlayerInput");
			AudioClip sfx = this.jumpSound;
			PlayAudio audioPlayer = (PlayAudio)GameObject.Find("Audio").GetComponent("PlayAudio");
			audioPlayer.PlaySound(sfx, playerNumber.playerIndex);
		}

		if (canDoActionB && input.GetPlayerInputAxis("Fire2") )
		{
			GameObject obj = Instantiate (actionBPrefab, GetComponent<Transform> ().position, Quaternion.identity) as GameObject;
			obj.transform.parent = GameObject.FindGameObjectWithTag("DynamicObjects").transform;
			canDoActionB = false;
			Invoke ("ActivateActionB", actionBCooldownTime);
			PlayerInput playerNumber = (PlayerInput)this.GetComponent("PlayerInput");
			AudioClip sfx = this.healSound;
			PlayAudio audioPlayer = (PlayAudio)GameObject.Find("Audio").GetComponent("PlayAudio");
			audioPlayer.PlaySound(sfx, playerNumber.playerIndex);
		}
		if (canDoActionX && input.GetPlayerInputAxis("Fire3"))
		{
			// pommi = x
			GameObject obj = Instantiate (actionXPrefab, GetComponent<Transform> ().position, Quaternion.identity) as GameObject;
			obj.transform.parent = GameObject.FindGameObjectWithTag("DynamicObjects").transform;
			canDoActionX = false;
			Invoke ("ActivateActionX", actionXCooldownTime);
		}
		if (canDoActionY && input.GetPlayerInputAxis("Fire4") )
		{
			// turretti = y
			GameObject obj = Instantiate (actionYPrefab, GetComponent<Transform> ().position, Quaternion.identity) as GameObject;
			obj.transform.parent = GameObject.FindGameObjectWithTag("DynamicObjects").transform;
			canDoActionY = false;
			Invoke ("ActivateActionY", actionYCooldownTime); 
		}
	}
}
