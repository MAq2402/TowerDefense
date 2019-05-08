using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float spawnCounter = 2f;
    public float spawnBreak = 15f;
    public int enemyCounter = 0;
    public int wavesQuantity = 3;
    public Dictionary<string, int> waves;

    private void Start()
    {
        waves = new Dictionary<string, int>();
        waves.Add("guardian", 3);
        waves.Add("warrior", 3);
        waves.Add("robot", 1);
        waves.Add("scout", 5);
    }

    void Update()
    {   
            if (spawnCounter <= 0 && wavesQuantity > 0)
            {
                StartCoroutine(SpanWave());
                spawnCounter = spawnBreak;
            wavesQuantity--;
            }
            spawnCounter -= Time.deltaTime;
    }

    public IEnumerator SpanWave()
    {

        foreach (KeyValuePair<string, int> entry in waves)
        {
            for (int i = 0; i < entry.Value; i++)
            {
                ObjectPooler.Instance.SpawnFromPool(entry.Key, transform.position, Quaternion.identity);
                enemyCounter++;
                yield return new WaitForSeconds(0.5f);
            }

        }
    }


}
