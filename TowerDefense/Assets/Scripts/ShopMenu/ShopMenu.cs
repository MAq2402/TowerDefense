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
    public TurretPrototype quickShootTurret;
    public TurretPrototype longRangeTurret;
    public TurretPrototype basicDefensiveTurret;
    public TurretPrototype superDefensiveTurret;
    public TurretPrototype laserTurret;
    public TurretPrototype missileLauncher;

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

    /* Author: Bartłomiej Krasoń */
    public void BuyQuickShootTurret()
    {
        builder.SetTurretToBuild(quickShootTurret);
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

    /* Author: Bartłomiej Krasoń */
    public void BuyMissileLauncher()
    {
        builder.SetTurretToBuild(missileLauncher);
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
        
        Money = LevelManager.levelFeatures[LevelManager.currentLevelNumber].startMoney;
        builder = Builder.Instance;

        foreach (string turretName in LevelManager.levelFeatures[LevelManager.currentLevelNumber].aditionalTurrets)
        {
            string buttonName = $"Canvas/ShopMenu/Buy{turretName}TurretButton";
            GameObject.Find(buttonName).SetActive(true);
           
        }
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
        buyQuickShootTurretButton.interactable = CheckIfEnoughMoney(quickShootTurret); ;
        buyMissileLauncherButton.interactable = CheckIfEnoughMoney(missileLauncher);
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
