using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonScript : MonoBehaviour {

    public GameObject tilesBase;
    public GameObject upgradeRequirements;

    void Update()
    {
        if (tilesBase.GetComponent<UpgradeStructureScript>().upgradeAvailable)
        {
            GetComponent<Button>().interactable = true;
            GetComponent<Image>().enabled = true;
            upgradeRequirements.SetActive(true);
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade to Level " + (tilesBase.GetComponent<UpgradeStructureScript>().selectedStructure.GetComponent<BaseStructureScript>().buildingLevel + 1).ToString();
        }

        else if (tilesBase.GetComponent<UpgradeStructureScript>().upgradeAvailable == false)
        {
            GetComponent<Button>().interactable = false;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade to Level " + (tilesBase.GetComponent<UpgradeStructureScript>().selectedStructure.GetComponent<BaseStructureScript>().buildingLevel + 1).ToString();
        }

        if (tilesBase.GetComponent<UpgradeStructureScript>().upgradeAvailable == false && tilesBase.GetComponent<UpgradeStructureScript>().selectedStructure.GetComponent<BaseStructureScript>().buildingLevel > tilesBase.GetComponent<UpgradeStructureScript>().selectedStructure.GetComponent<BaseStructureScript>().maxBuildingLevel)
        {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().enabled = false;
            upgradeRequirements.SetActive(false);
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Max Level";
        }
    }
}
