using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour {
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
    public void Pause()
    {
        Time.timeScale = 0;
        HUDcanvas.gameObject.SetActive(false);
        pausecanvas.gameObject.SetActive(true);
        QuitButtonTitle.gameObject.SetActive(false);
        QuitButtonNo.gameObject.SetActive(false);
        QuitButtonYes.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
    }
}
