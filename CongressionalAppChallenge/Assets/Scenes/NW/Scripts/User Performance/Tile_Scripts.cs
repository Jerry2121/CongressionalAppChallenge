using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Scripts : MonoBehaviour {

    public GameObject townHallPrefab;

    public GameObject GameManager;
    public Sprite EmptyTileIndicator;
    public GameObject childStructure;
    public Vector2 originalLocation;
    public bool spaceOccupied;

    // 1 = 1x1 tile occupation ; 2 = 2x2 tile occupation ; 
    public int sizeID;

    public GameObject tileButtonSet0;
    public GameObject tileButtonSet1;
    public GameObject tileButtonSet2;
    public GameObject tileButtonSet3;
    public GameObject tileButtonSet4;
    public GameObject tileButtonSet5;

    // Building IDs: 0 - Empty, 1 - Town Hall, 2 - Quarry, 3 - Sawmill, 4 - Mine, 5 - Forge, 
    public int buildingID;

    void Start()
    {
        originalLocation = gameObject.transform.position;
    }

    

    void Update()
    {
        ShowTilePlacement();
    }

    // This is for PC only, will have to create a different function for mobile
    void OnMouseUpAsButton()
    {
        if (spaceOccupied == true)
        {
            return;
        }
        if (GameManager.GetComponent<GameManager>().editMode == false)
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
                Debug.Log("This is an empty tile");
                temporaryUI = Instantiate(tileButtonSet0, GetComponentInParent<Transform>());
                temporaryUI.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y);
                temporaryUI.name = "temporaryUI";
                break;

            case 1:
                Debug.Log("This is an occupied tile; buildingType1");
                temporaryUI = Instantiate(tileButtonSet1, GetComponentInParent<Transform>());
                temporaryUI.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y);
                temporaryUI.name = "temporaryUI";
                break;

            case 2:
                Debug.Log("This is an occupied tile; buildingType2");
                temporaryUI = Instantiate(tileButtonSet2, GetComponentInParent<Transform>());
                temporaryUI.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y);
                temporaryUI.name = "temporaryUI";
                break;

            case 3:
                Debug.Log("This is an occupied tile; buildingType3");
                temporaryUI = Instantiate(tileButtonSet3, GetComponentInParent<Transform>());
                temporaryUI.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y);
                temporaryUI.name = "temporaryUI";
                break;

            case 4:
                Debug.Log("This is an occupied tile; buildingType4");
                temporaryUI = Instantiate(tileButtonSet4, GetComponentInParent<Transform>());
                temporaryUI.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y);
                temporaryUI.name = "temporaryUI";
                break;

            case 5:
                Debug.Log("This is an occupied tile; buildingType5");
                temporaryUI = Instantiate(tileButtonSet5, GetComponentInParent<Transform>());
                temporaryUI.transform.position = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y);
                temporaryUI.name = "temporaryUI";
                break;
        }
    }

    public void SpawnBuilding(GameObject structureType, int stoneConsumed, int woodConsumed, int steelConsumed, int setID)
    {
        Debug.Log("I PUSHED ANOTHER BUTTON");

        if (stoneConsumed < GameManager.GetComponent<GameManager>().stoneAcquired && woodConsumed < GameManager.GetComponent<GameManager>().woodAcquired &&
                steelConsumed < GameManager.GetComponent<GameManager>().steelAcquired)
        {
            GameManager.GetComponent<GameManager>().stoneAcquired -= stoneConsumed;
            GameManager.GetComponent<GameManager>().woodAcquired -= woodConsumed;
            GameManager.GetComponent<GameManager>().steelAcquired -= steelConsumed;

            Instantiate(structureType, GetComponentInParent<Transform>());

            buildingID = setID;

            Destroy(GameObject.Find("temporaryUI"));
        }

        else
        {

            return;
        }
    }

    public void SpawnTownHall()
    {

        Instantiate(townHallPrefab, GetComponent<Transform>());
        townHallPrefab.transform.position = new Vector3 (0.5f, 0.5f, 0);
        spaceOccupied = true;

        GameObject.Find("Tile(" + (originalLocation.x + 1) + ", " + originalLocation.y + ")").GetComponent<Tile_Scripts>().spaceOccupied = true;
        GameObject.Find("Tile(" + originalLocation.x + ", " + (originalLocation.y + 1) + ")").GetComponent<Tile_Scripts>().spaceOccupied = true;
        GameObject.Find("Tile(" + (originalLocation.x + 1) + ", " + (originalLocation.y + 1) + ")").GetComponent<Tile_Scripts>().spaceOccupied = true;
    }

    public void ShowTilePlacement()
    {
        if (GameManager.GetComponent<GameManager>().editMode == true && spaceOccupied == false)
        {
            GetComponent<SpriteRenderer>().sprite = EmptyTileIndicator;
        }
        else if (GameManager.GetComponent<GameManager>().editMode == false || spaceOccupied)
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }

        else
        {
            Debug.Log("Something's amiss here...");
        }
    }
}
