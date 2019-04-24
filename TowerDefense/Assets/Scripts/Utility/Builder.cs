using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public static Builder singleIstance;

    public TurretPrototype turretToBuild;

    void Awake()
    {
        if (singleIstance != null)
        {
            Debug.LogError("Error - More than one builder detected.");
            return;
        }
        singleIstance = this;
    }

    public void SetTurretToBuild(TurretPrototype turret)
    {
        this.turretToBuild = turret;
    }

    public void ResetTurretToBuild()
    {
        this.turretToBuild = null;
    }

    public bool TurretToBuildSelected { get { return this.turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (this.turretToBuild == null)
        {
            Debug.LogWarning("Cannot build. None turret selected. TODO: display info for player");
            return;
        }
        node.turret = (GameObject)Instantiate(turretToBuild.turretPrefab, node.GetPlacementPosition(), Quaternion.identity);
    }

    public void ShowTurretPrototypeOn(Node node)
    {
        if (this.turretToBuild == null)
        {
            return;
        }
        node.turret = (GameObject)Instantiate(turretToBuild.turretPrototypePrefab, node.GetPlacementPosition(), Quaternion.identity);
    }

    public void HideTurretPrototypeOn(Node node)
    {
        if (this.turretToBuild == null)
        {
            return;
        }
        Destroy(node.turret);
    }

}
