using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SCENE3TeleportB1toA1 : MonoBehaviour {

	public Transform  TeleportToA1;
	public Vector3 To;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider col){
		Debug.Log (col.transform.position);
		if (col.gameObject.tag == "Player") {
			col.transform.position = To;
		}
	}


}
