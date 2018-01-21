using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeleportB1toA1 : MonoBehaviour {

	public Transform  TeleportToA1;
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

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "TeleportB1") {
			text0.SetActive (true);
			PilihGambar.enabled = (true);
		}
	}

	void OnTriggerStay (Collider col){
		if (Input.GetKeyDown(KeyCode.T) && (col.gameObject.tag == "TeleportB1"))
		{
			
			this.transform.position = TeleportToA1.transform.position;
			PilihGambar.enabled = (false);
		}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "TeleportB1") {
			text0.SetActive (false);
			PilihGambar.enabled = (false);
		}
	}

}
