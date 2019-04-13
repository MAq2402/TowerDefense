using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class PrimaryTurret : MonoBehaviour
{

    [Header("Properties")]
    public int level = 1;
    public float range = 10f;
    public float attackSpeed = 20f;
    private float attackCountdown = 0f;
    public float attackStrength = 2f;
    
    public GameObject target;
    public string targetTag = "enemy";

    public Transform partToRotate;
    public float rotateSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTargets", 0f, 0.5f);
    }

    void ShowRange()
    {
        Drawer.DrawCircleOnSurface(
            this.gameObject.GetComponent<LineRenderer>(),
            this.range,
            0.25f,
            Color.green);
    }

    void HideRange()
    {
        Drawer.DrawEmpty(
            this.gameObject.GetComponent<LineRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateView();

        if(attackCountdown <= 0f && target !=null)
        {
            Shoot();
            attackCountdown = 1f / attackSpeed;
        }

        attackCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bulletGO = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.SetTarget(target?.transform);
        }
    }

    void UpdateTargets()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(this.targetTag);
        Vector3 myPosition = this.transform.position;
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(myPosition, enemy.transform.position);
            if(distanceToEnemy <= shortestDistance)
            {
                nearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }

        if(nearestEnemy && shortestDistance <= this.range)
        {
            this.target = nearestEnemy;
        }
        else
        {
            this.target = null;
        }
    }

    void UpdateView()
    {
        if(this.target)
        {
            Vector3 direction = this.target.transform.position - this.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(
                this.partToRotate.rotation,
                lookRotation,
                Time.deltaTime * this.rotateSpeed
                ).eulerAngles;

            this.partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

    }

    void Attack()
    {

    }

    void OnMouseEnter()
    {
        this.ShowRange();
    }

    void OnMouseExit()
    {
        this.HideRange();
    }
}
