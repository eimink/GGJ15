﻿using UnityEngine;
using System.Collections;

public class TimeBomb : MonoBehaviour {

	public float fuseDelay = 2.0f;
	public float explosionRadius = 2.0f;
	public float maxDamage = 10.0f;
	public float distanceFalloff = 2.0f;

	// Use this for initialization
	void Start () {
		Invoke ("Explode", fuseDelay);
	}

	void Explode()
	{
		RaycastHit[] hits = Physics.SphereCastAll (transform.position, explosionRadius, transform.forward);
		foreach (RaycastHit hit in hits)
		{
			float dmg = maxDamage - hit.distance * distanceFalloff;
			hit.collider.gameObject.SendMessage("ApplyDamage",dmg,SendMessageOptions.DontRequireReceiver);
		}
	}
}
