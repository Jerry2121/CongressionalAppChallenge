using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour {

    public int y_size;
    public int x_size;
    bool townHallSpawned = false;
    public GameObject emptyTilePrefab;

    public GameObject GameManager;
    public GameObject menuCanvas;

    public GameObject townHallParent;
    public Vector3 townHallParentLoc;

    public GameObject townHallPrefab;

    private void Start()
    {

        GetComponent<Transform>().position = new Vector3(- x_size / 2 + 0.5f, - y_size / 2 + 0.5f, 0);

        for (int iy = -y_size/2; iy < y_size/2; iy++)
        {
            for (int ix = -x_size/2; ix < x_size/2; ix++)
            {
                GameObject tilePrefab = 
                Instantiate(emptyTilePrefab, GetComponentInParent<Transform>());
                tilePrefab.transform.position = new Vector3(ix, iy, -5);
                tilePrefab.name = "Tile(" + ix + ", " + iy + ")";
                tilePrefab.tag = "EmptyTile";
                tilePrefab.GetComponent<Tile_Scripts>().GameManager = GameManager;
                tilePrefab.GetComponent<Tile_Scripts>().menuCanvas = menuCanvas;

                if (ix == 0 && iy == 0 && !townHallSpawned)
                {
                    townHallParent = tilePrefab;

                    townHallSpawned = true;
                }
            }
                        
        }

        townHallParent.GetComponent<Tile_Scripts>().SpawnTownHall();
        Debug.Log(townHallParent.name);

        menuCanvas.GetComponent<BuildStructureMenu>().MenuDisplayFunction();
    }
}
