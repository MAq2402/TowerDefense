using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float enemySpeed = 3f;
    private Transform target;
    private int wayPointIndex = 0; 

    void Start()
    {
        target = Way.wayPoints[wayPointIndex];
    }

    
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            GetNextWayPoint();
        }

    }

    void GetNextWayPoint()
    {
        if (wayPointIndex >= Way.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = Way.wayPoints[wayPointIndex];
    }
}
