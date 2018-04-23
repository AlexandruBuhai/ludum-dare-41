using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour {

	public Color hoverColor; // not used
	public Color notGoodColor; // not used

	[Header("Optional")]
	public GameObject turret;

	private SpriteRenderer rend;
	private Color startColor; //not used

	private BuildManager buildManager;

	// Use this for initialization
	void Start () {

		buildManager = BuildManager.instance;
		rend = GetComponent<SpriteRenderer>();
	}
	
	public Vector3 GetBuildPosition()
	{
		return transform.position;
	}

	void OnMouseEnter()
	{

		if(!buildManager.CanBuild)
		{
			return;
		}
		if(buildManager.HasMoney)
		{
			//rend.color = new Color(30f,186f,38f, 0.7f);//hoverColor; 1EBA2695
			rend.color = new Color(0f,1f,0f,0.6f);//hoverColor; 1EBA2695

			rend.sortingOrder = 5;
		}
		else
		{
			rend.color = new Color(1f, 0f, 0f, 0.6f);
			rend.sortingOrder = 5;
		}
		
	}

	void OnMouseExit()
	{
		rend.color = Color.white;
		rend.sortingOrder = 0;

	}

	void OnMouseDown()
	{
		//Debug.Log("Clicked");
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		if(!buildManager.CanBuild)
			return;
		if(turret != null)
		{
			Debug.Log("Can't build there!"); //TODO Dysplay on screen
			return;
		}
		
		buildManager.BuildTurretOn(this);
	}

	void OnMouseOver()
    {
        //Debug.Log("Mouse is over GameObject.");
		
		if(!buildManager.CanBuild)
		{
			return;
		}
		if(buildManager.HasMoney)
		{
			//rend.color = new Color(30f,186f,38f, 0.7f);//hoverColor; 1EBA2695
			rend.color = new Color(0f,1f,0f,0.6f);//hoverColor; 1EBA2695

			rend.sortingOrder = 5;
		}
		else
		{
			rend.color = new Color(1f, 0f, 0f, 0.6f);
			rend.sortingOrder = 5;
		}
    }

}
