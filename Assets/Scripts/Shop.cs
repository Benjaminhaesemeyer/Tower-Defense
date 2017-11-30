using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("StandardTurret Selected!");
        buildManager.SelectTurretToBuild(standardTurret);
        standardTurret.SelectedItem.GetComponent<Image>().sprite = standardTurret.SelectedSprite;
        //Deselect
        missileLauncher.SelectedItem.GetComponent<Image>().sprite = missileLauncher.DeselectedSprite;
        laserBeamer.SelectedItem.GetComponent<Image>().sprite = laserBeamer.DeselectedSprite;
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("MissileLauncher Selected!");
        buildManager.SelectTurretToBuild(missileLauncher);
        missileLauncher.SelectedItem.GetComponent<Image>().sprite = missileLauncher.SelectedSprite;
        //Deselect
        standardTurret.SelectedItem.GetComponent<Image>().sprite = standardTurret.DeselectedSprite;
        laserBeamer.SelectedItem.GetComponent<Image>().sprite = laserBeamer.DeselectedSprite;
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("LaserBeamer Selected!");
        buildManager.SelectTurretToBuild(laserBeamer);
        laserBeamer.SelectedItem.GetComponent<Image>().sprite = laserBeamer.SelectedSprite;
        //Deselect
        standardTurret.SelectedItem.GetComponent<Image>().sprite = standardTurret.DeselectedSprite;
        missileLauncher.SelectedItem.GetComponent<Image>().sprite = missileLauncher.DeselectedSprite;
    }

}
