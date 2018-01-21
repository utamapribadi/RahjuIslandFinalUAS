using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageUpload : MonoBehaviour {

	public Image Gambar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GambarUpload(){
		Gambar.sprite = Resources.Load<Sprite> ("Button_T");
	}
}
