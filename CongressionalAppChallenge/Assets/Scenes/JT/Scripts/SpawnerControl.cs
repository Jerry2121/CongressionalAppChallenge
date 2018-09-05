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
    public float bspawntime;
    private int d1;
    public int enemiesToSpawn = 5;
    private int enemyCount = 0;
    private Vector3 spawnPos;
    public bool canSpawnTop;
    public bool canSpawnLeft;
    public bool canSpawnRight;
    public bool canSpawnBot;
    // Use this for initialization
    void Start () {
        SpawnTime = 0.0f;
        bspawntime = 0.0f;
        canSpawnTop = true;
        canSpawnLeft = true;
        canSpawnRight = true;
        canSpawnBot = true;
    }
    private IEnumerator SpawnEnemies(int enemies, GameObject enemyToSpawn, Vector3 spawn)
    {
        int count = 0;
        Color c = Random.ColorHSV();
        for (int i = 0; i < enemies; i++)
        {
            GameObject g = Instantiate(enemyToSpawn, spawn, Quaternion.identity);
            g.GetComponent<SpriteRenderer>().color = c;
            count++;
            yield return new WaitForSeconds(1);
            Debug.Log(enemyCount);

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
        
        if (SpawnTime >= 3)
        {
            //bspawntime += Time.deltaTime;
           // if (enemyCount == 0)
           // {
                d1 = Random.Range(0, 5);
                if (d1 == 1 && canSpawnTop)
                {
                    spawnPos = SpawnerTop.transform.position;
                    canSpawnTop = false;
                }
                if (d1 == 2 && canSpawnLeft)
                {
                    spawnPos = SpawnerLeft.transform.position;
                    canSpawnLeft = false;
            }
                if (d1 == 3 && canSpawnRight)
                {
                    spawnPos = SpawnerRight.transform.position;
                    canSpawnRight = false;
            }
                if (d1 == 4 && canSpawnBot)
                {
                    spawnPos = SpawnerBot.transform.position;
                    canSpawnBot = false;
            }
           // }
            //Instantiate(Enemy1, spawnPos, Quaternion.identity);
            StartCoroutine(SpawnEnemies(enemiesToSpawn, Enemy1, spawnPos));
            SpawnTime = 0;
            //SpawnTime = 0;
            /*
                if (bspawntime >= 1)
                {
                    Instantiate(Enemy1, spawnPos, Quaternion.identity);
                    enemyCount++;
                }
                else if (bspawntime >= 2)
                {
                    Instantiate(Enemy2, spawnPos, Quaternion.identity);
                    enemyCount++;
                }
                else if (bspawntime >= 3)
                {
                    Instantiate(Enemy3, spawnPos, Quaternion.identity);
                    enemyCount++;
                }
                else if (bspawntime >= 4)
                {
                    Instantiate(Enemy4, spawnPos, Quaternion.identity);
                    enemyCount++;
                }
                else if (bspawntime >= 5)
                {
                    Instantiate(Enemy1, spawnPos, Quaternion.identity);
                    enemyCount = 0;
                    bspawntime = 0;
                    SpawnTime = 0;
                }
                
        */
            /*  if (d1 == 2)
              {
                  Instantiate(Enemy2, SpawnerTop.transform.position, Quaternion.identity);
                  if (bspawntime >= 1 && bspawntime <= 2)
                  {
                      Instantiate(Enemy2, SpawnerTop.transform.position, Quaternion.identity);
                      if (bspawntime >= 2 && bspawntime <= 3)
                      {
                          Instantiate(Enemy2, SpawnerTop.transform.position, Quaternion.identity);
                          if (bspawntime >= 3 && bspawntime <= 4)
                          {
                              Instantiate(Enemy2, SpawnerTop.transform.position, Quaternion.identity);
                              if (bspawntime >= 4 && bspawntime <= 5)
                              {
                                  Instantiate(Enemy2, SpawnerTop.transform.position, Quaternion.identity);
                                  if (bspawntime >= 5 && bspawntime <= 6)
                                  {
                                      Instantiate(Enemy2, SpawnerTop.transform.position, Quaternion.identity);
                                      SpawnTime = 0;
                                  }
                              }
                          }
                      }
                  }
              }
              if (d1 == 3)
              {
                  Instantiate(Enemy3, SpawnerTop.transform.position, Quaternion.identity);
                  if (bspawntime >= 1 && bspawntime <= 2)
                  {
                      Instantiate(Enemy3, SpawnerTop.transform.position, Quaternion.identity);
                      if (bspawntime >= 2 && bspawntime <= 3)
                      {
                          Instantiate(Enemy3, SpawnerTop.transform.position, Quaternion.identity);
                          if (bspawntime >= 3 && bspawntime <= 4)
                          {
                              Instantiate(Enemy3, SpawnerTop.transform.position, Quaternion.identity);
                              if (bspawntime >= 4 && bspawntime <= 5)
                              {
                                  Instantiate(Enemy3, SpawnerTop.transform.position, Quaternion.identity);
                                  if (bspawntime >= 5 && bspawntime <= 6)
                                  {
                                      Instantiate(Enemy3, SpawnerTop.transform.position, Quaternion.identity);
                                      SpawnTime = 0;
                                  }
                              }
                          }
                      }
                  }
              }
              if (d1 == 4)
              {
                  Instantiate(Enemy4, SpawnerTop.transform.position, Quaternion.identity);
                  if (bspawntime >= 1 && bspawntime <= 2)
                  {
                      Instantiate(Enemy4, SpawnerTop.transform.position, Quaternion.identity);
                      if (bspawntime >= 2 && bspawntime <= 3)
                      {
                          Instantiate(Enemy4, SpawnerTop.transform.position, Quaternion.identity);
                          if (bspawntime >= 3 && bspawntime <= 4)
                          {
                              Instantiate(Enemy4, SpawnerTop.transform.position, Quaternion.identity);
                              if (bspawntime >= 4 && bspawntime <= 5)
                              {
                                  Instantiate(Enemy4, SpawnerTop.transform.position, Quaternion.identity);
                                  if (bspawntime >= 5 && bspawntime <= 6)
                                  {
                                      Instantiate(Enemy4, SpawnerTop.transform.position, Quaternion.identity);
                                      SpawnTime = 0;
                                  }
                              }
                          }
                      }
                  }
              }*/

        }
	}
}
