using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;



public class SCENE2Save : MonoBehaviour {


	private float positionX = 0;
	private float positionY = 0;	
	private float positionZ = 0;


	public GameObject SaveHintText;
	public SCENE2HeroMovement hero;

	public float getPositionX()
	{
		return positionX;
	}

	public float getPositionY()
	{
		return positionY;
	}

	public float getPositionZ()
	{
		return positionZ;
	}

	// Use this for initialization
	void Start () {
		positionX = transform.position.x;
		positionY = transform.position.y;
		positionZ = transform.position.z;
		SaveHintText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			SaveHintText.SetActive (true);

			if(Input.GetKey(KeyCode.F)){
				hero.setPosition ();
			}
		}
	}

}



