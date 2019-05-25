using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class is responsible for managing enemies movement */
/*Author: Martyna Drabińska*/
public class EnemyMovement : MonoBehaviour
{

    public float enemySpeed = 5f;
    private Transform target;
    private int wayPointIndex = 0;
    private bool fights = false;

    /*Author: Martyna Drabińska*/
    void Start()
    {
        target = Way.wayPoints[0];
    }

    public void Fight(Transform target)
    {
        this.target = target;
        fights = true;
    }
    public void StopFight()
    {
        fights = false;
        target = Way.wayPoints[wayPointIndex];
        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            GetNextWayPoint();
        }
    }

    /*Authors: Martyna Drabińska, Michał Miciak */
    void Update()
    {
        if (fights)
        {
            FaceTowardsTarget();
        }
        else
        {
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = target.rotation;
            transform.rotation = rotation;
            transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) < 0.4f)
            {
                GetNextWayPoint();
            }
        }
    }

    private void FaceTowardsTarget()
    {
        if (target != null)
        {
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1);
        }

    }

    /*Author: Martyna Drabińska*/
    private void GetNextWayPoint()
    {
        if (wayPointIndex >= Way.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            GameObject.Find("GameMaster").GetComponent<PlayerStatistics>().TakeOneLive();
        }
        else
        {
            wayPointIndex++;
            target = Way.wayPoints[wayPointIndex];
        }
    }
}
