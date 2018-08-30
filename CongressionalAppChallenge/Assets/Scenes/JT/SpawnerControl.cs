using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour {
    public GameObject SpawnerTop;
    public GameObject SpawnerLeft;
    public GameObject SpawnerRight;
    public GameObject SpawnerBot;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public float SpawnTime;
    private int d1;
	// Use this for initialization
	void Start () {
        SpawnTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        SpawnTime += Time.deltaTime;
		if (SpawnTime >= 3)
        {
            d1 = Random.Range(0, 5);
            if (d1 == 1)
            {
                Instantiate(Enemy1, SpawnerTop.transform.position, Quaternion.identity);
            }
            if (d1 == 2)
            {
                Instantiate(Enemy2, SpawnerLeft.transform.position, Quaternion.identity);
            }
            if (d1 == 3)
            {
                Instantiate(Enemy3, SpawnerRight.transform.position, Quaternion.identity);
            }
            if (d1 == 4)
            {
                Instantiate(Enemy4, SpawnerBot.transform.position, Quaternion.identity);
            }
            SpawnTime = 0;
        }
	}
}
