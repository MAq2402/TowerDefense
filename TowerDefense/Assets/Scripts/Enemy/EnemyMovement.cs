using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float enemySpeed = 5f;
    private Transform target;
    private int wayPointIndex = 0;
    private bool fights = false;

    void Start()
    {
        target = Way.wayPoints[0];
    }

    public void Fight(Transform target)
    {
        this.target = target;
        fights = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
    public void StopFight()
    {
        fights = false;
        target = Way.wayPoints[wayPointIndex];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = target.rotation;
        transform.rotation = rotation;
        transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.4f && !fights)
        {
            GetNextWayPoint();
        }

    }

    private void GetNextWayPoint()
    {
        if (wayPointIndex >= Way.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            GameObject.Find("GameMaster").GetComponent<PlayerStatitstics>().TakeOneLive();
        }
        else {
            wayPointIndex++;
            target = Way.wayPoints[wayPointIndex];
        }
    }
}
