using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public GameObject camera_GameObject;

    public float xMax = 18.85f;
    public float yMax = 12.04f;
    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;
    bool isZooming;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManagerScript>().editMode == false)
        {
            if (Input.touchCount == 0 && isZooming)
            {
                isZooming = false;
            }

            if (Input.touchCount == 1)
            {
                if (!isZooming)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector2 NewPosition = GetWorldPosition();
                        Vector2 PositionDifference = NewPosition - StartPosition;
                        camera_GameObject.transform.Translate(-PositionDifference);
                        float x = Mathf.Clamp(camera_GameObject.transform.position.x, -xMax, xMax);
                        float y = Mathf.Clamp(camera_GameObject.transform.position.y, -yMax, yMax);
                        camera_GameObject.transform.position = new Vector3(x, y, camera_GameObject.transform.position.z);
                    }
                    StartPosition = GetWorldPosition();
                }
            }
            else if (Input.touchCount == 2)
            { 
                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    isZooming = true;

                    DragNewPosition = GetWorldPositionOfFinger(1);
                    Vector2 PositionDifference = DragNewPosition - DragStartPosition;

                    if (Vector2.Distance(DragNewPosition, Finger0Position) < DistanceBetweenFingers && camera_GameObject.GetComponent<Camera>().orthographicSize <= 5)
                    {
                        camera_GameObject.GetComponent<Camera>().orthographicSize += (PositionDifference.magnitude);
                        if (camera_GameObject.GetComponent<Camera>().orthographicSize >= 5)
                        {
                            camera_GameObject.GetComponent<Camera>().orthographicSize = 5;
                        }
                    }
                    if (Vector2.Distance(DragNewPosition, Finger0Position) >= DistanceBetweenFingers && camera_GameObject.GetComponent<Camera>().orthographicSize >= 1)
                    {
                        camera_GameObject.GetComponent<Camera>().orthographicSize -= (PositionDifference.magnitude);
                        if (camera_GameObject.GetComponent<Camera>().orthographicSize <= 1)
                        {
                            camera_GameObject.GetComponent<Camera>().orthographicSize = 1;
                        }
                    }

                    DistanceBetweenFingers = Vector2.Distance(DragNewPosition, Finger0Position);
                }
                DragStartPosition = GetWorldPositionOfFinger(1);
                Finger0Position = GetWorldPositionOfFinger(0);
            }
        }
    }

    Vector2 GetWorldPosition()
    {
        return camera_GameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetWorldPositionOfFinger(int FingerIndex)
    {
        return camera_GameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(FingerIndex).position);
    }
}