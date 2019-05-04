using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;

public class TurretPrototypeRange : MonoBehaviour
{
    public float prototypeRange;
    // Start is called before the first frame update
    void Start()
    {
        Drawer.DrawCircleOnSurface(
            this.gameObject.GetComponent<LineRenderer>(),
            prototypeRange,
            0.25f,
            Color.green);
    }
}
