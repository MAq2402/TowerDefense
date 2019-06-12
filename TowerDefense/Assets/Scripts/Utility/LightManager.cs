using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class responsible ligt color in the scene */
/*Author: Martyna Drabińska*/
public class LightManager : MonoBehaviour
{
    public Light light;

    /*Author: Martyna Drabińska*/
    void Start()
    {
        light.color = LevelManager.levelFeatures[LevelManager.currentLevelNumber].sceneColor;
    }
}
