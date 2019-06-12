using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Class responsible for spawning enemies waves*/
/*Author: Martyna Drabińska*/
public class EnemySpawner : MonoBehaviour
{

    private float spawnCounter = 2f;
    private float spawnBreak = 15f;
    public static int enemyCounter;
    int wavesQuantity;
    private int currentWaveNumber;
    List<Dictionary<string, int>> waves;
    private bool wavesStarted = false;
    public Button startButton;

    /*Author: Martyna Drabińska*/
    private void Start()
    {
        enemyCounter = 0;
        waves = LevelManager.levelFeatures[LevelManager.currentLevelNumber].levelWaves;
        wavesQuantity = waves.Count;
        currentWaveNumber = 0;
        foreach (Dictionary<string, int> singleWave in waves)
        {
            foreach (KeyValuePair<string, int> entry in singleWave)
            {
                enemyCounter += entry.Value;
            }
        }
    }

    /*Author: Martyna Drabińska*/
    void Update()
    {
        if (wavesStarted)
        {
            if (spawnCounter <= 0 && currentWaveNumber < wavesQuantity)
            {
                StartCoroutine(SpanWave());
                spawnCounter = spawnBreak;
                currentWaveNumber++;
            }
            spawnCounter -= Time.deltaTime;
        }
        
    }

    /*Author: Martyna Drabińska*/
    public IEnumerator SpanWave()
    {
        var currentWave = waves[currentWaveNumber];
        foreach (KeyValuePair<string, int> entry in currentWave)
        {
            for (int i = 0; i < entry.Value; i++)
            {
                ObjectPooler.Instance.SpawnFromPool(entry.Key, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.7f);
            }

        }
    }

    /*Author: Martyna Drabińska*/
    public static bool CheckIfLevelEnd()
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
