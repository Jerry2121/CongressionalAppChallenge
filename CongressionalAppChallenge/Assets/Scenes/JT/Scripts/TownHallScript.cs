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
}
