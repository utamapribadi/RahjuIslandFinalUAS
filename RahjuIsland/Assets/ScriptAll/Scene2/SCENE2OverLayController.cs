using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SCENE2OverLayController : MonoBehaviour {
	public bool isActive = false;
	public AudioSource BGMSource;



	void Start() {
		this.gameObject.SetActive (isActive);
	}

	public void toggleActive() {
		isActive = !isActive;
		this.gameObject.SetActive (isActive);

		if (isActive) {
			BGMSource.Pause();

			//bg.Stop();
		}
		if (!isActive)
			BGMSource.Play ();
	}


	void Update(){

	}
}
