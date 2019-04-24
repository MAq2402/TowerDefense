using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;

public class TurretPrototypeRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Drawer.DrawCircleOnSurface(
            this.gameObject.GetComponent<LineRenderer>(),
            Builder.singleIstance.turretToBuild.range,
            0.25f,
            Color.green);
    }
}
