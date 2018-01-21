using UnityEngine;
using System.Collections;

public class SCENE2PlaySound : MonoBehaviour {

	public AudioClip SoundToPlay;

	public AudioSource SoundToStop;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;

	public SCENE2SwitchColorAndItem AmbilFlag;


	void Start()
	{
		audio = GetComponent<AudioSource>();
	}



	void OnTriggerEnter()
	{
		
		if (!alreadyPlayed && AmbilFlag.FlagSwitch==1) {
				audio.PlayOneShot (SoundToPlay, Volume);
				SoundToStop.Stop ();
				alreadyPlayed = true;
			}
	}
}
