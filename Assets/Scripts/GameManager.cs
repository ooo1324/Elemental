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

    [SerializeField]
    private GameObject pausePanel;

    [Header("MainCheck")]
    public GameObject CheckPanelObj;


    [Header("Score")]
    public float plusScore;

    public float minusSocre;

    private float totalScore;

    [Header("balance")]
    public float decreaseValue;

    public float increaseValue;

    private AudioSource audioSource;

    [SerializeField]
    private AudioSource warningAudioSource;

    private void Awake()
    {
        instance = this;
        Management.Instance.Stop = false;
        totalScore = 0;
        uiManager = FindObjectOfType<UIManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        warningAudioSource.Stop();
        GamePanelManager.instance.ChangePanel(GamePanelManager.EElementalType.none);
        Management.Instance.Stop = true;
        gameOverText.SetActive(true);
        clearText.SetActive(false);
        gamePanelObj.SetActive(true);
        scoreText.text = totalScore.ToString();
        Management.Instance.isStartGame = false;
    }

    public void GameClear()
    {
        warningAudioSource.Stop();
        GamePanelManager.instance.ChangePanel(GamePanelManager.EElementalType.none);
        Management.Instance.Stop = true;
        gameOverText.SetActive(false);
        clearText.SetActive(true);
        gamePanelObj.SetActive(true);
        scoreText.text = totalScore.ToString();
    }

    public void CheckMainPanel()
    {
        //GamePanelManager.instance.ChangePanel(GamePanelManager.EElementalType.none);
        Management.Instance.Stop = true;
        Time.timeScale = 0;
        CheckPanelObj.SetActive(true);
    }

    public void ExitMainPanel()
    {
        Management.Instance.Stop = false;
        Time.timeScale = 1;
        GamePanelManager.instance.ActiveCollider();
        CheckPanelObj.SetActive(false);
    }

    public void LoadMain()
    {
        Management.Instance.Stop = false;
        Time.timeScale = 1;
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
            pausePanel.SetActive(true);
            audioSource.Pause();
            warningAudioSource.Pause();
        }
        else
        {
            Management.Instance.Stop = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            audioSource.Play();
            warningAudioSource.Play();
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
