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
    public void StopFight()
    {
        fights = false;
        target = Way.wayPoints[wayPointIndex];
        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            GetNextWayPoint();
        }
    }
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
        if(target !=null)
        {
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1);
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
