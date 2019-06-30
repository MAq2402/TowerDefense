using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevelUp : MonoBehaviour
{
    private Vector3 textMoveDirection = new Vector3(0.0f, 1.0f, 0.0f);
    private float moveSpeed = 0.5f;

    void Update()
    {
        var distanceThisFrame = moveSpeed * Time.deltaTime;
        transform.Translate(textMoveDirection * distanceThisFrame, Space.World);
    }

}
