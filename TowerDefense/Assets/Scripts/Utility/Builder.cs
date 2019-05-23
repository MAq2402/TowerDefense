using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * Builder class represents service which adds turrets at main scene 
 */
public class Builder : MonoBehaviour
{
    public static Builder Instance;

    private TurretPrototype turretToBuild;

    /* Author: Bartłomiej Krasoń */
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Error - More than one builder detected.");
        }
        else
        {
            Instance = this;
        }
    }

    /* Author: Bartłomiej Krasoń */
    public void SetTurretToBuild(TurretPrototype turret)
    {
        turretToBuild = turret;
    }

    /* Author: Bartłomiej Krasoń */
    public void ResetTurretToBuild()
    {
        turretToBuild = null;
    }

    /* Author: Bartłomiej Krasoń */
    public bool TurretToBuildSelected { get { return this.turretToBuild != null; } }

    /* Author: Bartłomiej Krasoń */
    public void BuildTurretOn(Node node)
    {
        if (TurretToBuildSelected)
        {
            HideTurretPrototypeOn(node);
            node.turret = (GameObject)Instantiate(turretToBuild.turretPrefab, node.GetPlacementPosition(), Quaternion.identity);
            ShopMenu.TakeMoney(turretToBuild.cost);
            ResetTurretToBuild();
        }
        else
        {
            Debug.LogWarning("Cannot build. None turret selected. TODO: display info for player");
        }
   
    }

    /* Author: Bartłomiej Krasoń */
    public void ShowTurretPrototypeOn(Node node)
    {
        if (TurretToBuildSelected)
        {
            node.turret = (GameObject)Instantiate(turretToBuild.turretPrototypePrefab, 
                                                  node.GetPlacementPosition(), 
                                                  Quaternion.identity);
        }
       
    }

    /* Author: Bartłomiej Krasoń */
    public void HideTurretPrototypeOn(Node node)
    {
        if (TurretToBuildSelected)
        {
            Destroy(node.turret);
        }
    }

}
