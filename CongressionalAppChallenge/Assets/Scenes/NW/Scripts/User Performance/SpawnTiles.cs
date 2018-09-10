using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour {

    public int y_size;
    public int x_size;
    bool townHallSpawned = false;
    public GameObject emptyTilePrefab;

    public GameObject buildMenu;
    public GameObject structureTypeSelectMenu;
    public GameObject productionStructuresMenu;
    public GameObject villageStructureMenu;
    public GameObject attackStructureMenu;
    public GameObject defenseStructureMenu;

    public GameObject townHallParent;
    public Vector3 townHallParentLoc;

    public GameObject townHallPrefab;

    private void Start()
    {
        buildMenu = GameObject.Find("BuildStructureMenu");
        structureTypeSelectMenu = GameObject.Find("StructureTypeSelect");
        productionStructuresMenu = GameObject.Find("ProductionStructures");
        villageStructureMenu = GameObject.Find("VillageStructures");
        attackStructureMenu = GameObject.Find("AttackStructures");
        defenseStructureMenu = GameObject.Find("DefenseStructures");

        GetComponent<Transform>().position = new Vector3(- x_size / 2 + 0.5f, - y_size / 2 + 0.5f, 0);

        for (int iy = -y_size/2; iy < y_size/2; iy++)
        {
            for (int ix = -x_size/2; ix < x_size/2; ix++)
            {
                GameObject tilePrefab = 
                Instantiate(emptyTilePrefab, GetComponentInParent<Transform>());
                tilePrefab.transform.position = new Vector3(ix, iy, 0);
                tilePrefab.name = "Tile(" + ix + ", " + iy + ")";
                tilePrefab.tag = "EmptyTile";
                tilePrefab.GetComponent<Tile_Scripts>().GameManager = GameObject.Find("GameManager");

                tilePrefab.GetComponent<Tile_Scripts>().buildMenu = buildMenu;
                tilePrefab.GetComponent<Tile_Scripts>().structureTypeSelectMenu = structureTypeSelectMenu;
                tilePrefab.GetComponent<Tile_Scripts>().productionStructuresMenu = productionStructuresMenu;
                tilePrefab.GetComponent<Tile_Scripts>().villageStructureMenu = villageStructureMenu;
                tilePrefab.GetComponent<Tile_Scripts>().attackStructureMenu = attackStructureMenu;
                tilePrefab.GetComponent<Tile_Scripts>().defenseStructureMenu = defenseStructureMenu;

                if (ix == 0 && iy == 0 && !townHallSpawned)
                {
                    townHallParent = tilePrefab;

                    townHallSpawned = true;
                }
            }
                        
        }

        townHallParent.GetComponent<Tile_Scripts>().SpawnTownHall();
        Debug.Log(townHallParent.name);

        defenseStructureMenu.SetActive(false);
        attackStructureMenu.SetActive(false);
        villageStructureMenu.SetActive(false);
        productionStructuresMenu.SetActive(false);
        structureTypeSelectMenu.SetActive(false);
        buildMenu.SetActive(false);
    }
}
