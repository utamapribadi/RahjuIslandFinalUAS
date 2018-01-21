using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlace : MonoBehaviour {
	public GameObject ui;
	public GameObject ObjectTeleport;
	public Transform TeleportLocation;

	// Use this for initialization
	void Start () {
		ui.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OntriggerStay(Collider other1)
	{
			ui.SetActive(true);
			if((other1.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
			{
				ObjectTeleport.transform.position = TeleportLocation.transform.position;
			}
	}

	void OnTriggerExit(){
			ui.SetActive(false);
		}
	
}

