using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallScript : MonoBehaviour {
    public int Enemiesleft;
    private float timer;
	// Use this for initialization
	void Start () {
        Enemiesleft = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Enemiesleft > 0)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().woodAcquired++;
                timer = 0;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 14)
        {
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 3;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 15)
        {
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 16)
        {
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 7;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 17)
        {
            Enemiesleft--;
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP = GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP - 9;
            Destroy(collision.gameObject);
        }
    }
}
