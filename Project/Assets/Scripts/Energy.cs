using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

	public float maxEnergy = 100.0f;
	private float curEnergy;

	// Use this for initialization
	void Start () {
		curEnergy = maxEnergy;

		TextMesh text = GetComponentInChildren<TextMesh> ();
		if (text != null)
		{
			text.text = ((int)curEnergy).ToString();
		}
	}

	void ApplyDamage( float dmg )
	{
		Debug.Log("Gameobject: " + gameObject.name + " takes damage " + dmg.ToString());

		curEnergy -= dmg;
		if (curEnergy <= 0.0f)
		{
			Debug.Log("Gameobject: " + gameObject.name + " killed");
			Invoke ("Destroy", 0.1f);
		}

		TextMesh text = GetComponentInChildren<TextMesh> ();
		if (text != null)
		{
			text.text = ((int)curEnergy).ToString();
		}

		ThirdPersonController c = GetComponent<ThirdPersonController>();
		if (c) {
			c.Jump();
		}
	}

	void Destroy()
	{
		Destroy (this.gameObject);
	}

	void Heal( float h )
	{
		Debug.Log("Gameobject: " + gameObject.name + " heals " + h.ToString());
		curEnergy = Mathf.Clamp (curEnergy + h, 0, maxEnergy);

		TextMesh text = GetComponentInChildren<TextMesh> ();
		if (text != null)
		{
			text.text = ((int)curEnergy).ToString();
		}
	}

}
