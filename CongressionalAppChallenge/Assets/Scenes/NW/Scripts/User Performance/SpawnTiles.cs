using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour {

    public int y_size;
    public int x_size;

    GameObject tilePrefab;

    private void Start()
    {
        for (int iy = 0; iy < x_size; iy++)
        {
            for (int ix = 0; ix < x_size; ix++)
            {
                Instantiate(tilePrefab, GetComponentInParent<Transform>());
                tilePrefab.transform.position += new Vector3(ix, iy, 0);
            }            
        }
    }
}
