using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE3WallPull : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Player") {
			Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();

			Vector3 Wall = transform.position;
			Vector3 Hero = col.transform.position;
			//supaya tidak ketitik tengah wall
			Wall.y = 0f;
			Hero.y = 0f;
			Wall.z = 0f;
			Hero.z = 0f;

			rb.AddForce (
				Vector3.Normalize (
					Wall - Hero
				) * 20f
			);

			//Lompat

			//rb.AddForce (
			//	(Vector3.Normalize (
			//		col.transform.position - transform.position
			//	) + transform.up) * 20f
			//);
		}
	}
}
