using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : PrimaryTurret
{
    public override int Cost { get; set; } = 300;

    void Start()
    {
        base.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        base.UpdateView();

        if (target != null)
        {
            this.Shoot();
        }
    }
}
