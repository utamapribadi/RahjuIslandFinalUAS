using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClicktoMove : MonoBehaviour {

	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
		{
			SetTargetPosition ();
		}
	}

	void SetTargetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 1000))
		{
			targetPosition = hit.point;
			this.transform.LookAt (targetPosition);
		}
	}
}
