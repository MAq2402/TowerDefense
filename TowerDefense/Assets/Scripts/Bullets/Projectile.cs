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
    private float specialEffectProbability = 0.0f;

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
    protected virtual void ApplySpecialEffect()
    {
        // default special effect is slow
        float slowDownRatio = 0.5f;
        target.gameObject.GetComponent<EnemyMovement>().SlowDown(slowDownRatio);
    }

    /* Author: Bartłomiej Krasoń */
    public void SetStrengthRatio(float ratio)
    {
        this.strengthRatio = ratio;
    }

    public void SetSpecialEffectProbability(float probability)
    {
        if (probability > 1.0f) probability = 1.0f;
        else if (probability < 0.0f) probability = 0.0f;

        this.specialEffectProbability = probability;
    }

    /* Author: Michał Miciak
     * Modified: Bartłomiej Krasoń */
    protected void Hit()
    {
        var currentSpecialEffectProbability = UnityEngine.Random.value;
        if (currentSpecialEffectProbability < this.specialEffectProbability)
        {
            Debug.Log(currentSpecialEffectProbability + " APPLIED");
            ApplySpecialEffect();
        }

        var effect = Instantiate(impactEffect, targetCenter, transform.rotation);
        Destroy(effect, 1f);

        target.gameObject.GetComponent<EnemyHealth>().DecreaseHealthBySpecificRatio(strengthRatio);

        Destroy(gameObject);
    }
}