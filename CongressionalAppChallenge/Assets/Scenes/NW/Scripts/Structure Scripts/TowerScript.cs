using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {

    private List<GameObject> enemiesInRange;

    private GameObject towerTarget;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
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
        towerTarget = enemiesInRange[0];
    }
}
