using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVillage : MonoBehaviour {
    public int hp;

    public GameObject parentTile;

    // Use this for initialization
    void Start () {
        parentTile = GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ")");

        hp = GameObject.Find("GameManager").GetComponent<GameManagerScript>().VillageStuctureHP;
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            parentTile.GetComponent<Tile_Scripts>().buildingID = 0;
            parentTile.GetComponent<Tile_Scripts>().spaceOccupied = false;

            Destroy(this.gameObject);
        }
    }
}

