﻿using UnityEngine;
using System.Collections;

public class TimeBomb : MonoBehaviour {

	public float fuseDelay = 2.0f;
	public float explosionRadius = 4.0f;
	public float maxDamage = 10.0f;
	public float explosionForce = 1000.0f;
	public float distanceFalloff = 0.1f;
	public float explosionTime = 0.5f;
	private bool exploding = false;

	float timeSinceExplosion = 0.0f;

	Light light;

	// Use this for initialization
	void Start () {
		light = GetComponentInChildren<Light> ();
		light.enabled = false;
		Invoke ("Explode", fuseDelay);
	}

	void ApplyDamage(string tag)
	{
		float scale = explosionRadius*(explosionTime-timeSinceExplosion);
		GameObject [] objects = GameObject.FindGameObjectsWithTag(tag);
		for (int i=0; i<objects.Length; ++i)
		{
			Vector3 delta = objects[i].GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
			if( delta.magnitude <= scale )
			{
				float dmg = (explosionRadius - delta.magnitude) / explosionRadius;
				objects[i].SendMessage("ApplyDamage",Time.deltaTime*dmg*maxDamage*(1.0f/explosionTime),SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void LightOff()
	{
		light.enabled = false;
	}

	void Explode()
	{
		exploding = true;
		this.gameObject.GetComponent<ParticleSystem>().Play();
		GameObject bm = GetComponent<Transform>().FindChild("Bomb_model").gameObject;
		bm.SetActive (false);
		light.enabled = true;

		timeSinceExplosion = 0.0f;
		Invoke ("DisableDamage", explosionTime);
		Invoke ("LightOff", explosionTime/3.0f);
		Invoke ("Destroy", explosionTime + 0.05f);

	}

	/*void MakeBiggerExplosion()
	{
	}*/

	void DisableDamage()
	{
		exploding = false;
	}

	void Update()
	{
		if (exploding)
		{
			timeSinceExplosion += Time.deltaTime;
			float scale = 2.0f*explosionRadius*(/*explosionTime-*/timeSinceExplosion);

			ApplyDamage ("Player1");
			ApplyDamage ("Player2");
			ApplyDamage ("DestroyableWall");

			GetComponent<Transform>().FindChild("ExplosionSphere").localScale = new Vector3(scale,scale,scale);
		}
	}

	void Destroy()
	{
		Destroy (this.gameObject);
	}
}
