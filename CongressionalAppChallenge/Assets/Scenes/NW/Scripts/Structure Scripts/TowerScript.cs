using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    private List<GameObject> enemiesInRange = new List<GameObject>();

    private GameObject towerTarget;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("Adding enemy to list");
            enemiesInRange.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }

    void Update()
    {
        if (enemiesInRange.Count >= 1)
        {
            towerTarget = enemiesInRange[0];
        }
    }
}
