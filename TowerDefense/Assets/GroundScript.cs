using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<GameObject> allies = new List<GameObject>();
    public static AllyMoveOrSpawnEventArgs args;
    private Vector3 start;
    private Vector3 end;
    private GameObject allyToMove; 
    void Start()
    {

    }

    // Update is called once per fram

    private void OnMouseDown()
    {
        if(args != null)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                if (allies.Any(x => x == args.GameObject))
                {
                    //GetComponent<Rigidbody>();
                    var allyX = allies.FirstOrDefault(x => x == args.GameObject);
                    //var comp = allyX.GetComponent<Rigidbody>();
                    //comp.transform.Translate(Vector3.forward * Time.deltaTime);
                    //var allyScript = GameObject.Find(allyX.name).GetComponent(typeof(Ally)) as Ally;
                    args.DefensiveTurret.move = true;

                    //while (true)
                    //{
                    //    args.DefensiveTurret.ally.transform.Translate(Vector3.forward * Time.deltaTime);
                    //}
                    //if (allyX.GetComponent<Move>() == null)
                    //{
                    //    allyX.AddComponent<Move>();
                    //}
                    //else
                    //{
                    //    Destroy(allyX.GetComponent<Move>());
                    //}
                    //Ally.currentAlly = allyX;
                    //allyScript.xD();
                    //Ally.move = true;
                    //start = allyX.transform.position;
                    //end = hit.point;
                    //allyToMove = allyX;
                    //var currentPosition = args.GameObject.transform.position;
                    //args.GameObject.transform.Translate(hit.point);
                    //Vector3.MoveTowards(currentPosition, hit.point, Time.deltaTime);
                    //comp.transform.position = new Vector3(3, 3, 3);
                }
                else
                {
                    Instantiate(args.DefensiveTurret.ally.transform, hit.point, new Quaternion(1, 2, 1, 1));
                    allyToMove = args.GameObject;
                    //args.DefensiveTurret.ally = args.GameObject;
                    allies.Add(args.GameObject);
                }

            }
        }
    }
}
