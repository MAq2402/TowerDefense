using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
   * Author: Michał Miciak
   * ShopMenu is responsible for managing money, enabling/disabling buttons(depends if there is enough money), 
   * telling Builder class , which turret should be built.
*/
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

    /*
          * Author: Michał Miciak
    */
    public void BuyPrimaryTurret()
    {
        builder.SetTurretToBuild(primaryTurret);
    }

    /*
       * Author: Michał Miciak
    */
    public void BuyBasicDefensiveTurret()
    {
        builder.SetTurretToBuild(basicDefensiveTurret);
    }

    /*
       * Author: Michał Miciak
    */
    public void BuySuperDefensiveTurret()
    {
        builder.SetTurretToBuild(superDefensiveTurret);
    }

    /*
       * Author: Michał Miciak
    */
    public void BuyLongRangeTurret()
    {
        builder.SetTurretToBuild(longRangeTurret);
    }

    /* Author: Bartłomiej Krasoń */
    public void BuyLaserTurret()
    {
        builder.SetTurretToBuild(laserTurret);
    }

    /*
        * Author: Michał Miciak
    */
    public static void AddMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Amount of money has negative value");
        }

        Money += amount;
    }

    /*
       * Author: Michał Miciak
    */
    public static void TakeMoney(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Amount of money has negative value");
        }

        Money -= amount;
    }

    /*
       * Author: Michał Miciak
    */
    void Start()
    {
        Money = 100;
        builder = Builder.Instance;
    }

    /*
      * Author: Michał Miciak
    */
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

    /*
      * Author: Michał Miciak
    */
    private bool CheckIfEnoughMoney(TurretPrototype turret)
    {
        return Money >= turret.cost;
    }
}
