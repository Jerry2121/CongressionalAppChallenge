using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public GameObject camera_GameObject;

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    Vector3 maxCameraMove = new Vector3(-14.5f, 9.5f, 0);
    private static readonly float[] BoundsX = new float[] { -14.5f, 14.5f };
    private static readonly float[] BoundsY = new float[] { -9.5f, 9.5f };
        private static readonly float[] ZoomBounds = new float[] { 1f, 5f };
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
                    Vector3 pos = transform.position;
                    pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
                    // pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
                    pos.y = Mathf.Clamp(transform.position.y, BoundsY[0], BoundsY[1]);
                    transform.position = pos;
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector2 NewPosition = GetWorldPosition();
                        Vector2 PositionDifference = NewPosition - StartPosition;
                        camera_GameObject.transform.Translate(-PositionDifference);
                       /* if(Mathf.Abs(camera_GameObject.transform.position.x) > maxCameraMove.x)
                        {
                            var foo = camera_GameObject.transform.position;
                            if (camera_GameObject.transform.position.x < 0)
                            {
                                foo.x = -maxCameraMove.x;
                            }
                            else
                            {
                                foo.x = maxCameraMove.x;
                            }
                            camera_GameObject.transform.position = foo;
                        }
                        if (Mathf.Abs(camera_GameObject.transform.position.y) > maxCameraMove.y)
                        {
                            var foo = camera_GameObject.transform.position;
                            if (camera_GameObject.transform.position.y < 0)
                            {
                                foo.y = -maxCameraMove.y;
                            }
                            else
                            {
                                foo.y = maxCameraMove.y;
                            }
                            camera_GameObject.transform.position = foo;
                        }*/
                    }
                    StartPosition = GetWorldPosition();
                }
            }
            else if (Input.touchCount == 2)
            {
                ZoomCamera(0, DistanceBetweenFingers);
                if (Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    isZooming = true;

                    DragNewPosition = GetWorldPositionOfFinger(1);
                    Vector2 PositionDifference = DragNewPosition - DragStartPosition;

                    if (Vector2.Distance(DragNewPosition, Finger0Position) < DistanceBetweenFingers)
                        camera_GameObject.GetComponent<Camera>().orthographicSize += (PositionDifference.magnitude);

                    if (Vector2.Distance(DragNewPosition, Finger0Position) >= DistanceBetweenFingers)
                        camera_GameObject.GetComponent<Camera>().orthographicSize -= (PositionDifference.magnitude);

                    DistanceBetweenFingers = Vector2.Distance(DragNewPosition, Finger0Position);
                }
                DragStartPosition = GetWorldPositionOfFinger(1);
                Finger0Position = GetWorldPositionOfFinger(0);
            }
        }
    }

    void ZoomCamera(float offset, float speed)
    {
        if (offset == 0)
        {
            return;
        }
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
        // cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
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