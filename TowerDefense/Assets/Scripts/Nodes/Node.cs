using Assets.Scripts.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * Node class represents single plate of ground in main scene 
 */
public class Node : MonoBehaviour
{
    public Vector3 placementOffset;

    [Header("Optional")]
    public GameObject turret;

    private Builder builder;
    private SkillManager skillManager;

    /* Author: Bartłomiej Krasoń */
    void Start()
    {
        turret = null;
        builder = Builder.Instance;
    }

    /* Author: Bartłomiej Krasoń */
    void OnMouseDown()
    {
        if(builder.TurretToBuildSelected)
        {
            PlaceTurret();
        }
    }

    /* Author: Bartłomiej Krasoń */
    void OnMouseEnter()
    {
        if (builder.TurretToBuildSelected)
        {
            builder.ShowTurretPrototypeOn(this);
        }
    }

    /* Author: Bartłomiej Krasoń */
    void OnMouseExit()
    {
        if (builder.TurretToBuildSelected)
        {
            builder.HideTurretPrototypeOn(this);
        }
    }

    /* Author: Bartłomiej Krasoń */
    public Vector3 GetPlacementPosition()
    {
        return this.transform.position + this.placementOffset;
    }

    /* Author: Bartłomiej Krasoń */
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
