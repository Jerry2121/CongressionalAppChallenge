using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ScreenResolution : MonoBehaviour {
    
    private PixelPerfectCamera pixelPerfectCamera;
    [SerializeField]
    private int resoultionDivider = 2;

	// Use this for initialization
	void Start () {
        pixelPerfectCamera = gameObject.GetComponent<PixelPerfectCamera>();

        Debug.Log(Screen.currentResolution.width);
        Debug.Log(Screen.currentResolution.height);

        pixelPerfectCamera.refResolutionX = Screen.currentResolution.width / resoultionDivider;
        pixelPerfectCamera.refResolutionY = Screen.currentResolution.height / resoultionDivider;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
