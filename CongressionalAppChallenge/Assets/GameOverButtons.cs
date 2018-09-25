using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour {
    public GameObject MainCamera;
    private int ranCode;
    void Update()
    {
        if (PlayerPrefs.GetInt("MusicEnabled") == 1 && ranCode == 0)
        {
            MainCamera.GetComponent<AudioSource>().Play();
            ranCode = 1;
        }
        else if (PlayerPrefs.GetInt("MusicEnabled") == 0)
        {
            MainCamera.GetComponent<AudioSource>().Pause();
            ranCode = 0;
        }
    }

}
