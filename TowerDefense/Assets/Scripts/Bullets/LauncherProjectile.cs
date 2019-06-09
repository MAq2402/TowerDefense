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
    private Vector3 startPosition;
    private float highRatio = 0.5f;

    void Start()
    {
        startPosition = transform.position;
    }

    /* Author: Bartłomiej Krasoń */
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        var currentPosition = transform.position;

        var distanceFromTarget = Vector3.Distance(targetCenter, currentPosition);
        var distanceFromStartPosition = Vector3.Distance(currentPosition, startPosition);

        var direction = this.targetCenter - transform.position;
        if (distanceFromStartPosition < distanceFromTarget)
        {// before half-a-way
            direction.y += highRatio;
        }
        else
        {//after half-a-way
            direction.y -= highRatio;
        }
        var distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            Hit();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
}
