using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake(){
		if (instance != null) {
			Debug.LogError ("More than one build manager in scene");
		}
		instance = this;
	}

	public GameObject buildEffect; //When turret is built
    public GameObject sellEffect; //When turret is sold

	private TurretBlueprint turretToBuild; //Type of turret to build
    private Node selectedNode; //Node to build on

    public NodeUI nodeUI;
    public GameObject shopLaserBeamer;
    public GameObject shopStandardTurret;
    public GameObject shopMissileLauncher;

    public Sprite defaultLaserBeamerSprite;
    public Sprite defaultStandardTurret;
    public Sprite defaultMissileLauncher;


	public bool CanBuild { get{ return turretToBuild != null; }}

	public bool HasMoney { get{ return PlayerStats.Money >= turretToBuild.cost; }}

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
        shopStandardTurret.GetComponent<Image>().sprite = defaultStandardTurret;
        shopLaserBeamer.GetComponent<Image>().sprite = defaultLaserBeamerSprite;
        shopMissileLauncher.GetComponent<Image>().sprite = defaultMissileLauncher;
    } 

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

	public void SelectTurretToBuild(TurretBlueprint turret){
		turretToBuild = turret;
        DeselectNode();
	}

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;

    }
}
