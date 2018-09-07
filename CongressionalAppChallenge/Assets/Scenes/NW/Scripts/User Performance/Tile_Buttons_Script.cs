using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Buttons_Script : MonoBehaviour {

    public GameObject GameManager;

    public int actionType;

    public int setID;

    public int stoneNeeded;
    public int woodNeeded;
    public int oreNeeded;
    public int steelNeeded;

    public GameObject structureType;

    public GameObject BuildMenu;
    //Production
    public GameObject BuildMenuA;
    //Village
    public GameObject BuildMenuB;
    //Attack
    public GameObject BuildMenuC;
    //Defense
    public GameObject BuildMenuD;

    void Start()
    {
        GameManager = GetComponentInParent<Tile_Scripts>().GameManager;
    }

    void OnMouseUpAsButton()
    {
        if (actionType == 1)
        {
            BuildStructure();
        }

        else if (actionType == 2)
        {
            DestroyStructure();
        }

        else if (actionType == 3)
        {
            UpgradeStructure();
        }

        else if (actionType == 4)
        {
            
        }
    }

    public void OpenBuildMenu()
    {
        BuildMenu.SetActive(true);
    }

    public void BuildStructure()
    {
        GetComponentInParent<Tile_Scripts>().SpawnBuilding(structureType, stoneNeeded, woodNeeded, steelNeeded, setID);
    }

    public void DestroyStructure()
    {

    }

    public void UpgradeStructure()
    {

    }
}
