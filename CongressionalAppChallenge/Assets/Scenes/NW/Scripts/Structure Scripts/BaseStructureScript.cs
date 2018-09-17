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
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                // Upgrade requirement = 100
                woodUpgradeRequirement = 100;
                break;

            case 12:
                GetComponent<ProductionStructureScript>().resourceID = 2;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                // Upgrade requirement = 200
                woodUpgradeRequirement = 50;
                stoneUpgradeRequirement = 150;
                break;

            case 13:
                GetComponent<ProductionStructureScript>().resourceID = 3;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                // Upgrade requirement = 300
                woodUpgradeRequirement = 150;
                stoneUpgradeRequirement = 100;
                oreUpgradeRequirement = 50;
                break;

            case 14:
                GetComponent<ProductionStructureScript>().resourceID = 4;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                // Upgrade requirement = 400
                woodUpgradeRequirement = 150;
                stoneUpgradeRequirement = 50;
                oreUpgradeRequirement = 150;
                steelUpgradeRequirement = 50;
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
                        // Upgrade requirement = 250
                        woodUpgradeRequirement = 200;
                        stoneUpgradeRequirement = 50;
                        break;

                    case 3:
                        // Upgrade requirement = 450
                        woodUpgradeRequirement = 300;
                        stoneUpgradeRequirement = 100;
                        oreUpgradeRequirement = 50;
                        break;

                    case 4:
                        // Upgrade requirement = 700
                        woodUpgradeRequirement = 400;
                        stoneUpgradeRequirement = 150;
                        oreUpgradeRequirement = 100;
                        steelUpgradeRequirement = 50;
                        break;
                }
                break;

            case 12:
                switch (buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 400
                        woodUpgradeRequirement = 100;
                        stoneUpgradeRequirement = 300;
                        break;

                    case 3:
                        // Upgrade requirement = 700
                        woodUpgradeRequirement = 150;
                        stoneUpgradeRequirement = 450;
                        oreUpgradeRequirement = 100;
                        break;

                    case 4:
                        // Upgrade requirement = 1100
                        woodUpgradeRequirement = 200;
                        stoneUpgradeRequirement = 600;
                        oreUpgradeRequirement = 200;
                        steelUpgradeRequirement = 100;
                        break;
                }
                break;

            case 13:
                switch (buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 600
                        woodUpgradeRequirement = 300;
                        stoneUpgradeRequirement = 200;
                        oreUpgradeRequirement = 100;
                        break;

                    case 3:
                        // Upgrade requirement = 950
                        woodUpgradeRequirement = 450;
                        stoneUpgradeRequirement = 300;
                        oreUpgradeRequirement = 150;
                        steelUpgradeRequirement = 50;
                        break;

                    case 4:
                        // Upgrade requirement = 1300
                        woodUpgradeRequirement = 600;
                        stoneUpgradeRequirement = 400;
                        oreUpgradeRequirement = 200;
                        steelUpgradeRequirement = 100;
                        break;
                }
                break;

            case 14:
                switch (buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 800
                        woodUpgradeRequirement = 300;
                        stoneUpgradeRequirement = 100;
                        oreUpgradeRequirement = 300;
                        steelUpgradeRequirement = 100;
                        break;

                    case 3:
                        // Upgrade requirement = 1200
                        woodUpgradeRequirement = 450;
                        stoneUpgradeRequirement = 150;
                        oreUpgradeRequirement = 450;
                        steelUpgradeRequirement = 150;
                        break;

                    case 4:
                        // Upgrade requirement = 1600
                        woodUpgradeRequirement = 600;
                        stoneUpgradeRequirement = 200;
                        oreUpgradeRequirement = 600;
                        steelUpgradeRequirement = 200;
                        break;
                }
                break;
        }
    }
}
