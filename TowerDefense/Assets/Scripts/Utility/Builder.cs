using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public static Builder Instance;

    private TurretPrototype turretToBuild;

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

    public void SetTurretToBuild(TurretPrototype turret)
    {
        turretToBuild = turret;
    }

    public void ResetTurretToBuild()
    {
        turretToBuild = null;
    }

    public bool TurretToBuildSelected { get { return this.turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (TurretToBuildSelected)
        {
            HideTurretPrototypeOn(node);
            node.turret = (GameObject)Instantiate(turretToBuild.turretPrefab, node.GetPlacementPosition(), Quaternion.identity);
            ResetTurretToBuild();
        }
        else
        {
            Debug.LogWarning("Cannot build. None turret selected. TODO: display info for player");
        }
   
    }

    public void ShowTurretPrototypeOn(Node node)
    {
        if (TurretToBuildSelected)
        {
            node.turret = (GameObject)Instantiate(turretToBuild.turretPrototypePrefab, 
                                                  node.GetPlacementPosition(), 
                                                  Quaternion.identity);
        }
       
    }

    public void HideTurretPrototypeOn(Node node)
    {
        if (TurretToBuildSelected)
        {
            Destroy(node.turret);
        }
    }

}
