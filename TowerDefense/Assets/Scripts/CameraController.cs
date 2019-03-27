using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float yMin = 10f;
    public float yMax = 80f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * scrollSpeed * 1000 * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, yMin, yMax);
        transform.position = position;        
    }
}
