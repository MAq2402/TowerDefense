using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public static int Money { get; private set; }
    // Start is called before the first frame update
    private Builder builder;

    public TurretPrototype primaryTurret;
    public TurretPrototype longRangeTurret;
    public TurretPrototype basicDefensiveTurret;
    public TurretPrototype superDefensiveTurret;
    public TurretPrototype laserTurret;

    public Button buyPrimaryTurretButton;
    public Button buyBasicDefensiveTurretButton;
    public Button buyLongRangeTurretButton;
    public Button buyQuickShootTurretButton;
    public Button buyMissileLauncherButton;
    public Button buyLaserTurretButton;
    public Button buySuperDefensiveTurretButton;
    public Text moneyAmountText;

    public void BuyPrimaryTurret()
    {
        builder.SetTurretToBuild(primaryTurret);
    }
    public void BuyBasicDefensiveTurret()
    {
        builder.SetTurretToBuild(basicDefensiveTurret);
    }
    public void BuySuperDefensiveTurret()
    {
        builder.SetTurretToBuild(superDefensiveTurret);
    }
    public void BuyLongRangeTurret()
    {
        builder.SetTurretToBuild(longRangeTurret);
    }

    /* Author: Bartłomiej Krasoń */
    public void BuyLaserTurret()
    {
        builder.SetTurretToBuild(laserTurret);
    }
    public static void AddMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Amount of money has negative value");
        }

        Money += amount;
    }

    public static void TakeMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Amount of money has negative value");
        }

        Money -= amount;
    }
    void Start()
    {
        Money = 100;
        builder = Builder.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        buyPrimaryTurretButton.interactable = CheckIfEnoughMoney(primaryTurret);
        buyBasicDefensiveTurretButton.interactable = CheckIfEnoughMoney(basicDefensiveTurret);
        buyLongRangeTurretButton.interactable = CheckIfEnoughMoney(longRangeTurret);
        buySuperDefensiveTurretButton.interactable = CheckIfEnoughMoney(superDefensiveTurret);
        buyQuickShootTurretButton.interactable = false;
        buyMissileLauncherButton.interactable = false;
        buyLaserTurretButton.interactable = CheckIfEnoughMoney(laserTurret);
        moneyAmountText.text = $"Money: {Money}$";
    }

    private bool CheckIfEnoughMoney(TurretPrototype turret)
    {
        return Money >= turret.cost;
    }
}
