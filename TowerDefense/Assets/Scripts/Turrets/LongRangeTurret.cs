using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeTurret : PrimaryTurret
{
    // Start is called before the first frame update
    [Header("LongRangeTurret specifications")]
    public Transform verticalRotatingPart;

    void Start()
    {
        base.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        base.OnUpdate();
    }

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
