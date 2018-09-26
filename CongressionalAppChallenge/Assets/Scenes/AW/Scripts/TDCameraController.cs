using UnityEngine;

public class TDCameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float panBorderThickness = 20f;
    public Vector2 panLimit;

    //zoom values
    public float zoomSpeed = 4f;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;
    private float targetOrtho;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {
        /*if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }*/


        Vector2 pos = transform.position;

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        #region PC Camera Controls
        //commented out border camera movement for now
        //mouse.position is measured from bottom left corner of screen
        if (Input.GetKey("w") /*|| Input.mousePosition.y >= Screen.height - panBorderThickness*/)
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") /*|| Input.mousePosition.y <= panBorderThickness*/)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") /*|| Input.mousePosition.x >= Screen.width - panBorderThickness*/)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") /*|| Input.mousePosition.x <= panBorderThickness*/)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float zoom = Input.GetAxis("Mouse ScrollWheel");
        if (zoom != 0.0f)
        {
            targetOrtho -= zoom * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        #endregion
#else
        #region Mobile Camera Controls
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

            targetOrtho += deltaMagDiff * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
            return;
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            pos.x = pos.x + -touchDeltaPosition.x * Time.deltaTime;
            pos.y = pos.y + -touchDeltaPosition.y * Time.deltaTime;
        }
        #endregion
#endif
        //LIMIT CAMERA MOVEMENT
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        //Move camera
        transform.position = new Vector3(pos.x, pos.y, -10);
    }

}
