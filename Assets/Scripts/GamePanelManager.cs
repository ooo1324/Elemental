using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelManager : MonoBehaviour
{
    public enum EElementalType
    {
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

    private void Awake()
    {
        instance = this;
    }


    public void ChangePanel(EElementalType type)
    {
        fireGamePanel.SetActive(false);
        waterGamePanel.SetActive(false);
        airGamePanel.SetActive(false);
        earthGamePanel.SetActive(false);

        switch (type)
        {
            case EElementalType.fire:
                fireGamePanel.SetActive(true);
                break;
            case EElementalType.water:
                waterGamePanel.SetActive(true);
                break;
            case EElementalType.air:
                airGamePanel.SetActive(true);
                break;
            case EElementalType.earth:
                earthGamePanel.SetActive(true);
                break;
        }
    }
}
