using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class SCENE1DeathScene : MonoBehaviour {




	public static SCENE1DeathScene Instance { set; get; }

	public string SelectScene = "SelectScene";

		public Image FadeDeathImage;
		private bool isInTransition;
		private float transition;
		private bool isShowing;
		private float duration;

		public Image DeathStartImage;
		public GameObject DeathStartText;
		public GameObject DeathRestartText;

	public AudioSource BGMSource;

	public GameObject[] resetObjects;
	public Vector3[] resetPositions;

	//public GameObject HeroRestartSource;

	//
	//public GameObject Box1RestartSource;
	//public GameObject Box2RestartSource;
	//

	public SCENE1FadeStart AutoFadeSelect;

	public AudioClip SoundToPlay;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;

	public bool AlreadyDied =false;

	public SCENE1HeroMovement AmbilHero;

		public void Fade(bool showing,float duration){
			isShowing = showing;
			isInTransition = true;
			this.duration = duration;
			transition = (isShowing) ? 0 : 1;
		}

		void Start (){
			DeathStartText.SetActive (false);
			DeathStartImage.enabled = (false);
			DeathRestartText.SetActive (false);

			audio = GetComponent<AudioSource>();
			
//			resetPositions = new Vector3[resetObjects.Length];
//			for (int i = 0; i < resetObjects.Length; i++) {
//				resetPositions [i] = resetObjects [i].transform.position;
//			}
		}



		// Update is called once per frame
		void Update () {
		if (Input.GetKeyDown (KeyCode.R) && AlreadyDied == true) {
			SceneManager.LoadScene (SelectScene);
		}
				


/////////////////////////////////////////////////////////
// Death By Restart Position Only
//////////////////////////////////			 
//			AlreadyDied = false;
//
//			BGMSource.Play ();
//
//			//HeroRestartSource.transform.position = new Vector3 (-1.23f,2.32f,5.13f);
//
//			//
//			//Box1RestartSource.transform.position = new Vector3 (-1.23f,2.32f,5.13f);
//			//Box2RestartSource.transform.position = new Vector3 (-1.23f,2.32f,5.13f);
//			//
//
//			for (int i = 0; i < resetObjects.Length; i++) {
//				resetObjects [i].transform.position = resetPositions [i];
//			}
//
//			alreadyPlayed = false;
//
//			DeathStartImage.enabled = (false);
//			DeathStartText.SetActive (false);
//			DeathRestartText.SetActive (false);
//
//			AutoFadeSelect.FadeImage.color = new Color (1, 1, 1, 1);
//
//			AutoFadeSelect.Fade (true, 0.0f);
//			StartCoroutine (AutoFadeSelect.Timer ());
//
/////////////////////////////////////



			if (!isInTransition) {
				return;
			}

			transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
			FadeDeathImage.color = Color.Lerp (new Color (1, 1, 1, 0), Color.red, transition);

			if (transition > 1 || transition < 0) {
				isInTransition = false;
			}



	}
		



	public void OnTriggerEnter(Collider col) {
		
		if (col.gameObject.tag == "Player") {

				if (AmbilHero.Flag == 0) {
						StartCoroutine (Timer ());
						AmbilHero.Pause2 += 1;
				}



		}
	}

	public IEnumerator Timer (){
		
		Fade (true, 0.3f);
		yield return new WaitForSeconds (0.1f);
		BGMSource.Stop ();

		yield return new WaitForSeconds (0.1f);


		if (!alreadyPlayed) {
			audio.PlayOneShot (SoundToPlay, Volume);
			alreadyPlayed = true;
		}
		yield return new WaitForSeconds (0.2f);


		DeathStartImage.enabled = (true);
		DeathStartText.SetActive (true);
		DeathRestartText.SetActive (true);
		Fade (false, 3f);



		yield return new WaitForSeconds (3.3f);
	
		AlreadyDied = true;


	}






}
