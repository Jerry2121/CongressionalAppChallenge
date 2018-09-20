using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionStructureScript : MonoBehaviour {

    public GameObject GameManager;

    public int resourceID;
    public int buildingResourceProduction;


    public float timer;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if ( GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft > 0)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                switch (resourceID)
                {
                    case 1:
                        if (GameManager.GetComponent<GameManagerScript>().woodAcquired >= 999)
                        {
                            GameManager.GetComponent<GameManagerScript>().woodAcquired = 999;
                            return;
                        }
                        GameManager.GetComponent<GameManagerScript>().woodAcquired += buildingResourceProduction;
                        break;

                    case 2:
                        if (GameManager.GetComponent<GameManagerScript>().stoneAcquired >= 999)
                        {
                            GameManager.GetComponent<GameManagerScript>().stoneAcquired = 999;
                            return;
                        }
                        GameManager.GetComponent<GameManagerScript>().stoneAcquired += buildingResourceProduction;
                        break;

                    case 3:
                        if (GameManager.GetComponent<GameManagerScript>().oreAcquired >= 999)
                        {
                            GameManager.GetComponent<GameManagerScript>().oreAcquired = 999;
                            return;
                        }
                        GameManager.GetComponent<GameManagerScript>().oreAcquired += buildingResourceProduction;
                        break;

                    case 4:
                        if (GameManager.GetComponent<GameManagerScript>().steelAcquired >= 999)
                        {
                            GameManager.GetComponent<GameManagerScript>().steelAcquired = 999;
                            return;
                        }
                        GameManager.GetComponent<GameManagerScript>().steelAcquired += buildingResourceProduction;
                        break;
                }
                timer -= 1.0f;
            }
        }
    }
}
