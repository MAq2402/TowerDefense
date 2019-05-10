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
    private int allyHealth = 3;

    public virtual int Cost { get; set; } = 100;
    void Start()
    {

    }

    private void OnMouseDown()
    {

    }
    private void OnMouseUp()
    {

    }
    // Update is called once per frame
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
                else
                {
                    CallAlly(ray, hit);
                    HideRange();
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
            MoveAlly();
        }
        else
        {
            SpawnAlly(hit);
        }
    }
    private void MoveAlly()
    {
        Debug.Log("Move ally");
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
