﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float yMin = 10f;
    public float yMax = 80f;

    public float mDelta = 10f;
    public float mSpeed = 20f;

    public float rSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zoom();
        translate();
                 
    }

    void zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * scrollSpeed * 1000 * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, yMin, yMax);
        transform.position = position;
    }

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