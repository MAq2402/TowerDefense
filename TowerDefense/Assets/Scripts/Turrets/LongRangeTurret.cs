﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * LongRangeTurret class represents specific data/actions for Long Range Tower 
 */
public class LongRangeTurret : PrimaryTurret
{
    [Header("LongRangeTurret specifications")]
    public Transform verticalRotatingPart;

    public override int Cost { get; set; } = 200;

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
        if (this.target)
        {
            //rotate horizontal
            Vector3 directionVector = this.targetCenter- this.transform.position;
            Quaternion fromQuaterion = this.rotatingPart.rotation;
            Quaternion toQuaternion = Quaternion.LookRotation(directionVector);
            var rotationAnglesHorizontal = Quaternion.RotateTowards(fromQuaterion, toQuaternion, this.rotateSpeed).eulerAngles;
            this.rotatingPart.rotation = Quaternion.Euler(0.0f, rotationAnglesHorizontal.y, 0.0f);

            //rotate vertical
            Vector3 directionVectorVertical = this.targetCenter - this.verticalRotatingPart.transform.position;
            Quaternion fromQuaternionVerical = this.verticalRotatingPart.rotation;
            Quaternion toQuaternionVertical = Quaternion.LookRotation(directionVectorVertical);
            var rotationAnglesVertical = Quaternion.RotateTowards(fromQuaternionVerical, toQuaternionVertical, this.rotateSpeed*10.0f).eulerAngles;
            this.verticalRotatingPart.rotation = Quaternion.Euler(90.0f + rotationAnglesVertical.x, rotationAnglesHorizontal.y, 0.0f);            
        }
    }
}
