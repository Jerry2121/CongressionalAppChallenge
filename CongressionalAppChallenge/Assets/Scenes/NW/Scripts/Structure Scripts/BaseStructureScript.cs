using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStructureScript : MonoBehaviour {

    public GameObject GameManager;

    public int buildingLevel;
    public int buildingID;

    int woodUpgradeRequirement;
    int stoneUpgradeRequirement;
    int oreUpgradeRequirement;
    int steelUpgradeRequirement;
    public bool upgradeAvailable;

    void Start()
    { 
        switch (buildingID)
        {
            case 11:
                GetComponent<ProductionStructureScript>().resourceID = 1;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 10
                woodUpgradeRequirement = 10;
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

    void UpgradeCheck()
    {
        if (GameManager.GetComponent<GameManagerScript>().woodAcquired >= woodUpgradeRequirement && GameManager.GetComponent<GameManagerScript>().stoneAcquired >= stoneUpgradeRequirement &&
                GameManager.GetComponent<GameManagerScript>().oreAcquired >= oreUpgradeRequirement && GameManager.GetComponent<GameManagerScript>().steelAcquired >= steelUpgradeRequirement)
        {
            upgradeAvailable = true;
        }

        else
        {
            upgradeAvailable = false;
        }
    }

    void UpgradeBuilding()
    {
        GameManager.GetComponent<GameManagerScript>().woodAcquired -= woodUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().stoneAcquired -= stoneUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().oreAcquired -= oreUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().steelAcquired -= steelUpgradeRequirement;

        buildingLevel++;

        switch (buildingID)
        {
            case 11:
                switch (buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 25
                        woodUpgradeRequirement = 20;
                        stoneUpgradeRequirement = 5;
                        break;

                    case 3:
                        // Upgrade requirement = 45
                        woodUpgradeRequirement = 30;
                        stoneUpgradeRequirement = 10;
                        oreUpgradeRequirement = 5;
                        break;

                    case 4:
                        // Upgrade requirement = 70
                        woodUpgradeRequirement = 40;
                        stoneUpgradeRequirement = 15;
                        oreUpgradeRequirement = 10;
                        steelUpgradeRequirement = 5;
                        break;
                }
                break;

            case 12:
                switch (buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 40
                        woodUpgradeRequirement = 10;
                        stoneUpgradeRequirement = 30;
                        break;

                    case 3:
                        // Upgrade requirement = 70
                        woodUpgradeRequirement = 15;
                        stoneUpgradeRequirement = 45;
                        oreUpgradeRequirement = 10;
                        break;

                    case 4:
                        // Upgrade requirement = 110
                        woodUpgradeRequirement = 20;
                        stoneUpgradeRequirement = 60;
                        oreUpgradeRequirement = 20;
                        steelUpgradeRequirement = 10;
                        break;
                }
                break;

            case 13:
                switch (buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 60
                        woodUpgradeRequirement = 30;
                        stoneUpgradeRequirement = 20;
                        oreUpgradeRequirement = 10;
                        break;

                    case 3:
                        // Upgrade requirement = 95
                        woodUpgradeRequirement = 45;
                        stoneUpgradeRequirement = 30;
                        oreUpgradeRequirement = 15;
                        steelUpgradeRequirement = 5;
                        break;

                    case 4:
                        // Upgrade requirement = 130
                        woodUpgradeRequirement = 60;
                        stoneUpgradeRequirement = 40;
                        oreUpgradeRequirement = 20;
                        steelUpgradeRequirement = 10;
                        break;
                }
                break;

            case 14:
                switch (buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 80
                        woodUpgradeRequirement = 30;
                        stoneUpgradeRequirement = 10;
                        oreUpgradeRequirement = 30;
                        steelUpgradeRequirement = 10;
                        break;

                    case 3:
                        // Upgrade requirement = 120
                        woodUpgradeRequirement = 45;
                        stoneUpgradeRequirement = 15;
                        oreUpgradeRequirement = 45;
                        steelUpgradeRequirement = 15;
                        break;

                    case 4:
                        // Upgrade requirement = 160
                        woodUpgradeRequirement = 60;
                        stoneUpgradeRequirement = 20;
                        oreUpgradeRequirement = 60;
                        steelUpgradeRequirement = 20;
                        break;
                }
                break;
        }
    }
}
