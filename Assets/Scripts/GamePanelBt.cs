using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelBt : MonoBehaviour
{
    public GamePanelManager.EElementalType panelType;
    private void OnMouseDown()
    {
        GamePanelManager.instance.ChangePanel(panelType);
    }
}
