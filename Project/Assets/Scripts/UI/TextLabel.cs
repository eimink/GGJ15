using UnityEngine;
using System.Collections;

public class TextLabel : MonoBehaviour {

	public Color textColor;
	public Color activeColor;
	public MenuRoot mainMenu;
	
	void Start () {
		if (mainMenu != null)
		{
			textColor = mainMenu.textColor;
			activeColor = mainMenu.activeColor;
		}
		renderer.material.color = textColor;
	}	
}
