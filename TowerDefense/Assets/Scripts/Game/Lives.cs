using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Text livesQuantity;

    public void ChangeQuantity(int quantity)
    {
        livesQuantity.text = quantity.ToString();
    }
}
