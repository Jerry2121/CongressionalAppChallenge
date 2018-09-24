using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStructureScript : MonoBehaviour {

    public GameObject GameManager;
    public GameObject selectedStructure;

    public GameObject SelectedTile;
    public GameObject MenuCanvas;

    public bool upgradeAvailable;

    void Update()
    {
        UpgradeCheck();
    }

    public void UpgradeBuilding()
    {
        selectedStructure = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure;

        GameManager.GetComponent<GameManagerScript>().woodAcquired -= selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().stoneAcquired -= selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().oreAcquired -= selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().steelAcquired -= selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement;

        selectedStructure.GetComponent<BaseStructureScript>().buildingLevel++;
        Debug.Log(selectedStructure.GetComponent<BaseStructureScript>().buildingLevel);

        switch (selectedStructure.GetComponent<BaseStructureScript>().buildingID)
        {
            case 11:
                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 25
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 5;
                        break;

                    case 3:
                        // Upgrade requirement = 45
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 30;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 10;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 5;
                        break;

                    case 4:
                        // Upgrade requirement = 70
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 40;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 15;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 10;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 5;
                        break;
                }
                break;

            case 12:
                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 40
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 10;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 30;
                        break;

                    case 3:
                        // Upgrade requirement = 70
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 15;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 45;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 10;
                        break;

                    case 4:
                        // Upgrade requirement = 110
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 10;
                        break;
                }
                break;

            case 13:
                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 60
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 30;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 10;
                        break;

                    case 3:
                        // Upgrade requirement = 95
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 45;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 30;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 15;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 5;
                        break;

                    case 4:
                        // Upgrade requirement = 130
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 40;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 10;
                        break;
                }
                break;

            case 14:
                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 80
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 30;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 10;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 30;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 10;
                        break;

                    case 3:
                        // Upgrade requirement = 120
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 45;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 15;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 45;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 15;
                        break;

                    case 4:
                        // Upgrade requirement = 160
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 20;
                        break;
                }
                break;

            case 31:
                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 100
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 30;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 70;
                        break;

                    case 3:
                        // Upgrade requirement = 170
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 45;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 105;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 20;
                        break;

                    case 4:
                        // Upgrade requirement = 265
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 140;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 40;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 25;
                        break;
                }
                break;
        }

        selectedStructure.GetComponent<BaseStructureScript>().BuildingLevelAnalysis();

        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().ShowTilePlacement();
        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
        MenuCanvas.GetComponent<BuildStructureMenu>().upgradeStructureMenu.SetActive(false);
    }

    void UpgradeCheck()
    {
        if (GameManager.GetComponent<GameManagerScript>().selectedTile != null)
        {

            if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure != null)
            {
                selectedStructure = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure;

                if (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel > 4)
                {
                    upgradeAvailable = false;
                }

                else if (GameManager.GetComponent<GameManagerScript>().woodAcquired >= selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement &&
                        GameManager.GetComponent<GameManagerScript>().stoneAcquired >= selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement &&
                            GameManager.GetComponent<GameManagerScript>().oreAcquired >= selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement &&
                                GameManager.GetComponent<GameManagerScript>().steelAcquired >= selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement)
                {
                    upgradeAvailable = true;
                }

                else
                {
                    upgradeAvailable = false;
                }
            }
        }
    }
}
