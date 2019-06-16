using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bartłomiej Krasoń
 * Projectile class represents base for projectiles which are fired by all turrets 
 */
public class Projectile : MonoBehaviour
{
    protected Transform target;
    public GameObject impactEffect;
    private float strengthRatio = 1.0f;
    protected Vector3 targetCenter;

    /* Author: Bartłomiej Krasoń */
    public void SetTarget(Transform target)
    {
        this.target = target;
        this.UpdateTargetCenter();
    }

    /* Author: Bartłomiej Krasoń */
    protected void UpdateTargetCenter()
    {
        var rend = this.target.GetComponent<Renderer>();
        if (rend == null)
        {
            rend = this.target.GetComponentInChildren<Renderer>();
        }
        this.targetCenter = rend.bounds.center;
    }

    /* Author: Bartłomiej Krasoń */
    public void SetStrengthRatio(float ratio)
    {
        this.strengthRatio = ratio;
    }

    /* Author: Michał Miciak */
    protected void Hit()
    {
        var effect = Instantiate(impactEffect, targetCenter, transform.rotation);
        Destroy(effect, 1f);

        target.gameObject.GetComponent<EnemyHealth>().DecreaseHealthBySpecificRatio(strengthRatio);

        Destroy(gameObject);
    }
}