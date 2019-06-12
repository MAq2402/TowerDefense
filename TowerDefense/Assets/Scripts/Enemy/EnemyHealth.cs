using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is responsilble for managing enemies health */
/*Author: Martyna Drabińska*/
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
    public void DecreaseHealth(float ratio)
    {
        currentHealth -= healthDecreaseSpeed * ratio;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            ShopMenu.AddMoney(moneyForKilling);
            Destroy(gameObject);
            PlayerStatistics.increaseKilledEnemies();
        }
    }
}
