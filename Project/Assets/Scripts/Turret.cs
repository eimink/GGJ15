﻿using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float activationDelay = 1.0f;
	public float activityDuration = 10.0f;
	public float timeBetweenShots = 0.5f;
	public float range = 10.0f;
	//public float damagePerShot = 10.0f;
	//public float distanceFalloff = 2.0f;
	public GameObject projectile;

	public GameObject turretObject;


	string myPlayer;
	string otherPlayer;

	public GameObject light;
	public Vector3 projectileOffset;

	// Use this for initialization
	void Start () {
		GameObject [] objects1 = GameObject.FindGameObjectsWithTag("Player1");
		GameObject [] objects2 = GameObject.FindGameObjectsWithTag("Player2");

		float nearest = 1000.0f;
		// Find nearest (it is most likely "mine" player)
		for (int i=0; i<objects1.Length; ++i)
		{
			Vector3 delta = objects1[i].GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
			if( delta.magnitude < nearest )
			{
				myPlayer = "Player1";
				otherPlayer = "Player2";
				nearest = delta.magnitude;
			}
		}
		for (int i=0; i<objects2.Length; ++i)
		{
			Vector3 delta = objects2[i].GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
			if( delta.magnitude < nearest )
			{
				myPlayer = "Player2";
				otherPlayer = "Player1";
				nearest = delta.magnitude;
			}
		}

		InvokeRepeating("Fire", activationDelay, timeBetweenShots);
		Invoke("Destroy", activityDuration);
		
	
		light.SetActive(false);
	}

	bool Shoot(string tag)
	{
		//float scale = explosionRadius*(explosionTime-timeSinceExplosion);
		GameObject [] objects = GameObject.FindGameObjectsWithTag(tag);
		for (int i=0; i<objects.Length; ++i)
		{
			Vector3 delta = objects[i].GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
			if( delta.magnitude <= range )
			{
				
				this.gameObject.GetComponent<AudioSource>().Play();
				turretObject.transform.LookAt(objects[i].GetComponent<Transform>().position);
				GameObject obj = Instantiate(projectile,turretObject.transform.position + turretObject.transform.rotation*projectileOffset,turretObject.transform.rotation) as GameObject;
				obj.transform.parent = GameObject.FindGameObjectWithTag("DynamicObjects").transform;
				return true;
			}
		}

		return false;
	}

	void TurnOffLight()
	{
		
		light.SetActive(false);
	}

	void Fire()
	{
		if (!Shoot (otherPlayer))
		{
			if( !Shoot (myPlayer) )
			{
				GetComponentInChildren<ParticleSystem>().Stop();
				return;
			}
		}
		
		light.SetActive(true);
		Invoke("TurnOffLight", 0.1f);
		GetComponentInChildren<ParticleSystem>().Play();
	}
	
	void Destroy()
	{
		Destroy (this.gameObject);
	}
}
