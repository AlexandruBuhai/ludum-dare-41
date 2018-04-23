using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmasherController : MonoBehaviour {

	public Button btn1;
	public Button btn2;

	//wow text polish, when theres time
	//public Text TextToEnable;
	//public Text TextToDisable;

	//public Canvas canv;
	private bool itStarted;
	private int count; 
	public Text smashText;
	public Image fishImage;
	public GameObject gameOverObj;
	//public Text gameOverTxt;

	void Awake()
	{
		//gameOverTxt.text = "You won! Thanks for playing our LD41 Submission";
		Debug.Log(this.ToString());
		gameOverObj.SetActive(false);
	}
	void Start()
	{
		itStarted = false;

	}
	void Update () {

		//to do when we have a condition for buttonsmash appearing
		//if something something

		// if (count > 3) {
		// //	btn1.enabled = false;
		// //	btn2.enabled = false;
		// //	winText.text = ("You got the fish!");
		// 	CloseUISmash ();
		// }
	}

	public void HowManyClicks(){
		
		if (count > 9) {
			CloseUISmash ();
			Debug.Log ("I stopped counting");
			return;
		}
		count = count + 1;
		print (count);
	}

	public void  CloseUISmash(){
		
		if(itStarted == false)
		{
			// Destroy (btn1);
			// Destroy (btn2);
			btn1.gameObject.GetComponent<Image>().enabled = false;
			btn2.gameObject.GetComponent<Image>().enabled = false;
			btn1.gameObject.GetComponent<SmasherController>().enabled = false;
			btn2.gameObject.GetComponent<SmasherController>().enabled = false;
			btn1.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
			btn2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
			// btn1.gameObject.SetActive(false);
			// btn2.gameObject.SetActive(false);
			smashText.text = ("YOU DOMINATED");

			itStarted = true;

			StartCoroutine(waitForWinMessage(3.3f));
			//fishingObj.SetActive (false);
		}
	}

	//wow text polish, when theres time
	/*public void TextAppear(){
		if (TextToEnable.enabled = false) {
			TextToEnable.enabled = true;

		}
		if (TextToDisable.enabled = true){
			TextToDisable.enabled = false;
		}

	}*/

	IEnumerator  waitForWinMessage(float waitTime)
	{
		yield return new WaitForSeconds(waitTime); 
		smashText.text = "";
		fishImage.GetComponent<Image>().enabled = false;
		gameOverObj.SetActive(true);

	}
		
}
