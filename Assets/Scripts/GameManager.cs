using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GaugeManager gaugeManager;

    [HideInInspector]
    public UIManager uiManager;

    [Header("GameOver/Clear")]
    public GameObject gamePanelObj;
    public Text scoreText;

    public GameObject gameOverText;
    public GameObject clearText;

    [Header("MainCheck")]
    public GameObject CheckPanelObj;


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
        uiManager = FindObjectOfType<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        GamePanelManager.instance.ChangePanel(GamePanelManager.EElementalType.none);
        gameOverText.SetActive(true);
        clearText.SetActive(false);
        gamePanelObj.SetActive(true);
        scoreText.text = totalScore.ToString();
        Management.Instance.isStartGame = false;
    }

    public void GameClear()
    {
        GamePanelManager.instance.ChangePanel(GamePanelManager.EElementalType.none);
        gameOverText.SetActive(false);
        clearText.SetActive(true);
        gamePanelObj.SetActive(true);
        scoreText.text = totalScore.ToString();
    }

    public void CheckMainPanel()
    {
        GamePanelManager.instance.ChangePanel(GamePanelManager.EElementalType.none);
        CheckPanelObj.SetActive(true);
    }

    public void ExitMainPanel()
    {
        GamePanelManager.instance.ActiveCollider();
        CheckPanelObj.SetActive(false);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void PlusScore(GamePanelManager.EElementalType type, Vector3 scorePos)
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
                typeScore = 4;
                break;
            case GamePanelManager.EElementalType.earth:
                gaugeManager.elementDataList[2].value += increaseValue;
                typeScore = 3;
                break;  
        }

        float addScore = Management.Instance.level * plusScore * typeScore;
        totalScore += addScore;
        uiManager.FloatingText(type, scorePos, (int)addScore);
    }

    public void PauseGame()
    {
        if (!Management.Instance.Stop)
        {
            Management.Instance.Stop = true;
            Time.timeScale = 0;
        }
        else
        {
            Management.Instance.Stop = false;
            Time.timeScale = 1;
        }

    }

    public void MinusSocre(GamePanelManager.EElementalType type, Vector3 scorePos)
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
                typeScore = 4;
                break;
            case GamePanelManager.EElementalType.earth:
                gaugeManager.elementDataList[2].value -= decreaseValue;
                typeScore = 1;
                break;
        }

        float minusScore = Management.Instance.level * minusSocre * typeScore;
        totalScore -= minusScore;
        uiManager.FloatingText(type, scorePos, -(int)minusScore);
    }
}
