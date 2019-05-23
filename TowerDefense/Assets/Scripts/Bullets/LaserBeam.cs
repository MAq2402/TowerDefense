using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;

/*
 * Author: Bartłomiej Krasoń
 * LaserBeam class represents specific projectile for: 
 *  LaserTurret
 */
public class LaserBeam : Projectile
{
    private bool frameFlag = false;

    /* Author: Bartłomiej Krasoń */
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (!frameFlag)
        {
            DrawLaserBeam();
            frameFlag = true;
        }
        else
        {
            Hit();
        }
    }

    /* Author: Bartłomiej Krasoń */
    private void DrawLaserBeam()
    {
        Drawer.DrawEmpty(gameObject.GetComponent<LineRenderer>());
        Drawer.DrawLaserBeam(
            gameObject.GetComponent<LineRenderer>(),
            transform.position,
            targetCenter,
            0.2f,
            Color.red);
    }
}
