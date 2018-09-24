using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStructureMenu : MonoBehaviour {

    public GameObject GameManager;
    public List<GameObject> BuildingTypes;

    public GameObject buildStructureMenu;
    public GameObject upgradeStructureMenu;
    public GameObject structureTypeSelectMenu;
    public GameObject productionStructuresMenu;
    public GameObject villageStructureMenu;
    public GameObject attackStructureMenu;
    public GameObject defenseStructureMenu;
    public GameObject playerCheckMenu;

    public bool buildStructureMenuActive;

    public bool disableUpgradeMenu;

    public string actionType;
    public int buildStructureType;

    public void MenuHardFalse()
    {
        buildStructureMenu.SetActive(false);
    }

    public void MenuDisplayFunction()
    {
        Debug.Log("We're running the MenuDisplayFunction!");
        defenseStructureMenu.SetActive(false);
        attackStructureMenu.SetActive(false);
        villageStructureMenu.SetActive(false);
        productionStructuresMenu.SetActive(false);
        playerCheckMenu.SetActive(false);

        if (GameManager.GetComponent<GameManagerScript>().editMode == false)
        {
            buildStructureMenu.SetActive(false);
            return;
        }
        Debug.Log("Build structure = " + !buildStructureMenuActive + " and selected tile != null = " + (GameManager.GetComponent<GameManagerScript>().selectedTile != null));
        if (!buildStructureMenuActive && GameManager.GetComponent<GameManagerScript>().selectedTile != null)
        {
            buildStructureMenu.SetActive(true);
            structureTypeSelectMenu.SetActive(true);
            buildStructureMenuActive = true;

        }

        else if (buildStructureMenuActive)
        {
            buildStructureMenu.SetActive(false);
            buildStructureMenuActive = false;
        }

        if (disableUpgradeMenu)
        {
            upgradeStructureMenu.SetActive(false);
        }
    }

    public void UpgradeStructureFunction()
    {
        upgradeStructureMenu.SetActive(true);
        disableUpgradeMenu = true;
    }

    public void PlayerCheckCancel()
    {
        MenuHardFalse();
    }

    public void PlayerCheckFunction()
    {
        switch (actionType)
        {
            case "buildStructure":
                switch (buildStructureType)
                {
                    case 11:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[0], 11);
                        GameManager.GetComponent<GameManagerScript>().woodAcquired -= 5;
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 12:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[1], 12);
                        GameManager.GetComponent<GameManagerScript>().woodAcquired -= 10;
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 13:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[2], 13);
                        GameManager.GetComponent<GameManagerScript>().woodAcquired -= 15;
                        GameManager.GetComponent<GameManagerScript>().stoneAcquired -= 5;
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 14:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[3], 14);
                        GameManager.GetComponent<GameManagerScript>().woodAcquired -= 15;
                        GameManager.GetComponent<GameManagerScript>().stoneAcquired -= 5;
                        GameManager.GetComponent<GameManagerScript>().oreAcquired -= 10;
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 21:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[4], 21);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 22:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[5], 22);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 23:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[6], 23);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 24:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[7], 24);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 25:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[8], 25);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 26:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[9], 26);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 31:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[10], 31);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 32:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[11], 32);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 33:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[12], 33);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 34:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[13], 34);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 35:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[14], 35);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 41:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[15], 41);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 42:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[16], 42);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;

                    case 43:
                        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[17], 43);
                        MenuDisplayFunction();
                        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
                        break;
                }
                break;

            case "upgradeStructure":
                GameObject.Find("TilesBase").GetComponent<UpgradeStructureScript>().UpgradeBuilding();
                break;

            case "destroyStructure":
                GameObject.Find("TilesBase").GetComponent<DestroyStructureScript>().DestroyStructure();
                break;
        }
    
    }

    // int buttonType
    // 1 = OpenProductionStructuresMenu ; 2 = OpenVillageStructureMenu ; 3 = OpenAttackStructureMenu ; 4 = OpenDefenseStructureMenu
    // 11 = Quarry ; 12 = Sawmill ; 13 = Mine ; 14 = Forge
   public void MenuButtonClick(int buttonType)
    {
        Debug.Log("A build mode menu button has been pressed!");

        switch (buttonType)
        {
            // These are our initial building type buttons
            case 1:
                structureTypeSelectMenu.SetActive(false);
                productionStructuresMenu.SetActive(true);
                break;

            case 2:
                structureTypeSelectMenu.SetActive(false);
                villageStructureMenu.SetActive(true);
                break;

            case 3:
                structureTypeSelectMenu.SetActive(false);
                attackStructureMenu.SetActive(true);
                break;

            case 4:
                structureTypeSelectMenu.SetActive(false);
                defenseStructureMenu.SetActive(true);
                break;

            case 11:
                buildStructureType = 11;
                actionType = "buildStructure";
                productionStructuresMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 12:
                buildStructureType = 12;
                actionType = "buildStructure";
                productionStructuresMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 13:
                buildStructureType = 13;
                actionType = "buildStructure";
                productionStructuresMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 14:
                buildStructureType = 14;
                actionType = "buildStructure";
                productionStructuresMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 21:
                buildStructureType = 21;
                actionType = "buildStructure";
                villageStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 22:
                buildStructureType = 22;
                actionType = "buildStructure";
                villageStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 23:
                buildStructureType = 23;
                actionType = "buildStructure";
                villageStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 24:
                buildStructureType = 24;
                actionType = "buildStructure";
                villageStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 25:
                buildStructureType = 25;
                actionType = "buildStructure";
                villageStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 26:
                buildStructureType = 26;
                villageStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 31:
                buildStructureType = 31;
                actionType = "buildStructure";
                attackStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 32:
                buildStructureType = 32;
                actionType = "buildStructure";
                attackStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 33:
                buildStructureType = 33;
                actionType = "buildStructure";
                attackStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 34:
                buildStructureType = 34;
                actionType = "buildStructure";
                attackStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 35:
                buildStructureType = 35;
                actionType = "buildStructure";
                attackStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 41:
                buildStructureType = 41;
                actionType = "buildStructure";
                defenseStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 42:
                buildStructureType = 42;
                actionType = "buildStructure";
                defenseStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

            case 43:
                buildStructureType = 43;
                actionType = "buildStructure";
                defenseStructureMenu.SetActive(false);
                playerCheckMenu.SetActive(true);
                break;

                // These are our Village Type building buttons

        }
    }
}
