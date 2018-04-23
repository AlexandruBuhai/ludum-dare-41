using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint powerfulTurret;
	BuildManager buildManager;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectNormalBear(){
		Debug.Log ("normal bear selected");
		buildManager.SelectTurretToBuild(standardTurret);
		//buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
	}


	public void SelectStrongBear(){
		Debug.Log("strong bear selected");
		buildManager.SelectTurretToBuild(powerfulTurret);
		//buildManager.SetTurretToBuild(buildManager.powerfulTurretPrefab);

	}


}
