using UnityEngine;
using System;
using System.Collections;

public class RandomLevelGenerator : LevelGenerator {

	public int spawnpoints = 4;
	public int width = 64; 
	public int height = 64;
	public int xOrg = 0;
	public int yOrg = 0;
	public float scale = 1.0f;
	public float darkTreshold = 0.3f;
	public float lightTreshold = 0.7f;

	bool m_started = false;

	// Use this for initialization
	void Start () {
		Init();
		RunGenerator();
	}

	void RunGenerator()
	{
		m_started = true;
	}

	void GenerateWithSeed(string seed)
	{
		UnityEngine.Random.seed = (Convert.ToInt32(seed));
		xOrg = UnityEngine.Random.Range(-64,64);
		yOrg = UnityEngine.Random.Range(-64,64);
		scale = UnityEngine.Random.Range (2, 16);
		darkTreshold = UnityEngine.Random.Range (1, 10) / 10;
		lightTreshold = UnityEngine.Random.Range (1, 10) / 10;
		RunGenerator();
	}

	void Update()
	{
		if (!Ready && m_started)
		{
			Texture2D perlin = PerlinGenerator.CreatePerlinTexture(width, height, xOrg, yOrg, scale);
			GenerateLevelFromBitmap(SetSpawnPoints(GenerateDebris(ApplyTresholds(perlin))));
		}
	}

	Texture2D ApplyTresholds(Texture2D tex)
	{
		Color[] pixels = tex.GetPixels ();
		for (int i = 0; i < pixels.Length; i++)
		{
			Color c = pixels[i];
			c.r = c.r <= darkTreshold ? 0f : c.r >= lightTreshold ? 1f : c.r;
			c.g = c.g <= darkTreshold ? 0f : c.g >= lightTreshold ? 1f : c.g;
			c.b = c.b <= darkTreshold ? 0f : c.b >= lightTreshold ? 1f : c.b;
			pixels[i] = c;
		}
		tex.SetPixels(pixels);
		return tex;
	}

	Texture2D SetSpawnPoints(Texture2D t)
	{
		Texture2D tex = t;
		int spawnsPerPlayer = spawnpoints / 2;
		for (int i = 0; i < spawnpoints; i = i + spawnsPerPlayer)
		{
			for (int j = 1; j < spawnsPerPlayer+1; j++)
			{
				Vector2 point = GetPoint((i+j)%4);
				Color pixel = tex.GetPixel((int)point.x,(int)point.y);
				while(pixel != floorColor)
				{
					point = GetPoint((i+j)%4);
					pixel = tex.GetPixel((int)point.x,(int)point.y);
				}
				tex.SetPixel((int)point.x,(int)point.y,spawnColor);
			}
		}
		return tex;
	}

	Texture2D GenerateDebris(Texture2D t)
	{
		Texture2D tex = t;
		Color debrisColor = new Color (0, 1, 0);
		int debrisAmount = UnityEngine.Random.Range (16, 32);
		for (int i = 0; i < debrisAmount; i++)
		{
			Vector2 point = GetPoint();
			Color pixel = tex.GetPixel((int)point.x,(int)point.y);
			while(pixel != floorColor)
			{
				point = GetPoint();
				pixel = tex.GetPixel((int)point.x,(int)point.y);
			}
			tex.SetPixel((int)point.x,(int)point.y,debrisColor);
		}

		return tex;
	}

	Vector2 GetPoint()
	{
		return new Vector2 (UnityEngine.Random.Range (0, width),UnityEngine.Random.Range (0, height));
	}

	Vector2 GetPoint(int quadrant)
	{
		if (quadrant <= 1)
			return new Vector2 (UnityEngine.Random.Range (1, width/4), UnityEngine.Random.Range (1, height/4));
		else if (quadrant == 2)
			return new Vector2 (UnityEngine.Random.Range (3*width/4, width), UnityEngine.Random.Range (1, height/4));
		else if (quadrant == 3)
			return new Vector2 (UnityEngine.Random.Range (1, 3*width/4),UnityEngine.Random.Range (3*height/4, height));
		else
			return new Vector2 (UnityEngine.Random.Range (3*width/4, width),UnityEngine.Random.Range (3*height/4, height));
	}
}
