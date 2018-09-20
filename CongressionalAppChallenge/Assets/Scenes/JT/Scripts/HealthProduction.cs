using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProduction : MonoBehaviour {
    public int hp;

    public List<GameObject> parentTiles;

    // Use this for initialization
    void Start () {
        parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ")"));
        parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + gameObject.transform.position.y + ")"));
        parentTiles.Add(GameObject.Find("Tile(" + gameObject.transform.position.x + ", " + (gameObject.transform.position.y + 1) + ")"));
        parentTiles.Add(GameObject.Find("Tile(" + (gameObject.transform.position.x + 1) + ", " + (gameObject.transform.position.y + 1) + ")"));

        hp = GameObject.Find("GameManager").GetComponent<GameManagerScript>().ProductionStuctureHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            for (int i = 0; i < parentTiles.Count; i++)
            {
                parentTiles[i].GetComponent<Tile_Scripts>().buildingID = 0;
                parentTiles[i].GetComponent<Tile_Scripts>().spaceOccupied = false;
            }

            Destroy(this.gameObject);
        }
	}
}
