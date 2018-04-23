using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject standardTurretPrefab;
	public GameObject powerfulTurretPrefab;

	private TurretBlueprint turretToBuild;

	public bool CanBuild { get { return turretToBuild != null; } } 
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } } 

	private AudioSource audioS;
	public AudioClip bearGrunt;

	void Awake()
	{
		//Debug.Log("Build Manager is instantiated"); //TODO - remove log
		if(instance != null)
		{
			Debug.Log("mode than one BuildManager in scene!");
		}
		instance = this;
	}

	void Start() {
		audioS = this.GetComponent<AudioSource>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
		}
	}
	public void SelectTurretToBuild(TurretBlueprint turret)
	{	
		audioS.PlayOneShot (bearGrunt, 0.8f);
		turretToBuild = turret;
		Debug.Log("turret to build selected " + turretToBuild.cost.ToString());

	}
	
	public void BuildTurretOn(NodeScript node)
	{
		if(PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enough money to build that");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;
		Debug.Log("Money left: " + PlayerStats.Money);
		GameObject obj = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), node.transform.rotation);
		node.turret = obj;
	}
}
