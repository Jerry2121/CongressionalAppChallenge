using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour {

    public int y_size;
    public int x_size;
    bool townHallSpawned = false;
    public GameObject emptyTilePrefab;
    //public GameObject townHallParent;
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
                tilePrefab.transform.position = new Vector3(ix, iy, 0);
                tilePrefab.name = "Tile(" + ix + ", " + iy + ")";
                tilePrefab.tag = "EmptyTile";
                tilePrefab.GetComponent<Tile_Scripts>().infoHub = GameObject.Find("InfoHub");
                if (ix == 0 && iy == 0 && !townHallSpawned)
                {
                    tilePrefab.GetComponent<Tile_Scripts>().SpawnTownHall(ix, iy);
                    Debug.Log(tilePrefab.name);
                    townHallSpawned = true;
                }
            }
                        
        }
    }
}
