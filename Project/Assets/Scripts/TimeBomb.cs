using UnityEngine;
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

	public GameObject smudgePrefab;

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

	void LightOn()
	{
		light.enabled = true;
	}

	void Explode()
	{
		exploding = true;
		this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
		GameObject bm = GetComponent<Transform>().FindChild("Bomb_model").gameObject;
		bm.SetActive (false);

		Quaternion rot = new Quaternion (UnityEngine.Random.value,UnityEngine.Random.value,UnityEngine.Random.value,UnityEngine.Random.value);

		GetComponent<Transform> ().FindChild ("ExplosionSphere").rotation = rot;


		timeSinceExplosion = 0.0f;
		Invoke ("DisableDamage", explosionTime);
		LightOn ();

		Quaternion r = Quaternion.Euler(new Vector3(0.0f,UnityEngine.Random.value*360.0f,0.0f));
		GameObject smudge = GameObject.Instantiate(smudgePrefab,GetComponent<Transform>().position,r) as GameObject;
		float scaleVal = 0.7f + UnityEngine.Random.value * 0.6f;
		smudge.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale * scaleVal;

		//Invoke ("LightOn", explosionTime/8.0f);
		//Invoke ("LightOff", explosionTime/3.0f);
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
			float scale = 1.0f + 2.0f*(explosionRadius-1.0f)*(/*explosionTime-*/timeSinceExplosion);

			ApplyDamage ("Player1");
			ApplyDamage ("Player2");
			ApplyDamage ("DestroyableWall");

			GetComponent<Transform>().FindChild("ExplosionSphere").localScale = new Vector3(scale,scale,scale);
			light.gameObject.GetComponent<Transform>().Translate(new Vector3(0,scale,0));
		}
	}

	void Destroy()
	{
	//	Quaternion rot = new Quaternion (UnityEngine.Random.value,UnityEngine.Random.value,UnityEngine.Random.value,UnityEngine.Random.value);


		Destroy (this.gameObject);
	}
}
