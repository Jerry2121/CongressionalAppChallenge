using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class losegame : MonoBehaviour {
    public int Waves;
    public GameObject WaveCountText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("GameManager").GetComponent<GameManagerScript>().TownHallHP <= 0)
        {
            Waves = GameObject.Find("GameManager").GetComponent<SpawnerControl>().waveCount;
            WaveCountText.GetComponent<TextMeshProUGUI>().text = "You got to wave: " + Waves;
        }
	}
}
