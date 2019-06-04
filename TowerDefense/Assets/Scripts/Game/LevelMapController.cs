using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* Class responsible for managing active levels on level map*/
/*Author: Martyna Drabińska*/
public class LevelMapController : MonoBehaviour
{
    public int levelNumber;
    private bool active;
    public GameObject effects;

    /*Author: Martyna Drabińska*/
    private void Start()
    {
        string effectsName = "Effects" + levelNumber.ToString();
        if (LevelManager.activeLevelsNumber >= this.levelNumber)
        {
            active = true;
           effects.SetActive(true);
        }
        else
        {
            active = false;
            effects.SetActive(false);
        }  
    }

    /*Author: Martyna Drabińska*/
    private void OnMouseDown()
    {
        Debug.Log(active);
        if (active)
        {
            GameObject.Find("GameMaster").GetComponent<LevelManager>().Play();
        }
           
    }
}
