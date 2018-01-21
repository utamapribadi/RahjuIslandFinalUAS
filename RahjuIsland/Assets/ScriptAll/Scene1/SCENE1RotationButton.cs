using UnityEngine;
using System.Collections;

public class SCENE1RotationButton : MonoBehaviour {
	private float lookAngle;
	public float turnSpeed = 0.2f;
	public float RightRotation=10f;
	public float LeftRotation=10f;


	public bool isFollow = true;
	public float isRotate = 0;

	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
	}


	void Update () {
		if (isFollow) {
			if (Input.GetKey (KeyCode.L)) {
				float x = RightRotation;
				lookAngle += x * turnSpeed;
				transform.localRotation = Quaternion.Euler (0f, lookAngle, 0f);
			} else if (Input.GetKey (KeyCode.K)) {
				float x = RightRotation;
				lookAngle -= x * turnSpeed;
				transform.localRotation = Quaternion.Euler (0f, lookAngle, 0f);
			}
		}

		if (isRotate == 1) {
			isFollow = !isFollow;
			isRotate = 0;
		}
	}


	public void toggleFollow() {
		isFollow = !isFollow;
	}
}
