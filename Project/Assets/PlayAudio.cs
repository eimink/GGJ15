using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayAudio : MonoBehaviour {
	
	public AudioSource p1sfx;
	public AudioSource p2sfx;


	public void PlaySound(AudioClip clip, PlayerIndex player)
	{
		if (player == (PlayerIndex)1)
		{
			p1sfx.clip = clip;
			p1sfx.Play();

		} 
		else 
		{
			p2sfx.clip = clip;
			p2sfx.Play();
		}

	}


	void Start () {
		p1sfx = gameObject.AddComponent<AudioSource>();
		p2sfx = gameObject.AddComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
