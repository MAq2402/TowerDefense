using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;

public class LaserBeam : Projectile
{
    private bool frameFlag = false;
    // Update is called once per frame
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
