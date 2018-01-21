using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.O)){
			GetComponent<Transform> ().position = new Vector3(transform.position.x,transform.position.y-.3f,transform.position.z+.1f);
				transform.Rotate (-9, 0, 0);
		}

		if(Input.GetKeyDown (KeyCode.P)){
			GetComponent<Transform> ().position = new Vector3(transform.position.x,transform.position.y+.3f,transform.position.z-.1f);
			transform.Rotate (9, 0, 0);
		}

	

	}
}
