using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour {
    [Header("UI Management")]
    public GameObject selectedTile;
    public GameObject menuCanvas;
    public GameObject Hammer;
    public GameObject X;
    public GameObject HPText;
    public GameObject WoodText;
    public GameObject StoneText;
    public GameObject OreText;
    public GameObject SteelText;
    public GameObject WaveButtonText;
    public GameObject WaveButton;
    public GameObject HUD;
    public GameObject MusicEnabledIcon;
    public GameObject MusicDisabledIcon;
    public GameObject BGMusic;
    public GameObject WaveMusic;
    public Sprite StartWaveBG;
    public Sprite NextWaveBG;
    [Space(25)]
    [Header("Booleans")]
    public bool canSpawnNextWave;
    public bool isFirstInstance;
    public bool editMode;
    public bool ran;
    public bool towerAction;
    [Space(25)]
    [Header("Floats")]
    public float cooldownTimer;
    [Space(25)]
    [Header("Integers")]
    public int TownHallHP;
    public int ProductionStuctureHP;
    public int VillageStuctureHP;
    public int TowerStuctureHP;
    public int FireTowerStructureHP;
    public int DefenseStructureHP;
    public int stoneAcquired;
    public int woodAcquired;
    public int oreAcquired;
    public int steelAcquired;
    public int ranCode;
    [Space(25)]
    Image myImageComponent;
    [Space(25)]
    public List<GameObject> WallTiles;
    [Space(25)]
    [Header("Cheats")]
    public bool InfiniteHealth;
    public bool InfiniteResources;


    // Use this for initialization
    void Start () {
        canSpawnNextWave = false;
        isFirstInstance = true;
        editMode = false;
        ranCode = 0;
        myImageComponent = WaveButton.GetComponent<Image>();
        if (PlayerPrefs.GetInt("MusicEnabled") == 1)
        {
            MusicEnabledIcon.SetActive(true);
            MusicDisabledIcon.SetActive(false);
            BGMusic.GetComponent<AudioSource>().Play();
        }
        else if (PlayerPrefs.GetInt("MusicEnabled") == 0) 
        {
            MusicEnabledIcon.SetActive(false);
            MusicDisabledIcon.SetActive(true);
            BGMusic.GetComponent<AudioSource>().Stop();
            WaveMusic.GetComponent<AudioSource>().Stop();
        }
        //editModeButton.GetComponent<TextMeshPro>().text = "Enter \n Edit mode";
        CheckIfLoading();
    }

    // Update is called once per frame
    void Update () {
        if (selectedTile != null)
        {
            selectedTile.GetComponent<Tile_Scripts>().selectedTileUpdate();
        }
        if (InfiniteHealth)
        {
            TownHallHP = 100;
        }
        if (InfiniteResources)
        {
            woodAcquired = 999;
            stoneAcquired = 999;
            oreAcquired = 999;
            steelAcquired = 999;
        }
        if (TownHallHP <= 0)
        {
            GameObject.Find("LevelChanger").GetComponent<LevelChanger>().GameOver();
        }
        if (Time.timeScale == 0 && HUD.GetComponent<HUDController>().Paused == true && PlayerPrefs.GetInt("MusicEnabled") == 1)
        {
            ranCode = 0;
            BGMusic.GetComponent<AudioSource>().Pause();
            WaveMusic.GetComponent<AudioSource>().Pause();
        }
        if (Time.timeScale == 1 && HUD.GetComponent<HUDController>().Paused == false && ranCode == 0 && PlayerPrefs.GetInt("MusicEnabled") == 1)
        {
            if (GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft <= 0)
            {
                BGMusic.GetComponent<AudioSource>().Play();
            }
            else if (GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft > 0)
            {
                //BGMusic.GetComponent<AudioSource>().Play();
                WaveMusic.GetComponent<AudioSource>().Play();
            }
            ranCode = 1;
        }
        HPText.GetComponent<TextMeshProUGUI>().text = "HP: " + TownHallHP;
        WoodText.GetComponent<TextMeshProUGUI>().text = "Wood: " + woodAcquired;
        StoneText.GetComponent<TextMeshProUGUI>().text = "Stone: " + stoneAcquired;
        OreText.GetComponent<TextMeshProUGUI>().text = "Ore: " + oreAcquired;
        SteelText.GetComponent<TextMeshProUGUI>().text = "Steel: " + steelAcquired;
        if (TownHallHP >= 100)
        {
            TownHallHP = 100;
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

        if (TownHallHP <= 0)
        {
            TownHallHP = 0;
        }
        if (woodAcquired <= 0)
        {
            woodAcquired = 0;
        }
        if (stoneAcquired <= 0)
        {
            stoneAcquired = 0;
        }
        if (oreAcquired <= 0)
        {
            oreAcquired = 0;
        }
        if (steelAcquired <= 0)
        {
            steelAcquired = 0;
        }
        cooldownTimer += Time.deltaTime;
        if (isFirstInstance == true)
        {
            WaveButtonText.GetComponent<Text>().text = "Start Wave";
            myImageComponent.sprite = StartWaveBG;
        }
        else if (canSpawnNextWave == true)
        {
            WaveButtonText.SetActive(false);
            WaveButton.SetActive(false);
        }
        if (canSpawnNextWave == false && GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft <= 0 && PlayerPrefs.GetInt("MusicEnabled") == 0)
        {
            WaveButtonText.SetActive(true);
            WaveButton.SetActive(true);
        }
        else if (canSpawnNextWave == false && GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft <= 0 && PlayerPrefs.GetInt("MusicEnabled") == 1)
        {
            BGMusic.GetComponent<AudioSource>().mute = false;
            BGMusic.SetActive(true);
            WaveMusic.GetComponent<AudioSource>().mute = true;
            WaveMusic.SetActive(false);
            WaveButtonText.SetActive(true);
            WaveButton.SetActive(true);
        }
        if (canSpawnNextWave && GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft > 0 && PlayerPrefs.GetInt("MusicEnabled") == 1)
        {
            BGMusic.GetComponent<AudioSource>().mute = true;
            BGMusic.SetActive(false);
            WaveMusic.GetComponent<AudioSource>().mute = false;
            WaveMusic.SetActive(true);
        }
        if (canSpawnNextWave && isFirstInstance)
        {
            WaveButtonText.GetComponent<Text>().text = "Next Wave";
            myImageComponent.sprite = NextWaveBG;
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
        ranCode = 0;
        canSpawnNextWave = true;
        GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft = 25;
        if (!WaveMusic.GetComponent<AudioSource>().isPlaying && PlayerPrefs.GetInt("MusicEnabled") == 1)
        {
            WaveMusic.GetComponent<AudioSource>().Play();
            BGMusic.GetComponent<AudioSource>().Stop();
        }
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
    public void MusicEnable()
    {
        PlayerPrefs.SetInt("MusicEnabled", 1);
        MusicEnabledIcon.SetActive(true);
        MusicDisabledIcon.SetActive(false);
    }
    public void MusicDisable()
    {
        PlayerPrefs.SetInt("MusicEnabled", 0);
        MusicEnabledIcon.SetActive(false);
        MusicDisabledIcon.SetActive(true);
    }

    public void WallCheckFunction()
    {
        for (int i = 0; i < WallTiles.Count; i++)
        {
            WallTiles[i].GetComponent<WallSpriteChanger>().NeighboringWallCheck();
        }
    }
    public void ModifyTownHallHP(int mod)
    {
        TownHallHP += mod;
    }

    public GameManagerInfo SaveGameManager()
    {
        GameManagerInfo gMI = new GameManagerInfo();

        gMI.townHallHP = TownHallHP;
        gMI.wood = woodAcquired;
        gMI.stone = stoneAcquired;
        gMI.ore = oreAcquired;
        gMI.steel = steelAcquired;

        gMI.waveCount = gameObject.GetComponent<SpawnerControl>().waveCount;

        return gMI;
    }

    public void Load (GameManagerInfo _gMI)
    {
        TownHallHP = _gMI.townHallHP;
        woodAcquired = _gMI.wood;
        stoneAcquired = _gMI.stone;
        oreAcquired = _gMI.ore;
        steelAcquired = _gMI.steel;

        gameObject.GetComponent<SpawnerControl>().waveCount = _gMI.waveCount;
    }

    private void CheckIfLoading()
    {
        if (GameObject.Find("SaveLoadManager").GetComponent<SaveLoadGame>() != null)
        {
            if (GameObject.Find("SaveLoadManager").GetComponent<SaveLoadGame>().Loading)
            {
                GameObject.Find("SaveLoadManager").GetComponent<SaveLoadGame>().LoadGameState();
            }
        }
        else
        {
            Debug.LogError("GameManagerScript -- CheckIfLoading: The SaveLoadGame script was not found. It should be on the SaveLoadManager");
        }
    }

    public void SaveGame()
    {
        if (GameObject.Find("SaveLoadManager").GetComponent<SaveLoadGame>() != null)
        {
            GameObject.Find("SaveLoadManager").GetComponent<SaveLoadGame>().SaveGame();
        }
        else
        {
            Debug.LogError("GameManagerScript -- SaveGame: The SaveLoadGame script was not found. It should be on the SaveLoadManager");
        }
    }

}
