using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile_Scripts : MonoBehaviour {

    public GameObject townHallPrefab;

    public GameObject menuCanvas;

    //public bool selectedTile;

    public GameObject GameManager;
    public Sprite EmptyTileIndicator;
    public GameObject childStructure;
    public Vector2 originalLocation;
    public bool spaceOccupied;
    //public bool clicked;

    // 1 = 1x1 tile occupation ; 2 = 2x2 tile occupation ; 
    public int sizeID;

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

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Aaron is veryvery smart");
            return;
        }

        if (GameManager.GetComponent<GameManager>().selectedTile == null)
        {
            GameManager.GetComponent<GameManager>().selectedTile = gameObject;
        }

        else if (GameManager.GetComponent<GameManager>().selectedTile != null)
        {
            GameManager.GetComponent<GameManager>().selectedTile = null;
            //This might break things
            menuCanvas.GetComponent<BuildStructureMenu>().MenuDisplayFunction();
            return;
        }

        if (GameManager.GetComponent<GameManager>().editMode == false)
        {
            Debug.Log("editMode isn't active!");
            return;
        }

        switch (buildingID)
        {

            case 0:
                Debug.Log("This is an empty tile");
                menuCanvas.GetComponent<BuildStructureMenu>().MenuDisplayFunction();
                break;

            case 11:
                Debug.Log("This is an occupied tile; buildingType = ID-11, Quarry");
                menuCanvas.GetComponent<BuildStructureMenu>().UpgradeStructureFunction();
                break;

            case 12:
                Debug.Log("This is an occupied tile; buildingType = ID-12, Sawmill");
                menuCanvas.GetComponent<BuildStructureMenu>().UpgradeStructureFunction();
                break;

            case 13:
                Debug.Log("This is an occupied tile; buildingType = ID-13, Mine");
                menuCanvas.GetComponent<BuildStructureMenu>().UpgradeStructureFunction();
                break;

            case 14:
                Debug.Log("This is an occupied tile; buildingType = ID-14, Forge");
                menuCanvas.GetComponent<BuildStructureMenu>().UpgradeStructureFunction();
                break;

            case -1:
                Debug.Log("This is your town hall");
                menuCanvas.GetComponent<BuildStructureMenu>().MenuHardFalse();
                break;
        }
    }

    public void SpawnTownHall()
    {

        Instantiate(townHallPrefab, GetComponent<Transform>());
        townHallPrefab.transform.position = new Vector3 (0.5f, 0.5f, 0);
        spaceOccupied = true;
        buildingID = -1;

        GameObject tempTile;
        tempTile = GameObject.Find("Tile(" + (originalLocation.x + 1) + ", " + originalLocation.y + ")");
        tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
        tempTile.GetComponent<Tile_Scripts>().buildingID = -1;

        tempTile = GameObject.Find("Tile(" + originalLocation.x + ", " + (originalLocation.y + 1) + ")");
        tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
        tempTile.GetComponent<Tile_Scripts>().buildingID = -1;

        tempTile = GameObject.Find("Tile(" + (originalLocation.x + 1) + ", " + (originalLocation.y + 1) + ")");
        tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
        tempTile.GetComponent<Tile_Scripts>().buildingID = -1;
    }

    public void SpawnBuilding(GameObject buildingType, int recievedBuildingID)
    {
        Instantiate(buildingType, GetComponent<Transform>());
        buildingType.transform.position = new Vector3(0, 0, 5);
        spaceOccupied = true;
        buildingID = recievedBuildingID;
    }

    public void ShowTilePlacement()
    {        
        if (GameManager.GetComponent<GameManager>().selectedTile != null)
        {
            GetComponent<SpriteRenderer>().sprite = null;
            if (GameManager.GetComponent<GameManager>().selectedTile == gameObject && !spaceOccupied)
            {
                GetComponent<SpriteRenderer>().sprite = EmptyTileIndicator;
            }
            return;
        }
        

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
