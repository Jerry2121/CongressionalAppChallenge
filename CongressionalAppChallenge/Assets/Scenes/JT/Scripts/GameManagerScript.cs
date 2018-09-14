using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    public GameObject ButtonText;
    public GameObject Button;
    public bool canSpawnNextWave;
    public bool isFirstInstance;
    public float cooldownTimer;
	// Use this for initialization
	void Start () {
        canSpawnNextWave = false;
        isFirstInstance = true;
	}
	
	// Update is called once per frame
	void Update () {

        cooldownTimer += Time.deltaTime;
        if (isFirstInstance == true)
        {
            ButtonText.GetComponent<Text>().text = "Start Wave";
        }
        else if (canSpawnNextWave == true)
        {
            ButtonText.SetActive(false);
            Button.SetActive(false);
        }
        if (canSpawnNextWave == false && GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft <= 0)
        {
            ButtonText.SetActive(true);
            Button.SetActive(true);
        }
        if (canSpawnNextWave && isFirstInstance)
        {
            ButtonText.GetComponent<Text>().text = "Next Wave";
            isFirstInstance = false;
            canSpawnNextWave = true;
        }
        if (GetComponent<SpawnerControl>().waveCount % 5 == 0 && cooldownTimer >= 5)
        {
            GetComponent<GameManagerScript>().canSpawnNextWave = false;
            return;
        }
    }
    public void NextWaveButton()
    {
        canSpawnNextWave = true;
        GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft = 25;
        cooldownTimer = 0;
    }
}
