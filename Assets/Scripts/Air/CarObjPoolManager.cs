using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObjPoolManager : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    [SerializeField]
    public float speedMin;

    [SerializeField]
    public float speedMax;


    [SerializeField]
    public float spawnRate;

    [SerializeField]
    public Sprite[] carSprites;

    [SerializeField]
    [Range(0f, 1f)]
    public float carExhaustRatio;

    //[SerializeField]
    //public float spawnRateMin;

    //[SerializeField]
    //public float spawnRateMax;

    public ObjectPool carObjPool;

    private void Awake()
    {
    }

    private void Start()
    {
        carObjPool.prefab = prefab;
    }
}
