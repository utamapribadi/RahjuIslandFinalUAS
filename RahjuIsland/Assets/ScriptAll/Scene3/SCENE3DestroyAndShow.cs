using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE3DestroyAndShow : MonoBehaviour {
	public bool isFade = false;
	public bool isShow = false;
	private float time = 0f;
	public bool isFades = false;
	public bool isFadess = false;

	public SCENE3HeroMovement AmbilHero;

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
			if (time <= 0.1f) {
				StartCoroutine (TimerFade());
			}
		}

		if (isShow) {
			r.material.color = new Color (1f, 1f, 1f, time * 2.1f);
			time += Time.deltaTime;
			if (time >= 0.3f) {
				

			}
		}

		if (isFadess) {
			StartCoroutine (TimerFade2());

		}
	}


	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player" && isFade== false) {
			time = 0.2f;
			isFade = true;
		}

		if (col.gameObject.tag == "Player" && isFades == true && isFadess == false) {
			time = 0.2f;
			isFadess = true;
		}
	}

	void OnCollisionExit(Collision col) {
		
			isFades = true;


		

	}
		




	IEnumerator TimerFade(){
		yield return new WaitForSeconds (0.1f);
			time = 0.2f;
			isShow = true;
	}

	public IEnumerator TimerFade2()
	{

		yield return new WaitForSeconds (0.3f);
		r.material.color = new Color (1f, 1f, 1f, time / 2f);
		time -= Time.deltaTime;
		if (time <= 0f) {
			AmbilHero.CanJump = false;
			Destroy (gameObject);

		}
	}


}
