using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStructureScript : MonoBehaviour {

    public GameObject GameManager;
    public GameObject SelectedTile;
    public GameObject MenuCanvas;

    public bool upgradeAvailable;

    void Update()
    {

        UpgradeCheck();
    }

    public void UpgradeBuilding()
    {
        GameManager.GetComponent<GameManagerScript>().woodAcquired -= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().stoneAcquired -= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().oreAcquired -= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().steelAcquired -= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement;

        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().buildingLevel++;

        switch (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().buildingID)
        {
            case 11:
                switch (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 25
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 20;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 5;
                        break;

                    case 3:
                        // Upgrade requirement = 45
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 30;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 10;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 5;
                        break;

                    case 4:
                        // Upgrade requirement = 70
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 40;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 15;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 10;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 5;
                        break;
                }
                break;

            case 12:
                switch (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 40
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 10;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 30;
                        break;

                    case 3:
                        // Upgrade requirement = 70
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 15;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 45;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 10;
                        break;

                    case 4:
                        // Upgrade requirement = 110
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 20;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 60;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 20;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 10;
                        break;
                }
                break;

            case 13:
                switch (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 60
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 30;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 20;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 10;
                        break;

                    case 3:
                        // Upgrade requirement = 95
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 45;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 30;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 15;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 5;
                        break;

                    case 4:
                        // Upgrade requirement = 130
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 60;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 40;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 20;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 10;
                        break;
                }
                break;

            case 14:
                switch (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 80
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 30;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 10;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 30;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 10;
                        break;

                    case 3:
                        // Upgrade requirement = 120
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 45;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 15;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 45;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 15;
                        break;

                    case 4:
                        // Upgrade requirement = 160
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 60;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 20;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 60;
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 20;
                        break;
                }
                break;
        }

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

                if (GameManager.GetComponent<GameManagerScript>().woodAcquired >= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement &&
                        GameManager.GetComponent<GameManagerScript>().stoneAcquired >= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement &&
                            GameManager.GetComponent<GameManagerScript>().oreAcquired >= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement &&
                                GameManager.GetComponent<GameManagerScript>().steelAcquired >= GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement)
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
