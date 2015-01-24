using UnityEngine;
using System.Collections;

public class TimeBomb : MonoBehaviour {

	public float fuseDelay = 2.0f;
	public float explosionRadius = 4.0f;
	public float maxDamage = 10.0f;
	public float explosionForce = 1000.0f;
	public float distanceFalloff = 0.1f;

	// Use this for initialization
	void Start () {
		Invoke ("Explode", fuseDelay);
	}

	void ApplyDamage(string tag)
	{
		GameObject [] objects = GameObject.FindGameObjectsWithTag(tag);
		for (int i=0; i<objects.Length; ++i)
		{
			Vector3 delta = objects[i].GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
			if( delta.magnitude <= explosionRadius )
			{
				float dmg = (explosionRadius - delta.magnitude) / explosionRadius;
				objects[i].SendMessage("ApplyDamage",dmg*maxDamage,SendMessageOptions.DontRequireReceiver);

				CharacterController controller = objects[i].GetComponent<CharacterController> ();
				if (controller != null)
				{
				//	Debug.Log("fdfsdf");
				//	controller.Move(5.0f*dmg * delta.normalized);
				}
			}
		}
	}

	void Explode()
	{
		this.gameObject.GetComponent<ParticleSystem>().Play();

		ApplyDamage ("Player1");
		ApplyDamage ("Player2");
		/*RaycastHit[] hits = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.forward, Mathf.Infinity);
		foreach (RaycastHit hit in hits)
		{
			if( hit.collider.gameObject.tag == "Player1" || hit.collider.gameObject.tag == "Player2" )
			{
				Debug.Log( "Name: " + hit.collider.gameObject.name +  " hit.distance: " + hit.distance.ToString() );
				if( hit.distance <= explosionRadius )
				{
				//	float dmg = Mathf.Clamp(maxDamage - hit.distance * distanceFalloff, 0.0f, maxDamage);
					hit.collider.gameObject.SendMessage("ApplyDamage",4.5f,SendMessageOptions.DontRequireReceiver);
					if (hit.rigidbody != null)
						hit.rigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadius);
				}
			}
		}*/


		Invoke ("Destroy", 2.0f);
	}
	void Destroy()
	{
		Destroy (this.gameObject);
	}
}
