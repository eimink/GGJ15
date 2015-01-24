using UnityEngine;
using System.Collections;

public class TimeBomb : MonoBehaviour {

	public float fuseDelay = 2.0f;
	public float explosionRadius = 4.0f;
	public float maxDamage = 10.0f;
	public float explosionForce = 1000.0f;
	public float distanceFalloff = 0.1f;

	private bool exploding = false;
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
				objects[i].SendMessage("ApplyDamage",Time.deltaTime*dmg*maxDamage,SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void Explode()
	{
		exploding = true;
		this.gameObject.GetComponent<ParticleSystem>().Play();
		GameObject bm = GetComponent<Transform>().FindChild("Bomb_model").gameObject;
		bm.SetActive (false);

		Invoke ("Destroy", 1.0f);
		
		Invoke ("DisableDamage", 0.3f);
	}

	void DisableDamage()
	{
		exploding = false;
	}

	void Update()
	{
		if (exploding)
		{
			ApplyDamage ("Player1");
			ApplyDamage ("Player2");
			ApplyDamage ("DestroyableWall");
		}
	}

	void Destroy()
	{
		Destroy (this.gameObject);
	}
}
