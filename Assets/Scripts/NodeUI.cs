using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text upgradeCost;

    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target) //Find the target Node to display Node UI on top of
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
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

    public void Sell () 
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
        target.isUpgraded = false; //Reset the node, so new turrets can be upgraded
    }

}
