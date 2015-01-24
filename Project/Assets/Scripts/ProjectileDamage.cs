using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour {

	public float damage = 10.0f;

	void OnTriggerEnter(Collider other) {
//		Debug.Log ("Projectile damage to " + other.gameObject.name);
		other.gameObject.SendMessage ("ApplyDamage", damage);
		Destroy (this.gameObject);
	}
}
