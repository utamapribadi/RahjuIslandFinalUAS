using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SCENE2DelayDestroy : MonoBehaviour {
	public bool isFade = false;
	public bool isFadeBack = false;
	private float time = 0f;

	public SCENE2HeroMovement AmbilHero;


	private Renderer r;
	private Collider c;

	void Start () {
		r = GetComponent<Renderer> ();
		c = GetComponent<Collider> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (isFade) {
			r.material.color = new Color (1f, 1f, 1f, time / 2f);
			time -= Time.deltaTime;
			if (time <= 0f) {
				
				r.enabled = false;
				c.enabled = false;
				isFade = false;
				StartCoroutine (ShowObject());

				time = 0f;


			}
		}

		if (isFadeBack) {
			r.material.color = new Color (1f, 1f, 1f, time / 2f);
			time += Time.deltaTime;
			if (time >= 2f) {
				
				c.enabled = true;
				isFadeBack = false;
				time = 2f;
			}
		}
			
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player" && isFade == false) {
			time = 0.3f;
			isFade = true;
		}
	}

	IEnumerator ShowObject(){
		yield return new WaitForSeconds (0.5f);
		AmbilHero.CanJump = false;
		yield return new WaitForSeconds (4f);
		r.enabled = true;
		isFadeBack = true;
	}
}
