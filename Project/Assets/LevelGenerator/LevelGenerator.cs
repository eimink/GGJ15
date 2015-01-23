﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public Color spawnColor;
	public GeneratorBlock[] blocks;
	public Texture2D testBitmap;
	public bool Ready {get{return m_ready;}}

	GameObject m_levelParent;
	bool m_ready = false;

	// Use this for initialization
	void Start () {
		m_ready = false;
		m_levelParent = new GameObject ();
		m_levelParent.name = "GeneratedLevel";
		GenerateLevelFromBitmap (testBitmap);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateLevelFromBitmap(Texture2D bitmap)
	{
		Color[] pixels = bitmap.GetPixels();
		int width = bitmap.width;
		int height = bitmap.height;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int idx = FindBlockIndex(pixels[i*width+j]);
				if (idx >= 0)
				{
					GameObject o = (GameObject)Instantiate(blocks[idx].prefab,new Vector3(i,0,j),Quaternion.identity);
					o.transform.parent = m_levelParent.transform;
					if (pixels[i*width+j] == spawnColor)
						o.tag = "SpawnPoint";
				}
			}
		}
		m_ready = true;
	}

	int FindBlockIndex(Color c)
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
