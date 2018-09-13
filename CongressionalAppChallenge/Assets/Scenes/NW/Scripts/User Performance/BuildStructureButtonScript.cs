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
        if (GameManager.GetComponent<GameManager>().stoneAcquired < stoneNeeded || GameManager.GetComponent<GameManager>().woodAcquired < woodNeeded ||
            GameManager.GetComponent<GameManager>().oreAcquired < oreNeeded || GameManager.GetComponent<GameManager>().steelAcquired < steelNeeded)
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
        GameManager.GetComponent<GameManager>().stoneAcquired -= stoneNeeded;
        GameManager.GetComponent<GameManager>().woodAcquired -= woodNeeded;
        GameManager.GetComponent<GameManager>().oreAcquired -= oreNeeded;
        GameManager.GetComponent<GameManager>().steelAcquired -= steelNeeded;
    }
}
