using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ScreenResolution : MonoBehaviour {
    
    private PixelPerfectCamera pixelPerfectCamera;

	// Use this for initialization
	void Start () {
        pixelPerfectCamera = gameObject.GetComponent<PixelPerfectCamera>();

        Debug.Log(Screen.currentResolution.width);
        Debug.Log(Screen.currentResolution.height);

        pixelPerfectCamera.refResolutionX = Screen.currentResolution.width / 2;
        pixelPerfectCamera.refResolutionY = Screen.currentResolution.height / 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
