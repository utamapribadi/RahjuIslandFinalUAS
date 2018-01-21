using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroMovement : MonoBehaviour {
	private Rigidbody rb;
	private Vector3 normalizedVelocity;

	public float MaxSpeed = 10;
	public float MoveSpeed = 20;
	public float JumpSpeed = 150;
	public bool canJump = false;

	public float JumpTimes = 0;
	float JumpFlag = 0;

	public float DoubleJumpSpeed = 100;
	public float DoubleJumpSpeedFlag = 1;

	public GameObject TextSuperJump;
	public GameObject TextDoubleJumpItem;
	public float TimerShow;
	public float TimerHide;

	public GameObject other1;


	public float Jumper = 3;




	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		TextSuperJump.SetActive (false);
		TextDoubleJumpItem.SetActive (false);
		JumpFlag += JumpTimes;
		DoubleJumpSpeedFlag += 5;

	}

	// Update is called once per frame
	void Update () 
	{

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

		if (Input.GetKeyDown (KeyCode.Space)  && JumpFlag>0) {
			rb.AddForce (transform.up * JumpSpeed);
			JumpFlag -= 1;
		}

		//biar tidak licin
		if (rb.velocity.magnitude > MaxSpeed) {
			normalizedVelocity = rb.velocity.normalized * MaxSpeed;
			normalizedVelocity.y = rb.velocity.y;
			rb.velocity = normalizedVelocity;
		}

		if (JumpFlag == 0) {
			canJump = false;
		} else if (JumpFlag > 0) {
			canJump = true;
		}
			

	}

	void OnCollisionEnter(Collision other){
		DoubleJumpSpeedFlag -= 1;
		if (DoubleJumpSpeedFlag ==0) {
			JumpSpeed -= DoubleJumpSpeed;
		}

		if (other.gameObject.tag == "Ground") {
			if (JumpFlag == 0 && canJump == false) {
				JumpFlag += JumpTimes;
				canJump = true;
			} else if (JumpFlag > 0) {
				JumpFlag += JumpTimes-JumpFlag;
				canJump = true;
			}



		
		} else if (other.gameObject.tag == "WellA1") {
			if (JumpFlag == 0 && canJump == false) {
				JumpFlag += JumpTimes;
				canJump = true;


			} else if (JumpFlag > 0) {
				JumpFlag += JumpTimes-JumpFlag;
				canJump = true;
			}

		
		} else if (other.gameObject.tag == "WellB1") {
			if (JumpFlag == 0 && canJump == false) {
				JumpFlag += JumpTimes;
				canJump = true;
		
			
			} else if (JumpFlag > 0) {
				JumpFlag += JumpTimes-JumpFlag;
				canJump = true;
			}
		
		}

		if (other.gameObject.tag == "CanJump") {
			if (JumpFlag == 0 && canJump == false) {
				JumpFlag += JumpTimes;
				canJump = true;


			} else if (JumpFlag > 0) {
				JumpFlag += JumpTimes-JumpFlag;
				canJump = true;
			}

		} 

	}

	void OnTriggerStay(Collider col) {
		 




	}

	void OnCollisionExit(Collision other){
		if (DoubleJumpSpeedFlag == 5) {
			DoubleJumpSpeedFlag -= 4;
		} else if (DoubleJumpSpeedFlag < 5) {
			DoubleJumpSpeedFlag += 1;
		}
		if (DoubleJumpSpeedFlag==1) {
			JumpSpeed += DoubleJumpSpeed;
		}

	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Dirt") {
			MoveSpeed -= 7;
		}
		if (col.gameObject.tag == "SuperJump") {
			JumpSpeed += 400;

			StartCoroutine (TextSuperjumpAppear ());
		}

		if (col.gameObject.tag == "DoubleJumpItem") {
			JumpTimes += 1;

			StartCoroutine (TextDoublejumpItemAppear ());
			Destroy (other1);
		}

		if (col.gameObject.tag == "Jumper") {
			rb.AddForce (transform.up * JumpSpeed * Jumper);
		}

	}
	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Dirt") {
			MoveSpeed += 7;
		}
		if (col.gameObject.tag == "SuperJump") {
			JumpSpeed -= 400;

			TextSuperJump.SetActive (false);
		}


	}
		
	IEnumerator TextSuperjumpAppear()
	{
		yield return new WaitForSeconds (TimerShow);
		TextSuperJump.SetActive (true);
		yield return new WaitForSeconds (TimerHide);
		TextSuperJump.SetActive (false);
	}

	IEnumerator TextDoublejumpItemAppear()
	{
		yield return new WaitForSeconds (TimerShow);
		TextDoubleJumpItem.SetActive (true);
		yield return new WaitForSeconds (TimerHide);
		TextDoubleJumpItem.SetActive (false);
	}

}
