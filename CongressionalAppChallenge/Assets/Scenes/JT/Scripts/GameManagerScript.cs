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

    public bool editMode;

    public GameObject selectedTile;

    public GameObject menuCanvas;
    
    public GameObject Hammer;
    public GameObject X;

    public int stoneAcquired;
    public int woodAcquired;
    public int oreAcquired;
    public int steelAcquired;

    // Use this for initialization
    void Start () {
        canSpawnNextWave = false;
        isFirstInstance = true;

        editMode = false;
        //editModeButton.GetComponent<TextMeshPro>().text = "Enter \n Edit mode";
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

    public void EditModeButton()
    {
        //selectedTile = null;

        if (editMode == false)
        {

            editMode = true;
            //editModeButton.GetComponent<TextMeshPro>().text = "Exit \n Edit Mode";
            Hammer.SetActive(false);
            X.SetActive(true);
        }

        else if (editMode == true)
        {
            editMode = false;
            //editModeButton.GetComponent<TextMeshPro>().text = "Enter \n Edit Mode";
            Hammer.SetActive(true);
            X.SetActive(false);
            Destroy(GameObject.Find("temporaryUI"));
            menuCanvas.GetComponent<BuildStructureMenu>().MenuDisplayFunction();
        }
    }
}
