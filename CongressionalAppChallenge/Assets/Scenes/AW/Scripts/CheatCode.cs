using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.KeypadMultiply))
        {
            Resources();
        }
	}
    public void Resources()
    {
        gameObject.GetComponent<GameManagerScript>().woodAcquired = 999;
        gameObject.GetComponent<GameManagerScript>().steelAcquired = 999;
        gameObject.GetComponent<GameManagerScript>().stoneAcquired = 999;
        gameObject.GetComponent<GameManagerScript>().oreAcquired = 999;
    }
}
