using UnityEngine;
using System;
using System.Collections;

public class MenuFunctions : MonoBehaviour {

	void StartGame()
	{
		//TODO: Load another scene and seed the level.
	}

	void TextChanged(textChangeMessageData msg)
	{
		if (msg.sender == "seed edit") 
		{
			SceneHelper.instance.levelSeed = msg.text;
		}
		if (msg.sender == "numOfChars edit") 
		{
			int value = Convert.ToInt32(msg.text);
			SceneHelper.instance.numOfCreatures = value; 
		}
	}
}
