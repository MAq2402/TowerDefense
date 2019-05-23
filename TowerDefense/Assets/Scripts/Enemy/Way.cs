using UnityEngine;

/* This class represents enemies path */
/*Author: Martyna Drabińska*/
public class Way : MonoBehaviour
{
    public static Transform[] wayPoints;
    /*Author: Martyna Drabińska*/
    void Awake()
    {
        wayPoints = new Transform[transform.childCount];

        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
        }
    }

}
