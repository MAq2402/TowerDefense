using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Class responsible for spawning enemies waves*/
/*Author: Martyna Drabińska*/
public class EnemySpawner : MonoBehaviour
{

    public float spawnCounter = 2f;
    public float spawnBreak = 15f;
    public static int enemyCounter;
    public int wavesQuantity = 3;
    public Dictionary<string, int> waves = new Dictionary<string, int>();
    public bool wavesStarted = false;
    public Button startButton;

    /*Author: Martyna Drabińska*/
    private void Start()
    {
        enemyCounter = 0;
        waves.Clear();
        waves.Add("guardian", 3);
        waves.Add("warrior", 3);
        waves.Add("robot", 1);
        waves.Add("scout", 5);

        foreach (KeyValuePair<string, int> entry in waves)
        {
            enemyCounter += entry.Value;
        }
        enemyCounter *= wavesQuantity;
    }

    /*Author: Martyna Drabińska*/
    void Update()
    {
        if (wavesStarted)
        {
            if (spawnCounter <= 0 && wavesQuantity > 0)
            {
                StartCoroutine(SpanWave());
                spawnCounter = spawnBreak;
                wavesQuantity--;
            }
            spawnCounter -= Time.deltaTime;
        }
        
    }

    /*Author: Martyna Drabińska*/
    public IEnumerator SpanWave()
    {

        foreach (KeyValuePair<string, int> entry in waves)
        {
            for (int i = 0; i < entry.Value; i++)
            {
                ObjectPooler.Instance.SpawnFromPool(entry.Key, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }

        }
    }

    /*Author: Martyna Drabińska*/
    public static bool CheckIfGameEnd()
    {
        if (enemyCounter <= PlayerStatistics.killedEnemies +
                (PlayerStatistics.playerLives - PlayerStatistics.currentLives))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*AuthorL Martyna Drabińska*/
    public void startWaves()
    {
        wavesStarted = true;
        Destroy(startButton.gameObject);
    }
}
