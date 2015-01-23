using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
	
	public GeneratorBlock[] Blocks;
	public Texture2D testBitmap;

	// Use this for initialization
	void Start () {
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
					Instantiate(Blocks[idx].prefab,new Vector3(i,0,j),Quaternion.identity);
			}
		}
	}

	int FindBlockIndex(Color c)
	{
		for (int i = 0; i < Blocks.Length; i++) 
		{
			if (Blocks [i].key == c)
			{
				return i;
			}
		}
		return -1;
	}
}
