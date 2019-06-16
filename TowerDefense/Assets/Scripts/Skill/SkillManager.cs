using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Skill
{
    public class SkillManager : MonoBehaviour
    {
        private LineRenderer lineRenderer;

        private ISkill selectedSkill;
        public GameObject empty;
        public GameObject explosionEffect;
        public Button explosionButton;

        private ParticleSystem explosionParticleSystem;

        public Text manaAmount;

        public int Mana { get; private set; } = 100;

        private void Awake()
        {
            StartCoroutine(UpdateMana());
            explosionParticleSystem = GetComponentInChildren<ParticleSystem>();
            explosionParticleSystem.Stop();
            Instantiate(empty);
        }
        public void OnExplosionClick()
        {
            selectedSkill = new BombSkill();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && selectedSkill != null)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    ApplySkill(hit);
                }
                selectedSkill = null;
            }

            if (Input.GetMouseButtonDown(1))
            {
                selectedSkill = null;
            }

            //if(selectedSkill != null)
            //{
            //    empty.transform.position = Input.mousePosition;
       
            //    Drawer.DrawCircleOnSurface(empty.GetComponent<LineRenderer>(), 200, 10, Color.green);
            //}

            manaAmount.text = $"Mana: {Mana}";

            explosionButton.interactable = CheckIfEnoughManaForSkill(BombSkill.SharedCost);
        }
        private void ApplySkill(RaycastHit hit)
        {
            selectedSkill.ApplySkill(hit.transform.position);
            Mana -= selectedSkill.Cost;
            explosionParticleSystem.transform.position = hit.transform.position;
            explosionParticleSystem.Play();
            StartCoroutine(StopExplosions());
        }
        private IEnumerator StopExplosions()
        {
            yield return new WaitForSeconds(explosionParticleSystem.main.duration);
            explosionParticleSystem.Stop();
        }

        private bool CheckIfEnoughManaForSkill(int cost)
        {
            return Mana >= cost;
        }

        private IEnumerator UpdateMana()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                if(Mana < 100)
                {
                    Mana += 1;
                }
            }
        }

 
    }
}
