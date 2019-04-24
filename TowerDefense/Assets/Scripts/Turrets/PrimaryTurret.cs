using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class PrimaryTurret : MonoBehaviour
{

    [Header("Properties")]
    public int level = 1;
    public float range = 10f;
    public float attackSpeed = 20f;
    public float attackStrength = 2f;

    [Header("Transforms")]
    public Transform rotatingPart;
    public Transform attackPoint;

    [Header("Prfabs")]
    public GameObject bulletPrefab;

    protected GameObject target;
    protected string targetTag = "enemy";
    protected float attackCountdown = 0f;
    protected float rotateSpeed = 10f;



    // Start is called before the first frame update
    void Start()
    {
        this.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        this.OnUpdate();
    }

    void OnMouseEnter()
    {
        this.ShowRange();
    }

    void OnMouseExit()
    {
        this.HideRange();
    }

    protected void OnStart()
    {
        InvokeRepeating("UpdateTargets", 0f, 0.5f);
    }

    protected void OnUpdate()
    {
        UpdateView();

        if (attackCountdown <= 0f && target != null)
        {
            Shoot();
            attackCountdown = 1f / attackSpeed;
        }

        attackCountdown -= Time.deltaTime;
    }

    protected void UpdateTargets()
    {
        Vector3 towerPosition = this.transform.position;
        var enemiesInRange = this.GetEnemiesInRange(towerPosition, this.range);
        if(enemiesInRange.Any())
        {
            this.target = enemiesInRange.OrderBy(e => Vector3.Distance(towerPosition, e.transform.position)).First();
        }
        else
        {
            this.target = null;
        }
    }

    protected IEnumerable<GameObject> GetEnemiesInRange(Vector3 towerPosition, float range)
    {
        List<GameObject> allEnemies = GameObject.FindGameObjectsWithTag(this.targetTag).ToList<GameObject>();
        return allEnemies.Where(e => Vector3.Distance(towerPosition, e.transform.position) < range);
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

    protected virtual void UpdateView()
    {
        if(this.target)
        {
            Vector3 directionVector = this.target.transform.position - this.transform.position;
            Quaternion fromQuaterion = this.rotatingPart.rotation;
            Quaternion toQuaternion = Quaternion.LookRotation(directionVector);
            this.rotatingPart.rotation = Quaternion.RotateTowards(fromQuaterion, toQuaternion, this.rotateSpeed);
        }
    }

    private void ShowRange()
    {
        Drawer.DrawCircleOnSurface(
            this.gameObject.GetComponent<LineRenderer>(),
            this.range,
            0.25f,
            Color.green);
    }

    private void HideRange()
    {
        Drawer.DrawEmpty(
            this.gameObject.GetComponent<LineRenderer>());
    }
}
