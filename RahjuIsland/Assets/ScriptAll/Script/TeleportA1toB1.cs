using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeleportA1toB1 : MonoBehaviour {

	public Transform  TeleportToB1;
	public GameObject text0;
	public Image PilihGambar;

	// Use this for initialization
	void Start () {
		text0.SetActive(false);
		PilihGambar.enabled = (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay (Collider col){
		if (Input.GetKeyDown(KeyCode.T) && (col.gameObject.tag == "TeleportA1"))
		{
			text0.SetActive (false);
			PilihGambar.enabled = (false);
			this.transform.position = TeleportToB1.transform.position;

		}
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "TeleportA1") {
			
			text0.SetActive (true);
			PilihGambar.enabled = (true);

		}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "TeleportA1") {
			text0.SetActive (false);
			PilihGambar.enabled = (false);
		}
	}



}
