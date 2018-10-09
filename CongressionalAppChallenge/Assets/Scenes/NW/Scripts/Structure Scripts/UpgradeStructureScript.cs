using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeStructureScript : MonoBehaviour {

    public GameObject GameManager;
    public GameObject selectedStructure;

    public GameObject SelectedTile;
    public GameObject MenuCanvas;

    public GameObject WoodRequirement;
    public GameObject StoneRequirement;
    public GameObject OreRequirement;
    public GameObject SteelRequirement;

    public GameObject WoodReturned;
    public GameObject StoneReturned;
    public GameObject OreReturned;
    public GameObject SteelReturned;

    public bool upgradeAvailable;

    void Update()
    {
        UpgradeCheck();
        //Upgrade Requirements and updates the text for it.
        if (GameManager.GetComponent<GameManagerScript>().selectedTile != null && GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure != null)
        {
            if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement > 0)
            {
                WoodRequirement.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement + " Wood";
                StoneRequirement.SetActive(false);
                OreRequirement.SetActive(false);
                SteelRequirement.SetActive(false);
                if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement > 0)
                {
                    StoneRequirement.SetActive(true);
                    StoneRequirement.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement + " Stone";
                    OreRequirement.SetActive(false);
                    SteelRequirement.SetActive(false);
                    if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement > 0)
                    {
                        OreRequirement.SetActive(true);
                        OreRequirement.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement + " Ore";
                        SteelRequirement.SetActive(false);
                        if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement > 0)
                        {
                            SteelRequirement.SetActive(true);
                            SteelRequirement.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement + " Steel";
                        }
                    }
                }
            }
        }
        //Returned Materials from Destoryed Structures if player decides to destory a building.
        if (GameManager.GetComponent<GameManagerScript>().selectedTile != null && GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure != null)
        {
            if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodReturned > 0)
            {
                WoodReturned.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().woodReturned + " Wood";
                StoneReturned.SetActive(false);
                OreReturned.SetActive(false);
                SteelReturned.SetActive(false);
                if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneReturned > 0)
                {
                    StoneReturned.SetActive(true);
                    StoneReturned.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().stoneReturned + " Stone";
                    OreReturned.SetActive(false);
                    SteelReturned.SetActive(false);
                    if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreReturned > 0)
                    {
                        OreReturned.SetActive(true);
                        OreReturned.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().oreReturned + " Ore";
                        SteelReturned.SetActive(false);
                        if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelReturned > 0)
                        {
                            SteelReturned.SetActive(true);
                            SteelReturned.GetComponent<TextMeshProUGUI>().text = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<BaseStructureScript>().steelReturned + " Steel";
                        }
                    }
                }
            }
        }
    }

    public void PlayerCheckFunction()
    {
        MenuCanvas.GetComponent<BuildStructureMenu>().upgradeStructureMenu.SetActive(false);
        MenuCanvas.GetComponent<BuildStructureMenu>().playerCheckMenu.SetActive(true);
        MenuCanvas.GetComponent<BuildStructureMenu>().buildStructureMenu.SetActive(false);
        MenuCanvas.GetComponent<BuildStructureMenu>().actionType = "upgradeStructure";
    }

    public void UpgradeBuilding()
    {
        SelectedTile = GameManager.GetComponent<GameManagerScript>().selectedTile;
        selectedStructure = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure;

        GameManager.GetComponent<GameManagerScript>().woodAcquired -= selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().stoneAcquired -= selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().oreAcquired -= selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement;
        GameManager.GetComponent<GameManagerScript>().steelAcquired -= selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement;

        selectedStructure.GetComponent<BaseStructureScript>().buildingLevel++;

        switch (selectedStructure.GetComponent<BaseStructureScript>().buildingID)
        {
            case 11:
                for (int i = 0; i < selectedStructure.GetComponent<BaseStructureScript>().parentTiles.Count; i++)
                {
                    selectedStructure.GetComponent<BaseStructureScript>().parentTiles[i].GetComponent<Tile_Scripts>().staticPriorityValue += 10;
                }

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
                for (int i = 0; i < selectedStructure.GetComponent<BaseStructureScript>().parentTiles.Count; i++)
                {
                    selectedStructure.GetComponent<BaseStructureScript>().parentTiles[i].GetComponent<Tile_Scripts>().staticPriorityValue += 8;
                }

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
                for (int i = 0; i < selectedStructure.GetComponent<BaseStructureScript>().parentTiles.Count; i++)
                {
                    selectedStructure.GetComponent<BaseStructureScript>().parentTiles[i].GetComponent<Tile_Scripts>().staticPriorityValue += 6;
                }

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
                SelectedTile.GetComponent<Tile_Scripts>().staticPriorityValue += 4;

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
                //Village
            case 21:
                SelectedTile.GetComponent<Tile_Scripts>().staticPriorityValue += 5;

                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 100
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 70;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 30;
                        break;

                    case 3:
                        // Upgrade requirement = 175
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 115;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 45;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 15;
                        break;

                    case 4:
                        // Upgrade requirement = 255
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 150;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 30;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 15;
                        break;
                }
                
                break;
                //Attack Tower 1
            case 31:
                SelectedTile.GetComponent<Tile_Scripts>().staticPriorityValue += 15;

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
            case 32:
                SelectedTile.GetComponent<Tile_Scripts>().staticPriorityValue += 20;
                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 100
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 35;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 45;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 15;
                        break;

                    case 3:
                        // Upgrade requirement = 170
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 90;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 100;
                        break;

                    case 4:
                        // Upgrade requirement = 265
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 130;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 160;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 120;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 30;
                        break;
                }
                break;

            case 41:
                SelectedTile.GetComponent<Tile_Scripts>().staticPriorityValue -= 10;
                switch (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel)
                {
                    case 2:
                        // Upgrade requirement = 100
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 10;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 36;
                        break;

                    case 3:
                        // Upgrade requirement = 170
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 15;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 48;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 10;
                        break;

                    case 4:
                        // Upgrade requirement = 265
                        selectedStructure.GetComponent<BaseStructureScript>().woodUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().stoneUpgradeRequirement = 60;
                        selectedStructure.GetComponent<BaseStructureScript>().oreUpgradeRequirement = 20;
                        selectedStructure.GetComponent<BaseStructureScript>().steelUpgradeRequirement = 15;
                        break;
                }
                break;
        }

        selectedStructure.GetComponent<BaseStructureScript>().BuildingLevelAnalysis();

        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().ShowTilePlacement();
        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
        MenuCanvas.GetComponent<BuildStructureMenu>().playerCheckMenu.SetActive(false);
        MenuCanvas.GetComponent<BuildStructureMenu>().upgradeStructureMenu.SetActive(false);
    }

    void UpgradeCheck()
    {
        if (GameManager.GetComponent<GameManagerScript>().selectedTile != null)
        {
            if (GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure != null)
            {
                selectedStructure = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure;

                if (selectedStructure.GetComponent<BaseStructureScript>().buildingLevel > selectedStructure.GetComponent<BaseStructureScript>().maxBuildingLevel)
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
