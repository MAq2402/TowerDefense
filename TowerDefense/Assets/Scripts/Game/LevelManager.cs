using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Class responsible for moving between scenes*/
/*Author: Martyna Drabińska*/
public class LevelManager : MonoBehaviour
{

    /*Author: Martyna Drabińska*/
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    /*Author: Martyna Drabińska*/
    public void Play()
    {
        PlayerStatistics.killedEnemies = 0;
        SceneManager.LoadScene("MainScene");
    

    }

    /*Author: Martyna Drabińska*/
    public void GameEnd()
    {
        SceneManager.LoadScene("GameEnd");
    }

    /*Author: Martyna Drabińska*/
    public void MainMenu()
    {
        if (PauseMenu.paused)
        {
            Time.timeScale = 1f;
            CameraController.movement = true;
            PauseMenu.paused = false;
        }
        SceneManager.LoadScene("MainMenu");
    }

    /*Author: Martyna Drabińska*/
    public void Exit()
    {
        Application.Quit();
    }
}
