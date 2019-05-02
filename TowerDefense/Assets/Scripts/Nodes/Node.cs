using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 placementOffset;

    [Header("Optional")]
    public GameObject turret;

    private Builder builder;
    // Start is called before the first frame update
    void Start()
    {
        turret = null;
        builder = Builder.Instance;
    }

    void OnMouseDown()
    {
        if(builder.TurretToBuildSelected)
        {
            PlaceTurret();
        }
        //if (isShowingPrototype)
        //{
        //    builder.HideTurretPrototypeOn(this);
        //    this.PlaceTurret();
        //    isShowingPrototype = false;
        //}
        //else
        //{
        //    Debug.LogWarning("Turret on this node already exists.");
        //    return;
        //}
    }

    void OnMouseEnter()
    {
        if (builder.TurretToBuildSelected)
        {
            builder.ShowTurretPrototypeOn(this);
        }
    }

    void OnMouseExit()
    {
        if (builder.TurretToBuildSelected)
        {
            builder.HideTurretPrototypeOn(this);
        }
    }

    public Vector3 GetPlacementPosition()
    {
        return this.transform.position + this.placementOffset;
    }

    private void PlaceTurret()
    {
        if (builder == null)
        {
            Debug.LogError("Buider not created.");
            return;
        }
        builder.BuildTurretOn(this);
    }
}
