using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour {

    public GameObject TilesBase;

    void Start()
    {
        TilesBase = GameObject.Find("TilesBase");
    }

    void Update()
    {
        if (TilesBase.GetComponent<UpgradeStructureScript>().upgradeAvailable)
        {
            GetComponent<Button>().interactable = true;
        }

        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
