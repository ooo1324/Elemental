using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelManager : MonoBehaviour
{
    public enum EElementalType
    {
        none,
        fire,
        water,
        air,
        earth
    }

    public static GamePanelManager instance;

    [HideInInspector]
    public EElementalType currType;

    public GameObject fireGamePanel;
    public GameObject waterGamePanel;
    public GameObject airGamePanel;
    public GameObject earthGamePanel;

    public GameObject fireGamePanelBt;
    public GameObject waterGamePanelBt;
    public GameObject airGamePanelBt;
    public GameObject earthGamePanelBt;

    private void Awake()
    {
        instance = this;
    }


    public void ChangePanel(EElementalType type)
    {
        if (currType == type) return;
        currType = type;
        fireGamePanel.SetActive(false);
        waterGamePanel.SetActive(false);
        airGamePanel.SetActive(false);
        earthGamePanel.SetActive(false);

        fireGamePanelBt.SetActive(true);
        waterGamePanelBt.SetActive(true);
        airGamePanelBt.SetActive(true);
        earthGamePanelBt.SetActive(true);

        switch (type)
        {
            case EElementalType.fire:
                fireGamePanel.SetActive(true);
                fireGamePanelBt.SetActive(false);
                break;
            case EElementalType.water:
                waterGamePanel.SetActive(true);
                waterGamePanelBt.SetActive(false);
                break;
            case EElementalType.air:
                airGamePanel.SetActive(true);
                airGamePanelBt.SetActive(false);
                break;
            case EElementalType.earth:
                earthGamePanel.SetActive(true);
                earthGamePanelBt.SetActive(false);
                break;
        }
    }
}