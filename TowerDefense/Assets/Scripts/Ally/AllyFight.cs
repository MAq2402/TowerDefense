using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ally
{
    public class AllyFight : MonoBehaviour
    {
        private double allyHealth = 500;
        private GameObject enemy;
        private EnemyHealth enemyHealth;
        private EnemyMovement enemyMovement;
        private Collider allyCollider;
        private Animator animator;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.GetComponents<EnemyMovement>().Any() && enemy == null)
            {
                enemy = collision.collider.gameObject;

                StartAnimating();

                enemyMovement = enemy.gameObject.GetComponent<EnemyMovement>();
                enemyMovement.Fight(transform);

                enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();

                allyCollider = GetComponent<Collider>();
                allyCollider.enabled = false;
            }

        }

        private void StartAnimating()
        {
            animator = gameObject.GetComponent<Animator>();
            animator.enabled = true;
            animator.SetTrigger("Aiming");
            animator.SetTrigger("Fire");
        }

        private void Update()
        {
            if(enemy != null)
            {
                FaceTowardsEnemy();
                allyHealth -= 10;
                enemyHealth.DecreaseHealth(0.1f);
                allyCollider.enabled = true;
            }
            else if(animator !=null)
            {
                if(animator.GetCurrentAnimatorStateInfo(0).IsName("Aiming"))
                {
                    animator.ResetTrigger("Aiming");
                }

                if(animator.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
                {
                    animator.ResetTrigger("Fire");
                }
            }

            if (allyHealth <= 0)
            {
                //Will work on that
                enemyMovement.StopFight();
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }

        private void FaceTowardsEnemy()
        {
            var targetRotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1);
        }
    }
}
