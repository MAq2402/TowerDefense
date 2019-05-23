using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;

/*
 * Author: Bartłomiej Krasoń
 * TurretPrototypeRange class provides needed action when instantiate turrets at main scene 
 */
public class TurretPrototypeRange : MonoBehaviour
{
    public float range;

    /* Author: Bartłomiej Krasoń */
    void Start()
    {
        Drawer.DrawCircleOnSurface(
            this.gameObject.GetComponent<LineRenderer>(),
            range,
            0.25f,
            Color.green);
    }
}
