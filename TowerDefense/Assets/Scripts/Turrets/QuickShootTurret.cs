using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * QuickShootTurret class represents specific data/actions for Quick Shoot Tower 
 */
public class QuickShootTurret : PrimaryTurret
{
    [Header("QuickShootTurret specifications")]
    public Transform attackPointLeft;

    private bool chooseRightCannon = true;

    public override int Cost { get; set; } = 150;

    /* Author: Bartłomiej Krasoń */
    void Start()
    {
        base.OnStart();
    }

    /* Author: Bartłomiej Krasoń */
    void Update()
    {
        base.OnUpdate();
    }

    protected override void Shoot()
    {
        GameObject projectileGO;
        if (chooseRightCannon)
        {
            projectileGO = Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
            chooseRightCannon = false;
        }
        else
        {
            projectileGO = Instantiate(projectilePrefab, attackPointLeft.position, attackPointLeft.rotation);
            chooseRightCannon = true;
        }
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.SetStrengthRatio(attackStrengthRatio);
            projectile.SetTarget(target?.transform);
        }
    }
}
