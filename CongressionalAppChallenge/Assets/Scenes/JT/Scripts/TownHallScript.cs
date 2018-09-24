using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallScript : MonoBehaviour {
    public int Enemiesleft;
	// Use this for initialization
	void Start () {
        Enemiesleft = 0;
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("TownHallScript: Collision Detected!");
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("TownHallScript: Collision is Layer 8!");
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 14)
        {
            Debug.Log("TownHallScript: Collision is Layer 14!");
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 3;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 15)
        {
            Debug.Log("TownHallScript: Collision is Layer 15!");
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 16)
        {
            Debug.Log("TownHallScript: Collision is Layer 16!");
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 7;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 17)
        {
            Debug.Log("TownHallScript: Collision is Layer 17!");
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 9;
            Destroy(collision.gameObject);
        }
    }
}
