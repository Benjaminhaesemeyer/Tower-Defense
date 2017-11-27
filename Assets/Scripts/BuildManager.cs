using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake(){
		if (instance != null) {
			Debug.LogError ("Moer than one build manager in scene");
		}
		instance = this;
	}

	public GameObject buildEffect;

	private TurretBlueprint turretToBuild;


	public bool CanBuild { get{ return turretToBuild != null; }}

	public bool HasMoney { get{ return PlayerStats.Money >= turretToBuild.cost; }}

	public void BuildTurretOn(Node node){
		if (PlayerStats.Money < turretToBuild.cost) {
			Debug.Log ("Not enough money to build that! Money Available:" + PlayerStats.Money);
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;

		GameObject effect = (GameObject)Instantiate (buildEffect, node.GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		GameObject turret = (GameObject)Instantiate (turretToBuild.prefab, node.GetBuildPosition (), Quaternion.identity);
		node.turret = turret;


		Debug.Log ("Turret Built! Money left:" + PlayerStats.Money);
	} 

	public void SelectTurretToBuild(TurretBlueprint turret){
		turretToBuild = turret;
	}
}
