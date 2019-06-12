using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Class responsible for showing panel with message about passed level*/
/*Author: Martyna Drabińska*/
public class LevelEndPanel : MonoBehaviour
{
    public Text killedEnemis;
    public GameObject panel;

    /*Author: Martyna Drabińska*/
    public void LevelEnd()
    {
        if (LevelManager.currentLevelNumber == 4)
        {
            GameObject.Find("GameMaster").GetComponent<SceneController>().GameEnd();
        }
        else
        {
            if (LevelManager.currentLevelNumber == SceneController.activeLevelsNumber)
            {
                SceneController.activeLevelsNumber++;
            }
        }

        killedEnemis.text = $"You've killed {PlayerStatistics.killedEnemies} enemies";
        panel.SetActive(true);
        CameraController.movement = false;
    }

}
