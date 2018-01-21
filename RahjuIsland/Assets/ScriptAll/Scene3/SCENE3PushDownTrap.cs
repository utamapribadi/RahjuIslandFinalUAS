using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE3PushDownTrap : MonoBehaviour {

	public SCENE3HeroMovement AmbilHero;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {
			AmbilHero.rb.AddForce(-transform.right*1000f);
			AmbilHero.rb.AddForce(transform.up*1000f);
		}
	}


}
