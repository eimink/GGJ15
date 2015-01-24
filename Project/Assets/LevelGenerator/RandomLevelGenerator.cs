using UnityEngine;
using System.Collections;

public class RandomLevelGenerator : LevelGenerator {

	public int width = 512; 
	public int height = 512;
	public int xOrg = 0;
	public int yOrg = 0;
	public float scale = 1.0f;
	// Use this for initialization
	void Start () {
		Init();
		GenerateLevelFromBitmap(PerlinGenerator.CreatePerlinTexture(width,height,xOrg,yOrg,scale));
	}

}
