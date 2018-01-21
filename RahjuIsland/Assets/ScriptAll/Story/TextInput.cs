using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {

	public InputField inputField;
	GameController controller;

	// Use this for initialization
	void Awake () {
		controller = GetComponent<GameController> ();
		inputField.onEndEdit.AddListener (AcceptStringInput);
	}

	void InputComplete()
	{
		controller.DisplayLoggedText ();
		inputField.ActivateInputField ();
		inputField.text = null;
	}

	void AcceptStringInput(string userInput){
		userInput = userInput.ToLower ();
		controller.LogStringWithReturn (userInput);

		char[] delimitersCharacters = { ' ' };
		string[] separatedInputWords = userInput.Split (delimitersCharacters);

		for (int i = 0; i < controller.inputActions.Length; i++) {
			InputAction inputAction = controller.inputActions [i];
			if (inputAction.keyword == separatedInputWords [0]) {
				inputAction.RespondToInput (controller, separatedInputWords);
			}
		}

		InputComplete ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
