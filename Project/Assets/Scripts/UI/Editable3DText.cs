using UnityEngine;
using System.Collections;

public struct textChangeMessageData{
	public string sender;
	public string text;
};

public class Editable3DText : MonoBehaviour {

	bool inEditMode = false;
	TextMesh textComponent;

	public Color textColor;
	public Color activeColor;
	public MenuRoot mainMenu;
	public string GetText(){return textComponent.text;}
		
	textChangeMessageData msgdata;

	void Start () {
		if (mainMenu != null)
		{
			textColor = mainMenu.textColor;
			activeColor = mainMenu.activeColor;
		}
		textComponent = GetComponent<TextMesh> ();
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
		msgdata.sender = this.gameObject.name;
		msgdata.text = textComponent.text;
		mainMenu.SendMessage ("TextChanged", msgdata, SendMessageOptions.DontRequireReceiver);
	}
	void startEditing() {
		Debug.Log ("to edit mode");
		inEditMode = true;
		textComponent.text = "";
		renderer.material.color = activeColor;
	}
}
