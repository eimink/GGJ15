using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float activationDelay = 2.0f;
	public float activityDuration = 2.0f;
	public float timeBetweenShots = 0.5f;
	public float range = 2.0f;
	public float damagePerShot = 10.0f;
	public float distanceFalloff = 2.0f;
	public GameObject projectile;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Fire", activationDelay, timeBetweenShots);
		Invoke("Destroy", activityDuration);
	}
	
	void Fire()
	{
		this.gameObject.GetComponent<ParticleSystem>().Play();
		RaycastHit hit;
		if (Physics.SphereCast (transform.position, range, Vector3.forward, out hit))
		{
			transform.LookAt(hit.collider.transform.position);
			Instantiate(projectile,this.transform.position,this.transform.rotation);
		}
	}
	
	void Destroy()
	{
		Destroy (this.gameObject);
	}
}
