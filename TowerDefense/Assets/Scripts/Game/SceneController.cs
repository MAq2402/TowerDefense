using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Class responsible for moving between scenes*/
/*Author: Martyna Drabińska*/
public class SceneController : MonoBehaviour
{
    public static int activeLevelsNumber = 4;
    /*Author: Martyna Drabińska*/
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    /*Author: Martyna Drabińska*/
    public void Play(int levelNumber)
    {
        PlayerStatistics.killedEnemies = 0;
        LevelManager.currentLevelNumber = levelNumber;
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


    /*Author: Martyna Drabińska*/
    public void ShowLevelMap()
    {
        SceneManager.LoadScene("LevelMap");
        
    }

    
    /*Author: Martyna Drabińska*/
    public void LevelEnd()
    {
        if (LevelManager.currentLevelNumber == 4)
        {
            GameEnd();
        }
        else
        {
            if (LevelManager.currentLevelNumber == activeLevelsNumber)
            {
                activeLevelsNumber++;
            }

            ShowLevelMap();
        }
    }

    /*Author: Martyna Drabińska*/
    public void ReplayAfterGameOver()
    {
        Play(LevelManager.currentLevelNumber);
    }

    /*Author: Martyna Drabińska*/
    public void ReplayAfterGameEnd()
    {
        LevelManager.currentLevelNumber = 1;
        activeLevelsNumber = 1;
        ShowLevelMap();
    }
}
