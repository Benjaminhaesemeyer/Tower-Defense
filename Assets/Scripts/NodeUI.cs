using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    private Node target;

    public void SetTarget(Node _target) //Find the target Node to display Node UI on top of
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true); //Show the Node UI
    }

    public void Hide() //Hide the Node UI
    {
        ui.SetActive(false);

    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //Close menu after selection made
    }

}
