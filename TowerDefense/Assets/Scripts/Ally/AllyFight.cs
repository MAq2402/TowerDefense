using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ally
{
    /*
        * Author: Michał Miciak
        * AllyFight is responsible for managing ally fights:
    */
    public class AllyFight : MonoBehaviour
    {
        public int allyHealth;
        private int allyStartHealth;
        public Image helthBar;
        public float attackRatio;
        private int healthLoss = 10;
        private GameObject enemy;
        private EnemyHealth enemyHealth;
        private EnemyMovement enemyMovement;
        private Collider allyCollider;
        private Animator animator;

        public void Start()
        {
            allyStartHealth = allyHealth;
        }
        /*
            * Author: Michał Miciak
        */
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

        /*
            * Author: Michał Miciak
         */
        private void StartAnimating()
        {
            animator = gameObject.GetComponent<Animator>();
            animator.enabled = true;
            animator.SetTrigger("Aiming");
            animator.SetTrigger("Fire");
        }

        /*
           * Author: Michał Miciak
        */
        private void Update()
        {
            if (enemy != null && enemyHealth)
            {
                FaceTowardsEnemy();
                allyHealth -= healthLoss;
                helthBar.fillAmount =(float) allyHealth / allyStartHealth;
                enemyHealth.DecreaseHealthBySpecificRatio(attackRatio);
                allyCollider.enabled = true;
            }
            else if (animator != null)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Aiming"))
                {
                    animator.ResetTrigger("Aiming");
                }

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
                {
                    animator.ResetTrigger("Fire");
                }
            }

            if (allyHealth <= 0)
            {
                enemyMovement.StopFight();
                gameObject.SetActive(false);
            }
        }

        /*
           * Author: Michał Miciak
        */
        private void FaceTowardsEnemy()
        {
            var targetRotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1);
        }
    }
}
