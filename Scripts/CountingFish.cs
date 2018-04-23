using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountingFish : MonoBehaviour {

	public Text fishEscapedText;
	private int fishCount;
	public GameObject gameOverObj;
	public Text gameOverText;


	void Awake()
	{
		gameOverObj.SetActive(false);
	}
	void Start()
	{
		fishEscapedText.text = "0/5";
	}

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log("i work");

		if (other.gameObject.tag == "enemy")
		{
			fishCount = fishCount +1;
			fishEscapedText.text = (fishCount.ToString () + "/" + "5");
		}
		if (other.gameObject.name == "EnemyBoss(Clone)")
		{
			fishCount = fishCount + 4;
			fishEscapedText.text = (fishCount.ToString () + "/" + "5");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (fishCount == 5){
			Debug.Log("you suck");
			gameOverObj.SetActive(true);
		}


}

}
