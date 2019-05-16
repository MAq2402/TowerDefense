using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
  
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameEnd(int killedEnemies)
    {
        SceneManager.LoadScene("GameEnd");
        KilledEnemies.setKilledEnemies(killedEnemies);
    }
}
