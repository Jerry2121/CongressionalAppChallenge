using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildStructureButtonScript : MonoBehaviour {

    public GameObject GameManager;
    public GameObject SelectedTile;

    public int buildingID;

    public int woodNeeded;
    public int stoneNeeded;    
    public int oreNeeded;
    public int steelNeeded;

    public bool canBuildStructure;

    void Update()
    {
        if (GameManager.GetComponent<GameManagerScript>().stoneAcquired < stoneNeeded || GameManager.GetComponent<GameManagerScript>().woodAcquired < woodNeeded ||
            GameManager.GetComponent<GameManagerScript>().oreAcquired < oreNeeded || GameManager.GetComponent<GameManagerScript>().steelAcquired < steelNeeded)
        {
            canBuildStructure = false;
            GetComponent<Button>().interactable = false;
            return;
        }

        else if (GameManager.GetComponent<GameManagerScript>().selectedTile != null)
        {
            SelectedTile = GameManager.GetComponent<GameManagerScript>().selectedTile;

            switch (buildingID)
            {
                case 11:
                    if (GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y).GetComponent<Tile_Scripts>().spaceOccupied ||
                            GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied ||
                                GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied)
                    {
                        canBuildStructure = false;
                        return;
                    }

                    break;

                case 12:
                    if (GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y).GetComponent<Tile_Scripts>().spaceOccupied ||
                            GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied ||
                                GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied)
                    {
                        canBuildStructure = false;
                        return;
                    }

                    break;

                case 13:
                    if (GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y).GetComponent<Tile_Scripts>().spaceOccupied ||
                            GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied ||
                                GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied)
                    {
                        canBuildStructure = false;
                        return;
                    }

                    break;

                case 14:
                    if (GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + SelectedTile.transform.position.y).GetComponent<Tile_Scripts>().spaceOccupied ||
                            GameObject.Find("Tile(" + SelectedTile.transform.position.x + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied ||
                                GameObject.Find("Tile(" + (SelectedTile.transform.position.x + 1) + ", " + (SelectedTile.transform.position.y + 1)).GetComponent<Tile_Scripts>().spaceOccupied)
                    {
                        canBuildStructure = false;
                        return;
                    }

                    break;
            }

            canBuildStructure = true;
            GetComponent<Button>().interactable = true;
        }
    }

    public void SubtractResources()
    {
        GameManager.GetComponent<GameManagerScript>().stoneAcquired -= stoneNeeded;
        GameManager.GetComponent<GameManagerScript>().woodAcquired -= woodNeeded;
        GameManager.GetComponent<GameManagerScript>().oreAcquired -= oreNeeded;
        GameManager.GetComponent<GameManagerScript>().steelAcquired -= steelNeeded;
    }
}
