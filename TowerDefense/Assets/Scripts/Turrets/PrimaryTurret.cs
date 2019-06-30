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
    public float range = 10f;
    public float attackSpeed = 20f;
    public float attackStrengthRatio = 0.1f;
    public float specialEffectProbability = 0.2f;
    public virtual int Cost { get; set; } = 100;
    public int shootsNumberForNextLevel = 100;
    protected int shootCounter = 0;

    [Header("Transforms")]
    public Transform rotatingPart;
    public Transform attackPoint;

    [Header("Prfabs")]
    public GameObject projectilePrefab;
    public GameObject levelUpPrefab;
    public GameObject[] changeColorParts;

    protected GameObject target;
    protected string targetTag = "enemy";
    protected Vector3 targetCenter;
    protected float attackCountdown = 0f;
    protected float rotateSpeed = 10f;
    protected bool secondLevel = false;



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

    public void LevelUp()
    {
        this.secondLevel = true;
        foreach(GameObject part in changeColorParts)
        {
            part.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        Vector3 instantinatePosition = transform.position;
        instantinatePosition.z -= 7.2f;
        instantinatePosition.y += gameObject.GetComponent<Collider>().bounds.size.y + 0.7f;
        var levelUpEffect = Instantiate(levelUpPrefab, instantinatePosition, Quaternion.identity);
        Destroy(levelUpEffect, 3.2f);
    }

    /* Author: Bartłomiej Krasoń */
    protected void OnStart()
    {
        InvokeRepeating("UpdateTargets", 0f, 0.5f);
        this.secondLevel = false;
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

    private void SetTargetCenter()
    {
        var rend = this.target.GetComponent<Renderer>();
        if (rend == null)
        {
            rend = this.target.GetComponentInChildren<Renderer>();
        }
        this.targetCenter = rend.bounds.center;
    }

    /* Author: Bartłomiej Krasoń */
    protected void UpdateTargets()
    {
        Vector3 towerPosition = this.transform.position;
        var enemiesInRange = this.GetEnemiesInRange(towerPosition, this.range);
        if (enemiesInRange.Any())
        {
            this.target = enemiesInRange.OrderBy(e => Vector3.Distance(towerPosition, e.transform.position)).First();
            this.SetTargetCenter();
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
    protected virtual void Shoot()
    {
        if(shootCounter < shootsNumberForNextLevel)
        {
            shootCounter++;
        }
        else
        {
            if (!secondLevel)
            {
                LevelUp();
            }
        }

        var projectileGO = Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        
        if (projectile != null)
        {
            projectile.SetStrengthRatio(attackStrengthRatio);
            projectile.SetTarget(target?.transform);
            if (secondLevel) projectile.SetSpecialEffectProbability(specialEffectProbability);
        }
    }

    /* Author: Bartłomiej Krasoń */
    protected virtual void UpdateView()
    {
        if (this.target)
        {
            Vector3 directionVector = this.targetCenter - this.transform.position;
            Quaternion fromQuaterion = this.rotatingPart.rotation;
            Quaternion toQuaternion = Quaternion.LookRotation(directionVector);
            var rotationAnglesHorizontal = Quaternion.RotateTowards(fromQuaterion, toQuaternion, this.rotateSpeed).eulerAngles;
            this.rotatingPart.rotation = Quaternion.Euler(rotationAnglesHorizontal.x, rotationAnglesHorizontal.y, 0.0f);
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
