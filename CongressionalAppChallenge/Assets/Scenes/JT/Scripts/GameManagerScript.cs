using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour {
    public GameObject selectedTile;
    public GameObject menuCanvas;
    public GameObject Hammer;
    public GameObject X;
    [Space(25)]
    public GameObject HPText;
    public GameObject WoodText;
    public GameObject StoneText;
    public GameObject OreText;
    public GameObject SteelText;
    public GameObject WaveButtonText;
    public GameObject WaveButton;
    [Space(25)]
    public bool canSpawnNextWave;
    public bool isFirstInstance;
    public bool editMode;
    [Space(25)]
    public float cooldownTimer;
    [Space(25)]
    public int HP;
    public int stoneAcquired;
    public int woodAcquired;
    public int oreAcquired;
    public int steelAcquired ;

    // Use this for initialization
    void Start () {
        canSpawnNextWave = false;
        isFirstInstance = true;
        editMode = false;
        //editModeButton.GetComponent<TextMeshPro>().text = "Enter \n Edit mode";
    }

    // Update is called once per frame
    void Update () {
        HPText.GetComponent<TextMeshProUGUI>().text = "HP: " + HP;
        WoodText.GetComponent<TextMeshProUGUI>().text = "Wood: " + woodAcquired;
        StoneText.GetComponent<TextMeshProUGUI>().text = "Stone: " + stoneAcquired;
        OreText.GetComponent<TextMeshProUGUI>().text = "Ore: " + oreAcquired;
        SteelText.GetComponent<TextMeshProUGUI>().text = "Steel: " + steelAcquired;
        if (HP >= 100)
        {
            HP = 100;
        }
        if (woodAcquired >= 999)
        {
            woodAcquired = 999;
        }
        if (stoneAcquired >= 999)
        {
            stoneAcquired = 999;
        }
        if (oreAcquired >= 999)
        {
            oreAcquired = 999;
        }
        if (steelAcquired >= 999)
        {
            steelAcquired = 999;
        }
        cooldownTimer += Time.deltaTime;
        if (isFirstInstance == true)
        {
            WaveButtonText.GetComponent<Text>().text = "Start Wave";
        }
        else if (canSpawnNextWave == true)
        {
            WaveButtonText.SetActive(false);
            WaveButton.SetActive(false);
        }
        if (canSpawnNextWave == false && GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft <= 0)
        {
            WaveButtonText.SetActive(true);
            WaveButton.SetActive(true);
        }
        if (canSpawnNextWave && isFirstInstance)
        {
            WaveButtonText.GetComponent<Text>().text = "Next Wave";
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
