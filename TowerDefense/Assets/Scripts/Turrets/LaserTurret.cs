using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : PrimaryTurret
{
    [Header("LaserTurret specifications")]
    public GameObject laserBeamPrefab;

    public override int Cost { get; set; } = 200;

    void Start()
    { 
        base.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        base.UpdateView();
        
        if(target != null)
        {
            SetLaser();
        }
    }



    private void SetLaser()
    {
        var laserBeamGO = Instantiate(laserBeamPrefab, attackPoint.position, attackPoint.rotation);
        LaserBeam laserBeam = laserBeamGO.GetComponent<LaserBeam>();

        if (laserBeam != null)
        {
            laserBeam.SetStrengthRatio(attackStrengthRatio);
            laserBeam.SetTarget(target?.transform);
        }
    }
}
