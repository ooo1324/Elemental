using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FireManager : MonoBehaviour
{
    public static FireManager instance;

    [HideInInspector]
    public enum EBombType
    {
        water,
        oil,
        None
    }

    [HideInInspector]
    public EBombType currBombType;

    public BombSpawner bombSpawner;

    [HideInInspector]
    public GameObject currBomb;

    [Range(0, 1)]
    public float waterSpawnRatio;

    [HideInInspector]
    private int fireScore = 0;

    public ObjectPool pool;

    public GameObject particleObj;

    [Header("Sound")]
    [SerializeField]
    private AudioClip correctSound;

    [SerializeField]
    private AudioClip throwSound;

    [SerializeField]
    private AudioClip incorrectSound;


    private AudioSource audioSource;

    private float waitTime;
    private void Awake()
    {
        instance = this;
        pool.prefab = particleObj;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // scoreText.text = $"Score: {fireScore}";
        waitTime = 0.2f;
        SpawnBomb();
    }

    public void AddScore(int score)
    {
        fireScore += score;
        // scoreText.text = $"Score: {fireScore}"; 
        audioSource.clip = correctSound;
        audioSource.volume = 0.6f;
        audioSource.Play();
        SpawnBomb();
    }

    public void MinusScore()
    {
        audioSource.clip = incorrectSound;
        audioSource.volume = 0.8f;
        audioSource.Play();
    }


    public void SpawnBomb()
    {
        StopCoroutine(spawnBombAction());
        StartCoroutine(spawnBombAction());
    }

    IEnumerator spawnBombAction()
    {
        if (currBomb != null)
        {
            currBombType = EBombType.None;
            Destroy(currBomb);
        }
          
        yield return new WaitForSeconds(waitTime / Management.Instance.level);
        float ranRatio = Random.Range(0f, 1.0f);

        int ranIdx = ranRatio <= waterSpawnRatio ? 0 : 1;

        currBombType = (EBombType)ranIdx;
        bombSpawner.BombSpawn(ranIdx);
    }

    public void CheckBomb()
    {
        currBombType = EBombType.None;
        audioSource.clip = throwSound;
        audioSource.volume = 1;
        audioSource.Play();
        SpawnBomb();
    }
}
