using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile_Scripts : MonoBehaviour {

    public GameObject infoHub;

    public GameObject tileButtonSet0;
    public GameObject tileButtonSet1;
    public GameObject tileButtonSet2;
    public GameObject tileButtonSet3;
    public GameObject tileButtonSet4;
    public GameObject tileButtonSet5;

    // Building IDs: 0 - Empty, 1 - Town Hall, 2 - Quarry, 3 - Sawmill, 4 - Mine, 5 - Forge, 
    public int buildingID;

    // This is for PC only, will have to create a different function for mobile
    void OnMouseUpAsButton()
    {
        Debug.Log(gameObject.transform.position);
        GameObject temporaryUI;


        switch (buildingID)
        {   

            case 0:
                temporaryUI = Instantiate(tileButtonSet0);
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

    
}
