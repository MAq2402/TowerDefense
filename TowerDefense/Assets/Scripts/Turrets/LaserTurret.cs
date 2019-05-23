using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * LaserTurret class represents specific data/actions for Laser Tower 
 */
public class LaserTurret : PrimaryTurret
{
    public override int Cost { get; set; } = 300;

    /* Author: Bartłomiej Krasoń */
    void Start()
    {
        base.OnStart();
    }

    /* Author: Bartłomiej Krasoń */
    void Update()
    {
        base.UpdateView();

        if (target != null)
        {
            this.Shoot();
        }
    }
}
