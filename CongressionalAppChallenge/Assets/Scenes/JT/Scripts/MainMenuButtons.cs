using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartB ()
    {
        SceneManager.LoadScene("JT");
    }
    public void QuitA ()
    {
        Application.Quit();
    }
}
