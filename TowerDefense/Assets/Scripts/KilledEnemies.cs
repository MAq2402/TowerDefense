using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledEnemies : MonoBehaviour
{
    public static Text killedEnemiesText;

    public static void setKilledEnemies(int killedEnemies)
    {
        Debug.Log(killedEnemies);
       // killedEnemiesText.text = killedEnemies.ToString();
    }
}
