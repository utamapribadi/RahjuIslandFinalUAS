using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCENE2ShowText : MonoBehaviour {

	public GameObject Text;
	public bool alreadyShowText = false;
	public SCENE2SwitchColorAndItem AmbilFlag;

	// Use this for initialization
	void Start () {
		Text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter()
	{
		if (!alreadyShowText && AmbilFlag.FlagSwitch == 1) {
			alreadyShowText = true;
			StartCoroutine (TextHideTimer());
		}
	}

	IEnumerator TextHideTimer()
	{
		Text.SetActive (true);
		yield return new WaitForSeconds (7);
		Text.SetActive (false);
	}
}