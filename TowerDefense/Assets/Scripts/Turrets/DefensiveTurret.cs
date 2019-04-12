using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllyMoveOrSpawnEventArgs : EventArgs
{
    public GameObject GameObject { get; set; }
    public Vector3 Positon { get; set; }
    public float Range { get; set; }
    public DefensiveTurret DefensiveTurret { get; set; }
    public Transform Transform { get; set; }
}
public class DefensiveTurret : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;
    public GameObject ally;
    private bool hasBeenClicked = false;
    public bool move = false;
    private float range = 5f;
    public static event EventHandler<AllyMoveOrSpawnEventArgs> ThresholdReached;
    private Action<Transform, Vector3, Quaternion> onGroundClickAction = (transform, position, rotation) => Instantiate(transform, position, rotation);
    public static void Move(Vector3 targetPosition)
    {
        
    }
    void Start()
    {
        move = false;
        SpawnAlly();
    }

    private void SpawnAlly()
    {
        //Instantiate(ally, spawnPoint.position, spawnPoint.rotation);

    }

    private void OnMouseDown()
    {
        hasBeenClicked = !hasBeenClicked;
        if (hasBeenClicked)
        {
            Drawer.DrawCircleOnSurface(gameObject.GetComponent<LineRenderer>(), this.range, 0.25f, Color.green);

            GroundScript.args = new AllyMoveOrSpawnEventArgs
            {
                GameObject = ally,
               // Transform = ally.transform,
                Range = range,
                Positon = this.transform.position,
                DefensiveTurret = this
            };

        }
        else
        {
            Drawer.DrawEmpty(gameObject.GetComponent<LineRenderer>());
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (move)
        //{
            ally.transform.Translate(Vector3.forward * Time.deltaTime);
            //var comp = ally.GetComponent<Transform>();
            //comp.transform.Translate(Vector3.forward * Time.deltaTime*100);
        //}
        
        //transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void startMovementOfAlly()
    {

    }
}
