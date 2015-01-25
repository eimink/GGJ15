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
		if (msg.sender = "seed edit") 
		{
			//TODO: set value to correct place. msg.text contains the seed.
		}
		if (msg.sender = "numOfChars edit") 
		{
			int value = Convert.ToInt32(msg.text);
			//TODO: set value to correct place.
		}
	}
}
