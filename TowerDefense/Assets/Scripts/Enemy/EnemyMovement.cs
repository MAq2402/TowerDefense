using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* This class is responsible for managing enemies movement */
/*Author: Martyna Drabińska, Michał Miciak*/
public class EnemyMovement : MonoBehaviour
{
    private float baseEnemeySpeed;

    public float enemySpeed = 5f;
    private Transform target;
    private int wayPointIndex = 0;
    private bool fights = false;
    public Text speedText;
    public Text statusText;

    public bool IsSlowedDown { get; private set; }
    /*Author: Martyna Drabińska*/
    void Start()
    {
        baseEnemeySpeed = enemySpeed;
        target = Way.wayPoints[0];
        speedText.text = enemySpeed.ToString();
    }


    /*Author: Michał Miciak*/

    public void Fight(Transform target)
    {
        this.target = target;
        fights = true;
    }

    /*Author: Michał Miciak*/
    public void Stun(int time)
    {
        enemySpeed = 0;
        this.statusText.color = Color.red;
        this.statusText.text = "STUNNED";
        StartCoroutine(AmounntOfTimeInSlow(time));
    }

    /*Author: Michał Miciak*/
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

    /*Author: Michał Miciak*/
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

    /*Author: Michał Miciak*/

    public void SlowDown(float slowPower)
    {
        if(slowPower > 1 && slowPower < 0)
        {
            throw new ArgumentException("Slow power has wrong value");
        }
        IsSlowedDown = true;
        enemySpeed *= 1-slowPower;
        this.statusText.color = Color.magenta;
        this.statusText.text = "SLOVED";

        StartCoroutine(AmounntOfTimeInSlow(3));
    }
    /*Author: Michał Miciak*/
    private IEnumerator AmounntOfTimeInSlow(int time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            ResetSpeed();
        }
    }
    /*Author: Michał Miciak*/
    private void ResetSpeed()
    {
        enemySpeed = baseEnemeySpeed;
        this.statusText.text = "";
    }
}
