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

    public Button buyPrimaryTurretButton;
    public Button buyLongRangeTurretButton;
    public Button buyBasicDefensiveTurretButton;
    public Text moneyAmountText;
    public void BuyPrimaryTurret()
    {
        builder.SetTurretToBuild(primaryTurret);
        TakeMoney(primaryTurret.cost);
    }
    public void BuyBasicDefensiveTurret()
    {
        builder.SetTurretToBuild(basicDefensiveTurret);
        TakeMoney(longRangeTurret.cost);
    }
    public void BuyLongRangeTurretTurret()
    {
        builder.SetTurretToBuild(longRangeTurret);
        TakeMoney(basicDefensiveTurret.cost);
    }

    public bool EnoughMoneyForPrimaryTurret { get => Money >= primaryTurret.cost; }
    public bool EnoughMoneyForLongRangeTurret { get => Money >= longRangeTurret.cost; }
    public bool EnoughBasicDefensiveTurret { get => Money >= basicDefensiveTurret.cost; }

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
        moneyAmountText.text = $"Money: {Money}$";
    }
}
