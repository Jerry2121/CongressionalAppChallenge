using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public bool editMode;

    public GameObject selectedTile;

    public bool cancelTileInteraction;

    public GameObject menuCanvas;

    public GameObject editModeButton;
    public GameObject Hammer;
    public GameObject X;

    public int stoneAcquired;
    public int woodAcquired;
    public int oreAcquired;
    public int steelAcquired;

    void Start()
    {
        editMode = false;
        //editModeButton.GetComponent<TextMeshPro>().text = "Enter \n Edit mode";
    }

    public void CancelTileInteraction()
    {
        Debug.Log("Preparing to cancel tile interaction!");
        cancelTileInteraction = true;
    }

    public void EditModeButton()
    {
        //selectedTile = null;

        if (editMode == false)
        {
            editMode = true;
            //editModeButton.GetComponent<TextMeshPro>().text = "Exit \n Edit Mode";
            Hammer.SetActive(false);
            X.SetActive(true);
        }

        else if (editMode == true)
        {
            editMode = false;
            //editModeButton.GetComponent<TextMeshPro>().text = "Enter \n Edit Mode";
            Hammer.SetActive(true);
            X.SetActive(false);
            Destroy(GameObject.Find("temporaryUI"));
            menuCanvas.GetComponent<BuildStructureMenu>().MenuDisplayFunction();
        }
    }
    
}
