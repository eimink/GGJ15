using UnityEngine;
using System.Collections;

public class Editable3DText : MonoBehaviour {

	bool inEditMode = false;
	string storedString;
	TextMesh textComponent;
	string guiString;

	public Color textColor;
	public Color activeColor;
	public MenuRoot mainMenu;
	
	void Start () {
		if (mainMenu != null)
		{
			textColor = mainMenu.textColor;
			activeColor = mainMenu.activeColor;
		}
		textComponent = GetComponent<TextMesh> ();
		storedString = textComponent.text;
		guiString = storedString;
		renderer.material.color = textColor;	
		checkChars();
	}
	
	void OnGUI () {


	}
	void Update()
	{
		if(inEditMode) {
			textComponent.text += Input.inputString;
		}

		if (inEditMode && Input.GetKeyDown(KeyCode.Return) || inEditMode && Input.GetKeyDown(KeyCode.Escape)) {
			inEditMode = false;
			renderer.material.color = textColor;
			checkChars();
		}
	}

	void checkChars () {
		if(textComponent.text.ToCharArray().Length==0) {
			textComponent.text = "NULL";
		}
	}
	void startEditing() {
		Debug.Log ("to edit mode");
		inEditMode = true;
		textComponent.text = "";
		renderer.material.color = activeColor;
	}
}
