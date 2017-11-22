using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;

	void Start(){
		buildManager = BuildManager.instance;
	}

	public void PurchaseStandardTurret(){

		Debug.Log("StandardTurret Selected!");
		buildManager.SetTurretToBuild (buildManager.standardTurretPrefab);
	}

	public void PurchaseMissileLauncher(){

		Debug.Log("MissileLauncher Selected!");
		buildManager.SetTurretToBuild (buildManager.missileLauncherPrefab);
	}
}
