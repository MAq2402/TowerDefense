using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 *  MissileLauncherTurret class represents specific data/actions for Missile Launcher 
 */
public class MissileLauncherTurret : PrimaryTurret
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
        base.OnUpdate();
    }

    /* Author: Bartłomiej Krasoń */
    protected override void UpdateView()
    {
        return;
    }
}
