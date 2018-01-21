using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE2DestroyOnTime : MonoBehaviour {
	private bool isFade = false;
	private float time = 0f;

	public SCENE2HeroMovement AmbilHero;

	private Renderer r;

	void Start () {
		r = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (isFade) {
			r.material.color = new Color (1f, 1f, 1f, time / 2f);
			time -= Time.deltaTime;
			if (time <= 0f) {
				AmbilHero.CanJump = false;
				Destroy (gameObject);

			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player" && isFade == false) {
			time = 0.3f;
			isFade = true;
		}
	}


}
