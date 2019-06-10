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
        if (SceneController.activeLevelsNumber >= this.levelNumber)
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
        if (active)
        {
            GameObject.Find("GameMaster").GetComponent<SceneController>().Play(levelNumber);
        }
           
    }
}
