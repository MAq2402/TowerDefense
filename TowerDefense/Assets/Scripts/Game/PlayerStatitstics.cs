using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatitstics : MonoBehaviour
{
    public static int avalibleLives = 10;
    public static int playerLives = 10;
    public static int killedEnemies = 0;
 
    public void TakeOneLive()
    {
        if (playerLives > 0)
        {
            playerLives--;
            GameObject.Find("heart").GetComponentInChildren<Lives>().ChangeQuantity(playerLives);
        }
        else
        {
            GameObject.Find("GameMaster").GetComponent<LevelManager>().GameOver();
        }

    }

    public static void increaseKilledEnemies()
    {
        killedEnemies++;
        int enemiesCounter = GameObject.Find("GameMaster").GetComponent<EnemySpawner>().enemyCounter;
        Debug.Log(enemiesCounter);
        Debug.Log(killedEnemies + (avalibleLives - playerLives));
        if (enemiesCounter <= killedEnemies + (avalibleLives - playerLives))
        {
            GameObject.Find("GameMaster").GetComponent<LevelManager>().GameEnd(killedEnemies);
        }
    }
}
