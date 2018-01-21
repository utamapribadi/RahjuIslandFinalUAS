using UnityEngine;
using System.Collections;

public class RotationButton : MonoBehaviour {
	private float lookAngle;
	public float turnSpeed;
	public float RightRotation=10f;
	public float LeftRotation=10f;
	public bool canRotate = true;

	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
	}


	void Update () {
		if (Input.GetKey (KeyCode.L) && canRotate == true) {
			

			float x = RightRotation;
			lookAngle += x * turnSpeed;
			transform.localRotation = Quaternion.Euler (0f, lookAngle, 0f);
		} else if (Input.GetKey (KeyCode.K) && canRotate == true) {
			

			float x = RightRotation;
			lookAngle -= x * turnSpeed;
			transform.localRotation = Quaternion.Euler (0f, lookAngle, 0f);
		}

	}
}
