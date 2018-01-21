using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCENE2MoveToDeathScene : MonoBehaviour {

	public static SCENE2MoveToDeathScene Instance { set; get; }

	public Image FadeImage;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;



	public void Fade(bool showing,float duration){
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing) ? 0 : 1;
	}

	void Start (){

	}



	// Update is called once per frame
	void Update () {
		if (!isInTransition) {
			return;
		}

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		FadeImage.color = Color.Lerp (new Color (1, 1, 1, 0), Color.red, transition);

		if (transition > 1 || transition < 0) {
			isInTransition = false;
		}

	}




	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			StartCoroutine (Timer());

		}
	}

	IEnumerator Timer (){
		Fade (true, 0.3f);

		yield return new WaitForSeconds (0.3f);
		Application.LoadLevel ("DeathScene");


	}






}
