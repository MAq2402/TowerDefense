using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 placementOffset;

    [Header("Optional")]
    public GameObject turret;

    private Builder builder;
    private bool isShowingPrototype;
    // Start is called before the first frame update
    void Start()
    {
        turret = null;
        builder = Builder.singleIstance;
        isShowingPrototype = false;
    }

    void OnMouseDown()
    {
        if (isShowingPrototype)
        {
            builder.HideTurretPrototypeOn(this);
            this.PlaceTurret();
            isShowingPrototype = false;
        }
        else
        {
            Debug.LogError("Turret on this node already exists.");
            return;
        }
    }

    void OnMouseEnter()
    {
        if (turret == null)
        {
            builder.ShowTurretPrototypeOn(this);
            isShowingPrototype = true;
        }
    }

    void OnMouseExit()
    {
        if(isShowingPrototype)
        {
            builder.HideTurretPrototypeOn(this);
            isShowingPrototype = false;
        }
    }

    public Vector3 GetPlacementPosition()
    {
        return this.transform.position + this.placementOffset;
    }

    private void PlaceTurret()
    {
        if(builder == null)
        {
            Debug.LogError("Buider not created.");
            return;
        }
        builder.BuildTurretOn(this);
    }
}
