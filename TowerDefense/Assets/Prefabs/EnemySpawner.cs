using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float spawnCounter = 3f;
    public float spawnBreak = 5f;
    public int enemyCounter = 0;

    void Update()
    {   
            if (spawnCounter <= 0)
            {
                StartCoroutine(SpanWave());
                spawnCounter = spawnBreak;
            }
            spawnCounter -= Time.deltaTime;
    }

    public IEnumerator SpanWave()
    {
        int enemyQuantity = Random.Range(1, 8);

        for (int i = 0; i < enemyQuantity; i++)
        {
            if (enemyCounter < ObjectPooler.Instance.poolDictionary["enemy"].Count)
            {
                ObjectPooler.Instance.SpawnFromPool("enemy", transform.position, Quaternion.identity);
                enemyCounter++;
                yield return new WaitForSeconds(0.5f);
            }  
        }
    }


}
