using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is responsilble for managing enemies health */
/*Author: Martyna Drabińska, Michał Miciak*/
public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public float healthDecreaseSpeed = 5f;
    public Image healthBar;

    private const int moneyForKilling = 20;

    /*Author: Martyna Drabińska*/
    private void Start()
    {
        currentHealth = maxHealth;
    }

    /* Author: Bartłomiej Krasoń */
    public void DecreaseHealthBySpecificRatio(float ratio)
    {
        currentHealth -= healthDecreaseSpeed * ratio;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    /* Author: Michał Miciak */
    public void DecreaseHealthByAmount(float amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }
    /* Author: Michał Miciak */
    private void KillEnemy()
    {
        ShopMenu.AddMoney(moneyForKilling);
        Destroy(gameObject);
        PlayerStatistics.increaseKilledEnemies();
    }
    /* Author: Michał Miciak */
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
