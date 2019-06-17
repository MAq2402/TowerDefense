using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Skill
{
    /*Author: Michał Miciak*/
    /*Class represents skill that stunes all enemies in specified range and for specified time*/
    public class IceSkill : ISkill
    {
        private float range = 10;
        public int Cost => 50;
        public static int SharedCost { get; private set; } = 50;
        public static int Duration => 5;

        /*Author: Michał Miciak*/
        public void ApplySkill(Vector3 position)
        {

            var collisons = Physics.OverlapSphere(position, range);

            var enemies = collisons.Where(x => x.gameObject.GetComponents<EnemyMovement>().Any()).Select(x => x.gameObject);

            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().Stun(Duration);
            }
        }
    }
}
