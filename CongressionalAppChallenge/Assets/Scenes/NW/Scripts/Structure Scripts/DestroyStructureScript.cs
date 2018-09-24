﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStructureScript : MonoBehaviour {

    public GameObject GameManager;
    public GameObject selectedStructure;

    public GameObject SelectedTile;
    public GameObject MenuCanvas;

    public void DestroyStructure()
    {
        selectedStructure = GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure;

        for (int i = 0; i < selectedStructure.GetComponent<BaseStructureScript>().parentTiles.Count; i++)
        {
            selectedStructure.GetComponent<BaseStructureScript>().parentTiles[i].GetComponent<Tile_Scripts>().buildingID = 0;
            selectedStructure.GetComponent<BaseStructureScript>().parentTiles[i].GetComponent<Tile_Scripts>().spaceOccupied = false;
        }

        GameManager.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().ShowTilePlacement();
        GameManager.GetComponent<GameManagerScript>().selectedTile = null;
        MenuCanvas.GetComponent<BuildStructureMenu>().upgradeStructureMenu.SetActive(false);

        GameManager.GetComponent<GameManagerScript>().woodAcquired += selectedStructure.GetComponent<BaseStructureScript>().woodReturned;
        GameManager.GetComponent<GameManagerScript>().stoneAcquired += selectedStructure.GetComponent<BaseStructureScript>().stoneReturned;
        GameManager.GetComponent<GameManagerScript>().oreAcquired += selectedStructure.GetComponent<BaseStructureScript>().oreReturned;
        GameManager.GetComponent<GameManagerScript>().steelAcquired += selectedStructure.GetComponent<BaseStructureScript>().steelReturned;

        Destroy(selectedStructure);
    }

}
