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
        if (collision.gameObject.layer == 8)
        {
            Enemiesleft--;
            Destroy(collision.gameObject);
        }
    }
}
