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
using UnityEngine.EventSystems;

namespace Assets.Scripts.Skill
{
    /*Author: Michał Miciak*/
    /*Class manages skills*/
    public class SkillManager : MonoBehaviour
    {
        private ISkill selectedSkill;

        private ParticleSystem explosionParticleSystem;
        private ParticleSystem iceParticleSystem;

        public GameObject explosionEffect;
        public Button explosionButton;
        public Button iceButton;
        public Text manaAmount;

        public int Mana { get; private set; } = 100;

        /*Author: Michał Miciak*/
        private void Awake()
        {
            StartCoroutine(UpdateMana());
            explosionParticleSystem = GetComponentsInChildren<ParticleSystem>().First(x => x.name.Contains("Big"));
            explosionParticleSystem.Stop();
            iceParticleSystem = GetComponentsInChildren<ParticleSystem>().First(x => x.name.Contains("Plasma"));
            iceParticleSystem.Stop();
        }
        /*Author: Michał Miciak*/
        public void OnExplosionClick()
        {
            selectedSkill = new BombSkill();
            explosionButton.GetComponentInParent<Image>().color = Color.green;
        }
        /*Author: Michał Miciak*/
        public void OnIceClick()
        {
            selectedSkill = new IceSkill();
            iceButton.GetComponentInParent<Image>().color = Color.green;
        }
        /*Author: Michał Miciak*/
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
                ResetButtonsColor(explosionButton);
                ResetButtonsColor(iceButton);
            }

            manaAmount.text = $"Mana: {Mana}%";

            explosionButton.interactable = CheckIfEnoughManaForSkill(BombSkill.SharedCost);
            iceButton.interactable = CheckIfEnoughManaForSkill(IceSkill.SharedCost);
        }
        /*Author: Michał Miciak*/
        private void ApplySkill(RaycastHit hit)
        {
            selectedSkill.ApplySkill(hit.transform.position);
            Mana -= selectedSkill.Cost;
            if(selectedSkill is BombSkill)
            {
                explosionParticleSystem.transform.position = hit.transform.position;
                explosionParticleSystem.Play();
                StartCoroutine(StopExplosions());
                ResetButtonsColor(explosionButton);
            }
            else if(selectedSkill is IceSkill)
            {
                iceParticleSystem.transform.position = hit.transform.position;
                iceParticleSystem.Play();
                StartCoroutine(StopIceEffect());
                ResetButtonsColor(iceButton);
            }
        }
        /*Author: Michał Miciak*/
        private void ResetButtonsColor(Button button)
        {
            button.GetComponentInParent<Image>().color = explosionButton.colors.normalColor;
        }
        /*Author: Michał Miciak*/
        private IEnumerator StopIceEffect()
        {
            yield return new WaitForSeconds(IceSkill.Duration);
            iceParticleSystem.Stop();
        }
        /*Author: Michał Miciak*/
        private IEnumerator StopExplosions()
        {
            yield return new WaitForSeconds(explosionParticleSystem.main.duration);
            explosionParticleSystem.Stop();
        }
        /*Author: Michał Miciak*/
        private bool CheckIfEnoughManaForSkill(int cost)
        {
            return Mana >= cost;
        }
        /*Author: Michał Miciak*/
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
