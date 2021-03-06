﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public Color spawnColor;
	public GeneratorBlock[] blocks;
	public GameObject floorTile;
	public Color floorColor;
	public bool Ready {get{return m_ready;}}

	GameObject m_levelParent;
	bool m_ready = false;

	// Use this for initialization
	void Start () {
		Init();
	}

	protected void Init() {
		m_ready = false;
		if (m_levelParent != null)
			Destroy (m_levelParent);
		if (GameObject.Find("GeneratedLevel") != null)
			Destroy (GameObject.Find("GeneratedLevel"));
		m_levelParent = new GameObject ();
		m_levelParent.name = "GeneratedLevel";
	}

	// Update is called once per frame
	void Update () {
	
	}

	protected void GenerateLevelFromBitmap(Texture2D bitmap)
	{
		Color[] pixels = bitmap.GetPixels();
		int width = bitmap.width;
		int height = bitmap.height;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int idx = FindBlockIndex(pixels[i*width+j]);
				if (i == 0 || j == 0 || i == width-1 || j == height-1)
				{
					GameObject o = (GameObject)Instantiate(blocks[0].prefab,new Vector3(i,0,j),Quaternion.identity);
					o.transform.parent = m_levelParent.transform;
				}
				else if (idx >= 0)
				{
					GameObject o = (GameObject)Instantiate(blocks[idx].prefab,new Vector3(i,0,j),Quaternion.identity);
					o.transform.parent = m_levelParent.transform;
					if (pixels[i*width+j] == spawnColor)
					{
						o.tag = "SpawnPoint";
					}
				}
				else
				{
					GameObject o = (GameObject)Instantiate(floorTile,new Vector3(i,0,j),Quaternion.identity);
					o.transform.parent = m_levelParent.transform;
				}
			}
		}
		m_ready = true;
	}

	protected int FindBlockIndex(Color c)
	{
		for (int i = 0; i < blocks.Length; i++) 
		{
			if (blocks [i].key == c)
			{
				return i;
			}
		}
		return -1;
	}
}
