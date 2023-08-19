using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GaugeManager gaugeManager;

    public GameObject gameOverObj;

    [Header("Score")]
    public float plusScore;

    public float minusSocre;

    private float totalScore;

    [Header("balance")]
    public float decreaseValue;

    public float increaseValue;



    private void Awake()
    {
        instance = this;
        totalScore = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Management.Instance.isStartGame = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
        Management.Instance.isStartGame = false;
    }

    public void GameClear()
    {

    }

    public void PlusScore(GamePanelManager.EElementalType type)
    {
        int typeScore = 0;

        switch (type)
        {
            case GamePanelManager.EElementalType.fire:
                gaugeManager.elementDataList[1].value += increaseValue;
                typeScore = 4;
                break;
            case GamePanelManager.EElementalType.water:
                gaugeManager.elementDataList[0].value += increaseValue;
                typeScore = 3;
                break;
            case GamePanelManager.EElementalType.air:
                gaugeManager.elementDataList[3].value += increaseValue;
                typeScore = 2;
                break;
            case GamePanelManager.EElementalType.earth:
                gaugeManager.elementDataList[2].value += increaseValue;
                typeScore = 1;
                break;  
        }

        totalScore += Management.Instance.level * plusScore * typeScore;

       
    }

    public void MinusSocre(GamePanelManager.EElementalType type)
    {
        int typeScore = 0;

        switch (type)
        {
            case GamePanelManager.EElementalType.fire:
                gaugeManager.elementDataList[1].value -= decreaseValue;
                typeScore = 4;
                break;
            case GamePanelManager.EElementalType.water:
                gaugeManager.elementDataList[0].value -= decreaseValue;
                typeScore = 3;
                break;
            case GamePanelManager.EElementalType.air:
                gaugeManager.elementDataList[3].value -= decreaseValue;
                typeScore = 2;
                break;
            case GamePanelManager.EElementalType.earth:
                gaugeManager.elementDataList[2].value -= decreaseValue;
                typeScore = 1;
                break;
        }

        totalScore -= Management.Instance.level * minusSocre * typeScore;
    }
}
