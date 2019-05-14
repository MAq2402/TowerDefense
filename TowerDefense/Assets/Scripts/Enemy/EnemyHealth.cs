using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float healthDecreaseSpeed = 5f;

    private const int moneyForKilling = 20;
    public void DecreaseHealth()
    {
        currentHealth -= healthDecreaseSpeed;
        if (currentHealth <= 0)
        {
            ShopMenu.AddMoney(moneyForKilling);
            Destroy(gameObject);
        }
    }

    public void DecreaseHealth(float ratio)
    {
        if (ratio > 1) ratio = 1.0f;
        currentHealth -= healthDecreaseSpeed * ratio;
        if (currentHealth <= 0)
        {
            ShopMenu.AddMoney(moneyForKilling);
            Destroy(gameObject);
        }
    }
}
