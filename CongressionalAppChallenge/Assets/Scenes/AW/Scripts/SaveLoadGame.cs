using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class SaveLoadGame : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoadIndex = 1;

    public static SaveLoadGame instance = null;

    [SerializeField]
    private string gameSavesDirectoryPath = "/GameState";

    List<GameTilesInfo> gameTilesInfoList;

    GameManagerInfo gameManagerInfo;

    public bool Loading { get; protected set; }

    void Start()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        gameManagerInfo = new GameManagerInfo();
    }
    //called from GameManagerScript
    public void SaveGame()
    {
        GameObject townHall_GO = GameObject.Find("TownHallTile(Clone)");
        if (townHall_GO.GetComponent<TownHallScript>().Enemiesleft > 0)
        {
            Debug.Log("SaveLoadGame -- SaveGame: The wave is still in progress!");
            return;
        }
        //If the Directory doesn't exist, then create the folder
        if (!Directory.Exists(Application.persistentDataPath + gameSavesDirectoryPath))
            Directory.CreateDirectory(Application.persistentDataPath + gameSavesDirectoryPath);

        //Ga through and save tiles
        gameTilesInfoList = new List<GameTilesInfo>();

        for (int i = -15; i < 15; i++)
        {
            for (int j = -25; j < 25; j++)
            {
                if (GameObject.Find("Tile(" + j + ", " + i + ")").GetComponent<Tile_Scripts>().baseTile)
                {
                    //add to the list
                    GameObject tile_GO = GameObject.Find("Tile(" + j + ", " + i + ")");
                    if (tile_GO.GetComponent<Tile_Scripts>().buildingID != -1)
                    {
                        Debug.Log(tile_GO);
                        GameTilesInfo gTI = tile_GO.GetComponent<Tile_Scripts>().Save();
                        gameTilesInfoList.Add(gTI);
                    }
                }
            }
        }

        SaveTiles();

        //Save the Game Manager
        gameManagerInfo = GameObject.Find("GameManager").GetComponent<GameManagerScript>().SaveGameManager();

        SaveGameManager();
    }

    public void LoadGame()
    {

        LevelChanger levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();

        if (File.Exists(Application.persistentDataPath + gameSavesDirectoryPath + "/GameTiles.cas") == false)
        {
            Debug.Log("SaveLoadGame -- LoadGame: " + Application.persistentDataPath + gameSavesDirectoryPath + "/GameTiles.cas doesn't exist");
            levelChanger.loadingText.text = "No Saved Game Found";
            return;
        }
        if (File.Exists(Application.persistentDataPath + gameSavesDirectoryPath + "/GameManager.cas") == false)
        {
            Debug.Log("SaveLoadGame -- LoadGame: " + Application.persistentDataPath + gameSavesDirectoryPath + "/GameManager.cas doesn't exist");
            levelChanger.loadingText.text = "Save Data Corrupted! Save Data cannot be loaded";
            return;
        }

        levelChanger.FadeToLevel(sceneToLoadIndex);

        Loading = true;
    }

    //Save the tile info out to a binary file
    private void SaveTiles()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + gameSavesDirectoryPath + "/GameTiles.cas", FileMode.OpenOrCreate);

        GameTilesInfoList myInfo = new GameTilesInfoList();

        //put what ever you're saving as myInfo.whatever
        myInfo.gameTileInfoList = gameTilesInfoList;
        bf.Serialize(file, myInfo);
        file.Close();
    }

    private void SaveGameManager()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + gameSavesDirectoryPath + "/GameManager.cas", FileMode.OpenOrCreate);

        GameManagerInfo myInfo = new GameManagerInfo();

        //put what ever you're saving as myInfo.whatever
        myInfo.townHallHP = gameManagerInfo.townHallHP;
        myInfo.wood = gameManagerInfo.wood;
        myInfo.stone = gameManagerInfo.stone;
        myInfo.ore = gameManagerInfo.ore;
        myInfo.steel = gameManagerInfo.steel;
        myInfo.waveCount = gameManagerInfo.waveCount;

        bf.Serialize(file, myInfo);
        file.Close();
    }
    //called from GameManagerScript
    public void LoadGameState()
    {
        if (File.Exists(Application.persistentDataPath + gameSavesDirectoryPath + "/GameTiles.cas"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + gameSavesDirectoryPath + "/GameTiles.cas", FileMode.Open);
            GameTilesInfoList myLoadedTileInfo = (GameTilesInfoList)bf.Deserialize(file);
            gameTilesInfoList = myLoadedTileInfo.gameTileInfoList;
            file.Close();

            if (File.Exists(Application.persistentDataPath + gameSavesDirectoryPath + "/GameManager.cas"))
            {
                bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + gameSavesDirectoryPath + "/GameManager.cas", FileMode.Open);
                GameManagerInfo myLoadedGameManagerInfo = (GameManagerInfo)bf.Deserialize(file);

                gameManagerInfo.townHallHP = myLoadedGameManagerInfo.townHallHP;
                gameManagerInfo.wood = myLoadedGameManagerInfo.wood;
                gameManagerInfo.stone = myLoadedGameManagerInfo.stone;
                gameManagerInfo.ore = myLoadedGameManagerInfo.ore;
                gameManagerInfo.steel = myLoadedGameManagerInfo.steel;

                SetLoadedTiles();

                GameObject.Find("GameManager").GetComponent<GameManagerScript>().Load(gameManagerInfo);
                file.Close();
            }
            else
            {
                Debug.LogError("SaveLoadGame -- LoadGame: Tile were saved but the GameManager file cannot be found!");
            }
        }
        else
        {
            Debug.Log("No saved tiles found");
        }
    }

    private void SetLoadedTiles()
    {
        //Wipe all current tiles
        for (int i = -15; i < 15; i++)
        {
            for (int j = -25; j < 25; j++)
            {
                if (GameObject.Find("Tile(" + j + ", " + i + ")").GetComponent<Tile_Scripts>().baseTile)
                {
                    Tile_Scripts tile_Script = GameObject.Find("Tile(" + j + ", " + i + ")").GetComponent<Tile_Scripts>();
                    if(tile_Script.buildingID != -1)
                        tile_Script.childStructure.GetComponent<StructureHP>().TakeDamage(999);
                }
            }
        }
        //Set tiles to what is loaded
        for (int i = 0; i < gameTilesInfoList.Count; i++)
        {
            GameTilesInfo gTI = gameTilesInfoList[i];
            GameObject tile = GameObject.Find(gTI.tileName);

            tile.GetComponent<Tile_Scripts>().Load(gTI);
        
        }
    }
}

[System.Serializable]
public class GameTilesInfo
{
    public string tileName;
    public int buildingID;
    public int buildingTypeID;
    public float buildingHP;
    public int buildingLevel;
}
[System.Serializable]
public class GameTilesInfoList{

    public List<GameTilesInfo> gameTileInfoList;
    
}
[System.Serializable]
public class GameManagerInfo
{
    public int townHallHP;
    public int wood;
    public int stone;
    public int ore;
    public int steel;

    public int waveCount;
}
