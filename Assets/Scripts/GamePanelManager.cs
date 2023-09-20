using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelManager : MonoBehaviour
{
    public BoxCollider2D[] box;

    public enum EElementalType
    {
        none = -1,
        water,
        fire,
        earth,
        air
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

    public List<PolygonCollider2D> colliderList;

    private void Awake()
    {
        instance = this;
        currType = EElementalType.none;
    }

    public void ActiveCollider()
    {
        for (int i = 0; i < 4; i++)
            box[i].enabled = true;

        for (int i = 0; i < colliderList.Count; i++)
            colliderList[i].enabled = true;
    }

    public void ChangePanel(EElementalType type)
    {
        for (int i = 0; i < 4; i++)
            box[i].enabled = false;

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

        if (type == EElementalType.none)
        {
            for (int i = 0; i < colliderList.Count; i++)
                colliderList[i].enabled = false;
            return;
        } 

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
