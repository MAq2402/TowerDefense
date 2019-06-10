using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Class responsible for managing basic player statistics like playerLives etc. */
/*Author: Martyna Drabińska*/
public class PlayerStatistics : MonoBehaviour
{
    public static int currentLives;
    public static int playerLives = 10;
    public static int killedEnemies;
    public Text livesQuantity;

    /*Author: Martyna Drabińska*/
    public void Start()
    {
        currentLives = playerLives;
        killedEnemies = 0;   
    }

    /*Author: Martyna Drabińska*/
    public void TakeOneLive()
    {
        if (currentLives > 0)
        {
            currentLives--;
            livesQuantity.text = currentLives.ToString();
            
            if (EnemySpawner.CheckIfLevelEnd())
            {
                GameObject.Find("GameMaster").GetComponent<SceneController>().LevelEnd();
            }
        }
        else
        {
            GameObject.Find("GameMaster").GetComponent<SceneController>().GameOver();
        }

    }

    /*Author: Martyna Drabińska*/
    public static void increaseKilledEnemies()
    {
        killedEnemies++;
        if (EnemySpawner.CheckIfLevelEnd())
        {
            GameObject.Find("GameMaster").GetComponent<SceneController>().LevelEnd();
        }
    }
}
