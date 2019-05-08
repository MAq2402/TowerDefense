using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void GameOver()
    {
          Debug.Log(SceneManager.sceneCount);
        SceneManager.LoadScene("GameOver");

    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");

    }
}
