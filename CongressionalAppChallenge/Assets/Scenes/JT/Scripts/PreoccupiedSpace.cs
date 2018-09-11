using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreoccupiedSpace : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
        {
            GetComponent<Tile_Scripts>().spaceOccupied = true;
        }
    }
}
