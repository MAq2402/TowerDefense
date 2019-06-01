using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Class responsible for managing pause menu*/
/*Author: Martyna Drabińska*/
public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseCanvas;

    /*Author: Martyna Drabińska*/
    public void PauseGame()
    {
        if (!paused)
        {
            pauseCanvas.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
            CameraController.movement = false;
        }
    }

    /*Author: Martyna Drabińska*/
    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
        CameraController.movement = true;

    }
}
