using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour {
	public GameObject fishingObject;


	// Use this for initialization
	void Awake () {
			fishingObject.SetActive(false);
		Debug.Log("smash INACTIVE");
		}
	public int waveCount;
		
	
	// Update is called once per frame
	//void Update () {
		//if 
		//	fishingObject.SetActive(true);
		//Debug.Log("smash ACTIVE");
		
	//}
}



