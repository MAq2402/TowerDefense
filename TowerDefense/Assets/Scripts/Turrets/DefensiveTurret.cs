using Assets.Scripts.AllyMovement;
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
    private Vector3 allyMovementDirection;

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
                else if(hasBeenAlreadyClicked)
                {
                    CallAlly(ray, hit);
                    HideRange();
                    hasBeenAlreadyClicked = false;
                }
            }
        }

        //if (allyHasBeenSpawned  && allyMovementDirection != null)
        //{
        //    //ally.transform.position = Vector3.MoveTowards(ally.transform.position, new Vector3(1, 1, 1), Time.deltaTime * 5);
        //    ally.transform.Translate(allyMovementDirection.normalized * Time.deltaTime * 2, Space.World);
        //}

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
    private void MoveAlly(RaycastHit hit)
    {
        var distanceBetween = Vector3.Distance(hit.point, transform.position);
        if (distanceBetween < range && hit.transform.gameObject.name.Contains(GROUND))
        {
            var direction = hit.transform.position - transform.position;
            allyMovementDirection = direction;
            //while(transform.position != hit.transform.position)
            //{
            //ally.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //ally.transform.Translate(direction.normalized * Time.deltaTime * 5, Space.World);
            //}
            //ally.GetComponent<AllyMovement>().SetTarget(hit.transform, 5);
            //ally.GetComponent<AllyMovement>().SetTarget(new Vector3(hit.point.x, hit.point.y, hit.point.z), 5);
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
        //if (ally != null)
        //{
        //    Destroy(ally); //WAT
        //}
        Destroy(gameObject);
    }


}
