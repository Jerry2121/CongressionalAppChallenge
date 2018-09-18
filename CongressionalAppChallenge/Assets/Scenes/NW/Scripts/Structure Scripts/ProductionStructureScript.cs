using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionStructureScript : MonoBehaviour {

    public GameObject GameManager;

    public int resourceID;
    public int buildingResourceProduction;

    public float timer;
    
    public bool waveActive;

    void Update()
    {
        if (waveActive)
        {   
            timer += Time.deltaTime;
            GameManager = GetComponent<BaseStructureScript>().GameManager;
            if (timer >= 1.0f)
            {
                switch (resourceID)
                {
                    case 1:
                        GameManager.GetComponent<GameManagerScript>().woodAcquired += buildingResourceProduction;
                        break;

                    case 2:
                        GameManager.GetComponent<GameManagerScript>().stoneAcquired += buildingResourceProduction;
                        break;

                    case 3:
                        GameManager.GetComponent<GameManagerScript>().oreAcquired += buildingResourceProduction;
                        break;

                    case 4:
                        GameManager.GetComponent<GameManagerScript>().steelAcquired += buildingResourceProduction;

                        break;
                }
                timer -= 1.0f;
            }
        }
        
        else
        {
            return;
        }

    }

    // if (waveActive){  }
}
