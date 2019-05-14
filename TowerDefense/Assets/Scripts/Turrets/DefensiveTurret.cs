using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveTurret : MonoBehaviour
{
    private const string GROUND = "Ground";
    public GameObject ally;
    private bool hasBeenAlreadyClicked = false;
    private float range = 5f;
    private bool allyHasBeenSpawned = false;

    public virtual int Cost { get; set; } = 100;
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
                else if(hasBeenAlreadyClicked)
                {
                    CallAlly(ray, hit);
                    HideRange();
                    hasBeenAlreadyClicked = false;
                }
            }
        }
    }
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

    private void ShowRange()
    {
        Drawer.DrawCircleOnSurface(gameObject.GetComponent<LineRenderer>(), this.range, 0.25f, Color.green);
    }

    private void HideRange()
    {
        Drawer.DrawEmpty(gameObject.GetComponent<LineRenderer>());
    }

    private void CallAlly(Ray ray, RaycastHit hit)
    {
        if (allyHasBeenSpawned)
        {
            MoveAlly(hit);
        }
        else
        {
            SpawnAlly(hit);
        }
    }

    //TODO:Does not work for now, we may reject this functionality
    private void MoveAlly(RaycastHit hit)
    {
        var distanceBetween = Vector3.Distance(hit.point, transform.position);
        if (distanceBetween < range && hit.transform.gameObject.name.Contains(GROUND))
        {
            var direction = hit.transform.position - transform.position;
        }
    }

    private void SpawnAlly(RaycastHit hit)
    {
        var distanceBetween = Vector3.Distance(hit.point, transform.position);
        if (distanceBetween < range && hit.transform.gameObject.name.Contains(GROUND))
        {
            Instantiate(ally, new Vector3(hit.point.x, hit.point.y, hit.point.z), hit.transform.rotation);
            allyHasBeenSpawned = true;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Sell();
        }
    }

    private void Sell()
    {
        ShopMenu.AddMoney(Cost / 2);
        Destroy(gameObject);
    }


}
