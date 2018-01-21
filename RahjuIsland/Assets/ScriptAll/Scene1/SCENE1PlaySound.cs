using UnityEngine;
using System.Collections;

public class SCENE1PlaySound : MonoBehaviour {

	public AudioClip SoundToPlay;

	public AudioSource SoundToStop;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;


	void Start()
	{
		audio = GetComponent<AudioSource>();
	}



	void OnTriggerEnter()
	{
		
			if (!alreadyPlayed) {
				audio.PlayOneShot (SoundToPlay, Volume);
				SoundToStop.Stop ();
				alreadyPlayed = true;
			}
	}
}
