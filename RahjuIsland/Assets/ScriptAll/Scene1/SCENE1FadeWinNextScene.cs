using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class SCENE1FadeWinNextScene : MonoBehaviour {

	public static SCENE1FadeWinNextScene Instance { set; get; }

	public Image FadeImage;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;

	public string SelectScene = "SelectScene";

	bool AlreadyWin = (false);

	public void Fade(bool showing,float duration){
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing) ? 0 : 1;
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isInTransition) {
			return;
		}

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		FadeImage.color = Color.Lerp (new Color (1, 1, 1, 0), Color.white, transition);

		if (transition > 1 || transition < 0) {
			isInTransition = false;
		}
			


	}


	void OnTriggerEnter()
	{
		if (AlreadyWin == (false)) {
			StartCoroutine (Timer ());
			AlreadyWin = (true);
		}
	}

	public IEnumerator Timer()
	{

		yield return new WaitForSeconds (3);
		Fade (true, 3.0f);
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (SelectScene);
	}
}
