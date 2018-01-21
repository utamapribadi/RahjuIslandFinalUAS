using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCENE2FadeStart : MonoBehaviour {

	public static SCENE2FadeStart Instance { set; get; }

	public Image FadeImage;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;


	public Image WelcomeImage;

	public float flag = 1;


	public SCENE2HeroMovement AmbilHero;



	// Use this for initialization
	void Start () {
		WelcomeImage.enabled = (false);

	}
	

	private void Awake()
	{
		

		Instance = this;
		Fade (true, 0.0f);
		StartCoroutine (Timer ());

	}

	public void Fade(bool showing,float duration){
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing) ? 0 : 1;
	}

	// Update is called once per frame
	private void Update () {

		if (Input.GetKeyDown (KeyCode.F) && flag == 0) {
			WelcomeImage.enabled = (false);
			flag = 2;
		}
			
	

		if (!isInTransition) {
			return;
		}

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		FadeImage.color = Color.Lerp (new Color (1, 1, 1, 0), Color.white, transition);

		if (transition > 1 || transition < 0) {
			isInTransition = false;
		}
	}



	public IEnumerator Timer(){
		

		yield return new WaitForSeconds (1);
		Fade (false, 3.0f);
		WelcomeImage.enabled = (true);
		yield return new WaitForSeconds (2f);
		flag = 0;
		AmbilHero.Pause2 -= 1;
	}


}


