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
<<<<<<< HEAD
        Debug.Log(name);
        if (GameManager.GetComponent<GameManager>().stoneAcquired < stoneNeeded || GameManager.GetComponent<GameManager>().woodAcquired < woodNeeded ||
            GameManager.GetComponent<GameManager>().oreAcquired < oreNeeded || GameManager.GetComponent<GameManager>().steelAcquired < steelNeeded)
=======
        if (GameManager.GetComponent<GameManagerScript>().stoneAcquired < stoneNeeded || GameManager.GetComponent<GameManagerScript>().woodAcquired < woodNeeded ||
            GameManager.GetComponent<GameManagerScript>().oreAcquired < oreNeeded || GameManager.GetComponent<GameManagerScript>().steelAcquired < steelNeeded)
>>>>>>> 1456e3edd4bfb001b9bd2156e5f5e5861a24635c
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
