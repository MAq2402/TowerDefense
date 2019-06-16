using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*Author: Michał Miciak*/
public class FreezeEffect : MonoBehaviour
{
    private float effectRadius = 5f;
    private BoxCollider collider;
    private ICollection<GameObject> slowedEnemies = new List<GameObject>();
    private float slowPower = 0.5f;
    private int slowCounter = 3;

    /*Author: Michał Miciak*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponents<EnemyMovement>().Any())
        {
            var enemy = collision.collider.gameObject;
            if (!slowedEnemies.Contains(enemy))
            {
                var enemyMovement = enemy.GetComponent<EnemyMovement>();
                enemyMovement.SlowDown(slowPower);
                slowedEnemies.Add(enemy);
            }
        }
    }

    /*Author: Michał Miciak*/
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.size = collider.size *= effectRadius;
    }
}
