using UnityEngine;
using System.Collections;

public class HealBox : MonoBehaviour {
	
	public float fuseDelay = 2.0f;
	public float activityDuration = 2.0f;
	public float healRadius = 2.0f;
	public float healAmountPerSecond = 5.0f;
	public float distanceFalloff = 2.0f;

	void ApplyHeal(string tag)
	{
		GameObject [] objects = GameObject.FindGameObjectsWithTag(tag);
		for (int i=0; i<objects.Length; ++i)
		{
			Vector3 delta = objects[i].GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
			if( delta.magnitude <= healRadius )
			{
				float dmg = (healRadius - delta.magnitude) / healRadius;
				objects[i].SendMessage("Heal",Time.deltaTime*dmg*healAmountPerSecond,SendMessageOptions.DontRequireReceiver);
			}
		}

		
		//this.gameObject.GetComponent<AudioSource>().Play();
	}

	// Use this for initialization
	void Start ()
	{
		Invoke("Destroy", activityDuration);
	}
	
	void Update()
	{
		Debug.Log ("Heal   ");
		ApplyHeal("Player1");
		ApplyHeal("Player2");
	}

	void Destroy()
	{
		Destroy (this.gameObject);
	}
}
