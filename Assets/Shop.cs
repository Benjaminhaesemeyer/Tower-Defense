using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;

	void Start(){
		buildManager = BuildManager.instance;
	}

	public void PurchaseStandardTurret(){

		Debug.Log("StandardTurret Purchased!");
		buildManager.SetTurretToBuild (buildManager.standardTurretPrefab);
	}

	public void PurchaseAnotherTurret(){

		Debug.Log("AnotherTurret Purchased!");
		buildManager.SetTurretToBuild (buildManager.anotherTurretPrefab);
	}
}
