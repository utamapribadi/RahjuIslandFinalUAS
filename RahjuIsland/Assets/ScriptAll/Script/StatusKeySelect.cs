using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusKeySelect : MonoBehaviour {

	public KeyCode SelectKeyForStatus;
	public float TimerOpenStatus;
	public float TimerCloseStatus;
	public Image SelectImage;
	public bool canCloseStatus = false;
	public GameObject TextToOpenStatus;
	public GameObject TextToCloseStatus;


	// Use this for initialization
	void Start () {
		TextToOpenStatus.SetActive(true);
		TextToCloseStatus.SetActive(false);
		SelectImage.enabled = (false);
		canCloseStatus = false;
	}


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (SelectKeyForStatus) && canCloseStatus == false) {
			StartCoroutine (StatusOpen ());
		}

		if (Input.GetKeyDown (SelectKeyForStatus) && canCloseStatus == true) {
			StartCoroutine (StatusClose ());
		}
	}

	IEnumerator StatusOpen()
	{
		yield return new WaitForSeconds (TimerOpenStatus);
		SelectImage.enabled = (true);
		canCloseStatus = true;

		TextToOpenStatus.SetActive(false);
		TextToCloseStatus.SetActive(true);
	}

	IEnumerator StatusClose()
	{
		yield return new WaitForSeconds (TimerCloseStatus);
		SelectImage.enabled = (false);
		canCloseStatus = false;

		TextToOpenStatus.SetActive(true);
		TextToCloseStatus.SetActive(false);
	}
}
