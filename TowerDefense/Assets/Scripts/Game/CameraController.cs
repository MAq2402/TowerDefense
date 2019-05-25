using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class is responsible for camera movement */
/*Author: Martyna Drabińska*/
public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float yMin = 10f;
    public float yMax = 80f;

    public float mDelta = 1f;
    public float mSpeed = 20f;


    /*Author: Martyna Drabińska*/
    void Update()
    {
        zoom();
        translate();
    }


    /*Author: Martyna Drabińska*/
    void zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * scrollSpeed * 1000 * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, yMin, yMax);
        transform.position = position;
    }


    /*Author: Martyna Drabińska*/
    void translate()
    {
        if (Input.mousePosition.x <= mDelta || Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * mSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width - mDelta || Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * mSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y <= mDelta || Input.GetKey("down"))
        {
            transform.Translate(Vector3.back * mSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y >= Screen.height - mDelta || Input.GetKey("up"))
        {
            transform.Translate(Vector3.forward * mSpeed * Time.deltaTime, Space.World);
        }
    }
}
