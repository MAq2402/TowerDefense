using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AllyMovement
{
    public class AllyMovement : MonoBehaviour
    {
        //public Transform Target { get; private set; }
        //public float? AllySpeed { get; private set; }

        //public Vector3? Vec { get; private set; }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    Debug.Log(collision.collider.gameObject.name);
        //    //if (collision.collider.gameObject.name.Contains("enemy".ToUpperInvariant()))
        //    //{
        //    if (collision.collider.gameObject.GetComponents(typeof(EnemyMovement)).Any())
        //    {
        //        collision.collider.gameObject.GetComponent<EnemyMovement>().Fight(transform);
        //    }
                
        //    // }
        //}
        //public void SetTarget(Transform target, float? allySpeed)
        //{
        //    Target = target;
        //    AllySpeed = allySpeed;
        //}
        //void Update()
        //{
        //    //if (Target != null && AllySpeed.HasValue)
        //    //{
        //    //    Vector3 direction = Target.position - transform.position;
        //    //    Quaternion rotation = Target.rotation;
        //    //    transform.rotation = rotation;
        //    //    transform.Translate(direction.normalized * AllySpeed.Value * Time.deltaTime, Space.World);

        //    //    if (Target.position == transform.position)
        //    //    {
        //    //        SetTarget(null, null);
        //    //    }
        //    //}

        //    //if (Vec.HasValue)
        //    //{
        //    //    transform.position = Vec.Value;
        //    //}
        //}

        //internal void SetTarget(Vector3 vector3, int v)
        //{
        //    Vec = Vector3.MoveTowards(transform.position, vector3, Time.deltaTime * 5);
        //}
    }
}
