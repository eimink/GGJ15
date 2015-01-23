using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public Dictionary<Color, GameObject> BlockDefinitions;
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
		GameObject g;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				BlockDefinitions.TryGetValue((Color)pixels.GetValue(i*width+j), out g);
				if (g != null)
					Instantiate((Object)g,new Vector3(i,0,j),Quaternion.identity);
			}
		}
	}
}
