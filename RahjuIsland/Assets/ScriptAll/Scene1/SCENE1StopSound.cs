using UnityEngine;
using System.Collections;

public class SCENE1StopSound : MonoBehaviour {

	public GameObject SoundToStop;
	public bool SoundPlaying = (true);

	void Start()
	{
		SoundToStop.SetActive (true);
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			if (SoundPlaying == (true)) {
				SoundToStop.SetActive (false);
				SoundPlaying = (false);
			}
		}
	}
}
