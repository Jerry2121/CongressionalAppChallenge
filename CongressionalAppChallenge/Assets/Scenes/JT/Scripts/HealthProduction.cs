using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProduction : MonoBehaviour {
    public int hp;

    // Use this for initialization
    void Start () {
        hp = GameObject.Find("GameManager").GetComponent<GameManagerScript>().ProductionStuctureHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            for (int i = 0; i < GetComponent<BaseStructureScript>().parentTiles.Count; i++)
            {
                GetComponent<BaseStructureScript>().parentTiles[i].GetComponent<Tile_Scripts>().buildingID = 0;
                GetComponent<BaseStructureScript>().parentTiles[i].GetComponent<Tile_Scripts>().spaceOccupied = false;
            }

            Destroy(this.gameObject);
        }
	}
}
