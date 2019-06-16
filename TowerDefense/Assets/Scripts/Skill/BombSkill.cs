using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Skill
{
    public class BombSkill : ISkill
    {
        private int power = 140;
        private int range = 3;

        public int Cost { get; private set; } = 70;
        public static int SharedCost { get; private set; }
        public BombSkill()
        {
            SharedCost = Cost;
        }
        public void ApplySkill(Vector3 position)
        {
            var collisons = Physics.OverlapSphere(position, range);

            var enemies = collisons.Where(x => x.gameObject.GetComponents<EnemyHealth>().Any()).Select(x => x.gameObject);

            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyHealth>().DecreaseHealthByAmount(power);
            }
        }
    }
}
