using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * LauncherProjectile class represents specific projectile for: 
 *  MissileLauncherTurret
 */
public class LauncherProjectile : Projectile
{
    public float speed = 70f;
    private const float highRatio = 0.21f;
    private const float constFixedRotation = 0.5f;
    private const float speedUpRatio = 0.06f;

    private int missileUpDelayCount = 56;


    /* Author: Bartłomiej Krasoń */
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        var currentPosition = transform.position;

        if (missileUpDelayCount >= 0)
        {//move missile projectile up
            missileUpDelayCount--;
            transform.position += Vector3.up * highRatio;
        }
        else
        {//follow the target
            base.UpdateTargetCenter();
            var direction = this.targetCenter - transform.position;
            var distanceThisFrame = speed * Time.deltaTime;
            speed += speedUpRatio;

            if (direction.magnitude <= distanceThisFrame)
            {
                Hit();
                return;
            }

            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
            Quaternion rotationQuaternion = Quaternion.LookRotation(direction);
            rotationQuaternion.x += constFixedRotation;
            transform.rotation = rotationQuaternion;
        }
    }

    /* Author: Bartłomiej Krasoń */
    protected override void ApplySpecialEffect()
    {
        int stunDuration = 3;
        target.gameObject.GetComponent<EnemyMovement>().Stun(stunDuration);
    }
}
