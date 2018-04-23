using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingSound : MonoBehaviour {

	private AudioSource audioS;
	public AudioClip winSound;
	public Text smashText;
	public bool oneTime;

	// Use this for initialization
	void Start () {
		audioS = this.GetComponent<AudioSource>();
		oneTime = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (smashText.text == ""){
			if(oneTime)
			{
				audioS.Stop();
				audioS.PlayOneShot (winSound);
				oneTime = false;
			}
		}
	}
}

