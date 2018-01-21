using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SCENE3TeleportA1toB1 : MonoBehaviour {

	public Transform  TeleportToB1;
	public Vector3 To;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter (Collider col){

		if (col.gameObject.tag == "Player") {
			Debug.Log (col.transform.position);
			col.transform.position = To;
			Debug.Log (col.transform.position);
		}
	}




}
