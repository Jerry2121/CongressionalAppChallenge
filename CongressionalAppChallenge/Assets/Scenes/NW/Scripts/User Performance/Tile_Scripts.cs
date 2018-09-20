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
    private int rancode;
    //public bool clicked;

    // 1 = 1x1 tile occupation ; 2 = 2x2 tile occupation ; 
    public int sizeID;

    // Building IDs: 0 - Empty, 1 - Town Hall, 2 - Quarry, 3 - Sawmill, 4 - Mine, 5 - Forge, 
    public int buildingID;

    void Start()
    {
        rancode = 0;
        originalLocation = gameObject.transform.position;
        ShowTilePlacement();
    }



    void Update()
    {
        if (GameManager.GetComponent<GameManagerScript>().editMode)
        {
            ShowTilePlacement();
            rancode = 1;
        }
        else if (!GameManager.GetComponent<GameManagerScript>().editMode && rancode == 1)
        {
            GetComponent<SpriteRenderer>().sprite = null;
            GameManager.GetComponent<GameManagerScript>().selectedTile = null;
            menuCanvas.GetComponent<BuildStructureMenu>().buildStructureMenuActive = false;
            rancode = 0;
        }
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() || IsPointerOverUIObject())
        {
            Debug.Log("Aaron is veryvery smart");
            return;
        }
        if (GameManager.GetComponent<GameManagerScript>().editMode == false)
        {
            Debug.Log("editMode isn't active!");
            return;
        }

        if (GameManager.GetComponent<GameManagerScript>().selectedTile == null)
        {
            GameManager.GetComponent<GameManagerScript>().selectedTile = gameObject;
        }

        else if (GameManager.GetComponent<GameManagerScript>().selectedTile != null)
        {
            GameManager.GetComponent<GameManagerScript>().selectedTile = null;
            //This might break things
            menuCanvas.GetComponent<BuildStructureMenu>().MenuDisplayFunction();
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

        GameObject TownHall = Instantiate(townHallPrefab, GetComponent<Transform>());
        spaceOccupied = true;
        buildingID = -1;
        childStructure = TownHall;

        GameObject tempTile;
        tempTile = GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + gameObject.transform.position.y + ")");
        tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
        tempTile.GetComponent<Tile_Scripts>().buildingID = -1;
        tempTile.GetComponent<Tile_Scripts>().childStructure = TownHall;

        tempTile = GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + (gameObject.transform.position.y + 1) + ")");
        tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
        tempTile.GetComponent<Tile_Scripts>().buildingID = -1;
        tempTile.GetComponent<Tile_Scripts>().childStructure = TownHall;

        tempTile = GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + (gameObject.transform.position.y + 1) + ")");
        tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
        tempTile.GetComponent<Tile_Scripts>().buildingID = -1;
        tempTile.GetComponent<Tile_Scripts>().childStructure = TownHall;
    }

    public void SpawnBuilding(GameObject buildingType, int recievedBuildingID)
    {
        GameObject structure = Instantiate(buildingType, GetComponent<Transform>());
        childStructure = structure;
        spaceOccupied = true;
        buildingID = recievedBuildingID;

        GameObject tempTile;
        GameObject SelectedTile = GameManager.GetComponent<GameManagerScript>().selectedTile;
        switch (buildingID)
        {
            case 11:
                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 11;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 11;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 11;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                break;

            case 12:
                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 12;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 12;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 12;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                break;

            case 13:
                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 13;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 13;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 13;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                // structure.GetComponent<Transform>().position = new Vector2(0.5f, 0.5f);

                break;

            case 14:
                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 14;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 14;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                tempTile = GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1) + ")");
                tempTile.GetComponent<Tile_Scripts>().spaceOccupied = true;
                tempTile.GetComponent<Tile_Scripts>().buildingID = 14;
                tempTile.GetComponent<Tile_Scripts>().childStructure = structure;

                // structure.GetComponent<Transform>().position = new Vector2(0.5f, 0.5f);

                break;
        }
    }

    public void ShowTilePlacement()
    {        
        if (GameManager.GetComponent<GameManagerScript>().selectedTile != null)
        {
           // Debug.Log("1st If Ran");
            GetComponent<SpriteRenderer>().sprite = null;
            if (GameManager.GetComponent<GameManagerScript>().selectedTile == gameObject && !spaceOccupied)
            {
               // Debug.Log("2nd If Ran");
                GetComponent<SpriteRenderer>().sprite = EmptyTileIndicator;
            }
            return;
        }
        

        if (GameManager.GetComponent<GameManagerScript>().editMode == true && spaceOccupied == false)
        {
            //Debug.Log("1st/2nd If Ran");
            GetComponent<SpriteRenderer>().sprite = EmptyTileIndicator;
        }
        else if (GameManager.GetComponent<GameManagerScript>().editMode == false || spaceOccupied)
        {
            //Debug.Log("2nd/2nd If Ran");
            GetComponent<SpriteRenderer>().sprite = null;

        }

        else
        {
            Debug.Log("Something's amiss here...");
        }
    }
}
