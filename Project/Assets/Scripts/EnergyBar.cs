using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	public float distance = 1.0f;
	public Material healthBarMaterial;
	Transform m_targetCameraTransform;
	GameObject m_healthQuad;
	float energy = 1.0f;

	// Use this for initialization
	void Start () {
		m_targetCameraTransform = GameObject.Find("Main Camera").transform;
		m_healthQuad = GameObject.CreatePrimitive (PrimitiveType.Quad);
		//m_healthQuad.transform.parent = this.transform;
		Vector3 pos = this.transform.position;
		pos.y += distance;
		m_healthQuad.transform.position = pos;
		m_healthQuad.renderer.material = healthBarMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		m_healthQuad.transform.LookAt (m_targetCameraTransform, Vector3.up);
		Color c = m_healthQuad.renderer.material.color;
		c.a = energy;
		m_healthQuad.renderer.material.color = c;
	}

	public void updateEnergyLevel(int percent)
	{
		energy = percent/100;
	}
}
