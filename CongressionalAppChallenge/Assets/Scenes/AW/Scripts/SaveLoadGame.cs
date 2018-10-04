using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadGame : MonoBehaviour
{
    [SerializeField]
    private string gameSavesDirectoryPath = "/GameState";


    List<GameTilesInfo> gameTilesInfoList;

    //Save the tile info out to a binary file
    public void SaveTiles()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + gameSavesDirectoryPath + "/GameTiles.cac", FileMode.OpenOrCreate);

        GameTilesInfoList myInfo = new GameTilesInfoList();

        //put what ever you're saving as myInfo.whatever
        myInfo.gameTileInfoList = gameTilesInfoList;
        bf.Serialize(file, myInfo);
        file.Close();
    }
    public void LoadGame()
    {

        if (File.Exists(Application.persistentDataPath + gameSavesDirectoryPath + "/GameTiles.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + gameSavesDirectoryPath +  "/GameTiles.cac", FileMode.Open);
            GameTilesInfoList myLoadedInfo = (GameTilesInfoList)bf.Deserialize(file);
            gameTilesInfoList = myLoadedInfo.gameTileInfoList;

            SetLoadedTiles();
        }
        else
        {
            Debug.Log("No saved games found");
        }

    }

    public void SaveGame()
    {
        GameObject townHall_GO = GameObject.Find("TownHallTile(Clone)");
        if (townHall_GO.GetComponent<TownHallScript>().Enemiesleft > 0)
        {
            Debug.Log("SaveLoadGame -- SaveGame: The wave is still in progress!");
            return;
        }
        //If the Directory doesn't exist, then create the folder
        if(!Directory.Exists(Application.persistentDataPath + gameSavesDirectoryPath))
            Directory.CreateDirectory(Application.persistentDataPath + gameSavesDirectoryPath);

        gameTilesInfoList = new List<GameTilesInfo>();

        for(int i = -15; i < 15; i++)
        {
            for(int j = -25; j < 25; j++)
            {
                if(GameObject.Find("Tile(" + j + ", " + i + ")").GetComponent<Tile_Scripts>().baseTile)
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

    }

    public void SetLoadedTiles()
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

            Tile_Scripts tile_Scripts = tile.GetComponent<Tile_Scripts>();

            tile_Scripts.buildingID = gTI.buildingID;
            tile_Scripts.buildingHP = gTI.buildingHP;
            tile_Scripts.buildingLevel = gTI.buildingLevel;

            tile_Scripts.isLoading = true;
            tile_Scripts.SpawnBuilding(gTI.buildingTypeID, gTI.buildingID);
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
}
