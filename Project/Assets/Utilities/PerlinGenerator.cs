using UnityEngine;
using System.Collections;

public static class PerlinGenerator {

	public static Texture2D CreatePerlinTexture(int width, int height, int xOrg = 0, int yOrg = 0, float scale = 1.0f)
	{
		Texture2D noise = new Texture2D (width, height);
		Color[] pixels = new Color[noise.width * noise.height];
		int y = 0;
		while (y < noise.height)
		{
			int x = 0;
			while (x < noise.width)
			{
				float xC = xOrg + x / noise.width * scale;
				float yC = yOrg + y / noise.height * scale;
				float sample = Mathf.PerlinNoise(xC, yC);
				pixels[y*noise.width + x] = new Color(sample,sample,sample);
				x++;
			}
			y++;
		}
		noise.SetPixels(pixels);
		return noise;
	}

}
