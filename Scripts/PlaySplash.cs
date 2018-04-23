using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySplash : MonoBehaviour {

	public AudioSource audioS;
	public AudioClip splashSoundOut;
	public AudioClip splashSoundIn;

	// Use this for initialization
	void Start () {
		audioS = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void PlaySplashOut () {
		audioS.PlayOneShot(splashSoundOut);
	}

	void PlaySplashIn () {
		audioS.PlayOneShot (splashSoundIn);
	}
}
