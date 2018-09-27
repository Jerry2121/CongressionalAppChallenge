using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpriteChanger : MonoBehaviour {

    public GameObject GameManager;

    public Sprite wallSprite_Base;

    public Sprite wallSprite_Cross;
    public Sprite wallSprite_CrossLeft;
    public Sprite wallSprite_CrossUp;
    public Sprite wallSprite_CrossRight;
    public Sprite wallSprite_CrossDown;

    public Sprite wallSprite_CornerA;
    public Sprite wallSprite_CornerB;
    public Sprite wallSprite_CornerC;
    public Sprite wallSprite_CornerD;

    public Sprite wallSprite_HoriCapRight;
    public Sprite wallSprite_HoriCapLeft;

    public Sprite wallSprite_VertiCapUp;
    public Sprite wallSprite_VertiCapDown;

    public Sprite wallSprite_Hori;
    public Sprite wallSprite_Verti;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        GameManager.GetComponent<GameManagerScript>().WallTiles.Add(gameObject);
        NeighboringWallCheck();
    }

    public void NeighboringWallCheck()
    {
        // If all neighboring tiles are occupied with walls
        if (GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                    GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_Cross;
        }

        // If all neighboring tiles, other than the one to the right, are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                    GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CrossLeft;
        }

        // If all neighboring tiles, other than the one beneath, are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                    GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CrossUp;
        }


        // If all neighboring tiles, other than the one to the left, are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                    GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CrossRight;
        }

        // If all neighboring tiles, other than the one above, are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                    GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CrossDown;
        }

        // If the neighboring tiles above and to the left are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CornerA;
        }

        // If the neighboring tiles above and to the right are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CornerB;
        }

        // If the neighboring tiles below and to the right are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CornerC;
        }

        // If the neighboring tiles below and to the left are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_CornerD;
        }

        // If the neighboring tiles to the right and to the left are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_Hori;
        }

        // If the neighboring tiles below and above are occupied with walls
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41 &&
                        GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_Verti;
        }

        // If the neighboring tile to the left is occupied with a wall
        else if (GameObject.Find("Tile(" + (transform.position.x - 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_HoriCapLeft;
        }

        // If the neighboring tile above is occupied with a wall
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y + 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_VertiCapUp;
        }

        // If the neighboring tile to the right is occupied with a wall
        else if (GameObject.Find("Tile(" + (transform.position.x + 1) + ", " + (transform.position.y) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_HoriCapRight;
        }

        // If the neighboring tile below is occupied with a wall
        else if (GameObject.Find("Tile(" + (transform.position.x) + ", " + (transform.position.y - 1) + ")").GetComponent<Tile_Scripts>().buildingID == 41)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_VertiCapDown;
        }

        else
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite_Base;
        }
    }
}
