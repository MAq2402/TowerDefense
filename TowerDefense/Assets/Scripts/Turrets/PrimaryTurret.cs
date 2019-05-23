using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * PrimaryTurret class represents base data/actions for all towers
 *  it is also used as specific class (it means no special data/actions added) for Primary Tower 
 */
[RequireComponent(typeof(LineRenderer))]
public class PrimaryTurret : MonoBehaviour
{

    [Header("Properties")]
    public int level = 1;
    public float range = 10f;
    public float attackSpeed = 20f;
    public float attackStrengthRatio = 0.1f;
    public virtual int Cost { get; set; } = 100;

    [Header("Transforms")]
    public Transform rotatingPart;
    public Transform attackPoint;

    [Header("Prfabs")]
    public GameObject projectilePrefab;

    protected GameObject target;
    protected string targetTag = "enemy";
    protected float attackCountdown = 0f;
    protected float rotateSpeed = 10f;


    /* Author: Bartłomiej Krasoń */
    void Start()
    {
        this.OnStart();
    }

    /* Author: Bartłomiej Krasoń */
    void Update()
    {
        this.OnUpdate();
    }

    /* Author: Bartłomiej Krasoń */
    void OnMouseEnter()
    {
        this.ShowRange();
    }

    /* Author: Bartłomiej Krasoń */
    void OnMouseExit()
    {
        this.HideRange();
    }

    /* Author: Bartłomiej Krasoń */
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {//when right click
            Sell();
        }
    }

    /* Author: Bartłomiej Krasoń */
    protected void OnStart()
    {
        InvokeRepeating("UpdateTargets", 0f, 0.5f);
    }

    /* Author: Bartłomiej Krasoń */
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

    /* Author: Michał Miciak */
    private void Sell()
    {
        ShopMenu.AddMoney(Cost / 2);
        Destroy(gameObject);
    }

    /* Author: Bartłomiej Krasoń */
    protected void UpdateTargets()
    {
        Vector3 towerPosition = this.transform.position;
        var enemiesInRange = this.GetEnemiesInRange(towerPosition, this.range);
        if (enemiesInRange.Any())
        {
            this.target = enemiesInRange.OrderBy(e => Vector3.Distance(towerPosition, e.transform.position)).First();
        }
        else
        {
            this.target = null;
        }
    }

    /* Author: Bartłomiej Krasoń */
    protected IEnumerable<GameObject> GetEnemiesInRange(Vector3 towerPosition, float range)
    {
        List<GameObject> allEnemies = GameObject.FindGameObjectsWithTag(this.targetTag).ToList<GameObject>();
        return allEnemies.Where(e => Vector3.Distance(towerPosition, e.transform.position) < range);
    }

    /* Author: Michał Miciak */
    protected void Shoot()
    {
        var projectileGO = Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        
        if (projectile != null)
        {
            projectile.SetStrengthRatio(attackStrengthRatio);
            projectile.SetTarget(target?.transform);
        }
    }

    /* Author: Bartłomiej Krasoń */
    protected virtual void UpdateView()
    {
        if (this.target)
        {
            Vector3 directionVector = this.target.transform.position - this.transform.position;
            Quaternion fromQuaterion = this.rotatingPart.rotation;
            Quaternion toQuaternion = Quaternion.LookRotation(directionVector);
            this.rotatingPart.rotation = Quaternion.RotateTowards(fromQuaterion, toQuaternion, this.rotateSpeed);
        }
    }

    /* Author: Bartłomiej Krasoń */
    private void ShowRange()
    {
        Drawer.DrawCircleOnSurface(
            this.gameObject.GetComponent<LineRenderer>(),
            this.range,
            0.25f,
            Color.green);
    }

    /* Author: Bartłomiej Krasoń */
    private void HideRange()
    {
        Drawer.DrawEmpty(
            this.gameObject.GetComponent<LineRenderer>());
    }
}
