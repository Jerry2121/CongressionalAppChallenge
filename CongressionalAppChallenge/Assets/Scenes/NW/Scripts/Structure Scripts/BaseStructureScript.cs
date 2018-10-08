using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStructureScript : MonoBehaviour {

    public GameObject GameManager;

    public int hpMax;
    public int hp;

    public int buildingLevel;
    public int buildingID;

    public int woodReturned;
    public int stoneReturned;
    public int oreReturned;
    public int steelReturned;

    public int woodUpgradeRequirement;
    public int stoneUpgradeRequirement;
    public int oreUpgradeRequirement;
    public int steelUpgradeRequirement;

    public bool upgradeAvailable;

    public List<GameObject> parentTiles;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");

        buildingLevel = 1;
        woodUpgradeRequirement = 0;
        stoneUpgradeRequirement = 0;
        oreUpgradeRequirement = 0;
        steelUpgradeRequirement = 0;

        switch (buildingID)
        {
            case 11:
                GetComponent<ProductionStructureScript>().resourceID = 1;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 10
                woodUpgradeRequirement = 10;

                BuildingLevelAnalysis();

                parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + gameObject.transform.position.y + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + (gameObject.transform.position.y + 1) + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + (gameObject.transform.position.y + 1) + ")"));

                break;

            case 12:
                GetComponent<ProductionStructureScript>().resourceID = 2;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 20
                woodUpgradeRequirement = 5;
                stoneUpgradeRequirement = 15;

                BuildingLevelAnalysis();

                parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + gameObject.transform.position.y + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + (gameObject.transform.position.y + 1) + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + (gameObject.transform.position.y + 1) + ")"));

                break;

            case 13:
                GetComponent<ProductionStructureScript>().resourceID = 3;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 30
                woodUpgradeRequirement = 15;
                stoneUpgradeRequirement = 10;
                oreUpgradeRequirement = 5;

                BuildingLevelAnalysis();

                parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + gameObject.transform.position.y + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + (gameObject.transform.position.y + 1) + ")"));
                parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + (gameObject.transform.position.y + 1) + ")"));

                break;

            case 14:
                GetComponent<ProductionStructureScript>().resourceID = 4;
                GetComponent<ProductionStructureScript>().buildingResourceProduction = 1;
                // Upgrade requirement = 40
                woodUpgradeRequirement = 15;
                stoneUpgradeRequirement = 5;
                oreUpgradeRequirement = 15;
                steelUpgradeRequirement = 5;

                BuildingLevelAnalysis();

                parentTiles.Add(gameObject);

                break;

            case 21:

                // Upgrade requirement = 50;
                woodUpgradeRequirement = 35;
                stoneUpgradeRequirement = 15;

                BuildingLevelAnalysis();

                parentTiles.Add(gameObject);

                break;

            case 31:
                // There will be a couple of 'GetComponent's here to grab tower properties like damage

                // Upgrade requirement = 50;
                woodUpgradeRequirement = 15;
                stoneUpgradeRequirement = 35;

                BuildingLevelAnalysis();

                parentTiles.Add(gameObject);

                break;
            case 32:
                // There will be a couple of 'GetComponent's here to grab tower properties like damage

                // Upgrade requirement = 50;
                woodUpgradeRequirement = 25;
                stoneUpgradeRequirement = 35;
                oreUpgradeRequirement = 13;

                BuildingLevelAnalysis();

                parentTiles.Add(gameObject);
                break;

            case 41:

                // Upgrade requirement = 29;
                woodUpgradeRequirement = 5;
                stoneUpgradeRequirement = 24;

                BuildingLevelAnalysis();

                parentTiles.Add(gameObject);

                break;
        }
    }

    public void BuildingLevelAnalysis()
    {
        switch (buildingID)
        {
            case 11:
                switch (buildingLevel)
                {
                    case 1:
                        woodReturned += 3;
                        break;

                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        woodReturned += 5;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        woodReturned += 10;
                        stoneReturned += 3;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        woodReturned += 15;
                        stoneReturned += 5;
                        oreReturned += 3;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        woodReturned += 20;
                        stoneReturned += 8;
                        oreReturned += 5;
                        steelReturned += 3;
                        break;
                }
                break;

            case 12:
                switch (buildingLevel)
                {
                    case 1:
                        woodReturned += 5;
                        break;

                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        woodReturned += 3;
                        stoneReturned += 8;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        woodReturned += 5;
                        woodReturned += 15;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        woodReturned += 8;
                        stoneReturned += 23;
                        oreReturned += 5;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        woodReturned += 10;
                        stoneReturned += 30;
                        oreReturned += 10;
                        steelReturned += 5;
                        break;
                }
                break;

            case 13:
                switch (buildingLevel)
                {
                    case 1:
                        woodReturned += 8;
                        stoneReturned += 3;
                        break;

                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        woodReturned += 8;
                        stoneReturned += 5;
                        oreReturned += 3;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        woodReturned += 15;
                        stoneReturned += 10;
                        oreReturned += 5;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        woodReturned += 23;
                        stoneReturned += 15;
                        oreReturned += 8;
                        steelReturned += 3;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        woodReturned += 30;
                        stoneReturned += 20;
                        oreReturned += 10;
                        steelReturned += 5;
                        break;
                }
                break;

            case 14:
                switch (buildingLevel)
                {
                    case 1:
                        woodReturned += 8;
                        stoneReturned += 3;
                        oreReturned += 5;
                        break;

                    case 2:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 2;
                        woodReturned += 8;
                        stoneReturned += 3;
                        oreReturned += 8;
                        steelReturned += 3;
                        break;

                    case 3:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 3;
                        woodReturned += 15;
                        stoneReturned += 5;
                        oreReturned += 15;
                        steelReturned += 5;
                        break;

                    case 4:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 4;
                        woodReturned += 23;
                        stoneReturned += 8;
                        oreReturned += 23;
                        steelReturned += 8;
                        break;

                    case 5:
                        GetComponent<ProductionStructureScript>().buildingResourceProduction = 5;
                        woodReturned += 30;
                        stoneReturned += 10;
                        oreReturned += 30;
                        steelReturned += 10;
                        break;
                }
                break;
        }
    }
}
