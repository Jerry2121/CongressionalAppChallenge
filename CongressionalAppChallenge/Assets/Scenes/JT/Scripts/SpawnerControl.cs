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
    private int enemyCount = 0;
    private Vector3 spawnPos;
    public int enemiesToSpawn = 3;
	// Use this for initialization
	void Start () {
        SpawnTime = 0.0f;
        bspawntime = 0.0f;
	}
    /*private IEnumerator SpawnEnemies(int enemies, GameObject enemyToSpawn)
    {
        for (int i = 0; i < enemies; i++)
        {
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(1);
            Debug.Log(enemyCount);

        }
        enemyCount = 0;
    }*/
	// Update is called once per frame
	void Update () {
        SpawnTime += Time.deltaTime;
        bspawntime += Time.deltaTime;
        if (SpawnTime >= 3)
        {
            //bspawntime += Time.deltaTime;
           // if (enemyCount == 0)
           // {
                d1 = Random.Range(0, 5);
                if (d1 == 1)
                {
                    spawnPos = SpawnerTop.transform.position;
                }
                if (d1 == 2)
                {
                    spawnPos = SpawnerLeft.transform.position;
                }
                if (d1 == 3)
                {
                    spawnPos = SpawnerRight.transform.position;
                }
                if (d1 == 4)
                {
                    spawnPos = SpawnerBot.transform.position;
                }
           // }
            //Instantiate(Enemy1, spawnPos, Quaternion.identity);
            //StartCoroutine(SpawnEnemies(enemiesToSpawn, Enemy1));
            //SpawnTime = 0;
            
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
