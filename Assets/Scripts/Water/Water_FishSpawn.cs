using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Water_FishSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform parentObj;
    public List<GameObject> targetPrefabs;

    public float spawnRate = 1.0f;

    private float minValueX = -13.0f;

    public ObjectPool pool;

    private int sorting_Value;

    [SerializeField]
    private GameObject explosionFx;

    private int score; 

    [Range(0,100)]
    public int percent;

    void Start()
    {
        sorting_Value = 1;
        pool.prefab = explosionFx;
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnTarget());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            int index = 0;

            if (percent < Random.Range(0,100)) // ������
            {
                index = Random.Range(0, 3);
            }
            else
                index = Random.Range(3, 8);

            yield return new WaitForSeconds(spawnRate / Management.Instance.level);

            //���⿡ ���� ���������ʴ´ٴ� bool ���� �������� 
            GameObject obj = Instantiate(targetPrefabs[index], parentObj);
            obj.GetComponent<Water_MovingFish>().fish_Spawn = this;
            obj.transform.position = RandomSpawnPosition();

            obj.GetComponent<SpriteRenderer>().sortingOrder = sorting_Value;
            sorting_Value++; // ���߿� �ѹ� �����ϴ� �ڵ� �ֱ� 

     
        }
    }

    Vector2 RandomSpawnPosition()
    {
        float spawnPosX = minValueX;
        float spawnPosY = RandomSquareIndex();

        Vector2 spawnPosition = new Vector2(spawnPosX, spawnPosY);

        return spawnPosition;

    }
    float RandomSquareIndex()
    {
        return Random.Range(-3.5f, 4.0f);
    }
}
