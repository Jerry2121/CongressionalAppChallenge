using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildStructureButtonScript : MonoBehaviour {

    public GameObject GameManager;

    public int stoneNeeded;
    public int woodNeeded;
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

        else
        {
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
