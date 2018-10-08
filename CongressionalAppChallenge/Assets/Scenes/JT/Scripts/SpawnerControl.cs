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
    public GameObject Enemy5;
    public float SpawnTime;
    private int d1;
    private int d2;
    private int d3;
    private int d4;
    private int d5;
    private int d6;
    public int enemiesToSpawn = 5;
    private int enemyCount = 0;
    private int log = 0;
    private Vector3 spawnPos;
    public bool canSpawnTop;
    public bool canSpawnLeft;
    public bool canSpawnRight;
    public bool canSpawnBot;
    public bool Spawn;
    List<Wave> myWaves;
    public int waveCount = 0;

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
        myWaves.Add(new Wave(Enemy3, Enemy1, Enemy4, Enemy4, Enemy4));
        myWaves.Add(new Wave(Enemy3, Enemy1, Enemy4, Enemy4, Enemy4));
        myWaves.Add(new Wave(Enemy3, Enemy1, Enemy4, Enemy4, Enemy4));

        SpawnTime = 0.0f;
        Spawn = true;
        canSpawnTop = true;
        canSpawnLeft = true;
        canSpawnRight = true;
        canSpawnBot = true;
    }

    private IEnumerator SpawnEnemies(int enemies, int myWave, Vector3 spawn)
    {
        log++;
        int myWaveCount = myWave;
        int count = 0;
        waveCount++;
        //Color c = Random.ColorHSV();
        for (int i = 0; i < enemies; i++)
        {
            GameObject g = Instantiate(myWaves[myWaveCount].enemies[i], spawn, Quaternion.identity);
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
        Spawn = false;
        count = 0;
        PlayerPrefs.SetInt("WaveCountNum", waveCount);
    }

	// Update is called once per frame
	void Update () {
        SpawnTime += Time.deltaTime;
        if (SpawnTime >= 3.2 && GetComponent<GameManagerScript>().canSpawnNextWave == true)
        {
            if (waveCount == myWaves.Count)
            {
                RandomWave();
            }
            d1 = Random.Range(0, 5);
            if (d1 == 1 && canSpawnTop)
            {
                canSpawnTop = false;
                spawnPos = SpawnerTop.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, waveCount, spawnPos));
            }
            if (d1 == 2 && canSpawnLeft)
            {
                canSpawnLeft = false;
                spawnPos = SpawnerLeft.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, waveCount, spawnPos));
            }
            if (d1 == 3 && canSpawnRight)
            {
                canSpawnRight = false;
                spawnPos = SpawnerRight.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, waveCount, spawnPos));
            }
            if (d1 == 4 && canSpawnBot)
            {
                canSpawnBot = false;
                spawnPos = SpawnerBot.transform.position;
                SpawnTime = 0;
                StartCoroutine(SpawnEnemies(enemiesToSpawn, waveCount, spawnPos));
            }

        }
	}
    public void RandomWave ()
    {
        //SS1
        GameObject e1 = Enemy1;
        d2 = Random.Range(1, 6);
        if (d2 == 1)
        {
            e1 = Enemy1;
        }
        if (d2 == 2)
        {
            e1 = Enemy2;
        }
        if (d2 == 3)
        {
            e1 = Enemy3;
        }
        if (d2 == 4)
        {
            e1 = Enemy4;
        }
        if (d2 == 5)
        {
            e1 = Enemy5;
        }
        //SS2
        GameObject e2 = Enemy2;
        d3 = Random.Range(1, 6);
        if (d3 == 1)
        {
            e2 = Enemy1;
        }
        if (d3 == 2)
        {
            e2 = Enemy2;
        }
        if (d3 == 3)
        {
            e2 = Enemy3;
        }
        if (d3 == 4)
        {
            e2 = Enemy4;
        }
        if (d3 == 5)
        {
            e2 = Enemy5;
        }
        //SS3
        GameObject e3 = Enemy3;
        d4 = Random.Range(1, 6);
        if (d4 == 1)
        {
            e3 = Enemy1;
        }
        if (d4 == 2)
        {
            e3 = Enemy2;
        }
        if (d4 == 3)
        {
            e3 = Enemy3;
        }
        if (d4 == 4)
        {
            e3 = Enemy4;
        }
        if (d4 == 5)
        {
            e3 = Enemy5;
        }
        //SS4
        GameObject e4 = Enemy4;
        d5 = Random.Range(1, 6);
        if (d5 == 1)
        {
            e4 = Enemy1;
        }
        if (d5 == 2)
        {
            e4 = Enemy2;
        }
        if (d5 == 3)
        {
            e4 = Enemy3;
        }
        if (d5 == 4)
        {
            e4 = Enemy4;
        }
        if (d5 == 5)
        {
            e4 = Enemy5;
        }
        //SS5
        GameObject e5 = Enemy5;
        d6 = Random.Range(1, 6);
        if (d6 == 1)
        {
            e5 = Enemy1;
        }
        if (d6 == 2)
        {
            e5 = Enemy2;
        }
        if (d6 == 3)
        {
            e5 = Enemy3;
        }
        if (d6 == 4)
        {
            e5 = Enemy4;
        }
        if (d6 == 5)
        {
            e5 = Enemy5;
        }
        myWaves.Add(new Wave(e1, e2, e3, e4, e5));
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
