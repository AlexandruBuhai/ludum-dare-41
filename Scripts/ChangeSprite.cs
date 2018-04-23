using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour {

	public Sprite spriteToChange;
	//public Sprite buttonToChange;

	public Sprite OffSprite;
	public Sprite OnSprite;
	public Button but1;
	public Button but2;


	public void ChangeImage(Image imageToChangeTo){
		imageToChangeTo.sprite = spriteToChange;
	}

	/*public void ChangeButton(Image buttonToChangeTo){
		buttonToChange = gameObject.GetComponent<Image> ();
		buttonToChangeTo = buttonToChange;
	}*/

	public void ChangeButImage(){
		if (but1.image.sprite == OnSprite)
		{
			but1.image.sprite = OffSprite;
			but2.image.sprite = OnSprite;
		}	
	
	} 
}



