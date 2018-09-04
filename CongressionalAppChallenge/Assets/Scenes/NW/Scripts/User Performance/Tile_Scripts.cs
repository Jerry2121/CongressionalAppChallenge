﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Scripts : MonoBehaviour {

    public GameObject infoHub;
    public GameObject childSprite;

    public GameObject tileButtonSet0;
    public GameObject tileButtonSet1;
    public GameObject tileButtonSet2;
    public GameObject tileButtonSet3;
    public GameObject tileButtonSet4;
    public GameObject tileButtonSet5;

    // Building IDs: 0 - Empty, 1 - Town Hall, 2 - Quarry, 3 - Sawmill, 4 - Mine, 5 - Forge, 
    public int buildingID;

    void Update()
    {
        ShowTilePlacement();
    }

    // This is for PC only, will have to create a different function for mobile
    void OnMouseUpAsButton()
    {

        if (infoHub.GetComponent<Info_Hub>().editMode == false)
        {
            Debug.Log("editMode isn't active!");
            return;
        }
        
        GameObject temporaryUI;

        if (GameObject.Find("temporaryUI") == true)
        {
            Debug.Log("TemporaryUI found!");
            Destroy(GameObject.Find("temporaryUI"));
            return;
        }

        switch (buildingID)
        {   

            case 0:
                Debug.Log("I PRESSED THE BUTTON");
                temporaryUI = Instantiate(tileButtonSet0, GetComponentInParent<Transform>());
                temporaryUI.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y);
                temporaryUI.name = "temporaryUI";
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;
        }
    }

    public void SpawnBuilding(GameObject structureType, int stoneConsumed, int woodConsumed, int steelConsumed, int setID)
    {
        Debug.Log("I PUSHED ANOTHER BUTTON");

        if (stoneConsumed < infoHub.GetComponent<Info_Hub>().stoneAcquired && woodConsumed < infoHub.GetComponent<Info_Hub>().woodAcquired &&
                steelConsumed < infoHub.GetComponent<Info_Hub>().steelAcquired)
        {
            infoHub.GetComponent<Info_Hub>().stoneAcquired -= stoneConsumed;
            infoHub.GetComponent<Info_Hub>().woodAcquired -= woodConsumed;
            infoHub.GetComponent<Info_Hub>().steelAcquired -= steelConsumed;

            Instantiate(structureType, GetComponentInParent<Transform>());

            buildingID = setID;

            Destroy(GameObject.Find("temporaryUI"));
        }

        else
        {

            return;
        }
    }

    public void ShowTilePlacement()
    {
        if (infoHub.GetComponent<Info_Hub>().editMode == true)
        {
            childSprite.SetActive(true);
        }

        else if (infoHub.GetComponent<Info_Hub>().editMode == false)
        {
            childSprite.SetActive(false);
        }

        else
        {
            Debug.Log("Something's amiss here...");
        }
    }
}
