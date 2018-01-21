using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCENE1SignTriggerAppear : MonoBehaviour {

	public Image Sign;
	public GameObject SignPressText;
	public float SignFlag = 1;

	// Use this for initialization
	void Start () {

		Sign.enabled = (false);
		SignPressText.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.F) && SignFlag == 1) {
				Sign.enabled = (true);
				SignPressText.SetActive (false);
				SignFlag = 0;

			}else if (Input.GetKeyDown (KeyCode.F) && SignFlag == 0) {
				//slides.Stop ();
				Sign.enabled = (false);
				SignPressText.SetActive (true);
				SignFlag = 1;




			}

		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			SignPressText.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player") {
			Sign.enabled = (false);
			SignPressText.SetActive (false);
			SignFlag = 1;
		}
		
	}


}
