using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStructureMenu : MonoBehaviour {

    public GameObject GameManager;

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
   /* public void MenuButtonClick(int buttonType)
    {
        Debug.Log("A build mode menu button has been pressed!");

        switch (buttonType)
        {
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
        }
    }*/
}
