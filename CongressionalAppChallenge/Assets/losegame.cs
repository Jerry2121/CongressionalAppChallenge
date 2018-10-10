using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class losegame : MonoBehaviour {
    public GameObject WaveCountText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        WaveCountText.GetComponent<TextMeshProUGUI>().text = "You got to wave: " + PlayerPrefs.GetInt("WaveCountNum");
    }
}
