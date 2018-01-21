using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text displayText;
	public InputAction[] inputActions;

	[HideInInspector] public StoryNavigation storyNavigation;
	[HideInInspector] public List<string> interactiveDescriptionsInStory = new List<string>();

	List<string> actionLog = new List<string>();

	// Use this for initialization
	void Awake () {
		storyNavigation = GetComponent<StoryNavigation> ();
	}

	void Start(){
		DisplayStoryText ();
		DisplayLoggedText ();
	}

	public void DisplayLoggedText(){
		string logAsText = string.Join ("\n", actionLog.ToArray ());

		displayText.text = logAsText;

	}

	public void DisplayStoryText()
	{

		ClearCollectionsForNewStory (); 

		UnpackStory ();

		string joinedInteractionDescription = string.Join("\n", interactiveDescriptionsInStory.ToArray());

		string combinedText = storyNavigation.currentStory.description + "\n";

		LogStringWithReturn (combinedText);
	}

	void UnpackStory(){
		storyNavigation.UnpackStartGamesInStory ();
	}

	void ClearCollectionsForNewStory(){
		interactiveDescriptionsInStory.Clear ();
		storyNavigation.ClearStartGames ();
	}
		

	public void LogStringWithReturn(string stringToAdd)
	{
		actionLog.Add (stringToAdd + "\n");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
