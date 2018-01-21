using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCENE1ShowText : MonoBehaviour {

	public GameObject Text;
	public bool alreadyShowText = false;

	// Use this for initialization
	void Start () {
		Text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter()
	{
		if (!alreadyShowText) {
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