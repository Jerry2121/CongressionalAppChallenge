using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    public GameObject MusicEnabledIcon;
    public GameObject MusicDisabledIcon;
    public GameObject MainCamera;
    private int ranCode;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("MusicEnabled") == 1 && ranCode == 0)
        {
            MusicEnabledIcon.SetActive(true);
            MusicDisabledIcon.SetActive(false);
            MainCamera.GetComponent<AudioSource>().Play();
            ranCode = 1;
        }
        else if (PlayerPrefs.GetInt("MusicEnabled") == 0)
        {
            MainCamera.GetComponent<AudioSource>().Pause();
            MusicEnabledIcon.SetActive(false);
            MusicDisabledIcon.SetActive(true);
            ranCode = 0;
        }
    }
    public void StartB ()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void QuitA ()
    {
        Application.Quit();
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
}
