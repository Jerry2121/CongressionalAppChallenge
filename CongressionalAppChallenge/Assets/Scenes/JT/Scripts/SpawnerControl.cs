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
    public int enemiesToSpawn = 5;
    private int enemyCount = 0;
    private int log = 0;
    private Vector3 spawnPos;
    public bool canSpawnTop;
    public bool canSpawnLeft;
    public bool canSpawnRight;
    public bool canSpawnBot;
    List<Wave> myWaves;
    private int waveCount = 0;

    // Use this for initialization
    void Start () {
        myWaves = new List<Wave>();
        myWaves.Add(new Wave(Enemy1, Enemy1, Enemy1, Enemy1, Enemy1));
        myWaves.Add(new Wave(Enemy1, Enemy1, Enemy1, Enemy1, Enemy2));
        myWaves.Add(new Wave(Enemy1, Enemy1, Enemy1, Enemy2, Enemy2));
        myWaves.Add(new Wave(Enemy1, Enemy1, Enemy2, Enemy2, Enemy2));
        myWaves.Add(new Wave(Enemy2, Enemy2, Enemy2, Enemy2, Enemy2));

        myWaves.Add(new Wave(Enemy2, Enemy2, Enemy3, Enemy2, Enemy1));
        myWaves.Add(new Wave(Enemy3, Enemy3, Enemy1, Enemy2, Enemy4));
        myWaves.Add(new Wave(Enemy4, Enemy3, Enemy2, Enemy1, Enemy3));
        myWaves.Add(new Wave(Enemy1, Enemy4, Enemy4, Enemy4, Enemy3));
        myWaves.Add(new Wave(Enemy1, Enemy1, Enemy3, Enemy4, Enemy4));

        myWaves.Add(new Wave(Enemy4, Enemy4, Enemy4, Enemy4, Enemy4));
        myWaves.Add(new Wave(Enemy3, Enemy1, Enemy4, Enemy4, Enemy4));

        SpawnTime = 0.0f;
        canSpawnTop = true;
        canSpawnLeft = true;
        canSpawnRight = true;
        canSpawnBot = true;
    }

    private IEnumerator SpawnEnemies(int enemies, GameObject enemyToSpawn, Vector3 spawn)
    {
        log++;
        Debug.Log("IEnumerator Started " + log + " times");
        int count = 0;
        waveCount++;
        //Color c = Random.ColorHSV();
        for (int i = 0; i < enemies; i++)
        {
            GameObject g = Instantiate(myWaves[waveCount].enemies[i], spawn, Quaternion.identity);
            //g.GetComponent<SpriteRenderer>().color = c;
            count++;
            yield return new WaitForSeconds(1);

        }
        if (spawn == SpawnerTop.transform.position)
        {
            canSpawnTop = true;
        }
        else if (spawn == SpawnerLeft.transform.position)
        {
            canSpawnLeft = true;
        }
        else if (spawn == SpawnerRight.transform.position)
        {
            canSpawnRight = true;
        }
        else if(spawn == SpawnerBot.transform.position)
        {
            canSpawnBot = true;
        }
        count = 0;
    }

	// Update is called once per frame
	void Update () {
        
        SpawnTime += Time.deltaTime;
        if (waveCount % 5 == 0 && SpawnTime < 20)
        {
            return;
        }
        if (SpawnTime >= 3.2)
        {
            d1 = Random.Range(0, 5);
            if (d1 == 1 && canSpawnTop)
            {
                canSpawnTop = false;
                spawnPos = SpawnerTop.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, Enemy1, spawnPos));
            }
            if (d1 == 2 && canSpawnLeft)
            {
                canSpawnLeft = false;
                spawnPos = SpawnerLeft.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, Enemy2, spawnPos));
            }
            if (d1 == 3 && canSpawnRight)
            {
                canSpawnRight = false;
                spawnPos = SpawnerRight.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, Enemy3, spawnPos));
            }
            if (d1 == 4 && canSpawnBot)
            {
                canSpawnBot = false;
                spawnPos = SpawnerBot.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, Enemy4, spawnPos));
            }
        }
	}
}
public class Wave
{
    public GameObject[] enemies;

    public Wave(GameObject s1, GameObject s2, GameObject s3, GameObject s4, GameObject s5)
    {
        enemies = new GameObject[5];
        enemies[0] = s1;
        enemies[1] = s2;
        enemies[2] = s3;
        enemies[3] = s4;
        enemies[4] = s5;
    }
}
