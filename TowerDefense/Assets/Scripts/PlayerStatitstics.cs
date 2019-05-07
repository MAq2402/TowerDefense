using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatitstics : MonoBehaviour
{
    public int playerLives = 10;

    public void TakeOneLive()
    {
        if (playerLives > 0)
        {
            playerLives--;
            GameObject.Find("heart").GetComponentInChildren<Lives>().ChangeQuantity(playerLives);
        }

    }
}
