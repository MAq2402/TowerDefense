using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 *  MissileLauncherTurret class represents specific data/actions for Missile Launcher 
 */
public class MissileLauncherTurret : PrimaryTurret
{
    [Header("MissileLauncherTurret specifications")]
    public Transform verticalRotatingPart;

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
        if (this.target)
        {
            //rotate horizontal
            Vector3 directionVector = this.target.transform.position - this.transform.position;
            Quaternion fromQuaterion = this.rotatingPart.rotation;
            Quaternion toQuaternion = Quaternion.LookRotation(directionVector);
            var rotationAnglesHorizontal = Quaternion.RotateTowards(fromQuaterion, toQuaternion, this.rotateSpeed).eulerAngles;
            this.rotatingPart.rotation = Quaternion.Euler(0.0f, rotationAnglesHorizontal.y, 0.0f);

            //rotate vertical
            Vector3 directionVectorVertical = this.target.transform.position - this.verticalRotatingPart.transform.position;
            Quaternion fromQuaternionVerical = this.verticalRotatingPart.rotation;
            Quaternion toQuaternionVertical = Quaternion.LookRotation(directionVectorVertical);
            var rotationAnglesVertical = Quaternion.RotateTowards(fromQuaternionVerical, toQuaternionVertical, this.rotateSpeed*10.0f).eulerAngles;
            this.verticalRotatingPart.rotation = Quaternion.Euler(90.0f + rotationAnglesVertical.x, rotationAnglesHorizontal.y, 0.0f);            
        }
    }
}
