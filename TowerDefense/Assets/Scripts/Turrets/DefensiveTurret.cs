using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
     * Author: Michał Miciak
     * Resposible for managing defensive turrets, which spawn allies.
*/
public class DefensiveTurret : MonoBehaviour
{
    private const float resurectionCooldownValue = 1;
    private const string GROUND = "Ground";
    public GameObject ally;
    private bool hasBeenAlreadyClicked = false;
    public float range;
    private bool allyHasBeenSpawned = false;
    private RaycastHit positionOfAlly;
    private float resurectionCooldown = resurectionCooldownValue;

    public virtual int Cost { get; set; } = 100;

    /*
        * Author: Michał Miciak
    */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform == transform)
                {
                    UseDrawer();
                }
                else if (hasBeenAlreadyClicked)
                {
                    SpawnAlly(hit);
                    HideRange();
                    hasBeenAlreadyClicked = false;
                }
            }
        }
        //Will work on that
        //if (!ally.activeInHierarchy && allyHasBeenSpawned){
        //    StartCounter();
        //}
        //if(resurectionCooldown <= 0)
        //{
        //    resurectionCooldown = resurectionCooldownValue;
        //    ResurrectAlly();
        //}
    }

    /*
       * Author: Michał Miciak
    */
    private void StartCounter()
    {
        resurectionCooldown -= Time.deltaTime;
    }
    /*
       * Author: Michał Miciak
     */
    private void UseDrawer()
    {
        if (hasBeenAlreadyClicked)
        {
            HideRange();
        }
        else
        {
            ShowRange();
        }
        hasBeenAlreadyClicked = !hasBeenAlreadyClicked;
    }

    /*
       * Author: Michał Miciak
    */
    private void ShowRange()
    {
        Drawer.DrawCircleOnSurface(gameObject.GetComponent<LineRenderer>(), this.range, 0.25f, Color.green);
    }

    /*
       * Author: Michał Miciak
    */
    private void HideRange()
    {
        Drawer.DrawEmpty(gameObject.GetComponent<LineRenderer>());
    }

    /*
       * Author: Michał Miciak
    */
    private void ResurrectAlly()
    {
        ally.SetActive(true);
    }

    /*
      * Author: Michał Miciak
    */
    private void SpawnAlly(RaycastHit hit)
    {
        if (!allyHasBeenSpawned)
        {
            var distanceBetween = Vector3.Distance(hit.point, transform.position);
            if (distanceBetween < range && hit.transform.gameObject.name.Contains(GROUND))
            {
                Instantiate(ally, new Vector3(hit.point.x, hit.point.y, hit.point.z), hit.transform.rotation);
                positionOfAlly = hit;
                allyHasBeenSpawned = true;
            }
        }
    }

    /*
      * Author: Michał Miciak
    */
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Sell();
        }
    }

    /*
      * Author: Michał Miciak
    */
    private void Sell()
    {
        ShopMenu.AddMoney(Cost / 2);
        Destroy(gameObject);
    }
}
