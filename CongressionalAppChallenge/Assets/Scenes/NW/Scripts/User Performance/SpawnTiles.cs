using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour {

    public int y_size;
    public int x_size;

    public GameObject tilePrefab;

    private void Start()
    {
        GetComponent<Transform>().position = new Vector3(- x_size / 2, - y_size / 2, 0);

        for (int iy = 0; iy < y_size; iy++)
        {
            for (int ix = 0; ix < x_size; ix++)
            {
                Instantiate(tilePrefab, GetComponentInParent<Transform>());
                tilePrefab.transform.position = new Vector3(ix, iy, 0);
                tilePrefab.name = "Tile(" + ix + ", " + iy + ")";
                tilePrefab.GetComponent<Tile_Scripts>().infoHub = GameObject.Find("InfoHub");
            }            
        }
    }
}
