using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuildingTest : MonoBehaviour {

	public void DestroyBuilding()
    {

        if(gameObject.GetComponent<GameManagerScript>().selectedTile != null)
        {
            gameObject.GetComponent<GameManagerScript>().selectedTile.GetComponent<Tile_Scripts>().childStructure.GetComponent<StructureHP>().TakeDamage(999);
        }
        else
        {
            Debug.Log("DestroyBuildingTest -- DestroyBuilding: No selected tile");
        }

    }

}
