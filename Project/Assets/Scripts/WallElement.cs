using UnityEngine;
using System.Collections;

public class WallElement : MonoBehaviour {

	public float maxHealth = 20.0f;
	float m_health;

	// Use this for initialization
	void Start () {
		m_health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_health <= 0f)
			Destroy (this.gameObject);
	}

	void ApplyDamage(float damage)
	{
		m_health -= damage;
	}

}
