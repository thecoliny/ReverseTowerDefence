using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPan : MonoBehaviour
{
    Vector3 touchStart;
    Vector3 twoFingerTouchStart;
    public float zoomOutMin = 1f;
    public float zoomOutMax = 7.5f;
    public float levelZMin = -0.5f;
    public float levelXMin = -5.5f;
    public float levelZMax = 14.5f;
    public float levelXMax = 19.5f;

    public float levelHeight;
    public float levelWidth;
    public float zoomSensitivity = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

        levelHeight = levelZMax - levelZMin;
        levelWidth = levelXMax - levelXMin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // 2 finger Panning:
            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                twoFingerTouchStart = Camera.main.ScreenToWorldPoint((touchZero.position + touchOne.position) / 2);
            }
            Vector3 twoFingerTouch = Camera.main.ScreenToWorldPoint(((touchZero.position + touchOne.position) / 2));
            Vector3 direction = twoFingerTouchStart - twoFingerTouch;
            touchStart = twoFingerTouch;

            pan(direction);



            // 2 finger Zooming:

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;


            zoom(difference * zoomSensitivity);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pan(direction);
            }
            zoom(Input.GetAxis("Mouse ScrollWheel"));
        }

    }

    private void pan(Vector3 direction)
    {
        float zMin = Camera.main.orthographicSize + levelZMin;
        float zMax = levelZMax - Camera.main.orthographicSize;

        float xMin = Camera.main.aspect * Camera.main.orthographicSize + levelXMin;
        float xMax = levelXMax - Camera.main.aspect * Camera.main.orthographicSize;

        Vector3 currentCameraPos = Camera.main.transform.position;
        Vector3 newCameraPos = new Vector3(Mathf.Clamp(currentCameraPos.x + direction.x, xMin, xMax),
                                           currentCameraPos.y,
                                           Mathf.Clamp(currentCameraPos.z + direction.z, zMin, zMax));

        Camera.main.transform.position = newCameraPos;
    }

    private void zoom(float increment)
    {
        float currentSize = Camera.main.orthographicSize;
        float newSize = Camera.main.orthographicSize - increment;
        Vector3 cameraPos = Camera.main.transform.position;



        Camera.main.orthographicSize = Mathf.Clamp(newSize, zoomOutMin, zoomOutMax);
        float actualNewSize = Camera.main.orthographicSize;

        //z min
        if (cameraPos.z - actualNewSize < levelZMin)
        {
            cameraPos.z = levelZMin + Camera.main.orthographicSize;
        }
        //z max
        if (cameraPos.z + actualNewSize > levelZMax)
        {
            cameraPos.z = levelZMax - Camera.main.orthographicSize;
        }
        //x min
        if (cameraPos.x - Camera.main.aspect * actualNewSize < levelXMin)
        {
            cameraPos.x = levelXMin + Camera.main.aspect * Camera.main.orthographicSize;
        }
        //x max
        if (cameraPos.x + Camera.main.aspect * actualNewSize > levelXMax)
        {
            cameraPos.x = levelXMax - Camera.main.aspect * Camera.main.orthographicSize;
        }
        Camera.main.transform.position = cameraPos;
    }
}
