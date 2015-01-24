using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BitmapLevelGenerator : LevelGenerator {

	public Texture2D testBitmap;

	GameObject m_levelParent;
	bool m_ready = false;
	
	void Start () {
		GenerateLevelFromBitmap (testBitmap);
	}
}
