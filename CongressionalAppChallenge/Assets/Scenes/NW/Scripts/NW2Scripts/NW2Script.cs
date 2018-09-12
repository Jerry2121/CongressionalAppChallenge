using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW2Script : MonoBehaviour
{


    void OnMouseUpAsButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            // the object identified by hit.transform was clicked
            // do whatever you want
        }
    }
}
