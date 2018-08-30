using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Buttons_Script : MonoBehaviour {

    public GameObject infoHub;

    public int setID;

    public int stoneNeeded;
    public int woodNeeded;
    public int oreNeeded;
    public int steelNeeded;

    void OnMouseUpAsButton()
    {
        // if()
        GetComponentInParent<Tile_Scripts>().buildingID = setID;
    }



    public void SpawnBuilding(int stoneNeeded, int woodNeeded, int steelNeeded)
    {

    }

    public void ForgeSteel(int woodNeeded, int oreNeeded)
    {
        if (infoHub.GetComponent<User_Interaction>().storedOre >= oreNeeded &&
                infoHub.GetComponent<User_Interaction>().storedWood >= woodNeeded)
        {

        }
    }
}
