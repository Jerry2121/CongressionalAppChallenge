using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    //Gameobject for pausemenu canvas
    public GameObject pausecanvas;
    public GameObject HUDcanvas;
    //Are you sure you want to quit options
    public GameObject QuitButtonTitle;
    public GameObject QuitButtonNo;
    public GameObject QuitButtonYes;
    //pause menu buttons and title
    public GameObject ResumeButton;
    public GameObject QuitButton;
    public GameObject Title;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Resume Game
    public void Resume()
    {
        Time.timeScale = 1;
        HUDcanvas.gameObject.SetActive(true);
        pausecanvas.gameObject.SetActive(false);
        GameObject.Find("HUD").GetComponent<HUDController>().Paused = false;
    }
    //Button to open Quit Options (Are you sure)
    public void QuitButtonCanvas()
    {
        QuitButtonTitle.gameObject.SetActive(true);
        QuitButtonNo.gameObject.SetActive(true);
        QuitButtonYes.gameObject.SetActive(true);
        ResumeButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
    }
    //Quit Options Button yes
    public void QuitYesButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        GameObject.Find("HUD").GetComponent<HUDController>().Paused = false;
    }
    public void QuitNoButton()
    {
        QuitButtonTitle.gameObject.SetActive(false);
        QuitButtonNo.gameObject.SetActive(false);
        QuitButtonYes.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
    }
}
