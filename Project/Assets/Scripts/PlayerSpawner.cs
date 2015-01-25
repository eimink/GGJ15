using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject player1Prefab;
	public GameObject player2Prefab;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GetComponent<LevelGenerator>().Ready) 
		{
			GameObject [] spawns = GameObject.FindGameObjectsWithTag ("SpawnPoint");
			if (spawns.Length == 0) 
			{
				Debug.LogError("Player spawnpoints not found!");
			}

			if( spawns.Length%2 != 0 )
			{				
				Debug.LogError("Spawnpoints count not even!");
			}

			for(int i=0; i<spawns.Length; ++i )
			{
				Vector3 spawnPos = spawns[i].GetComponent<Transform>().position;
				spawnPos.y += 3.0f;
				if( i%2 == 0 )
				{
					GameObject obj = GameObject.Instantiate(player1Prefab,spawnPos,Quaternion.identity) as GameObject;
					obj.transform.parent = GameObject.FindGameObjectWithTag("PlayersPool").transform;
				}
				else
				{
					GameObject obj = GameObject.Instantiate(player2Prefab,spawnPos,Quaternion.identity) as GameObject;
					obj.transform.parent = GameObject.FindGameObjectWithTag("PlayersPool").transform;
				}
			}

			enabled = false;
		}
	}
}
