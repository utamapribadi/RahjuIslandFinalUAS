using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SCENE1HeroMovement : MonoBehaviour {
	private Rigidbody rb;
	private Vector3 normalizedVelocity;

	public float MaxSpeed = 10;
	public float MoveSpeed = 20;
	string newScene;

	bool alreadyJump = false;

	public bool Pause = false;
	public float Pause2 = 1;



	private bool isStep, isWaitAudio;

	public bool isInputActive = true;


	public GameObject GameMenu;
	public AudioSource BGMSource;

	AudioSource audioku;

	public SCENE1RotationButton AmbilRotate;

	public SCENE1FadeStart AmbilFadeStart;

	public float Flag = 0;




	// Use this for initialization
	void Start () 
	{
		
		rb = GetComponent<Rigidbody> ();


		audioku = GetComponent<AudioSource> ();

		isStep = false;
		isWaitAudio = false;

	}

	// Update is called once per frame
	public void Update ()
	{
		isStep = false;

		//
		if (isInputActive == false) {
			rb.isKinematic = true;
			Flag = 1;
		}else{
			rb.isKinematic = false;
			Flag = 0;
		}



		if (isInputActive) {
			

			if (Input.GetKey (KeyCode.W)) {
				rb.AddForce (transform.forward * MoveSpeed);
			} else if (Input.GetKey (KeyCode.S)) {
				rb.AddForce (-transform.forward * MoveSpeed);
			}

			if (Input.GetKey (KeyCode.A)) {
				rb.AddForce (-transform.right * MoveSpeed);
			} else if (Input.GetKey (KeyCode.D)) {
				rb.AddForce (transform.right * MoveSpeed);



			}



			if (Input.GetKeyDown (KeyCode.R) && Pause == true && Pause2 == 0) {
				Application.LoadLevel (Application.loadedLevel);
				Pause = false;

			}

			if (isStep && !isWaitAudio) {
				isWaitAudio = true;
				BGMSource.Stop ();
				StartCoroutine (resetWaitAudio ());
			}
		}

		if (Input.GetKeyDown (KeyCode.P) && Pause2 == 0 && AmbilFadeStart.flag==2) {
			
				AmbilRotate.isRotate = 1;
			
			if (GameMenu == true) {
					GameMenu.SetActive (!GameMenu.activeSelf);
					isInputActive = !isInputActive;

				}

				

			}



	


	


		//biar tidak licin
		if (rb.velocity.magnitude > MaxSpeed) {
			normalizedVelocity = rb.velocity.normalized * MaxSpeed;
			normalizedVelocity.y = rb.velocity.y;
			rb.velocity = normalizedVelocity;
		}

	}

	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Win"&&alreadyJump==false) {
			MoveSpeed -= MoveSpeed;
			StartCoroutine (TimerJump());

		}


	}


	IEnumerator TimerJump(){
		alreadyJump = true;
		yield return new WaitForSeconds (2);
		rb.AddForce (transform.up * 200);

		yield return new WaitForSeconds (1.5f);
		rb.AddForce (transform.up * 200);
		yield return new WaitForSeconds (1.5f);
		rb.AddForce (transform.up * 200);
	
		//Fade to clear

	}


	IEnumerator resetWaitAudio() {
		yield return new WaitForSeconds (0.2f);
		isWaitAudio = false;
	}

	public void toggleInput() {
		isInputActive = !isInputActive;
	}



}
