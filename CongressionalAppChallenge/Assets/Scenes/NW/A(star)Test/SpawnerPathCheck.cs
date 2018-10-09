using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPathCheck : MonoBehaviour {

    public Transform target;
    public bool foundPathOut;

    void Update ()
    {
        //PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            foundPathOut = true;
        }

        else
        {
            foundPathOut = false;
        }
    }
}
