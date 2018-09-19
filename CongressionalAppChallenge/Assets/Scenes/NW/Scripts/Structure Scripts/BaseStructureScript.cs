using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStructureScript : MonoBehaviour {

    public GameObject GameManager;

    public int buildingLevel;
    public int buildingID;

    public int woodUpgradeRequirement;
    public int stoneUpgradeRequirement;
    public int oreUpgradeRequirement;
    public int steelUpgradeRequirement;
    public bool upgradeAvailable;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");

        buildingLevel = 1;
        woodUpgradeRequirement = 0;
        stoneUpgradeRequirement = 0;
        oreUpgradeRequirement = 0;
        steelUpgradeRequirement = 0;

        switch (buildingID)
        {
            case 11:
                GetComponent<ProductionStructureScript>().resourceID = 1;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 10
                woodUpgradeRequirement = 10;
                Debug.Log("Wood Required to Upgrade: " + woodUpgradeRequirement);
                break;

            case 12:
                GetComponent<ProductionStructureScript>().resourceID = 2;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 20
                woodUpgradeRequirement = 5;
                stoneUpgradeRequirement = 15;
                break;

            case 13:
                GetComponent<ProductionStructureScript>().resourceID = 3;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 30
                woodUpgradeRequirement = 15;
                stoneUpgradeRequirement = 10;
                oreUpgradeRequirement = 5;
                break;

            case 14:
                GetComponent<ProductionStructureScript>().resourceID = 4;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 40
                woodUpgradeRequirement = 15;
                stoneUpgradeRequirement = 5;
                oreUpgradeRequirement = 15;
                steelUpgradeRequirement = 5;
                break;
        }
    }

    public void LevelUpBuilding()
    {
        switch (buildingID)
        {
            case 11:
                switch (buildingLevel)
                {
                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        break;
                }
                break;

            case 12:
                switch (buildingLevel)
                {
                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        break;
                }
                break;

            case 13:
                switch (buildingLevel)
                {
                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        break;
                }
                break;

            case 14:
                switch (buildingLevel)
                {
                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        break;
                }
                break;
        }
    }
}
