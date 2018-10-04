using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadGame : MonoBehaviour
{

    List<GameTilesInfo> gameTilesInfoList;

    //Save the tile info out to a binary file
    public void SaveTiles()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/GameTiles.dat", FileMode.OpenOrCreate);

        GameTilesInfoList myInfo = new GameTilesInfoList();

        //put what ever you're saving as myInfo.whatever
        myInfo.gameTileInfoList = gameTilesInfoList;
        bf.Serialize(file, myInfo);
        file.Close();
    }
    public void Load()
    {

        if (File.Exists(Application.persistentDataPath + "/GameTiles.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameTiles.dat", FileMode.Open);
            GameTilesInfoList myLoadedInfo = (GameTilesInfoList)bf.Deserialize(file);
            gameTilesInfoList = myLoadedInfo.gameTileInfoList;

            SetLoadedTiles();
        }
        else
        {
            Debug.Log("No saved games found");
        }

    }
    public void TestSaveThing()
    {

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
