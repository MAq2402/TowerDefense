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
    public TurretPrototype laserTurret;

    public Button buyPrimaryTurretButton;
    public Button buyBasicDefensiveTurretButton;
    public Button buyLongRangeTurretButton;
    public Button buyQuickShootTurretButton;
    public Button buyMissileLauncherButton;
    public Button buyLaserTurretButton;
    public Text moneyAmountText;

    public void BuyPrimaryTurret()
    {
        builder.SetTurretToBuild(primaryTurret);
    }
    public void BuyBasicDefensiveTurret()
    {
        builder.SetTurretToBuild(basicDefensiveTurret);
    }
    public void BuyLongRangeTurret()
    {
        builder.SetTurretToBuild(longRangeTurret);
    }
    public void BuyLaserTurret()
    {
        builder.SetTurretToBuild(laserTurret);
    }

    public bool EnoughMoneyForPrimaryTurret { get => Money >= primaryTurret.cost; }
    public bool EnoughMoneyForLongRangeTurret { get => Money >= longRangeTurret.cost; }
    public bool EnoughBasicDefensiveTurret { get => Money >= basicDefensiveTurret.cost; }
    public bool EnoughMoneyLaserTurret { get => Money >= laserTurret.cost; }

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
        buyPrimaryTurretButton.interactable = EnoughMoneyForPrimaryTurret;
        buyBasicDefensiveTurretButton.interactable = EnoughBasicDefensiveTurret;
        buyLongRangeTurretButton.interactable = EnoughMoneyForLongRangeTurret;
        buyQuickShootTurretButton.interactable = false;
        buyMissileLauncherButton.interactable = false;
        buyLaserTurretButton.interactable = EnoughMoneyLaserTurret;
        moneyAmountText.text = $"Money: {Money}$";
    }
}
