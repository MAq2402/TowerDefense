using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Michał Miciak
 * Bullet class represents specific projectile for: 
 *  PrimaryTurret, LongRangeTurret
 */
public class Bullet : Projectile
{
    public float speed = 70f;

    /* Author: Michał Miciak */
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        base.UpdateTargetCenter();
        var direction = this.targetCenter - transform.position;
        var distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            Hit();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
}
