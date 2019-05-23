using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * TurretPrototype class provides data needed to instantiate turrets at main scene 
 */
[System.Serializable]
public class TurretPrototype
{
    public GameObject turretPrefab;
    public GameObject turretPrototypePrefab;
    public int cost;
}
