using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStructureMenu : MonoBehaviour {

    public GameObject GameManager;
    public List<GameObject> BuildingTypes;

    public GameObject buildStructureMenu;
    public GameObject structureTypeSelectMenu;
    public GameObject productionStructuresMenu;
    public GameObject villageStructureMenu;
    public GameObject attackStructureMenu;
    public GameObject defenseStructureMenu;

    public bool buildStructureMenuActive;

    public void MenuHardFalse()
    {
        buildStructureMenu.SetActive(false);
    }

    public void MenuDisplayFunction()
    {
        defenseStructureMenu.SetActive(false);
        attackStructureMenu.SetActive(false);
        villageStructureMenu.SetActive(false);
        productionStructuresMenu.SetActive(false);

        if (GameManager.GetComponent<GameManager>().editMode == false)
        {
            buildStructureMenu.SetActive(false);
            return;
        }

        if (!buildStructureMenuActive)
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
    }

    // int buttonType
    // 1 = OpenProductionStructuresMenu ; 2 = OpenVillageStructureMenu ; 3 = OpenAttackStructureMenu ; 4 = OpenDefenseStructureMenu
    // 11 = BT1.v1 ; 12 = BT1.v2 ; 13 = BT1.v3 ; 14 = BT1.v4 ; 15 = BT1,v5 ; 16 = BT1.v6
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

            // These are our Village Type building buttons
            case 11:
                GameManager.GetComponent<GameManager>().selectedTile.GetComponent<Tile_Scripts>().SpawnBuilding(BuildingTypes[0]);
                break;

            case 12:
                break;

            case 13:
                break;

            case 14:
                break;

            case 15:
                break;

            case 16:
                break;
        }
    }
}
