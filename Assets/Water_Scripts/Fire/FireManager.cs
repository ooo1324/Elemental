using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireManager : MonoBehaviour
{
    public static FireManager instance;

    [HideInInspector]
    public enum EBombType
    {
        water,
        oil
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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       // scoreText.text = $"Score: {fireScore}";
        SpawnBomb();
    }

    public void AddScore(int score)
    {
        fireScore += score;
       // scoreText.text = $"Score: {fireScore}";
        SpawnBomb();
    }

    public void SpawnBomb()
    {
        if (currBomb != null)
            Destroy(currBomb);
        float ranRatio = Random.Range(0f, 1.0f);

        int ranIdx = ranRatio <= waterSpawnRatio ? 0 : 1;

        currBombType = (EBombType)ranIdx;
        bombSpawner.BombSpawn(ranIdx);
    }

    public void CheckBomb()
    {
        if (currBombType == EBombType.water)
        {

        }
        else if (currBombType == EBombType.oil)
        {
            
        }

        SpawnBomb();
    }
}
