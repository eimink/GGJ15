using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 1.0f;
	public float range = 3.0f;
	public float speed = 10.0f;

	Vector3 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime);
		if (Vector3.Distance(startPosition, transform.position) >= range)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
		other.gameObject.SendMessage ("ApplyDamage", damage);
		Destroy (this.gameObject);
	}
}
