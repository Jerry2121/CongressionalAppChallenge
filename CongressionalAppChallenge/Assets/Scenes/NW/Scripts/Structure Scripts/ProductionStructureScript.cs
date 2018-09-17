using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionStructureScript : MonoBehaviour {

    public GameObject GameManager;
    public int resourceID;

    public float timer;
    public int buildingResourceProduction;
    public bool waveActive;

    void Start()
    {
        
    }

    void Update()
    {
        if (waveActive)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                switch (resourceID)
                {
                    case 1:
                        GameManager.GetComponent<GameManagerScript>().woodAcquired += buildingResourceProduction;
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
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
