using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SriptAll/InputActions/Go")]
public class Go : InputAction {

	public override void RespondToInput(GameController controller, string[] separatedInputWords)
	{
		controller.storyNavigation.AttempToChangeStorys (separatedInputWords [1]);
	}
}
