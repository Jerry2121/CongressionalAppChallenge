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

    public GameObject structureType;

    void Start()
    {
        infoHub = GetComponentInParent<Tile_Scripts>().infoHub;
    }

    void OnMouseUpAsButton()
    {
      GetComponentInParent<Tile_Scripts>().SpawnBuilding(structureType, stoneNeeded, woodNeeded, steelNeeded, setID);
    }
}
