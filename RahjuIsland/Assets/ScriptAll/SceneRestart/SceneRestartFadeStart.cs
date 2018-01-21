using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneRestartFadeStart : MonoBehaviour {

	public static SceneRestartFadeStart Instance { set; get; }

	public Image FadeImage;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;



	// Use this for initialization
	void Start () {

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




		if (!isInTransition) {
			return;
		}

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		FadeImage.color = Color.Lerp (new Color (1, 1, 1, 0), Color.red, transition);

		if (transition > 1 || transition < 0) {
			isInTransition = false;
		}
	}



	IEnumerator Timer(){
		yield return new WaitForSeconds (1);

		Fade (false, 2f);
		Application.LoadLevel ("Scene1");
	}

}


