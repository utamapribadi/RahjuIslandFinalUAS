using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SriptAll/Story")]
public class Story : ScriptableObject {
	[TextArea]
	public string description;
	public string roomName;
	public StartGame[] startgames;

}
