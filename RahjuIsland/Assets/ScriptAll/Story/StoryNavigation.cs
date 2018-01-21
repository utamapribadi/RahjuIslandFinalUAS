using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StoryNavigation : MonoBehaviour {
	public string SelectScene = "SelectScene";

	public Story currentStory;

	Dictionary<string, Story> startgameDictionary = new Dictionary<string, Story>();


	GameController controller;

	void Awake(){
		controller = GetComponent<GameController> ();
	}

	public void UnpackStartGamesInStory(){
		for (int i = 0; i < currentStory.startgames.Length; i++) {
			startgameDictionary.Add (currentStory.startgames [i].keyString, currentStory.startgames [i].valueStory);
			controller.interactiveDescriptionsInStory.Add (currentStory.startgames [i].StartGameDescription);
		}
	}

	public void AttempToChangeStorys(string directionNoun)
	{
		if (startgameDictionary.ContainsKey (directionNoun)) {
			currentStory = startgameDictionary [directionNoun];

			controller.LogStringWithReturn ("====================================================================");
			controller.LogStringWithReturn ("Press 'go +Keyword' Ex: go sleepagain");
			controller.LogStringWithReturn ("====================================================================");

			controller.DisplayStoryText ();

			if (directionNoun == "openthepackage") {
				controller.LogStringWithReturn ("You start the game and teleported to Rahju Island!");
				SceneManager.LoadScene (SelectScene);
			}
				


		} else {
			controller.LogStringWithReturn ("Your keyword incorrect, there is no keyword such as " + directionNoun);
		}
	}

	public void ClearStartGames()
	{
		startgameDictionary.Clear ();
	}

}
