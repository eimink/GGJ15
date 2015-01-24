using UnityEngine;
using System.Collections;

public class HealBox : MonoBehaviour {

	public float fuseDelay = 2.0f;
	public float activityDuration = 2.0f;
	public float timeBetweenTicks = 0.5f;
	public float healRadius = 2.0f;
	public float healAmountPerTick = 10.0f;
	public float distanceFalloff = 2.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Heal", fuseDelay, timeBetweenTicks);
		Invoke("Destroy", activityDuration);
	}
	
	void Heal()
	{
		this.gameObject.GetComponent<ParticleSystem>().Play();
		RaycastHit[] hits = Physics.SphereCastAll (transform.position, explosionRadius, transform.forward);
		foreach (RaycastHit hit in hits)
		{
			float dmg = maxDamage - hit.distance * distanceFalloff;
			hit.collider.gameObject.SendMessage("ApplyDamage",dmg,SendMessageOptions.DontRequireReceiver);
			if (hit.rigidbody != null)
				hit.rigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadius);
		}
	}

	void Destroy()
	{
		Destroy (this.gameObject);
	}
}
