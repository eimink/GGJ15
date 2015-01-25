using UnityEngine;
using System.Collections;

public class SceneHelper : MonoBehaviour {

	public static SceneHelper instance;

	public string levelSeed = "kekkonen";
	public int numOfCreatures = 4;

	void Awake ()
	{
		DontDestroyOnLoad (this.transform.gameObject);
		if (instance == null)
			instance = this;
		else
			Destroy(this.gameObject);
	}
}


