﻿using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveTurret : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;
    public Transform ally;
    private bool hasBeenClicked = false;
    private float range = 5f; 
    void Start()
    {
        SpawnAlly();
    }

    private void SpawnAlly()
    {
        Instantiate(ally, spawnPoint.position, spawnPoint.rotation);
        
    }

    private void OnMouseDown()
    {
        hasBeenClicked = !hasBeenClicked;
        if(hasBeenClicked)
        {
            Drawer.DrawCircleOnSurface(gameObject.GetComponent<LineRenderer>(), this.range, 0.25f, Color.green);
        }
        else
        {
            Drawer.DrawEmpty(gameObject.GetComponent<LineRenderer>());
        }
    }
    private void OnMouseUp()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}