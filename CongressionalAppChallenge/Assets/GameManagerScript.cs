using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    public GameObject Button;
    public bool canSpawnNextWave;
    public bool isFirstInstance;
    private float cooldownTimer;
	// Use this for initialization
	void Start () {
        canSpawnNextWave = false;
        isFirstInstance = true;
	}
	
	// Update is called once per frame
	void Update () {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= 5)
        {
            canSpawnNextWave = false;
        }
        if (isFirstInstance == true)
        {
            Button.GetComponent<Text>().text = "Start Wave";
        }
        if (canSpawnNextWave && isFirstInstance)
        {
            Button.GetComponent<Text>().text = "Next Wave";
            isFirstInstance = false;
            canSpawnNextWave = true;
        }
        else if (canSpawnNextWave == true) {
            Button.SetActive(false);
        }
        else
        {
            Button.SetActive(true);
        }
	}
    public void NextWaveButton()
    {
        canSpawnNextWave = true;
        cooldownTimer = 0;
    }
}
