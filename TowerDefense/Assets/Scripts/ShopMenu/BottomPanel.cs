using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Bartłomiej Krasoń
 * BottomPanel class represents bottom panel in shop HUD which contains turret icons,
 *  which allow user to buy turrets
 */
public class BottomPanel : MonoBehaviour
{
    public GameObject bottomPanel;
    public Button toggleBottomPanelButton;
    public Text toggleButtonText;

    private Vector3 moveBottomPanelVecotr = new Vector3(0.0f, 100.0f, 0.0f);
    private bool isBottomPanelHidden = false;

    /* Author: Bartłomiej Krasoń */
    public void ToggleBottomPanel()
    {
        if (isBottomPanelHidden)
        {
            ShowPanel();
        }
        else
        {
            HidePanel();
        }
    }

    /* Author: Bartłomiej Krasoń */
    private void HidePanel()
    {
        if (isBottomPanelHidden)
            return;

        toggleBottomPanelButton.transform.Translate(-moveBottomPanelVecotr);
        bottomPanel.transform.Translate(-moveBottomPanelVecotr);
        toggleButtonText.text = "^ EXPAND ^";
        isBottomPanelHidden = true;
    }

    /* Author: Bartłomiej Krasoń */
    private void ShowPanel()
    {
        if (!isBottomPanelHidden)
            return;

        toggleBottomPanelButton.transform.Translate(moveBottomPanelVecotr);
        bottomPanel.transform.Translate(moveBottomPanelVecotr);
        toggleButtonText.text = "v FOLD v";
        isBottomPanelHidden = false;
    }
}
