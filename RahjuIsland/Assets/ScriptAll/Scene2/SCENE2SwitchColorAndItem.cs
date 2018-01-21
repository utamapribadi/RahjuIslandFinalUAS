using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE2SwitchColorAndItem : MonoBehaviour {
	public GameObject ItemAHide;
	public GameObject ItemBShow;

	public GameObject ItemCHide;

	public Texture changeTexture;
	public Renderer r;

	public float FlagSwitch = 0;

	public GameObject Text;

	private float Flag = 0;


	void Awake(){
		ItemAHide.SetActive (false);
		ItemBShow.SetActive (true);
		ItemCHide.SetActive (false);

		Text.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player"){
			r.material.mainTexture = changeTexture;
			ItemAHide.SetActive (true);
			ItemBShow.SetActive (false);
			ItemCHide.SetActive (true);

			FlagSwitch = 1;

			StartCoroutine (Timer());
		}

	}

	public IEnumerator Timer()
	{
		if (Flag == 0) {
			Text.SetActive (true);
			yield return new WaitForSeconds (1f);
			Text.SetActive (false);

			Flag = 1;
		}
	}
}
