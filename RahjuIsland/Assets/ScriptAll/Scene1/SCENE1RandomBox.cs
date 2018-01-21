using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE1RandomBox : MonoBehaviour {
	public GameObject [] RandomBox;
	public Vector3 [] RandomBoxOther;

	// Use this for initialization
	void Start () {
		RandomBox [0].transform.position = RandomBoxOther [2];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
